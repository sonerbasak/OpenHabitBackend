# Developer Guide

This document provides complete technical guidelines, setup procedures, and architecture insights for developers contributing to or maintaining the OpenHabitBackend project.

## Prerequisites

Ensure your local development workstation is configured with the following toolchain:
* **.NET SDK:** .NET 10 SDK or higher.
* **IDE/Text Editor:** Visual Studio Code, Visual Studio 2022+, or JetBrains Rider.
* **API Testing Utility:** Postman, cURL, or Thunder Client for testing REST endpoints.

## Local Environment Setup & Execution

1. **Clone and Navigate**
   Clone the repository to your local machine and open your terminal inside the root folder (`OpenHabitBackend`).

2. **Understanding the Data Seeder**
   The application relies on an Entity Framework Core **In-Memory Database**. To prevent the application from starting with an empty state, the initialization pipeline calls `SeedData.Initialize()`, which automatically injects default test records (habits and users) into the runtime memory.

3. **Running the Application**
   Navigate into the execution entry point project directory and run the project:
   ```bash
   cd OpenHabitBackend.Controller
   dotnet run