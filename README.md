# 📚 Campus Library Management System

A desktop-based Library Management System designed to streamline common library operations such as student management, book inventory, book issuing, and returns.

The application is built with **C# Windows Forms** and **Microsoft SQL Server**, following a structured **3-Tier Architecture** consisting of the Presentation, Business Logic, and Data Access layers.

---

## ✨ Features

### 🎨 Modern User Interface

- Clean and modern flat-design interface
- Responsive Windows Forms layout
- Custom-styled controls and dashboard components
- Improved visual experience compared with traditional WinForms interfaces
- Organized navigation for major library operations

### 👨‍🎓 Student Management

Manage student records through complete CRUD operations.

- Add new students
- View student records
- Update student information
- Delete student records
- Store:
  - Student ID
  - Full Name
  - Roll Number
  - Department
  - Phone Number

### 📚 Book Inventory Management

Manage the library's book catalog and availability.

- Add and manage books
- Store book information
- Track total copies
- Track available copies
- Automatically update available inventory when books are issued or returned

### 📤 Book Issuing

The issuing system manages the process of assigning books to students.

- Search/select students
- Select available books
- Verify book availability before issuing
- Record issue information
- Automatically decrease available book copies
- Maintain issue records

### 📥 Book Returns

The return system manages active book loans.

- Search active loans by student Roll Number
- View currently issued books
- Process book returns
- Update loan status
- Automatically restore available book copies

### 🔐 Database Transaction Safety

Important database operations use SQL transactions to maintain data consistency.

For example, when a book is issued, the system can perform the related database operations within a transaction so that inventory and issue records remain synchronized.

---

## 🛠️ Technology Stack

| Category | Technology |
|---|---|
| Language | C# |
| UI Framework | Windows Forms |
| Framework | .NET Framework |
| Database | Microsoft SQL Server |
| Data Access | ADO.NET |
| Architecture | 3-Tier Architecture |
| IDE | Visual Studio |
| Database Management | SQL Server Management Studio (SSMS) |

---

## 🏗️ Architecture

The application follows a **3-Tier Architecture** to separate presentation, business logic, and database operations.

