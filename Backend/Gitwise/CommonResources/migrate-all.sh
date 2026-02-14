#!/bin/bash

# EF Core Migration Script for GitWise Solution
# Usage: ./migrate-all.sh [optional-migration-name]
# Example: ./migrate-all.sh "AddNewUserTable"
# If no name provided, will auto-generate based on timestamp

set -e

# Auto-generate migration name if not provided
if [ -z "$1" ]; then
    MIGRATION_NAME="Migration_$(date +%Y%m%d_%H%M%S)"
    echo "No migration name provided. Auto-generating: $MIGRATION_NAME"
else
    MIGRATION_NAME="$1"
    echo "Using provided migration name: $MIGRATION_NAME"
fi

# Navigate to solution directory (up one level from CommonResources)
cd "$(dirname "$0")/.."

echo ""
echo "=== Adding migration for ControlPlaneDbContext ==="
dotnet ef migrations add "$MIGRATION_NAME" \
    --context ControlPlaneDbContext \
    --project ControlPlane.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "=== Adding migration for SummaryEngineDbContext ==="
dotnet ef migrations add "$MIGRATION_NAME" \
    --context SummaryEngineDbContext \
    --project SummaryEngine.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "=== Updating ControlPlane database ==="
dotnet ef database update \
    --context ControlPlaneDbContext \
    --project ControlPlane.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "=== Updating SummaryEngine database ==="
dotnet ef database update \
    --context SummaryEngineDbContext \
    --project SummaryEngine.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "✅ All migrations completed successfully!"
echo "Migration '$MIGRATION_NAME' has been applied to both databases."
