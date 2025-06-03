# ✅ Minimal API Todo Project

A simple yet practical Todo management project built using **ASP.NET Core 8 Minimal API**. This project is great for learning lightweight API design, database integration with Dapper, and a clean and understandable structure.

---

## 🧰 Technologies Used

- [.NET 8](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-8)
- **ASP.NET Core Minimal API**
- **Dapper** (Micro ORM for data access)
- **SQL Server**
- Entity Framework Core (used only for database creation/migrations)

---

## 🚀 How to Run the Project

1. Clone the project:
   ```bash
   git clone https://github.com/your-username/minimalApi.git
2. Navigate into the project directory:
```bash
cd minimalApi/minimalApi 
```
3. Make sure SQL Server is installed and running on your machine.
4. Update your connection string in appsettings.json:
```
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=TodoDB;Trusted_Connection=True;"
}
```
5. Apply migrations to create the database:
```
dotnet ef database update
```
6. Run the project:
```
dotnet run
```
📁 Project Structure
```
minimalApi/
│
├── Program.cs                      → Entry point (Minimal API endpoints)
├── Entities/TodoModel.cs          → Todo entity model
├── AppDb/AppDBContext.cs          → EF Core DbContext
├── Configurations/TodoConfiguration.cs → Fluent API configurations
├── Services/ITodoService.cs       → Service interface
├── Services/TodoService.cs        → Service implementation using Dapper
├── HistoryCodefirst/              → EF Core migration files
├── appsettings.json               → App and database settings
└── minimalApi.http                → HTTP file to test endpoints (Visual Studio)
```
---
🧠 What is Minimal API?
Minimal APIs were introduced in .NET 6 to create lightweight, fast, and easy-to-maintain web APIs without the need for controllers or the full MVC pattern.
They are ideal for small projects, microservices, and rapid prototyping.
---
🔗 Clone and Run Locally
```
git clone https://github.com/your-username/minimalApi.git
cd minimalApi/minimalApi
dotnet run
```
---
🧪 API Testing
Use the included minimalApi.http file in Visual Studio to test the available API endpoints (GET, POST, DELETE, etc.).
---
💡 Future Enhancements
Add Swagger for API documentation

* Implement authentication (e.g., JWT)

* Add unit tests

* Introduce repository pattern

* Extend features (e.g., task categories, deadlines)
