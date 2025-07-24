# 📘 Enhanced Issue Tracker with SOLID Principles


## 🚀 Enhancements Overview

## 🏗️ Class Design

### 🧱 Abstract Base Class: `Issue`
- **Properties:**
  - `Id` (int)
  - `Title` (string)
  - `Description` (string)
  - `Status` (string) *(default: "Open")*
- **Constructor:**
  - Includes **input validation** (no null or empty values)
- **Abstract Method:**
  - `Display()` – must be implemented by derived classes

---

### 🐞 `Bug` Class  
- Inherits: `Issue`  
- Implements: `IReportable`  
- **Enhancements:**
  - Overrides Display() abstract method

---

### 📝 `Task` Class  
- Inherits: `Issue`  
- Implements: `IReportable`  
- **Enhancements:**
  - Overrides Display() abstract method

---

### 🌟 `FeatureRequest` Class  
- Inherits: `Issue`  
- Implements: `IReportable`  
- **Enhancements:**
  - Overrides Display() abstract method

---

## 🔧 Service Layer

### Interface: `IIssueService`
- Methods:
  - `GetAllReportStatus()`
  - `GetAllSummary()`

### Implementation: `IssueService`
- Stores and manages a list of issues
- Executes reporting and summary functionality for all issues
- Promotes **encapsulation** and **separation of concerns**

---

## 🧪 Program Execution (`Program.cs`)

**Operations Performed:**
- Created a list of `Issue` containing:
  - `Bug`
  - `Task`
  - `FeatureRequest`
- Used **polymorphism** to:
  - Call `Display()`, `ReportStatus()`, `GetSummary()`
- Updated issue states using `UpdateStatus()`
- Counted how many issues are in `"Open"` vs `"Closed"` using iteration
- Used `IssueService` to call reporting functions

---

## 🧠 Key OOP Concepts Applied

- ✅ **Abstraction** – Base class `Issue` with abstract method
- ✅ **Inheritance** – Shared structure from `Issue` class
- ✅ **Polymorphism** – Interface-based and method overriding
- ✅ **Encapsulation** – Data and behavior encapsulated in services
- ✅ **SOLID Principles**:

---

## Output Screenshots

<img width="1443" height="622" alt="image" src="https://github.com/user-attachments/assets/232d8008-9431-45e2-889e-eb348b43b1a4" />



