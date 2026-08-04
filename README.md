# OpenHabitBackend

OpenHabitBackend is a robust, production-grade .NET Core Web API built for tracking and managing daily personal habits and user accounts. Designed with a strict interpretation of modern software architecture principles, the project serves as an enterprise-ready template for scalable backend services.

## Architecture Overview

The solution strictly enforces **Separation of Concerns** and **Clean Architecture** principles, decoupling business logic, data access, and API presentation into independent layers:

1. **OpenHabitBackend.Core**
   * **Role:** The foundational and innermost layer of the application.
   * **Contents:** Domain entities (e.g., `Habit`, `User`), core interfaces, and domain-level Data Transfer Objects (`DTOs` such as `LoginModel`, `UserRegisterDto`, `UserResponseDto`).
   * **Dependencies:** None. It remains completely independent of any frameworks or external infrastructure, ensuring high testability and domain purity.

2. **OpenHabitBackend.Data**
   * **Role:** The persistence layer responsible for handling data interactions and database configurations.
   * **Contents:** Entity Framework Core `DbContext` implementations, database mapping configurations, and initial bootstrap data loaders (`SeedData`).
   * **Dependencies:** Relies on `OpenHabitBackend.Core` for domain entities.

3. **OpenHabitBackend.Business**
   * **Role:** The intermediate business logic layer.
   * **Contents:** Service interfaces (`IHabitService`, `IUserService`) and concrete service implementations (`HabitManager`, `UserManager`). This layer encapsulates validation rules, DTO mapping, and operational workflows.
   * **Dependencies:** References `OpenHabitBackend.Core` and `OpenHabitBackend.Data`.

4. **OpenHabitBackend.Controller**
   * **Role:** The presentation and API entry point layer.
   * **Contents:** ASP.NET Core API controllers (`HabitsController`, `UsersController`), JWT authentication middleware configurations, dependency injection setups, and application bootstrap logic (`Program.cs`).
   * **Dependencies:** References `OpenHabitBackend.Business`, `OpenHabitBackend.Data`, and `OpenHabitBackend.Core`.

## Core Technologies & Frameworks

* **Platform:** .NET Core (.NET 10 SDK)
* **Data Access Framework:** Entity Framework Core (EF Core)
* **Storage Engine:** EF Core In-Memory Database provider for lightweight, configuration-free local execution and testing.
* **Security & Auth:** JSON Web Tokens (JWT) for stateless bearer authentication and authorization policies (`[Authorize]`).
* **API Architecture:** RESTful compliance with standardized HTTP status codes and routing conventions.