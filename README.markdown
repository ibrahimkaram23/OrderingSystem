# Ordering System

## Overview
The Ordering System is a robust web application built using .NET Core, designed to manage orders efficiently. It implements modern architectural patterns and best practices to ensure scalability, maintainability, and performance. The system supports features like CQRS, Generic Repository, Pagination, Localization, Fluent Validations, and comprehensive configuration options.

## Features
1. **CQRS Design Pattern**: Separates read and write operations to optimize performance and scalability. Commands handle create/update/delete operations, while Queries manage data retrieval.
2. **Generic Repository Design Pattern**: Provides a reusable data access layer, reducing code duplication and simplifying CRUD operations across entities.
3. **Pagination Schema**: Implements server-side pagination to efficiently handle large datasets, improving response times and user experience.
4. **Localizations of Data and Responses**: Supports multiple languages for data and API responses, enabling a global user base.
5. **Fluent Validations**: Uses FluentValidation for robust input validation, ensuring data integrity and providing meaningful error messages.
6. **Configurations Using Data Annotations**: Leverages Data Annotations for entity validation and database schema configuration.
7. **Configurations Using Fluent API**: Utilizes Entity Framework's Fluent API for precise control over entity relationships and database mappings.
8. **EndPoints of Operations**: Exposes RESTful API endpoints for managing orders, including CRUD operations and additional functionalities.
9. **Allow CORS**: Configured to allow Cross-Origin Resource Sharing, enabling secure access from different domains.
10. **Unit Testing**: Includes a comprehensive suite of unit tests using frameworks like xUnit or NUnit to ensure code reliability.

## Technologies
- **Backend**: .NET Core (C#)
- **Database**: Entity Framework Core (SQL Server or other compatible databases)
- **Validation**: FluentValidation
- **Testing**: xUnit/NUnit, Moq
- **API**: ASP.NET Core Web API
- **Localization**: ASP.NET Core Localization Middleware

## Prerequisites
- .NET Core SDK (version 6.0 or later)
- SQL Server (or another compatible database)
- IDE (Visual Studio, VS Code, or Rider)
- Git

## Setup Instructions
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/ibrahimkaram23/OrderingSystem.git
   cd OrderingSystem
   ```

2. **Configure the Database**:
   - Update the connection string in `appsettings.json` to point to your SQL Server instance.
   - Run migrations to set up the database:
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

3. **Install Dependencies**:
   - Restore NuGet packages:
     ```bash
     dotnet restore
     ```

4. **Run the Application**:
   - Start the API:
     ```bash
     dotnet run --project OrderingSystem.Api
     ```
   - The API will be available at `https://localhost:5001` (or the configured port).

5. **Run Unit Tests**:
   - Execute the test suite:
     ```bash
     dotnet test
     ```

## API Endpoints
Below are some key endpoints (base URL: `https://localhost:5001/api`):
- **GET /orders/{id}**: Retrieve a specific order by ID.
- **POST /orders/CreateOrder**: Create a new order.
- **PUT /orders/UpdateStatus**: Update an existing order.

For detailed endpoint documentation, refer to the Swagger UI at `https://localhost:5001/swagger`.

## Configuration
- **CORS**: Configured in `Startup.cs` or `Program.cs` to allow specific origins. Update the allowed origins in `appsettings.json` or code as needed.
- **Localization**: Supports multiple cultures (e.g., en-US, ar-SA). Configure supported cultures in the localization middleware.
- **Fluent API Configurations**: Entity mappings are defined in the `DbContext` using Fluent API for precise control.
- **Data Annotations**: Applied to entity models for validation and schema definition.

## Running Tests
The project includes unit tests for core functionalities:
- Tests for CQRS handlers (commands and queries).
- Tests for repository methods.
- Tests for validation rules using FluentValidation.
- Run tests using:
  ```bash
  dotnet test
  ```

## Contributing
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -m "Add your feature"`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Open a Pull Request.

## Contact
For questions or feedback, please contact [ebrahem.karm23@gmail.com] or open an issue on GitHub.