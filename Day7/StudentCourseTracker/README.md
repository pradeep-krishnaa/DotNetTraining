# 🎓 StudentCourse Tracker

A simple console-based Student-Course tracking system using **.NET Core** and **Entity Framework Core (Database First)**. It supports adding, viewing, updating, and deleting students and courses, backed by SQL Server.

---

## 🗄️ Database Setup using Azure Data Studio

Open **Azure Data Studio**, and run the following SQL statements:

```sql
-- Create the database
CREATE DATABASE StudentCourseDB;
USE StudentCourseDB;

-- Create Courses table
CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(50) NOT NULL
);

-- Create Students table
CREATE TABLE Students (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    CourseId INT NOT NULL,
    FOREIGN KEY (CourseId) REFERENCES Courses(CourseId)
);

```

## Use following commands in Project  
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer  
dotnet add package Microsoft.EntityFrameworkCore.Tools  
dotnet add package Microsoft.EntityFrameworkCore.Design
```

## To create a scaffold  
```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=<DBname>;TrustServerCertificate=True;User Id=<your username>;Password=<Your passwd>;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c CourseContext -f
```
---

## Program.cs  
- Seeded the db  
- Menu driven to  
    - Add course  
    - Add student  
    - View students with course name  
    - Update a student by ID
    - Delete a student by ID

---
 
## Output Screenshots

### Add Course and student
<img width="533" height="767" alt="image" src="https://github.com/user-attachments/assets/b1d6a912-6131-414e-8688-1458de06b53e" />

### View Students
<img width="503" height="205" alt="image" src="https://github.com/user-attachments/assets/fdcc3f15-0619-4ac9-b445-28b366b270e9" />

### Update and Delete Student
<img width="451" height="583" alt="image" src="https://github.com/user-attachments/assets/ea98164f-4486-4bc1-b8f6-e811d99d20c8" />

---

## GIT Commands

```bash
git add .
git commit -m "msg"
git push origin main
```
