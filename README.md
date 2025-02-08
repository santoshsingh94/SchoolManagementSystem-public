# 📚 School Management System

## 🏫 Overview
The **School Management System** is a web-based application developed using **.NET 6, Razor Pages, jQuery, and Entity Framework Core**. It provides an efficient way to manage students, teachers, classes, and other school-related operations.

## 🚀 Features
- **Student Management**: Add, update, and track student details.
- **Teacher Management**: Manage faculty members, subjects, and schedules.
- **Class Scheduling**: Assign students and teachers to specific classes.
- **User Authentication**: Secure login/logout system using **ASP.NET Identity**.
- **Database Integration**: Uses **SQL Server** with **EF Core** for data management.
- **Interactive UI**: Implemented using **Razor Pages**, **jQuery**, and **JavaScript**.
- **LINQ Queries**: Efficient data retrieval and manipulation.

## 🏗️ Tech Stack
- **Backend**: .NET 6, ASP.NET Core Razor Pages
- **Frontend**: HTML, CSS, Bootstrap, JavaScript, jQuery
- **Database**: Microsoft SQL Server, EF Core
- **Authentication**: ASP.NET Identity

## 🔧 Installation & Setup
Follow these steps to run the project locally.

### **1️⃣ Clone the repository**  
   ```sh
   git clone https://github.com/SantoshSingh1312/SchoolManagementSystem-public.git
   cd SchoolManagementSystem-public
   ```

### **2️⃣ Set up the Connection String**
    "ConnectionStrings": {
      "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=SchoolManagementDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    }

### 3️⃣ Apply Database Migrations
    dotnet ef database update
### 4️⃣ Run the Application
    dotnet run
    Once the application starts, open your browser and visit:
    http://localhost:5000

