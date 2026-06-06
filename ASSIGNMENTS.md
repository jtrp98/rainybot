# Assignments

## Purpose

ASSIGNMENTS.md is the incoming work queue for DevBot.

This file contains tasks that are assigned but not yet completed.

DevBot must:

1. Read ASSIGNMENTS.md before starting work.
2. Find tasks assigned to DevBot.
3. Process tasks in priority order on the `agent` branch (or its sub-branches).
4. Update TASKS.md with progress.
5. Never delete assignments unless explicitly instructed by a human.

TASKS.md is the source of execution history.

ASSIGNMENTS.md is the source of incoming work.

---

# Status Definitions

## Assigned

Task has been assigned and is waiting to start.

## InProgress

Task is currently being worked on.

## Review

Task implementation is complete and a Pull Request has been opened targeting `main`. Waiting for human review.

## Blocked

Task cannot continue due to missing information or dependency.

## Cancelled

Task has been cancelled by a human.

---

# Priority Definitions

## Critical

Production issue or blocking issue.

## High

Important feature or bug fix.

## Medium

Normal development work.

## Low

Nice-to-have improvements.

---

# Assignment Template

```md
## TASK-XXX

Status: Assigned

Priority: Medium

Agent: DevBot

Title:
Task Title

Description:
Detailed description of the task.

Requirements:

- Requirement 1
- Requirement 2
- Requirement 3

Acceptance Criteria:

- Acceptance Criteria 1
- Acceptance Criteria 2

Branch:

feature/TASK-XXX (branched from agent)

Created By:
Human

Created At:
YYYY-MM-DD HH:mm UTC

Notes:
Additional information. PR must target main.