# RAGS Player Decompiled Source

Decompiled .NET assemblies from RAGS Suite 2.4.16, 2.5.2, 2.6.1, 3.0.59, and 3.0.60.
Preservation reference for reverse engineering the RAGS game format.

Not for redistribution of the original software. Binaries included for provenance only.

**Engine spec:** [link to rags-engine-spec repo]
**Preservation archive (originals + dependencies):** [link to archive.org item]

## Contents

| Folder       | Version              | UI Framework | Obfuscation            |
|--------------|----------------------|--------------|------------------------|
| `2.4.16/`    | 2.4.16               | WinForms     | Agile.NET (aggressive) |
| `2.4.16-sf/` | 2.4.16 + speed patch | WinForms     | Agile.NET (aggressive) |
| `2.5.2/`     | 2.5.2                | WinForms     | Dotfuscator (light)    |
| `2.6.1/`     | 2.6.1                | WinForms     | Dotfuscator (light)    |
| `3.0.59/`    | 3.0.59               | WPF          | Dotfuscator (light)    |
| `3.0.60/`    | 3.0.60               | WPF          | Dotfuscator (light)    |

Each version folder contains the original `.exe`/`.dll` files. The `<version>-decompiled/` folders contain ilspycmd output (one subdirectory per assembly,
named after the source file including extension).

**Note on 2.4.16:** Agile.NET obfuscation renames classes to MD5 hashes and
encrypts string literals. Only 2.4.16 and the "slightly faster" patch are affected —
2.5.2 onward switched to Dotfuscator and is fully readable.

**Note on 3.0.x:** The command/condition system is identical between 2.6.1 and 3.0.60
(verified by diff). The 3.0 release was a UI framework rewrite (WinForms → WPF) and
file format migration (NRBF → SQL CE SDF), not a feature addition.

## Reproducing

### Prerequisites

- .NET SDK 8.0+
  - Fedora: `sudo dnf install dotnet-sdk-8.0`
  - Windows: [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Linux / macOS

```bash
chmod +x decompile.sh
./decompile.sh 2.4.16
./decompile.sh 2.4.16-sf
./decompile.sh 2.5.2
./decompile.sh 2.6.1
./decompile.sh 3.0.59
./decompile.sh 3.0.60
```

### Windows (PowerShell)

```powershell
.\decompile.ps1 -Target "2.4.16"
.\decompile.ps1 -Target "2.4.16-sf"
.\decompile.ps1 -Target "2.5.2"
.\decompile.ps1 -Target "2.6.1"
.\decompile.ps1 -Target "3.0.59"
.\decompile.ps1 -Target "3.0.60"
```

Native DLLs (SQL CE, etc.) and MSHTML interop stubs are skipped automatically.

## Tooling

ilspycmd 11.x. No deobfuscation applied.
