# 🛒 Week 1 Assessment - July 25  
## 📦 EcommerceApp (OOP + SOLID Principles)

This project simulates a basic e-commerce application demonstrating **Object-Oriented Programming** principles such as **abstraction**, **inheritance**, **interface implementation**, and adherence to **SOLID design principles**.

---

### 🔷 Abstract Class: `Product`
Represents the base for all product types.

**Properties:**
- `int Id`
- `string Name`
- `double Price`
- `string Description`
- `int StockQuantity`

**Methods:**
- `void UpdateStock(int quantity)`
- `abstract void DisplayProdDetails()`

---

### 🔷 Interface: `IPurchasable`
Defines methods related to the shopping experience.

**Methods:**
- `void ViewCart()`
- `void Order(Product product, int quantity)`
- `void CancelOrder(Product product, int quantity)`
- `void OrderSummary()`

---

## 🛍️ Product Types

### 🔹 Class: `Electronics`  
Inherits: `Product`, Implements: `IPurchasable`

**Additional Properties:**
- `string Brand`
- `int WarrantyPeriod`

**Overrides:**
- `DisplayProdDetails()`

---

### 🔹 Class: `Clothing`  
Inherits: `Product`, Implements: `IPurchasable`

**Additional Properties:**
- `string Size`
- `string Color`

**Overrides:**
- `DisplayProdDetails()`

---

## 👤 User Module

### 🔹 Class: `User`  
Implements: `IPurchasable`

**Properties:**
- `int UserId`
- `string Name`

**Methods:**
- `void DisplayUserDetails()`
- `void Order(Product product, int quantity)`
- `void CancelOrder(Product product, int quantity)`
- `void ViewCart()`
- `void OrderSummary()`

---

## 🧰 Services

### 🔹 Interface: `IProductService`

**Methods:**
- `void DisplayAllProducts(List<Product> products)`
- `void ViewAllOrderSummary(List<IPurchasable> purchasables)`

### 🔹 Class: `ProductService`  
Implements: `IProductService`

---

### 🔹 Interface: `IUserService`

**Methods:**
- `void ViewAllUsers(List<User> users)`
- `void ViewAllCarts(List<IPurchasable> purchasables)`

### 🔹 Class: `UserService`  
Implements: `IUserService`

---

## 🧪 Implementation Highlights

- Created sample objects of `Electronics`, `Clothing`, and `User`.
- Implemented all service methods for both user and product services.
- Simulated complete flow of:
  - Ordering products
  - Cancelling orders
  - Viewing cart
  - Viewing all user & product information

---

## ✅ Design Principles Followed

### 🧱 SOLID Principles:
- **S - Single Responsibility:** Each class has a single responsibility.
- **O - Open/Closed:** Product is open for extension, closed for modification.
- **L - Liskov Substitution:** Derived classes substitute base classes correctly.
- **I - Interface Segregation:** Interface `IPurchasable` is specific and segregated.
- **D - Dependency Inversion:** High-level modules depend on abstractions (`IProductService`, `IUserService`).

---

## 📌 Technologies Used
- Language: `C#`
- Paradigm: `OOP`
- Concepts: `Interfaces`, `Abstraction`, `Inheritance`, `Polymorphism`, `Encapsulation`

---

## Output Screenshot

<img width="768" height="601" alt="image" src="https://github.com/user-attachments/assets/8d2a488b-134a-4830-9dfc-1181aefad15c" />

## Git Commands

```bash
git pull (if required)
git add .
git commit -m "commit msg"
git push origin main

```


## 👨‍💻 Author
**Pradeep**  
July 25, 2025 - Week 1 Assessment  
