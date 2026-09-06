# Restaurant & Café POS System

A full-stack Point-of-Sale system for restaurants and cafés, built with **C# Windows Forms**, **ADO.NET**, and **SQL Server**, following a layered (3-tier) architecture.

## Tech Stack

- **Frontend:** C# Windows Forms (.NET 8)
- **Backend:** ADO.NET via `Microsoft.Data.SqlClient` — layered Services/DataAccess architecture
- **Database:** SQL Server (tables, views, stored procedures)

## Features

- **Authentication & Role-Based Access** — Admin / Cashier roles, login validation, user management (add/update/activate/deactivate/delete)
- **Table Management** — dynamic table grid, Available/Occupied/Reserved status, full CRUD
- **Category & Product Management** — CRUD, category/availability filters, stock tracking, duplicate/validation checks
- **Order Management** — select table → open/reuse order → add items (persisted immediately) → back to table (stays Occupied) → reopen later
- **Checkout** — review, add/remove items, apply discount, before payment
- **Payments** — Cash (with change calculation), KHQR, and Card, via a pluggable `IPaymentProcessor` design (OOP: polymorphism)
- **Automatic stock deduction & table release** on successful payment
- **Receipts** — on-screen and printable
- **Sales Reports** — date range, quick "Today"/"This Month" filters, order status filter, best-sellers, revenue/tax/items-sold totals
- **Order Search** — search any order (any status) by ID, table, cashier, or date

## Project Structure

```
RestaurantPOS/
├── Forms/          # WinForms UI (Login, Dashboard, POS Billing, Checkout, Payment, Reports, etc.)
├── Models/         # Domain entities (User, Product, Order, Payment, ...)
├── Interfaces/     # IPaymentProcessor abstraction
├── Services/       # Business logic layer
├── DataAccess/     # Repository layer (ADO.NET, stored procedure calls)
├── Database/       # RestaurantPOSDB.sql — full schema, views, stored procedures, seed data
└── Program.cs
```

## Getting Started

### 1. Set up the database
Run `Database/RestaurantPOSDB.sql` against your SQL Server instance (SSMS or Azure Data Studio). This creates the `RestaurantPOSDB` database, all tables/views/stored procedures, and seed data.

### 2. Configure the connection string
Edit `App.config` and point it at your SQL Server instance:

```xml
<add name="RestaurantPOSDB"
     connectionString="Server=YOUR_SERVER_NAME;Database=RestaurantPOSDB;Trusted_Connection=True;TrustServerCertificate=True;"
     providerName="Microsoft.Data.SqlClient" />
```

### 3. Build and run
Open `RestaurantPOS.sln` in Visual Studio 2022+, restore NuGet packages, and press **F5**.

### 4. Log in
| Role    | Username | Password   |
|---------|----------|------------|
| Admin   | admin    | admin123   |
| Cashier | cashier  | cashier123 |

## License

This project is for personal / educational use.
