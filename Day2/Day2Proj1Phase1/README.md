# 📘 Day 2 Project 2 Phase 1 - Issue Tracker

A simple C# console application to manage software issues using Object-Oriented Programming concepts like **inheritance**, **interfaces**, and **polymorphism**.

---

## 🚀 Features

- Tracks different types of issues (Bugs, Tasks).
- Displays issue details.
- Reports issue status using an interface.
- Demonstrates use of collections and inheritance.

---

## 📦 Classes & Structure

### ✅ `Issue` (Base Class)
- **Properties**:  
  `int ID`  
  `string Title`  
  `string AssignedTo`
- **Method**:  
  `Display()` – prints basic issue details.

### ✅ `IReportable` (Interface)
- **Method**:  
  `ReportStatus()` – to report the current status of the issue.

### 🐞 `Bug` (Inherits `Issue`, Implements `IReportable`)
- **Property**:  
  `string Severity`
- **Methods**:  
  `Display()` – overrides base display to include severity.  
  `ReportStatus()` – prints bug-specific status.

### 📝 `Task` (Inherits `Issue`, Implements `IReportable`)
- **Property**:  
  `int EstimatedHours`
- **Methods**:  
  `Display()` – overrides base display.  
  `ReportStatus()` – prints task-specific status.

---

## 🧪 Execution

- Objects of `Bug` and `Task` were created.
- Stored in a `List<Issue>`.
- Used `foreach` to loop through and:
  - Display issue details.
  - Call `ReportStatus()` for reportable issues.

---

## Output Screenshots

<img width="607" height="193" alt="image" src="https://github.com/user-attachments/assets/2dbc150f-b47e-4f30-b6d5-8c5fd626440d" />

## 💻 Git Commands

```bash
git init
git remote add origin <your-repo-url>
git add .
git commit -m "Initial commit - Issue Tracker"
git branch -M main
git push origin main
