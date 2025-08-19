# 📝 Blog Website (ASP.NET Core MVC + C#)

A **full-stack beginner-friendly blog platform** built with **ASP.NET Core MVC, C#, and Entity Framework Core**.
This project demonstrates **CRUD operations, authentication, authorization, and role-based access control** with a real-world blog system.

---

## 🚀 Tech Stack

* **Frontend:** ASP.NET Core MVC (Razor Views, Bootstrap)
* **Backend:** C# (Controllers, Models, Services)
* **Database:** SQL Server / SQLite (Entity Framework Core)
* **Authentication:** ASP.NET Identity (Role-based)
* **Hosting (optional):** Azure App Service / Render

---

## ✨ Features

### 🔐 User Management

* User registration & login with **ASP.NET Identity**
* Role-based access:

  * **Admin:** Manage users, approve blogs
  * **User:** Create, edit, and delete own blogs

### 📰 Blog Management

* Create blog posts (title, content, image, tags)
* Edit / Delete posts
* Blog feed (list of all blogs)
* Blog details page with comments and likes

### 📊 Dashboards

* User dashboard → View and manage own blogs
* Admin dashboard → View/manage all blogs and users

### 🔍 Search & Filters

* Search blogs by title/content
* Filter by category or tags

---

## 📂 Database Design

| Table        | Columns                                                               |
| ------------ | --------------------------------------------------------------------- |
| **Users**    | Id, Username, Email, PasswordHash, Role                               |
| **Blogs**    | BlogId, Title, Content, ImageUrl, CreatedAt, AuthorId (FK → Users.Id) |
| **Comments** | CommentId, BlogId (FK), UserId (FK), Text, CreatedAt                  |
| **Likes**    | LikeId, BlogId (FK), UserId (FK)                                      |

---

## 🏗️ Project Structure

```
BlogWebsite/
 ├── Controllers/
 │    ├── HomeController.cs
 │    ├── BlogController.cs
 │    ├── AccountController.cs
 │    └── AdminController.cs
 │
 ├── Models/
 │    ├── Blog.cs
 │    ├── Comment.cs
 │    ├── Like.cs
 │    └── ApplicationUser.cs
 │
 ├── Views/
 │    ├── Home/ (Index.cshtml, About.cshtml)
 │    ├── Blog/ (Create.cshtml, Edit.cshtml, Details.cshtml, List.cshtml)
 │    ├── Account/ (Login.cshtml, Register.cshtml)
 │    └── Shared/ (_Layout.cshtml, _Navbar.cshtml)
 │
 ├── Data/
 │    └── ApplicationDbContext.cs
 │
 ├── wwwroot/ (Static files: CSS, JS, Images)
 │
 ├── Program.cs
 └── BlogWebsite.csproj
```

---

## ⚙️ Setup & Installation

### 1️⃣ Clone the repository

```bash
git clone https://github.com/mustaque01/BlogWebsite.git
cd BlogWebsite
```

### 2️⃣ Install dependencies

```bash
dotnet restore
```

### 3️⃣ Configure Database

* Update `appsettings.json` with your SQL Server or SQLite connection string.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BlogWebsiteDb;Trusted_Connection=True;"
}
```

### 4️⃣ Run Migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 5️⃣ Run the Project

```bash
dotnet run
```

Open in browser:
👉 `https://localhost:5001`
👉 `http://localhost:5000`

---

## 📸 Screenshots (Optional)

*Add some screenshots of your app UI here (Home page, Login, Blog List, etc.).*

---

## 🔮 Future Enhancements

* Add user profile page with bio + avatar
* Rich text editor for blog content (TinyMCE/CKEditor)
* Image upload with cloud storage
* Blog categories & tags
* Deploy to Azure / Render with custom domain

---

## 🤝 Contributing

Contributions are welcome!
Feel free to **fork this repo** and submit a pull request with improvements.

---

## 📜 License

This project is licensed under the **MIT License**.

---

**💡 I am building this project to practice ASP.NET Core MVC, Entity Framework, and to gain hands-on experience in real-world full-stack development.**