```text
┌─────────────────────────────────────┐
│        Presentation Layer           │
│          C# Windows Forms           │
│                                     │
│  Dashboard / Student / Books /      │
│  Issue / Return Controls             │
└──────────────────┬──────────────────┘
                   │
                   ▼
┌─────────────────────────────────────┐
│       Business Logic Layer          │
│               BLL                   │
│                                     │
│ StudentBLL / IssueBLL / ReturnBLL   │
│ Validation & Business Rules         │
└──────────────────┬──────────────────┘
                   │
                   ▼
┌─────────────────────────────────────┐
│         Data Access Layer           │
│               DAL                   │
│                                     │
│ StudentDAL / IssueDAL / ReturnDAL   │
│        ADO.NET / SQL Queries        │
└──────────────────┬──────────────────┘
                   │
                   ▼
┌─────────────────────────────────────┐
│          SQL Server Database        │
│           CampusLibraryDB           │
└─────────────────────────────────────┘
1. Presentation Layer

The Presentation Layer contains the Windows Forms interface used by librarians and users.

Examples include:

MainDashboard
ManageStudentsControl
IssueBooksControl
Return management interface

Its responsibilities include:

Displaying information
Collecting user input
Handling UI interactions
Presenting operation results
2. Business Logic Layer

The Business Logic Layer acts as the middle layer between the interface and database.

Examples include:

StudentBLL
IssueBLL
ReturnBLL

Its responsibilities include:

Validating input
Applying business rules
Processing operations
Preventing invalid data from being passed directly to the database
3. Data Access Layer

The Data Access Layer handles communication with Microsoft SQL Server.

Examples include:

StudentDAL
IssueDAL
ReturnDAL

The DAL uses ADO.NET components such as:

SqlConnection
SqlCommand
DataTable

Parameterized queries are used for database operations to help protect against SQL injection.

🗄️ Database

The application uses a relational SQL Server database named:

CampusLibraryDB
Main Tables
Students

Stores student information.

Students
├── StudentID
├── FullName
├── RollNumber
├── Department
└── Phone
Books

Stores information about books and their availability.

Books
├── BookID
├── Title
├── Author
├── AvailableCopies
└── Other book information
IssuedBooks

Stores book issue and return information.

IssuedBooks
├── IssueID
├── BookID
├── StudentRollNo
├── IssueDate
└── Status

The tables work together to maintain relationships between students, books, and issued-book records.

🔄 Library Workflow

The main workflow of the system can be represented as:

Student Management
       │
       ▼
Book Management
       │
       ▼
Book Availability Check
       │
       ▼
    Issue Book
       │
       ▼
Update Inventory
       │
       ▼
Active Loan
       │
       ▼
   Return Book
       │
       ▼
Update Inventory

When a book is issued, the system verifies availability before processing the transaction.

When a book is returned, the available copy count is restored.

🔒 Data Integrity

The system uses SQL transactions for operations that require multiple database changes.

For example:

Issue Book
    │
    ├── Create Issue Record
    │
    └── Decrease Available Copies
            │
            ▼
       COMMIT TRAN

If the operation cannot be completed successfully, the transaction can be rolled back to prevent inconsistent database state.

This approach helps keep related database operations synchronized.

📁 Project Structure

A simplified structure of the application is:

Library-Management-System/
│
├── Presentation/
│   ├── MainDashboard
│   ├── ManageStudentsControl
│   ├── IssueBooksControl
│   └── ReturnBooksControl
│
├── BLL/
│   ├── StudentBLL.cs
│   ├── IssueBLL.cs
│   └── ReturnBLL.cs
│
├── DAL/
│   ├── StudentDAL.cs
│   ├── IssueDAL.cs
│   └── ReturnDAL.cs
│
├── Database/
│   └── SQL Scripts
│
└── README.md

The exact folder and file structure may vary depending on the current repository implementation.

🚀 Getting Started
Prerequisites

Before running the application, install:

Visual Studio 2019 or newer
Microsoft SQL Server
SQL Server Management Studio (SSMS)
1. Clone the Repository
git clone https://github.com/mohsin715786/Library-Management-System.git

Navigate into the project directory:

cd Library-Management-System
2. Setup the Database

Open SQL Server Management Studio (SSMS).

Create a database named:

CampusLibraryDB

Then execute the SQL scripts provided in the repository's database section/folder to create the required tables.

The database should contain the required tables for:

Students
Books
IssuedBooks
3. Configure the Database Connection

Open the project in Visual Studio.

Locate the Data Access Layer files and update the SQL Server connection string according to your local SQL Server instance.

Example:

private string connectionString =
    "Data Source=YOUR_SERVER_NAME;Initial Catalog=CampusLibraryDB;Integrated Security=True";

Replace:

YOUR_SERVER_NAME

with your SQL Server instance name.

For example:

DESKTOP-ABC123\SQLEXPRESS

if you are using SQL Server Express.

4. Build the Project

Open the solution in Visual Studio.

Then:

Restore/build the project.
Make sure the database is running.
Verify the connection string.
Press F5 or select Start.

The Library Management System should launch as a Windows desktop application.
🧪 Core Operations

The application currently focuses on the following core operations:

Operation	Description
Student Management	Create, view, update and delete student records
Book Management	Manage books and inventory
Issue Books	Assign available books to students
Return Books	Process active book returns
Inventory Tracking	Maintain available book copies
Database Transactions	Maintain consistency across related operations
🎯 Project Goals

The project was developed to demonstrate practical software development concepts including:

Object-oriented programming with C#
Windows Forms application development
3-Tier software architecture
Database design
SQL Server integration
ADO.NET data access
CRUD operations
Business logic separation
Database transactions
Input validation
Maintainable application structure
🔮 Future Improvements

Potential improvements for future versions include:

Authentication and role-based access
Librarian/admin accounts
Book search and advanced filtering
Due dates and overdue tracking
Fine calculation
Dashboard analytics
Book reservation functionality
Improved reporting
Exportable library reports
Automated database backup
🤝 Contributing

Contributions, issues, and feature requests are welcome.

If you would like to contribute:

Fork the repository
Create a new branch
Make your changes
Commit your changes
Push the branch
Open a Pull Request
📝 License

This project is licensed under the MIT License.

👨‍💻 Author

Muhammad Mohsin Ghafoor

Computer Science Undergraduate | Flutter Developer

Connect
GitHub: mohsin715786
LinkedIn: Muhammad Mohsin Ghafoor
Portfolio: mohsin-zeta.vercel.app
⭐ Support

If you find this project useful or interesting, consider giving the repository a ⭐ on GitHub.


### One important thing before you publish it

I intentionally used **“Potential improvements”** rather than presenting those future features as existing functionality. I also marked the screenshot paths as placeholders. That keeps the README credible.

For your portfolio, I would position the projects like this:

**1. Peer-Link** → strongest/flagship Flutter project  
**2. Campus Library Management System** → strongest C# + SQL Server + architecture project  
**3. Expense Tracker** → supporting Flutter project  
**4. BMI Calculator / Todo** → learning projects

That gives recruiters evidence that you can work with **both modern Flutter development and traditional software engineering/database architecture**, without making your profile look unfocused.
