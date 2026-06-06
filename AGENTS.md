# RainyBot AI Agent Instructions

You are a senior .NET developer.

---

# General Rules

- Use .NET 9
- Use C# 13
- Nullable enabled
- Async/Await everywhere
- Dependency Injection
- SOLID Principles
- Clean Architecture
- Repository Pattern

Generate production-ready code only.

Do not generate pseudo code.

---

# Architecture

RainyBot is a Modular Monolith.

Do NOT create Microservices.

Do NOT create multiple deployable applications.

Build and deploy as a single solution.

Layers:

- Domain
- Application
- Infrastructure
- Discord
- Api
- Shared

Dependency Direction:

```text
Domain
↑
Application
↑
Infrastructure
↑
Api / Discord
```

Rules:

- Domain must never depend on Infrastructure.
- Business logic belongs in Application.
- Infrastructure contains external integrations.
- Api and Discord are presentation layers.
- Shared contains common utilities and extensions.

---

# Bot Architecture

The solution contains two Discord bots.

## RainyBot

Purpose:

- Personal Assistant
- Chat
- Notes
- Todo Management
- Reminders
- Memory
- Daily Summaries

Allowed Channels:

```text
#rainy-chat
#rainy-notes
```

---

## DevBot

Purpose:

- Development Assistant
- Task Management
- Code Generation
- Git Operations
- Pull Request Creation

Allowed Channels:

```text
#rainy-dev
#tasks
```

Never mix responsibilities between bots.

Both bots run in the same application.

Both bots share:

- PostgreSQL
- Domain Layer
- Application Layer
- Infrastructure Layer

---

# Required Context Files

Always read the following files before starting any work:

1. AGENTS.md
2. CONTEXT.md
3. STRUCTURE.md
4. ASSIGNMENTS.md
5. TASKS.md

If a file is missing:

- Continue with best effort.
- Report the missing file.

---

# Database

Provider:

```csharp
Npgsql.EntityFrameworkCore.PostgreSQL
```

Always use:

```csharp
UseNpgsql(...)
```

Never use:

```csharp
UseSqlServer(...)
```

Never use:

```csharp
UseSqlite(...)
```

Database Engine:

```text
PostgreSQL
```

Use:

- EF Core Code First
- EF Core Migrations
- Repository Pattern

All entities must use:

```csharp
Guid Id
```

Store all dates in UTC.

---

# Environment Variables

All secrets must come from environment variables.

Never hardcode secrets.

Required variables:

```env
RAINYBOT_TOKEN=

DEVBOT_TOKEN=

GEMINI_API_KEY=

DB_HOST=
DB_PORT=
DB_NAME=
DB_USER=
DB_PASSWORD=

ASPNETCORE_ENVIRONMENT=
```

Configuration priority:

1. appsettings.json
2. appsettings.{Environment}.json
3. Environment Variables

Environment Variables override all previous values.

---

# Coding Standards

Classes:

- PascalCase

Methods:

- PascalCase

Properties:

- PascalCase

Private Fields:

- _camelCase

Interfaces:

- I{Name}

Examples:

```csharp
public class TodoService
{
}
```

```csharp
public interface ITodoService
{
}
```

```csharp
private readonly ILogger _logger;
```

---

# Dependency Injection

Use constructor injection.

Never use Service Locator.

Register dependencies through:

```csharp
IServiceCollection
```

Example:

```csharp
builder.Services.AddScoped<ITodoService, TodoService>();
```

---

# Logging

Use:

```text
Serilog
```

Log:

- Application Startup
- Discord Events
- AI Requests
- Task Execution
- Errors

Never log:

- API Keys
- Passwords
- Tokens
- Connection Strings

Mask sensitive values.

Example:

```text
GEMINI_API_KEY=********
```

---

# Security Rules

Never:

- Expose secrets
- Drop databases
- Delete migrations
- Disable authentication
- Disable authorization
- Modify production credentials

Always follow least privilege principles.

---

# Git Rules

Repository URL:
https://github.com/jtrp98/rainybot.git

Branch Strategy:
main
agent
feature/*
bugfix/*

Agents may create branches derived from `agent`:
feature/*
bugfix/*

Agents must never push directly to:
main

All changes must go through Pull Requests. 
Pull Requests must be opened from the `agent` branch (or its sub-branches) targeting the `main` branch.
Humans will manually review and merge the PR into `main`.

# Assignment Workflow

Assignments are stored in:

```text
ASSIGNMENTS.md
```

Task tracking is stored in:

```text
TASKS.md
```

Workflow:

1. Read ASSIGNMENTS.md
2. Find assigned tasks
3. Create or update task entry in TASKS.md
4. Execute work
5. Update progress in TASKS.md
6. Create Pull Request
7. Set task status to Review

Never remove task history.

Always append progress updates.

---

# Assignment Workflow

Assignments are stored in:
ASSIGNMENTS.md

Task tracking is stored in:
TASKS.md

Workflow:

1. Read ASSIGNMENTS.md
2. Find assigned tasks
3. Create or update task entry in TASKS.md
4. Execute work on the `agent` branch or a sub-branch derived from it
5. Update progress in TASKS.md
6. Create Pull Request targeting `master`
7. Set task status to Review

---

# TASKS.md Rules

TASKS.md is the execution history.

Track:

- Task Id
- Status
- Branch Name
- Progress
- Files Modified
- Pull Request

Example:

```md
TASK-001

Status: InProgress

Branch:
feature/TASK-001

Completed Actions:

- Created Todo Entity
- Created Repository
- Created Service

Pending:

- Create Discord Command
```

Never delete history.

Always append updates.

---

# DevBot Rules

DevBot must never:

- Merge pull requests
- Deploy applications
- Modify secrets
- Delete repositories
- Force push
- Delete branches
- Push directly to `main`

---

# Human Approval Policy

Human approval is required for:

- Pull Request Approval
- Merging to `main`
- Production Deployment
- Database Schema Changes
- Infrastructure Changes

Agents may prepare changes.

Humans approve changes.

---

# Build Rules

Agents may run:

```bash
dotnet build
```

Agents may run:

```bash
dotnet test
```

If build or tests fail:

- Analyze errors
- Fix issues
- Re-run validation

Do not ignore build failures.

Do not ignore test failures.

---

# Output Rules

When generating code:

- Generate complete files
- Include namespaces
- Include using statements
- Include dependency injection registration
- Use async/await
- Follow SOLID
- Follow Clean Architecture
- Production-ready code only

Never generate:

- Pseudo code
- TODO placeholders
- Incomplete implementations

---

# Testing Rules

Framework:

```text
xUnit
```

Mock:

- AI Services
- External APIs
- Repositories

Test:

- Services
- Handlers
- Business Logic

Coverage should focus on critical business functionality.

---

# Self Modification Rules

Agents may update:

- Documentation
- TASKS.md
- CONTEXT.md
- STRUCTURE.md

Agents must never modify:

- Security Rules
- Human Approval Policy
- Deployment Rules

without explicit human approval.

---

# Completion Rules

When a task is completed:

Update TASKS.md

Example:

```md
TASK-001

Status: Review

Files Modified:

- Todo.cs
- TodoRepository.cs
- TodoService.cs

Pull Request:

#25
```

Provide a summary including:

- Task
- Branch
- Files Changed
- Build Result
- Test Result
- Pull Request Reference

---

# Final Rule

Code quality is more important than speed.

Always prefer:

- Maintainability
- Readability
- Testability
- Security

over short-term convenience.