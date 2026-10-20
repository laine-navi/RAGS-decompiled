# RAGS Player Decompiled Source

Decompiled .NET assemblies from RAGS Suite 2.4.16, 3.0.59, and 3.0.60.
Preservation reference for reverse engineering the RAGS game format.

Not for redistribution of the original software. Binaries included for
provenance only.

**Engine spec:** [link to rags-engine-spec repo]

## Contents

| Folder | Version | Notes |
|--------|---------|-------|
| `3.0.60/` | 3.0.60 (WPF) | Last 3.x release |
| `3.0.59/` | 3.0.59 (WPF) | |
| `2.4.16/` | 2.4.16 (WinForms) | Last widely-used 2.x |

Each version folder contains the original `.exe`/`.dll` files plus a
`<version>-decompiled/` subfolder with ilspycmd output.

## Reproducing

### Prerequisites

- .NET SDK 8.0+
  - Fedora: `sudo dnf install dotnet-sdk-8.0`
  - Windows: [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Linux / macOS

```bash
chmod +x decompile.sh
./decompile.sh 3.0.60
./decompile.sh 3.0.59
./decompile.sh 2.4.16
```

### Windows (PowerShell)

```powershell
.\decompile.ps1 -Target "3.0.60"
.\decompile.ps1 -Target "3.0.59"
.\decompile.ps1 -Target "2.4.16"
```

Native DLLs (SQL CE, etc.) are skipped automatically. MSHTML interop stubs
are excluded.

## Tooling

ilspycmd 11.x. No deobfuscation applied — Dotfuscator string encryption is 
partial and most logic is readable as-is for 3.X, 2.X looked iffy.
