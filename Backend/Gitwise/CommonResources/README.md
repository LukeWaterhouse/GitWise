# GitWise Database Management

Quick reference for managing the GitWise database with automated scripts.

## Database Scripts

Two scripts in this directory handle all your database needs:

### 🚀 `init-database.sh` - Setup & Deployment

**When to use:**
- Setting up a new development environment
- Deploying to staging/production
- Onboarding new team members
- Fresh database setup

```bash
./init-database.sh
```

### 🔄 `migrate-all.sh` - Development Changes

**When to use:**
- You modified Entity models/DbContext
- You added/changed database fields
- You need to update the database schema

```bash
# Auto-generate migration name
./migrate-all.sh

# Custom migration name
./migrate-all.sh "AddUserProfileColumn"
```

## Quick Workflows

**🆕 New Environment:**
1. Clone repo → 2. Configure `appsettings.json` → 3. Run `./init-database.sh`

**🔨 Model Changes:**
1. Modify entities → 2. Run `./migrate-all.sh "DescriptiveName"` → 3. Done

**🚀 Deployment:**
1. Commit code → 2. Deploy → 3. Run `./init-database.sh` on server

## Troubleshooting

**"No migrations found"** → Run `./migrate-all.sh "InitialCreate"`

**Permission denied** → Run `chmod +x *.sh`

**Connection issues** → Check `appsettings.json` connection string

---

That's it! The scripts handle the complexity - you just pick the right one for your situation.
