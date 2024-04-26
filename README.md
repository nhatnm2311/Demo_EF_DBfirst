# Demo_EF_DBfirst
# Tạo Database và kết nối
create database QLSV
go
use QLSV
go
create table SinhVien (
SV_ID int not null primary key identity,
SV_Name nvarchar(30) not null,
SV_Phone varchar(11) not null,
SV_Email varchar(30) not null
)
