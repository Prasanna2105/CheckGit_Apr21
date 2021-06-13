create database BooksDb
go

use BooksDb

--Books - BookID, Title, AuthorID, Price
--Author - AuthorID, AuthorName

--create table tbl_author
--(
--AuthorID int identity(1,1) Primary Key,
--AuthorName varchar(20)
--)
--drop table tbl_author

create table tbl_author
(
AuthorID int identity(1,1),
AuthorName varchar(20),
Constraint PK_auth Primary Key (AuthorID)
)

create table tbl_Books
(
BookID int identity(1000,1),
Title varchar(50),
AuthorID int,
Price money,
Constraint PK_book Primary Key (BookID),
Constraint FK_auth Foreign Key (AuthorID)
references tbl_author(AuthorID)
)

select * from tbl_Books
select * from tbl_author

--Insert Book
create proc sp_InsBook
@Title varchar(20),
@AuthorID int,
@Price money
as
begin
insert into tbl_Books(Title,AuthorID,Price)
values(@Title,@AuthorID,@Price)
end

--Update Book
create proc sp_UpdateBook
@BookID int,
@Price money
as 
begin
update tbl_Books set Price = @Price where BookID = @BookID
end

exec sp_UpdateBook 1000,430

--Delete Book
create proc sp_DeleteBook
@BookID int
as 
begin
delete from tbl_Books where BookID = @BookID
end

exec sp_DeleteBook 1008

--Insert Author
create proc sp_InsertAuthor
@AuthorName varchar(20)
as
begin
insert into tbl_author(AuthorName) values(@AuthorName)
end

exec sp_InsertAuthor 'Anton Checkov'

--Update Author
create proc sp_UpdateAuthor
@AuthorID int,
@AuthorName varchar(20)
as
begin
update tbl_author set AuthorName = @AuthorName where AuthorID = @AuthorID
end

exec sp_UpdateAuthor 4,'Robing Singh'

--Delete Author
create proc sp_DeleteAuthor
@AuthorID int
as 
begin
delete from tbl_author where AuthorID = @AuthorID
end

exec sp_DeleteAuthor 4