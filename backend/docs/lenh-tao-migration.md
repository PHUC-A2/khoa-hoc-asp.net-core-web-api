B1: Lệnh tạo migration
Add-Migration TenMigration
Add-Migration CreateSMT_CauTrucDe_ThanhPhan

B2: Update-Database


=========================
1️⃣ Tạo Migration đầu tiên

Khi tạo model/table mới.

Add-Migration InitialCreate

👉 EF tạo file migration trong thư mục Migrations.

2️⃣ Tạo Database từ Migration

Áp dụng migration vào database.

Update-Database

👉 EF sẽ:

tạo database

tạo table

tạo index

tạo relationship

3️⃣ Khi chỉnh sửa Model

Ví dụ:

thêm column

đổi kiểu dữ liệu

thêm relationship

thêm precision decimal

Ta tạo migration mới:

Add-Migration TenMigration

Ví dụ bạn đã dùng:

Add-Migration TestConnection
Add-Migration CreateSMT_CauTrucDeTable
Add-Migration CreateSMT_CauTrucDe_ThanhPhan
Add-Migration CreateSMT_CauTrucDe_ThanhPhan_Sub
Add-Migration AddRelationshipCauTrucDe
Add-Migration FixDecimalPrecision
4️⃣ Cập nhật Database sau khi có Migration mới
Update-Database

👉 EF sẽ chạy migration mới.

5️⃣ Xóa Migration nếu tạo nhầm
Remove-Migration

⚠️ Chỉ dùng khi chưa Update-Database

6️⃣ Xóa Database (reset lại từ đầu)
Drop-Database

Sau đó tạo lại:

Update-Database
7️⃣ Quy trình chuẩn khi code

Thông thường workflow sẽ như này:

1. Sửa Model
2. Add-Migration TenMigration
3. Update-Database

Ví dụ thực tế:

Add-Migration AddRelationshipCauTrucDe
Update-Database
8️⃣ Các lệnh EF Core quan trọng cần nhớ
Lệnh	Ý nghĩa
Add-Migration	tạo migration mới
Update-Database	áp dụng migration vào database
Remove-Migration	xóa migration vừa tạo
Drop-Database	xóa database
Script-Migration	xuất SQL migration
Get-Migration	xem danh sách migration
9️⃣ Ví dụ chuỗi lệnh bạn đã chạy

Thực tế trong log của bạn:

Add-Migration AddRelationshipCauTrucDe
Update-Database

Drop-Database
Update-Database

Add-Migration FixDecimalPrecision
Update-Database
🔟 Cấu trúc Database hiện tại của bạn

Sau khi chạy xong migration:

Users
SMT_CauTrucDes
SMT_CauTrucDe_ThanhPhans
SMT_CauTrucDe_ThanhPhan_Subs

Quan hệ:

CauTrucDe
   └── ThanhPhan
           └── Sub
🚀 Mình khuyên bạn thêm 1 lệnh rất hữu ích

Xem danh sách migration:

Get-Migration

==================

Lưu ý: Sau khi định nghĩa quan hệ (relationship) trong model
Cần run:
Add-Migration RefactorEntityMapping
Update-Database

== hoặc cách an toàn không mất dữ liệu:
Drop-Database
Update-Database

=========================
Xóa Migration để tạo lại từ đầu:
Drop-Database

========================
B1: run lệnh sau để tạo lại migration từ đầu:
Add-Migration InitialCreate
B2: Update-Database