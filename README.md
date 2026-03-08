# Clean Architecture Pro Template (.NET 10)

A high-quality, production-ready implementation of **Clean Architecture** (Onion Architecture) focusing on separation of concerns, testability, and the Result Pattern.

## 🚀 Architecture Overview
This project follows the **Dependency Inversion Principle**, ensuring the Domain and Application layers are independent of external frameworks.

- **Domain**: Entities, Value Objects, Enums, and Domain Logic.
- **Application**: Business logic, Interfaces, DTOs, and the Result Pattern.
- **Infrastructure**: Data access (EF Core In-Memory), External Services, and Repositories.
- **WebAPI**: RESTful Endpoints, Swagger UI, and Global Exception Handling.

## 🛠️ Tech Stack
- **Framework**: .NET 10
- **Database**: Entity Framework Core (In-Memory)
- **API Docs**: Swagger / OpenAPI
- **Patterns**: Repository Pattern, Result Pattern, Middleware, Dependency Injection.

## 🚦 Getting Started
1. Clone the repo.
2. Run `dotnet restore`.
3. Set `CleanArch.WebAPI` as the startup project and press F5.
4. Explore the API via Swagger at `http://localhost:5016/`.