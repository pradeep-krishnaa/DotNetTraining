# 📚 Book Rental System

## 🗓️ Day 3 Project

A simple console-based Book Rental System built using object-oriented principles in C#. This system allows users to manage Fiction and Non-Fiction books, rent or return them, and display their status.

---

## 📌 Objectives

This project demonstrates the following OOP concepts and SOLID Principles:

- Inheritance
- Polymorphism
- Interfaces
- Encapsulation

---

## 🛠️ Features & Tasks Implemented

1. **Base Class - `Book`**
   - Common properties:
     - `Id` (int)
     - `Title` (string)
     - `Author` (string)
     - `IsAvailable` (bool)

2. **Derived Classes**
   - `Fiction`:
     - Inherits from `Book`
     - Additional Property: `Genre` (string)
   - `NonFiction`:
     - Inherits from `Book`
     - Additional Property: `Category` (string)

3. **Interface - `IRentable`**
   - Methods:
     - `Rent()`
     - `Return()`
     - `ReportStatus()`

4. **Polymorphism**
   - Overridden `Display()` method in both `Fiction` and `NonFiction` classes.

5. **Service Layer**
   - Interface: `IBookService`
     - `DisplayAll()`
     - `ReportAll()`
   - Implementation: `BookService` class handles collection and operations on books.

6. **Program.cs Implementation**
   - Added 1 Fiction and 1 Non-Fiction book
   - Performed operations:
     - `Rent()`
     - `Return()`
     - `DisplayAll()`
     - `ReportAll()`

---

## Git Commands Used 

```bash
git pull
git add .
git commit -m "commit msg"
git push origin main

