# 📝 Leave Management System

## 🗓️ Day 3 Project 1

A console-based Leave Management System demonstrating core object-oriented programming concepts in C#. The system manages employee leave requests including Sick Leave and Casual Leave, with approval and status tracking.

---

## 📌 Objectives

This project was built to practice and implement:

- **Abstract classes**
- **Interfaces**
- **Inheritance**
- **Polymorphism**
- **Encapsulation**
- **SOLID Principles**

---

## 🛠️ Features & Tasks Implemented

### 1. **Abstract Class - `LeaveRequest`**
- Common Properties:
  - `Id` (int)
  - `EmpName` (string)
  - `DaysRequested` (int)
  - `Status` (string)
- Common Methods:
  - `Approve()` – Marks the request as approved
  - `Reject()` – Marks the request as rejected
  - `Display()` – Abstract method to be implemented by derived classes

### 2. **Interface - `IApprovable`**
- Method:
  - `ShowApprovalStatus()`

### 3. **Derived Classes**
- **`SickLeave`**
  - Inherits: `LeaveRequest`, `IApprovable`
  - Additional Property: `DoctorNote` (string)
  - Overrides: `Display()`, `ShowApprovalStatus()`
  
- **`CasualLeave`**
  - Inherits: `LeaveRequest`, `IApprovable`
  - Additional Property: `Reason` (string)
  - Overrides: `Display()`, `ShowApprovalStatus()`

### 4. **Service Layer**
- **Interface - `ILeaveService`**
  - Methods:
    - `DisplayAll()`
    - `ShowAllApprovalStatuses()`

- **Implementation - `LeaveService`**
  - Manages collection of leave requests and executes all related operations

### 5. **Program.cs**
- Created objects of `SickLeave` and `CasualLeave`
- Performed the following operations:
  - `Approve()` / `Reject()`
  - `Display()`
  - `DisplayAll()` and `ShowAllApprovalStatuses()` via the service

---

<img width="1027" height="166" alt="image" src="https://github.com/user-attachments/assets/9b31dd74-cd43-4cdd-9cc4-1e124b9d8d6c" />


