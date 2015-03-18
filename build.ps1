Param(
    [string] $Target = "Default",
    [string] $Configuration = "Debug",
    [string] $Verbosity = "normal",
    [switch] $ForcePackage
)

$SelfRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition
$Script = Join-Path $SelfRoot "build.csx"

$TOOLS_DIR = Join-Path $SelfRoot "tools"
$CAKE_DIR = Join-Path $TOOLS_DIR "Cake"
$NUGET_EXE = Join-Path $TOOLS_DIR "nuget.exe"
$CAKE_EXE = Join-Path $CAKE_DIR "Cake.exe"

if (!(Test-Path $NUGET_EXE)) {
    Throw "Could not find " + $NUGET_EXE
}

Invoke-Expression "$NUGET_EXE install Cake -OutputDirectory $TOOLS_DIR -ExcludeVersion"
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

if (!(Test-Path $CAKE_EXE)) {
    Throw "Could not find " + $CAKE_EXE
}

$ForcePackageArg = ""
if ($ForcePackage)
{
    $ForcePackageArg = "-forcePackage"
}

Invoke-Expression "$CAKE_EXE `"$Script`" -target=`"$Target`" -configuration=`"$Configuration`" -verbosity=`"$Verbosity`" $ForcePackageArg"

exit $LASTEXITCODE
