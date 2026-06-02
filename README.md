Here is a complete, professional `README.md` file tailored exactly to the architecture, features, and modern UI we just built for your project.

You can copy this directly and paste it into your GitHub repository!

---

# 📚 Campus Library Management System

A sleek, responsive, and robust desktop application built to streamline library operations for educational institutions. Developed using **C# Windows Forms** and **Microsoft SQL Server**, this project utilizes a clean **3-Tier Architecture** (Presentation, Business Logic, and Data Access Layers) to ensure maintainable, secure, and efficient code.

## ✨ Features

* **Modern & Responsive UI:** Custom-styled, flat-design interface with responsive elements that stretch and adapt perfectly to different screen sizes. Replaced legacy 3D WinForms styling with a clean, web-inspired aesthetic.
* **Student Management:** Full CRUD (Create, Read, Update, Delete) functionality for student records. Tracks Roll Number, Full Name, Department, and Phone Number.
* **Book Inventory:** Complete management of the library's catalog, automatically tracking total and available copies.
* **Issue Processing:** Secure transaction handling that verifies available stock before assigning a book to a student, instantly updating the inventory count.
* **Return Processing:** Dynamic active-loan dashboard that allows librarians to search by student Roll Number, view currently issued books, process returns, and automatically restore stock levels.
* **SQL Transaction Safety:** Uses `BEGIN TRAN` and `COMMIT TRAN` at the database level to ensure data integrity during complex actions (like issuing a book and updating stock simultaneously).

## 🛠️ Technology Stack

* **Frontend:** C# Windows Forms (.NET Framework)
* **Backend:** C# (Custom BLL and DAL layers)
* **Database:** Microsoft SQL Server
* **Data Access:** ADO.NET (SqlConnections, SqlCommands, DataTables)

## 🏗️ Architecture

This project strictly adheres to a 3-Tier Architecture pattern:

1. **Presentation Layer (UI):** Contains the forms and user controls (e.g., `MainDashboard`, `ManageStudentsControl`, `IssueBooksControl`). Handles data visualization and captures user input.
2. **Business Logic Layer (BLL):** The "Middleman." Validates user input, processes business rules, and prevents invalid data from reaching the database (e.g., `StudentBLL`, `IssueBLL`, `ReturnBLL`).
3. **Data Access Layer (DAL):** The "Pipeline." Handles all direct communication with SQL Server using parameterized queries to prevent SQL injection (e.g., `StudentDAL`, `IssueDAL`, `ReturnDAL`).

## 🗄️ Database Schema (CampusLibraryDB)

The core database relies on relational tables linked by constraints:

* `Students` (StudentID, FullName, RollNumber, Department, Phone)
* `Books` (BookID, Title, Author, AvailableCopies, etc.)
* `IssuedBooks` (IssueID, BookID, StudentRollNo, IssueDate, Status)

## 🚀 Getting Started

### Prerequisites

* Visual Studio 2019 or newer
* Microsoft SQL Server Management Studio (SSMS)

### Installation & Setup

1. **Clone the repository:**
```bash
git clone https://github.com/yourusername/CampusLibraryManagement.git

```


2. **Setup the Database:**
* Open SSMS and create a new database named `CampusLibraryDB`.
* Run the provided SQL scripts in the `/Database` folder to generate the `Students`, `Books`, and `IssuedBooks` tables.


3. **Configure the Connection String:**
* Open the project in Visual Studio.
* Navigate to the `DAL` folder (e.g., `StudentDAL.cs`, `IssueDAL.cs`, `ReturnDAL.cs`).
* Update the `connectionString` variable in each file to match your local SQL Server instance name:
```csharp
private string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=CampusLibraryDB;Integrated Security=True";

```




4. **Build and Run:**
* Press `F5` in Visual Studio to build the solution and launch the application.



## 🤝 Contributing

Contributions, issues, and feature requests are welcome! Feel free to check the issues page.

## 📝 License

This project is licensed under the MIT License.
