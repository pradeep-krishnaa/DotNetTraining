# Day 1 - Project 2: SupportPortal

## Overview

The **SupportPortal** is a basic support request management system designed to simulate agent assignment and issue resolution. This project introduces two main classes: `SupportAgent` and `SupportRequest`, focusing on class composition, object management, and method-based interactions.

---

## Classes Implemented

### 1. `SupportAgent`

Represents a support agent responsible for handling support requests.

- **Properties:**
  - `AgentId`
  - `Name`
  - `Department`

- **Method:**
  - `DisplayAgent()` — Displays agent details.

---

### 2. `SupportRequest`

Represents a customer support request that can be assigned to a support agent.

- **Properties:**
  - `RequestId`
  - `Issue`
  - `Status`
  - `CreatedOn`
  - `ResolutionTime`
  - `IsResolved`
  - `AssignedTo` (a `SupportAgent` object)

- **Methods:**
  - `ResolveRequest()`  
    Marks the request as resolved, sets `IsResolved` to true, and calculates `ResolutionTime`.
  
  - `ReassignRequest(SupportAgent newAgent)`  
    Reassigns the request to a new agent.
  
  - `DisplayRequest()`  
    Displays all details about the support request, including agent info.

---

## Features Demonstrated

- Object creation and method execution for real-world simulation.

---

## Output Screenshots

<img width="566" height="761" alt="image" src="https://github.com/user-attachments/assets/3f1e891b-3429-4e51-82b4-4d74f01c84c5" />


## Git Commands Used

```bash
git init
git remote add origin <repository-url>
git add .
git commit -m "feat: implemented SupportPortal with SupportAgent and SupportRequest classes"
git branch
git branch -M main
git push origin main
