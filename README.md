# Blog System with Role-based Authentication

## 📌 Project Overview
The **Blog System** is a web application that allows users to create, manage, and comment on blog posts. It includes role-based authentication, supporting **Admins, Editors, and Readers**, each with specific permissions.

## 🚀 Features
- **User Authentication & Role Management** (Admin, Editor, Reader)
- **Blog Post Management** (Create, Edit, Delete posts)
- **Commenting System** (Readers can comment; Admins can moderate)
- **Role-based Authorization** (RBAC with ASP.NET Core Identity)
- **RESTful API** (CRUD operations for posts and comments)
- **Search & Filtering** (By tags, categories, status)

## 🛠️ Technologies Used
- **.NET 8** (ASP.NET Core Web API & MVC)
- **Entity Framework Core** (EF Core for database interaction)
- **ASP.NET Core Identity** (User authentication & authorization)
- **SQL Server** (Database for storing blog posts, users, and comments)

## 📂 Project Structure
```
📦 BlogSystem
 ┣ 📂 Application (Business Logic Layer)
 ┣ 📂 Domain (Entities & Interfaces)
 ┣ 📂 Infrastructure (Repositories & Database Context)
 ┣ 📂 API (Controllers & Endpoints)
 ┣ 📂 UI (MVC Views & Components)
 ┣ 📜 README.md (Project Documentation)
```

## ⚙️ Installation & Setup
### 1️⃣ Clone the Repository
```sh
git clone https://github.com/yourusername/BlogSystem.git
cd BlogSystem
```

### 2️⃣ Configure Database
- Update the connection string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BlogDB;Trusted_Connection=True;"
}
```

- Run EF Core Migrations:
```sh
dotnet ef database update
```

### 3️⃣ Run the Application
```sh
dotnet run
```
The API will be available at `http://localhost:5000/api/`

## 🔗 API Endpoints
### Authentication
- **Register:** `POST /api/auth/register`
- **Login:** `POST /api/auth/login`

### Blog Posts
- **Get All Posts:** `GET /api/posts`
- **Get Post by ID:** `GET /api/posts/{id}`
- **Create Post:** `POST /api/posts` _(Admin, Editor)_
- **Update Post:** `PUT /api/posts/{id}` _(Admin, Editor)_
- **Delete Post:** `DELETE /api/posts/{id}` _(Admin)_

### Comments
- **Add Comment:** `POST /api/comments`
- **Get Comments for Post:** `GET /api/comments/{postId}`

## 🔒 Role-based Access
| Role  | Actions |
|--------|------------------------|
| **Admin** | Manage users, posts, comments |
| **Editor** | Create & edit posts |
| **Reader** | Read posts & add comments |

