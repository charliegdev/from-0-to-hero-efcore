#!/usr/bin/env bash
# Open an interactive SQL Server terminal.
# Run ./start first if the container isn't up.
set -euo pipefail

CONTAINER_NAME="efcore-mssql"
SA_PASSWORD="MySaPassword123"

if [ -f /run/.containerenv ] || [ -n "${CONTAINER_ID:-}" ]; then
  PODMAN="distrobox-host-exec podman"
else
  PODMAN="podman"
fi

exec $PODMAN exec -it "$CONTAINER_NAME" \
  /opt/mssql-tools18/bin/sqlcmd -C -S localhost -U sa -P "$SA_PASSWORD" -d MoviesDB