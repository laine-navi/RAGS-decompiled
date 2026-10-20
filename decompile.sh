#!/bin/bash
# decompile.sh — Decompile all RAGS assemblies in a version folder.
# Usage: ./decompile.sh <version_folder>
#   e.g. ./decompile.sh 3.0.60

TARGET="$1"
if [ -z "$TARGET" ] || [ ! -d "$TARGET" ]; then
    echo "Usage: $0 <version_folder>"
    echo "  e.g. $0 3.0.60"
    exit 1
fi

OUT="${TARGET}-decompiled"

if ! command -v ilspycmd &>/dev/null; then
    echo "ilspycmd not found. Installing..."
    dotnet tool install --global ilspycmd
    export PATH="$PATH:$HOME/.dotnet/tools"
fi

echo "Decompiling $TARGET → $OUT"

find "$TARGET" -maxdepth 1 \( -name "*.dll" -o -name "*.exe" \) \
  | grep -iv "mshtml" \
  | sort \
  | while read -r f; do
      name=$(basename "$f")
      ilspycmd -p --nested-directories -o "${OUT}/${name}/" "$f" 2>/dev/null
      if [ $? -eq 0 ]; then
          echo "  ✓ $name → ${OUT}/${name}/"
      else
          echo "  ⚠ $name (skipped: native or unsupported)"
          rm -rf "${OUT}/${name}"
      fi
  done

echo "Done."   
