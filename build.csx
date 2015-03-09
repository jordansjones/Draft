///////////////////////////////////////////////////////////////////////////////
// ARGUMENTS
///////////////////////////////////////////////////////////////////////////////

var target          = Argument<string>("target", "Default");
var configuration   = Argument<string>("configuration", "Debug");
var forcePackage    = HasArgument("forcePackage");

///////////////////////////////////////////////////////////////////////////////
// GLOBAL VARIABLES
///////////////////////////////////////////////////////////////////////////////

var projectName = "Draft";

// "Root"
var context =  GetContext();
var baseDir = context.Environment.WorkingDirectory;
var solution = baseDir.GetFilePath(projectName + ".sln");

// Directories
// WorkingDirectory is relative to this file. Make it relative to the Solution file.
var solutionDir = solution.GetDirectory();
var packagingRoot = baseDir.Combine("publish");
var testResultsDir = baseDir.Combine("TestResults");
var nugetPackagingDir = packagingRoot.Combine(projectName);
var sourcesDir = solutionDir.Combine("source");
var testsDir = solutionDir.Combine("tests");
var metaDir = solutionDir.Combine("meta");

// Files
var solutionInfoCs = metaDir.GetFilePath("SolutionInfo.cs");
var nuspecFile = metaDir.GetFilePath(projectName + ".nuspec");
var licenseFile = solutionDir.GetFilePath("LICENSE.txt");
var readmeFile = solutionDir.GetFilePath("README.md");
var releaseNotesFile = solutionDir.GetFilePath("ReleaseNotes.md");

var appVeyorEnv =  context.AppVeyor().Environment;

// Get whether or not this is a local build.
var local = !context.BuildSystem().IsRunningOnAppVeyor;
var isReleaseBuild = !local && appVeyorEnv.Repository.Tag.IsTag;

// Release notes
var releaseNotes = ParseReleaseNotes(releaseNotesFile);

// Version
var buildNumber = !isReleaseBuild ? 0 : appVeyorEnv.Build.Number;
var version = releaseNotes.Version.ToString();
var semVersion = isReleaseBuild ? version : (version + string.Concat("-build-", buildNumber));

///////////////////////////////////////////////////////////////////////////////
// SETUP / TEARDOWN
///////////////////////////////////////////////////////////////////////////////

Setup(() =>
{
    // Executed BEFORE the first task.
    Information("Running tasks...");

    if (!FileSystem.Exist(testResultsDir))
    {
        CreateDirectory(testResultsDir);
    }
    if (!FileSystem.Exist(nugetPackagingDir))
    {
        CreateDirectory(nugetPackagingDir);
    }
});

Teardown(() =>
{
    // Executed AFTER the last task.
    Information("Finished running tasks.");
});

///////////////////////////////////////////////////////////////////////////////
// TASK DEFINITIONS
///////////////////////////////////////////////////////////////////////////////

Task("Clean")
	.Does(() =>
{
	// Clean Solution directories
	Information("Cleaning {0}", solutionDir);
	CleanDirectories(solutionDir + "/packages");
	CleanDirectories(solutionDir + "/**/bin/" + configuration);
	CleanDirectories(solutionDir + "/**/obj/" + configuration);

    foreach (var dir in new [] { packagingRoot, testResultsDir })
    {
         Information("Cleaning {0}", dir);
         CleanDirectory(dir);
    }
});

Task("Restore")
    .IsDependentOn("Clean")
	.Does(() =>
{
	Information("Restoring {0}", solution);
	NuGetRestore(solution);
});

Task("AssemblyInfo")
    .IsDependentOn("Restore")
    .WithCriteria(() => !isReleaseBuild)
    .Does(() =>
{
    Information("Creating {0} - Version: {1}", solutionInfoCs, version);
    CreateAssemblyInfo(solutionInfoCs, new AssemblyInfoSettings {
        Product = projectName,
        Version = version,
        FileVersion = version,
        InformationalVersion = semVersion
    });
});

Task("Build")
	.IsDependentOn("AssemblyInfo")
	.Does(() =>
{
	Information("Building {0}", solution);
	MSBuild(solution, settings =>
        settings.SetConfiguration(configuration)
	);
});

Task("UnitTests")
    .IsDependentOn("Build")
    .Does(() =>
{
    Information("Running Tests in {0}", solution);

    XUnit(
        solutionDir + "/**/bin/" + configuration + "/**/*.Tests*.dll",
        new XUnitSettings {
            OutputDirectory = testResultsDir,
            HtmlReport = true,
            XmlReport = true
        }
    );
});

Task("CopyNugetPackageFiles")
    .IsDependentOn("UnitTests")
    .Does(() =>
{

    var baseBuildDir = sourcesDir.Combine(projectName).Combine("bin").Combine(configuration);

    var net45BuildDir = baseBuildDir.Combine("Net45");
    var net45PackageDir = nugetPackagingDir.Combine("lib/net45/");

    var dirMap = new Dictionary<DirectoryPath, DirectoryPath> {
        { net45BuildDir, net45PackageDir }
    };

    CleanDirectories(dirMap.Values);

    foreach (var dirPair in dirMap)
    {
        var files = FileSystem.GetDirectory(dirPair.Key)
            .GetFiles(projectName + "*", SearchScope.Current)
            .Select(x => x.Path);
        CopyFiles(files, dirPair.Value);
    }

    var packageFiles = new FilePath[] {
        licenseFile,
        readmeFile,
        releaseNotesFile
    };

    CopyFiles(packageFiles, nugetPackagingDir);
});

Task("CreateNugetPackage")
    .IsDependentOn("CopyNugetPackageFiles")
    .Does(() =>
{
    NuGetPack(
        nuspecFile,
        new NuGetPackSettings {
            Version = semVersion,
            ReleaseNotes = releaseNotes.Notes.ToArray(),
            BasePath = nugetPackagingDir,
            OutputDirectory = packagingRoot,
            Symbols = false,
            NoPackageAnalysis = false
        }
    );
});

///////////////////////////////////////////////////////////////////////////////
// TASK TARGETS
///////////////////////////////////////////////////////////////////////////////

Task("Package")
    .IsDependentOn("CreateNugetPackage")
    .WithCriteria(() => isReleaseBuild || forcePackage);

Task("Default")
    .IsDependentOn("Package");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

Information("Building {0} [{1}] ({2} - {3}).", solution.GetFilename(), configuration, version, semVersion);

RunTarget(target);
