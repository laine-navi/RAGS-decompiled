param(
    [Parameter(Mandatory=$true)]
    [string]$Target
)

if (-not (Test-Path $Target -PathType Container)) {
    Write-Error "Folder not found: $Target"
    exit 1
}

$Out = "$Target-decompiled"

if (-not (Get-Command ilspycmd -ErrorAction SilentlyContinue)) {
    Write-Host "ilspycmd not found. Installing..."
    dotnet tool install --global ilspycmd
    $env:PATH += ";$env:USERPROFILE\.dotnet\tools"
}

Write-Host "Decompiling $Target → $Out"

Get-ChildItem -Path $Target -File |
    Where-Object { $_.Extension -in ".dll", ".exe" -and $_.Name -notmatch "(?i)mshtml" } |
    Sort-Object Name |
    ForEach-Object {
        $name = $_.Name
        $result = & ilspycmd -p --nested-directories -o "$Out/$name/" $_.FullName 2>&1
        $code = $LASTEXITCODE
        if ($code -eq 0) {
            Write-Host "  ✓ $name → $Out/$name/"
        } else {
            Write-Host "  ⚠ $name (skipped: native or unsupported)"
            Remove-Item -Recurse -Force "$Out/$name/" -ErrorAction SilentlyContinue
        }
    }

Write-Host "Done."   
