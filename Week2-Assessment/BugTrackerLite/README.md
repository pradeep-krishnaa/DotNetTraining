# Week 2 Assessment - BugTrackerLite

---

## 🛢️ SQL Schema

Created a database named `BugTrackerLiteDB` and switched to it.

### Tables:

- **User**
  - `UserId` (PK)
  - `UserName`

- **Ticket**
  - `TicketId` (PK)
  - `Title`
  - `Description`
  - `Status`
  - `CreatedDate`
  - `UserId` (FK → User)

- **Tag**
  - `TagId` (PK)
  - `TagName`

- **TicketTag** (Join Table)
  - `TicketId` (FK → Ticket)
  - `TagId` (FK → Tag)

---

## ⚙️ Setup & Packages

Installed the following NuGet packages:

- `Microsoft.EntityFrameworkCore.SqlServer`
- `Microsoft.EntityFrameworkCore.Tools`
- `Microsoft.EntityFrameworkCore.Design`

### 🏗️ Scaffold Command Used:

```bash
dotnet ef dbcontext scaffold "Server=localhost;Database=BugTrackerLiteDB;TrustServerCertificate=True;User Id=sa;Password=xxx;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c IssueTrackerContext -f
```

---

###  📁 **Models Folder**
- `User.cs`
- `Ticket.cs`
- `Tag.cs`
- `TicketTag.cs`
  - Contains `TicketId`, `TagId`
  - Navigation properties to `Ticket` and `Tag`

### 📁 **Data Folder**
- `AppDBContext.cs`
  - Contains `DbSet` for all tables
  - Configured many-to-many `Ticket-Tag` relationship using Fluent API:
    - `.HasKey()`
    - `.HasOne()`
    - `.WithMany()`
    - `.HasForeignKey()`

---

## 🧠 Services

### `IIssueService.cs` (Interface)
Defines methods:
- `int TicketCount()`
- `int TagCount()`
- `int UserCount()`
- `int TicketTagCount()`
- `Ticket? GetTicketById(int id)`
- `Tag? GetTagById(int id)`
- `User? GetUserById(int id)`

### `IssueService.cs` (Class)
Implements `IIssueService` and defines logic for all the above methods.

---

## 🖥️ Program.cs

- Creates objects for `AppDBContext` and `IssueService`
- Console-based **menu-driven application** with the following features:

---

## ✅ Features

- Create **User**
- Create **Ticket** (only if users exist)
- Create **Tag**
- Assign **Tag** to a Ticket (only if both exist)
- Mark a **Ticket as Resolved** (only if tickets exist)
- View all **Tickets** along with assigned **Users and Tags**

---

## 🔐 Validations Implemented (via `IssueService.cs`)

- ❌ Cannot create a ticket without an existing user
- ❌ Cannot assign a tag to a ticket if no tags or tickets exist
- ❌ Cannot mark a ticket as resolved if no tickets exist
- ❌ Cannot view tickets if no tickets exist
- ✅ Prompts for valid `UserId`, `TicketId`, and `TagId` (if they already exist)

---

## Output Screenshots

### Validation Logic

<img width="464" height="225" alt="image" src="https://github.com/user-attachments/assets/1bcc6831-57f4-46af-bff8-84cdf6048817" />
<img width="512" height="666" alt="image" src="https://github.com/user-attachments/assets/99367b63-21d6-4ea7-a175-3b3bdfe55845" />

---
### User Creation

<img width="413" height="299" alt="image" src="https://github.com/user-attachments/assets/733dcc5c-aaff-48ed-b673-bb778976d680" />

---
### Ticket Creation 

<img width="424" height="377" alt="image" src="https://github.com/user-attachments/assets/c14daef1-78b2-4008-a706-82f33b70b624" />

---
### Tag Creation 

<img width="362" height="303" alt="image" src="https://github.com/user-attachments/assets/c30d19e1-5d9c-453b-a4d6-9f23a592d9de" />

---
### Assigning Tag to Ticket

<img width="569" height="384" alt="image" src="https://github.com/user-attachments/assets/e0dc1dda-5db5-497f-bb19-6d4fe000e54e" />

---
### Viewing Tickets before Resolving It

<img width="1160" height="262" alt="image" src="https://github.com/user-attachments/assets/790df0e2-802a-4f99-990e-22000788516a" />

---
### Resolving Ticket

<img width="396" height="259" alt="image" src="https://github.com/user-attachments/assets/b56d5064-de19-4bd5-b7cc-135ef688ef9e" />

---
### Viewing Tickets after Resolving it

<img width="1216" height="259" alt="image" src="https://github.com/user-attachments/assets/6d7d5b51-6782-4877-b5a5-842de2f7010f" />

---
## GIT Commands

```bash
git add .
git commit -m "msg"
git push origin main
```
---

## 🧪 Notes

- All core logic and validations are implemented via service methods
- Designed for extensibility using clean separation of concerns (Models, Data, Services, Program)
