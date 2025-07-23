# 📘 Day 2 Project 1 Phase 2 - Enhanced Issue Tracker

This project builds upon a basic issue tracking system by introducing enhancements like **input validation**, an extended interface (`IReportable`), and a new class `FeatureRequest`. It demonstrates key OOP principles including **inheritance**, **polymorphism**, and **interface implementation**.

---

## 🚀 Enhancements Overview

### ✅ Extended Interface: `IReportable`
- **New Methods Added**:
  - `ReportStatus()`
  - `GetSummary()`
  - `UpdateStatus(string newStatus)`

- **New Property**:
  - `string Status` 

---

## 🏗️ Updated Classes

### 🧱 `Issue` (Base Class)
- **Properties added**:
  - `string Status` (default: "Open")
- **Constructor**:
  - Includes **input validation** (no empty/null values)

---

### 🐞 `Bug` (Inherits `Issue`, Implements `IReportable`)
- **Enhancements**:
  - Input validation in constructor
  - Implements:
    - `ReportStatus()`
    - `GetSummary()`
    - `UpdateStatus()`

---

### 📝 `Task` (Inherits `Issue`, Implements `IReportable`)
- **Enhancements**:
  - Input validation in constructor
  - Implements:
    - `ReportStatus()`
    - `GetSummary()`
    - `UpdateStatus()`

---

### 🌟 `FeatureRequest` (New Class)
- **Inherits**: `Issue`
- **Implements**: `IReportable`
- **Properties**:
  - `string RequestedBy`
  - `string PlannedReleaseDate`
- **Methods**:
  - Overrides `Display()`
  - Implements:
    - `ReportStatus()`
    - `GetSummary()`
    - `UpdateStatus()`
- **Validation**:
  - Constructor includes input validation for all fields

---

## 🧪 Program Execution

### Main Operations in `Program.cs`:
- Create a `List<Issue>` with instances of `Bug`, `Task`, and `FeatureRequest`.
- Use polymorphism to call:
  - `Display()`
  - `ReportStatus()`
  - `GetSummary()`
- Call `UpdateStatus()` to change issue states.
- Track how many issues are in `"Open"` and `"Closed"` using a loop.

---

## Output Screenshots

<img width="1469" height="663" alt="image" src="https://github.com/user-attachments/assets/38e537f8-5541-4686-ae62-1cffa018acd9" />


## 📊 Git Commands

```bash
git init
git remote add origin <your-repo-url>
git add .
git commit -m "Initial commit - Issue Tracker"
git branch -M main
git push origin main

