
# 🏦 Bank Application (.NET 6 Web API)

This is a sample **Banking Application** built with **.NET 6**, following a clean layered architecture.

It demonstrates:
- Entities: **Customer, Account, Transaction**
- Repository Pattern (with EF Core & async methods)
- Services with business logic
- Controllers (API endpoints)
- DTOs (Request & Response) with **manual mapping** (no AutoMapper)
- CRUD operations for Customers & Accounts
- Banking operations: **Deposit, Withdraw, Transfer**
- Automatic **Transaction logging**
- View-only **TransactionController**

---

## 📂 Project Structure

```
BankApp/
│── BankApp.Core/               # Entities + DTOs + Interfaces
│   ├── Entities/               # Customer, Account, Transaction
│   ├── DTOs/                   # Request & Response DTOs
│   ├── Interfaces/             # IRepository, ICustomerRepo, IAccountRepo, ITransactionRepo
│
│── BankApp.Infrastructure/     # EF Core DbContext + Repository implementations
│
│── BankApp.Application/        # Services
│   ├── CustomerService.cs
│   ├── AccountService.cs
│   ├── TransactionService.cs
│
│── BankApp.API/                # Controllers (Web API Layer)
│   ├── CustomerController.cs
│   ├── AccountController.cs
│   ├── TransactionController.cs
│
│── BankApp.sln
```

---

## ⚙️ Setup

1. Clone repository:
   ```sh
   git clone https://github.com/your-repo/bankapp.git
   cd bankapp
   ```

2. Update **appsettings.json** with your DB connection string.

3. Run EF Core migrations:
   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

4. Run the API:
   ```sh
   dotnet run --project BankApp.API
   ```

5. Navigate to Swagger:
   ```
   https://localhost:5001/swagger
   ```

---

## 📌 API Endpoints

### 👤 Customer
- `GET /api/customer` → Get all customers
- `GET /api/customer/{id}` → Get customer by ID
- `POST /api/customer` → Create customer
- `PUT /api/customer/{id}` → Update customer
- `DELETE /api/customer/{id}` → Delete customer

### 🏦 Account
- `GET /api/account` → Get all accounts
- `GET /api/account/{id}` → Get account by ID
- `POST /api/account` → Create account
- `PUT /api/account/{id}` → Update account
- `DELETE /api/account/{id}` → Delete account
- `POST /api/account/deposit` → Deposit money
- `POST /api/account/withdraw` → Withdraw money
- `POST /api/account/transfer` → Transfer money between accounts

### 💰 Transaction (Read-Only)
- `GET /api/transaction` → Get all transactions
- `GET /api/transaction/{id}` → Get transaction by ID
- `GET /api/transaction/account/{accountId}` → Get all transactions for a specific account

---

## 🔄 Business Logic

- **Deposit** → Increases account balance + logs a "Deposit" transaction  
- **Withdraw** → Decreases account balance + logs a "Withdraw" transaction  
- **Transfer** → Moves money from one account to another + logs two transactions  
- **Transactions** are **automatically created** when performing account operations.  

---

## 🛠️ Tech Stack

- .NET 6 Web API
- Entity Framework Core
- SQL Server (default, configurable)
- Swagger (API Documentation)

---

## 🚀 Future Improvements

- Authentication & Authorization (JWT)
- Unit Tests & Integration Tests
- Pagination for transactions
- UI integration (React / Angular frontend)

---

## 👨‍💻 Author

**Your Name**  
Bank Application - Training Project
