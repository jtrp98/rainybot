# RainyBot Solution Structure

## Overview

RainyBot is a modular monolith.

The solution contains two Discord bots:

- RainyBot (Personal Assistant)
- DevBot (Development Assistant)

Both bots run within the same application.

Both bots share:

- PostgreSQL
- Domain Layer
- Application Layer
- Infrastructure Layer

Deployment Model:

- Single Application
- Single Database
- Single Docker Container
- Single Repository

---

# High Level Architecture

```text
Discord
│
├── #rainy-chat
│   └── RainyBot
│
├── #rainy-notes
│   └── RainyBot
│
├── #rainy-dev
│   └── DevBot
│
└── #tasks
    └── DevBot

                │
                ▼

        RainyBot.Discord

                │

                ▼

      RainyBot.Application

                │

                ▼

        RainyBot.Domain

                │

                ▼

    RainyBot.Infrastructure

                │

                ▼

            PostgreSQL
```

---

# Solution Structure

```text
RainyBot
│
├── AGENTS.md
├── CONTEXT.md
├── STRUCTURE.md
├── ASSIGNMENTS.md
├── TASKS.md
│
├── .env
├── .env.example
│
├── docker-compose.yml
├── RainyBot.sln
│
├── src
│   │
│   ├── RainyBot.Api
│   │
│   ├── RainyBot.Application
│   │
│   ├── RainyBot.Domain
│   │
│   ├── RainyBot.Infrastructure
│   │
│   ├── RainyBot.Discord
│   │
│   └── RainyBot.Shared
│
└── tests
    │
    ├── RainyBot.UnitTests
    └── RainyBot.IntegrationTests
```

---

# Domain Layer

Purpose:

- Business Entities
- Domain Models
- Enums
- Core Business Rules

Rules:

- No Infrastructure References
- No Database Logic
- No Discord Logic
- No External Dependencies

Structure:

```text
RainyBot.Domain
│
├── Common
│   ├── BaseEntity.cs
│   └── AuditableEntity.cs
│
├── Entities
│   ├── User.cs
│   ├── Todo.cs
│   ├── Note.cs
│   ├── Reminder.cs
│   ├── Conversation.cs
│   ├── Message.cs
│   ├── Assignment.cs
│   ├── TaskItem.cs
│   └── AgentExecution.cs
│
├── Enums
│   ├── TaskStatus.cs
│   ├── AssignmentStatus.cs
│   └── AgentType.cs
│
└── Interfaces
```

---

# Application Layer

Purpose:

- Business Logic
- Use Cases
- Commands
- Queries
- Service Contracts

Rules:

- No EF Core
- No PostgreSQL
- No Discord.Net
- No External API Calls

Structure:

```text
RainyBot.Application
│
├── Features
│   │
│   ├── Todo
│   │   ├── Commands
│   │   ├── Queries
│   │   └── Handlers
│   │
│   ├── Note
│   │
│   ├── Reminder
│   │
│   ├── Conversation
│   │
│   ├── Assignment
│   │
│   └── TaskTracking
│
├── Interfaces
│   │
│   ├── IAIService.cs
│   ├── ITodoService.cs
│   ├── INoteService.cs
│   ├── IReminderService.cs
│   ├── IConversationService.cs
│   ├── IAssignmentService.cs
│   ├── ITaskTrackingService.cs
│   └── IGitService.cs
│
├── DTOs
│
└── Behaviors
```

---

# Infrastructure Layer

Purpose:

- Database
- AI Integration
- Git Integration
- Repositories
- Logging

Rules:

- Implements Application Interfaces
- Contains External Dependencies

Structure:

```text
RainyBot.Infrastructure
│
├── Persistence
│   │
│   ├── RainyBotDbContext.cs
│   │
│   ├── Configurations
│   │
│   └── Migrations
│
├── Repositories
│
├── AI
│   │
│   ├── GeminiService.cs
│   ├── ConversationMemoryService.cs
│   └── PromptBuilder.cs
│
├── Git
│   │
│   ├── GitService.cs
│   ├── BranchService.cs
│   ├── CommitService.cs
│   └── PullRequestService.cs
│
├── Markdown
│   │
│   ├── AssignmentReader.cs
│   ├── TaskTrackerWriter.cs
│   └── MarkdownParser.cs
│
├── Logging
│
└── DependencyInjection
```

---

# Discord Layer

Purpose:

- Discord Clients
- Command Handling
- Channel Routing
- Message Processing

Rules:

- No Business Logic
- No Database Access
- Use Application Services Only

Structure:

```text
RainyBot.Discord
│
├── Bots
│   │
│   ├── RainyBotHostedService.cs
│   └── DevBotHostedService.cs
│
├── Commands
│   │
│   ├── Rainy
│   │   ├── AskCommand.cs
│   │   ├── TodoCommand.cs
│   │   ├── NoteCommand.cs
│   │   ├── ReminderCommand.cs
│   │   └── SummaryCommand.cs
│   │
│   └── Dev
│       ├── AssignCommand.cs
│       ├── TaskCommand.cs
│       ├── ReviewCommand.cs
│       └── PullRequestCommand.cs
│
├── Handlers
│
└── Routing
    └── ChannelRouter.cs
```

---

# Shared Layer

Purpose:

- Shared Utilities
- Constants
- Extensions
- Configuration Objects

Structure:

```text
RainyBot.Shared
│
├── Constants
│
├── Extensions
│
├── Helpers
│
└── Options
```

---

# Test Projects

Structure:

```text
tests
│
├── RainyBot.UnitTests
│
└── RainyBot.IntegrationTests
```

Unit Tests:

- Services
- Handlers
- Business Logic

Integration Tests:

- EF Core
- PostgreSQL
- Repository Tests

---

# RainyBot Responsibilities

Purpose:

- Personal Assistant
- Notes
- Todo Management
- Reminders
- Conversation Memory
- Summaries

Allowed Channels:

```text
#rainy-chat
#rainy-notes
```

Commands:

```text
!ask
!todo
!todos
!note
!notes
!remind
!summary
```

---

# DevBot Responsibilities

Purpose:

- Task Management
- Assignment Processing
- Code Generation
- Branch Creation
- Commit Creation
- Pull Request Creation

Allowed Channels:

```text
#rainy-dev
#tasks
```

Commands:

```text
/assign
/task
/review
/pr
```

---

# Markdown Workflow

## ASSIGNMENTS.md

Purpose:

Incoming work queue.

Example:

```md
TASK-001

Status: Assigned

Agent:
DevBot

Title:
Implement Todo Module
```

DevBot reads this file before starting work.

---

## TASKS.md

Purpose:

Execution history.

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

- Create Command Handler
```

Never delete history.

Always append updates.

---

# Database Tables

Required Tables:

```text
users

todos

notes

reminders

conversations

messages

assignments

tasks

agent_executions
```

All tables use:

```csharp
Guid Id
```

All dates stored in UTC.

---

# Hosted Services

The application hosts two Discord bots.

```csharp
builder.Services.AddHostedService<RainyBotHostedService>();

builder.Services.AddHostedService<DevBotHostedService>();
```

Both bots run within the same process.

Both bots share:

- Dependency Injection Container
- PostgreSQL Database
- Application Layer
- Infrastructure Layer