# TÀI LIỆU NHANH – KẾT NỐI DATABASE (SQL SERVER)

> Mục tiêu: **Xác nhận kết nối DB thành công trước khi viết CRUD**
>
> Áp dụng cho: **ASP.NET Core Web API + Entity Framework Core**

---

## 1️⃣ Tạo project

* Visual Studio → **Create a new project**
* Chọn **ASP.NET Core Web API**
* .NET: **.NET 8 / .NET 9 / .NET 10** (đều OK)
* Authentication: **None**
* HTTPS: ✔️ bật

---

## 2️⃣ Cài các package bắt buộc

Mở:

```
Tools → NuGet Package Manager → Package Manager Console
```

Chạy lệnh:

```powershell
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.Tools
```

---

## 3️⃣ Cấu hình Connection String

### 📄 File: `appsettings.json`

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=testdb;Trusted_Connection=True;TrustServerCertificate=True"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

📌 Ghi chú:

* `testdb` **không cần tạo trước**
* EF Core sẽ tự tạo database khi cần

---

## 4️⃣ Tạo DbContext (bắt buộc)

### 📁 Folder: `Data`

### 📄 File: `ApplicationDbContext.cs`

```csharp
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
```

⚠️ Lưu ý quan trọng:

* **BẮT BUỘC dùng** `DbContextOptions<ApplicationDbContext>`
* Không cần `DbSet` ở bước này (chỉ test kết nối)

---

## 5️⃣ Đăng ký DbContext

### 📄 File: `Program.cs`

Thêm các dòng sau:

```csharp
using backend.Data;
using Microsoft.EntityFrameworkCore;

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);
```

📌 Nếu thiếu bước này → EF Core **KHÔNG tìm thấy DbContext**

---

## 6️⃣ Kiểm tra kết nối Database (QUAN TRỌNG NHẤT)

### ✅ Cách chuẩn & nhanh nhất

Trong **Package Manager Console**:

```powershell
Add-Migration TestConnection
```

### ✔️ Kết quả mong đợi:

* Build succeeded
* Không báo lỗi
* Xuất hiện folder `Migrations`

👉 **KẾT LUẬN: Database kết nối thành công**

=== nếu đổi DB
B1 đổi tên migration:
dotnet ef migrations add InitStructureModule
dotnet ef database update

---

## 7️⃣ (Tùy chọn) Tạo database thật trong SQL Server

```powershell
Update-Database
```

Kết quả:

* EF Core tự tạo database `testdb`
* Tạo bảng `__EFMigrationsHistory`

📌 Không cần tạo DB thủ công trong SSMS

---

## 8️⃣ Các lỗi thường gặp & cách nhận biết nhanh

### ❌ Lỗi: `No DbContext was found`

👉 Chưa tạo DbContext hoặc constructor sai generic

---

### ❌ App chạy nhưng DB chưa chắc kết nối

👉 Bình thường – vì EF chỉ kết nối khi **Migration / Query**

---

## 9️⃣ Ghi nhớ nhanh (Checklist)

* [x] Cài EF Core SqlServer
* [x] Có ConnectionString
* [x] Có DbContext đúng chuẩn
* [x] Đăng ký DbContext trong Program.cs
* [x] `Add-Migration` chạy không lỗi

👉 **Đến đây mới bắt đầu viết CRUD**

---

## 🎯 Kết luận

> Nếu `Add-Migration` chạy được → **DB đã kết nối OK**

> Không cần tạo database trước trong SQL Server

> Không nên viết CRUD khi chưa qua bước này

---

📌 Tài liệu dùng để:

* Ôn nhanh
* Làm lại project mới
* Áp dụng cho mọi Web API sau này
