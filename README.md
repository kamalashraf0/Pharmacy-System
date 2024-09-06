# Pharmacy Management System

## Overview
This project is a comprehensive Pharmacy Management System built using ASP.NET Core 8 and MVC architecture. It leverages the Repository Pattern and Services Pattern to ensure a clean separation of concerns and maintainable code. The system includes features such as sessions and cookies for state management, CRUD operations, filters and custom filters, ViewModel, view components, Bootstrap for responsive design, AJAX and jQuery for dynamic content updates, and Identity Claims and Roles for robust authentication and authorization.

## Features
- **ASP.NET Core 8**: Utilizes the latest version of ASP.NET Core for building modern web applications.
- **MVC Architecture**: Implements the Model-View-Controller pattern for a clean separation of concerns.
- **Repository Pattern**: Abstracts data access logic to promote a more maintainable and testable codebase.
- **Services Pattern**: Encapsulates business logic within services to enhance code reusability.
- **Sessions and Cookies**: Manages user sessions and cookies for state persistence.
- **CRUD Operations**: Supports Create, Read, Update, and Delete operations for managing pharmacy data.
- **Filters and Custom Filters**: Implements filters for cross-cutting concerns such as logging and error handling.
- **ViewModel**: Uses ViewModel to pass data between controllers and views.
- **View Components**: Reusable components for rendering parts of the UI.
- **Bootstrap**: Ensures responsive design and a modern look and feel.
- **AJAX and jQuery**: Enhances user experience with dynamic content updates.
- **Identity Claims and Roles**: Provides robust authentication and authorization mechanisms.

## Getting Started

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022
- SQL Server

### Installation
1. Clone the repository:
    ```bash
    git clone https://github.com/yourusername/pharmacy-management-system.git
    ```
2. Navigate to the project directory:
    ```bash
    cd pharmacy-management-system
    ```
3. Restore the dependencies:
    ```bash
    dotnet restore
    ```
4. Update the database connection string in `appsettings.json`.

### Usage
1. Run the application:
    ```bash
    dotnet run
    ```
2. Open your browser and navigate to `https://localhost:5001`.

## Project Structure
- **Controllers**: Handles incoming HTTP requests and returns responses.
- **Models**: Represents the data and business logic.
- **Views**: Defines the UI using Razor syntax.
- **Repositories**: Contains data access logic.
- **Services**: Encapsulates business logic.
- **ViewModels**: Passes data between controllers and views.
- **wwwroot**: Contains static files such as CSS, JavaScript, and images.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Acknowledgements
- ASP.NET Core Documentation
- Bootstrap Documentation
- jQuery Documentation

