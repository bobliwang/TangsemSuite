
param (
    [string]$parameter
)

$exePath = ".\Tangsem.Generator.Console.exe"

if (Test-Path $exePath) {
    Start-Process -FilePath $exePath -ArgumentList $parameter -Wait
} else {
    Write-Host "Executable file not found at $exePath."
}