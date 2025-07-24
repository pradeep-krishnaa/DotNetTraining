# 📌 Day 2 - Project 2: Support Desk Pro

## 📦 Class Structure

### 🔹 Base Class: `SupportTicket`
Represents a generic support ticket.

**Properties:**
- `Id` (int)
- `Title` (string)
- `Description` (string)
- `CreatedBy` (string)
- `Status` (string)

**Methods:**
- `virtual void DisplayDetails()` – Prints ticket information
- `void CloseTicket()` – Changes `Status` to `Closed`

---

### 🔸 Interface: `IReportable`
Used by tickets to provide reporting functionality.

**Method:**
- `void ReportStatus()` – Outputs current status of the ticket

---

### 🐞 Derived Class: `BugReport` (inherits `SupportTicket`, implements `IReportable`)
Represents a software bug.

**Additional Property:**
- `Severity` (string)

**Implements:**
- `ReportStatus()` – Prints status and severity

---

### 🌟 Derived Class: `FeatureRequest` (inherits `SupportTicket`, implements `IReportable`)
Represents a new feature suggestion.

**Additional Properties:**
- `RequestedBy` (string)
- `EstimatedHours` (int)

**Implements:**
- `ReportStatus()` – Prints current status and estimated time

---

## 🧪 Testing (Main Class)

In the `Main` method, the following operations were tested:

- Creating `BugReport` and `FeatureRequest` objects
- Calling `DisplayDetails()` polymorphically
- Using `ReportStatus()` via the `IReportable` interface
- Closing tickets with `CloseTicket()`

---

## Output Screenshots

<img width="1338" height="249" alt="image" src="https://github.com/user-attachments/assets/029d7240-08f3-4329-806f-2cf882e8a283" />

## Git Commands Used

```bash
git init
git pull(if required)
git add .
git commit -m "commit msg"
git branch -M main(if necessary)
git push origin main

