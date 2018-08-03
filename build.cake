#tool "xunit.runner.console"

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
var baseDir = Context.Environment.WorkingDirectory;
var solution = baseDir.GetFilePath(projectName + ".sln");

// Directories
// WorkingDirectory is relative to this file. Make it relative to the Solution file.
var solutionDir = solution.GetDirectory();
var packagingRoot = baseDir.Combine("publish");
var testResultsDir = baseDir.Combine("TestResults");
var sourcesDir = solutionDir.Combine("source");
var testsDir = solutionDir.Combine("tests");
var metaDir = solutionDir.Combine("meta");

// Files
var solutionInfoCs = metaDir.GetFilePath("SolutionInfo.cs");
var nuspecFile = metaDir.GetFilePath(projectName + ".nuspec");
var releaseNotesFile = solutionDir.GetFilePath("ReleaseNotes.md");

var appVeyorEnv =  Context.AppVeyor().Environment;

// Get whether or not this is a local build.
var local = !Context.BuildSystem().IsRunningOnAppVeyor;
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

Setup(context =>
{
    // Executed BEFORE the first task.
    Information("Running tasks...");

    if (!DirectoryExists(testResultsDir))
    {
        CreateDirectory(testResultsDir);
    }

    if (DirectoryExists(packagingRoot))
    {
        CleanDirectory(packagingRoot);
    }
});

Teardown(context =>
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
	.Does(() =>
{
	Information("Restoring {0}", solution);
	NuGetRestore(solution);
});

Task("AssemblyInfo")
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
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
	.IsDependentOn("AssemblyInfo")
	.Does(() =>
{
	Information("Building {0}", solution);
	MSBuild(solution, settings => settings
        .SetConfiguration(configuration)
        .SetVerbosity(Context.Log.Verbosity)
        .SetMaxCpuCount(System.Environment.ProcessorCount)
        .SetNodeReuse(false)
        .WithProperty("UseSharedCompilation", "false")
	);
});

Task("UnitTests")
    .Does(() =>
{
    Information("Running Tests in {0}", solution);

    var testAssemblies = GetFiles(testsDir + "/**/bin/" + configuration + "/**/*.Tests*.dll").ToList();
    testAssemblies.ForEach(x => Information("Test File: {0}", x.GetFilename()));

    XUnit2(
        testAssemblies,
        new XUnit2Settings {
            OutputDirectory = testResultsDir,
            HtmlReport = true,
            NUnitReport = true,
            XmlReport = true,
        }
    );
});

Task("CreateNugetPackage")
    .WithCriteria(() => isReleaseBuild || forcePackage)
    .Does(() =>
{
    NuGetPack(
        nuspecFile,
        new NuGetPackSettings {
            Version = semVersion,
            ReleaseNotes = releaseNotes.Notes.ToArray(),
            BasePath = solutionDir,
            OutputDirectory = packagingRoot,
            Symbols = true,
            NoPackageAnalysis = false
        }
    );
});

///////////////////////////////////////////////////////////////////////////////
// TASK TARGETS
///////////////////////////////////////////////////////////////////////////////

Task("Package")
    .IsDependentOn("Build")
    .IsDependentOn("CreateNugetPackage");

Task("Test")
    .IsDependentOn("Build")
    .IsDependentOn("UnitTests");

Task("Default")
    .IsDependentOn("Build")
    .IsDependentOn("UnitTests")
    .IsDependentOn("CreateNugetPackage");

///////////////////////////////////////////////////////////////////////////////
// EXECUTION
///////////////////////////////////////////////////////////////////////////////

Information("Building {0} [{1}] ({2} - {3}).", solution.GetFilename(), configuration, version, semVersion);

RunTarget(target);
