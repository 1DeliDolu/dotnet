#!/bin/bash
set -euo pipefail

WINDOWS_DOTNET="/mnt/c/Program Files/dotnet/dotnet.exe"
MARKER="# DOTNET_FROM_WINDOWS"

if [ ! -x "$WINDOWS_DOTNET" ]; then
    echo "Windows tarafındaki dotnet bulunamadı: $WINDOWS_DOTNET" >&2
    echo "Lütfen Windows'a .NET SDK/Runtime kurulu olduğundan emin olun." >&2
    exit 1
fi

if grep -Fq "$MARKER" "$HOME/.bashrc"; then
    echo ".bashrc içinde gerekli ayarlar zaten mevcut."
else
    cat >> "$HOME/.bashrc" <<'EOF'
# DOTNET_FROM_WINDOWS
if [ -x "/mnt/c/Program Files/dotnet/dotnet.exe" ]; then
    export DOTNET_ROOT="/mnt/c/Program Files/dotnet"
    export PATH="$DOTNET_ROOT:$PATH"
    alias dotnet='"/mnt/c/Program Files/dotnet/dotnet.exe"'
fi
EOF
    echo ".bashrc güncellendi. Yeni ayarların etkin olması için 'source ~/.bashrc' çalıştırın."
fi

echo "WSL oturumunuzda artık Windows'taki dotnet kullanılabilir."
