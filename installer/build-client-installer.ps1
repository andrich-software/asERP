# Builds the asERP desktop client Windows installer locally.
#
# Prerequisites: .NET 10 SDK, Uno workloads, Inno Setup 6 (https://jrsoftware.org/isinfo.php).
#
# Usage:
#   .\build-client-installer.ps1                     # version defaults to YYYY.MM.DD.0
#   .\build-client-installer.ps1 -Version 2026.07.06.1

param(
    [string]$Version = "$(Get-Date -Format 'yyyy.MM.dd').0"
)

$ErrorActionPreference = 'Stop'
$repoRoot = Split-Path -Parent $PSScriptRoot
$publishDir = Join-Path $repoRoot 'publish'

Write-Host "Publishing asERP.Client (self-contained win-x64, version $Version)..."
dotnet publish (Join-Path $repoRoot 'src\asERP.Client\asERP.Client.csproj') `
    --configuration Release `
    --framework net10.0-desktop `
    --runtime win-x64 `
    --self-contained true `
    -p:Version=$Version `
    -p:AssemblyVersion=$Version `
    -p:FileVersion=$Version `
    --output (Join-Path $publishDir 'client')
if ($LASTEXITCODE -ne 0) { throw 'Client publish failed.' }

$iscc = @(
    "${env:ProgramFiles(x86)}\Inno Setup 6\ISCC.exe",
    "$env:ProgramFiles\Inno Setup 6\ISCC.exe"
) | Where-Object { Test-Path $_ } | Select-Object -First 1
if (-not $iscc) { throw 'ISCC.exe not found - install Inno Setup 6.' }

Write-Host "Compiling installer..."
& $iscc `
    "/DAppVersion=$Version" `
    "/DClientPublishDir=$(Join-Path $publishDir 'client')" `
    (Join-Path $PSScriptRoot 'asERP.Client.Setup.iss')
if ($LASTEXITCODE -ne 0) { throw 'Installer compilation failed.' }

Write-Host "Installer written to $(Join-Path $PSScriptRoot "output\asERP-Desktop-Setup-$Version.exe")"
