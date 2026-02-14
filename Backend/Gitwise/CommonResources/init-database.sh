#!/bin/bash

# EF Core Database Initialization Script for GitWise Solution
# This script ensures the database is created and all migrations are applied
# Usage: ./init-database.sh

set -e

echo "🚀 GitWise Database Initialization Script"
echo "=========================================="

# Navigate to solution directory (up one level from CommonResources)
cd "$(dirname "$0")/.."

echo ""
echo "📦 Building solution..."
dotnet build --configuration Release

echo ""
echo "🔧 Ensuring database exists and applying ControlPlane migrations..."
dotnet ef database update \
    --context ControlPlaneDbContext \
    --project ControlPlane.Infrastructure \
    --startup-project Gitwise.Api \
    --verbose

echo ""
echo "🔧 Ensuring database exists and applying SummaryEngine migrations..."
dotnet ef database update \
    --context SummaryEngineDbContext \
    --project SummaryEngine.Infrastructure \
    --startup-project Gitwise.Api \
    --verbose

echo ""
echo "📊 Listing applied migrations for ControlPlane..."
echo "ControlPlane Database Migrations:"
dotnet ef migrations list \
    --context ControlPlaneDbContext \
    --project ControlPlane.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "📊 Listing applied migrations for SummaryEngine..."
echo "SummaryEngine Database Migrations:"
dotnet ef migrations list \
    --context SummaryEngineDbContext \
    --project SummaryEngine.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "🔍 Verifying database connections..."
echo "ControlPlane Database Info:"
dotnet ef dbcontext info \
    --context ControlPlaneDbContext \
    --project ControlPlane.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "SummaryEngine Database Info:"
dotnet ef dbcontext info \
    --context SummaryEngineDbContext \
    --project SummaryEngine.Infrastructure \
    --startup-project Gitwise.Api

echo ""
echo "✅ Database initialization completed successfully!"
echo ""
echo "📋 Summary:"
echo "   • Built solution in Release configuration"
echo "   • Created database if it didn't exist"
echo "   • Applied all pending migrations for both contexts"
echo "   • Verified database connections"
echo ""
echo "Your GitWise database is now ready for use! 🎉"
