# RainyBot Context

## Project Overview

RainyBot is a personal AI assistant platform built for productivity, knowledge management, and software development assistance.

Repository: `https://github.com/jtrp98/rainybot.git`

The system contains two Discord bots:

1. RainyBot
2. DevBot

Both bots run in the same application and share the same PostgreSQL database.

Deployment Model:

- Single Repository
- Single Application
- Single PostgreSQL Database
- Single Docker Deployment

---

# Vision

RainyBot should act as a personal digital assistant.

DevBot should act as a software development assistant.

The goal is to automate repetitive work while keeping humans responsible for all final approvals.

---

# Bots

## RainyBot

Purpose:

- General Chat
- Todo Management
- Notes
- Reminders
- Conversation Memory
- Daily Summaries

Channels:

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

## DevBot

Purpose:

- Task Management
- Assignment Processing
- Code Generation
- Code Refactoring
- Pull Request Creation
- Development Documentation

Channels:

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

# Technology Stack

Backend:

- .NET 9

Language:

- C# 13

Database:

- PostgreSQL

ORM:

- Entity Framework Core

AI Provider:

- Gemini 2.5 Flash

Discord Framework:

- Discord.Net

Scheduling:

- Quartz.NET

Logging:

- Serilog

Testing:

- xUnit

Containerization:

- Docker
- Docker Compose

---

# Solution Structure

Projects:

```text
RainyBot.Api
RainyBot.Application
RainyBot.Domain
RainyBot.Infrastructure
RainyBot.Discord
RainyBot.Shared
```

Tests:

```text
RainyBot.UnitTests
RainyBot.IntegrationTests
```

Detailed structure is documented in:

```text
STRUCTURE.md
```

---

# Core Features

## Todo Management

Users can:

- Create Todos
- Complete Todos
- View Todo Lists

---

## Notes

Users can:

- Save Notes
- Search Notes
- List Notes

---

## Reminders

Users can:

- Create Reminders
- Receive Scheduled Notifications

Scheduling is handled by Quartz.NET.

---

## Conversation Memory

Store:

- User Messages
- Assistant Messages

Purpose:

- Maintain conversation context
- Improve response quality

Memory Window:

```json
{
  "Memory": {
    "MaxMessages": 20
  }
}
```

Default:

```text
Last 20 Messages
```

---

# Assignment Workflow

Incoming work is stored in:

```text
ASSIGNMENTS.md
```

Progress tracking is stored in:

```text
TASKS.md
```

Workflow:

```text
Assignment
    ↓
Development (Bot works on `agent` branch)
    ↓
Pull Request (Bot opens PR targeting `main`)
    ↓
Human Review
    ↓
Merge (Human manually merges PR to `main`)
```

---

# Human Approval Process

DevBot may:
- Analyze code
- Modify code
- Create branches from `agent`
- Create commits
- Create pull requests

DevBot may not:
- Merge pull requests
- Deploy applications
- Modify secrets
- Push to `main`

Human approval is required before:
- Merge into `main`
- Deployment
- Production changes

---

# Database Tables

Current Tables:

```text
users

todos

notes

reminders

conversations

messages
```

Development Tables:

```text
assignments

tasks

agent_executions
```

---

# Memory Strategy

Conversation history should be persisted.

Load:

```text
Last 20 Messages
```

before generating AI responses.

Message history should be associated with:

- User
- Conversation

Memory size should be configurable.

---

# Logging Strategy

Log:

- Application Startup
- Discord Events
- AI Requests
- Task Execution
- Errors

Never store:

- API Keys
- Passwords
- Tokens

---

# Future Roadmap

## Phase 1

- RainyBot
- Todo Module
- Notes Module
- Reminder Module
- Conversation Memory

## Phase 2
- DevBot
- Assignment Tracking
- Markdown Workflow
- Pull Request Creation targeting `main`

## Phase 3

- GitHub Integration
- Automated Code Reviews
- Documentation Generation

## Phase 4

- QA Agent
- Reviewer Agent
- Multi-Agent Collaboration

---

## Success Criteria

RainyBot should become a reliable personal assistant.
DevBot should become a reliable development assistant.
All code changes must remain under human control and approval via Pull Requests targeting `main`.