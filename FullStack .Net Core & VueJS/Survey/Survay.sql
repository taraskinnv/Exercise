--create database Hospital;

use survey;


--create table Users
--(
--	id int primary key identity,
--	email nvarchar(max),
--	password_email nvarchar(max),
--)

--create table Question
--(
--	id int primary key identity,
--	question nvarchar(max) not null,
--	id_Users int references Users(id),
--	addAnswer TINYINT default 0,
--	createDate datetime2 DEFAULT GETDATE(),
--	expiresOn datetime2 DEFAULT GETDATE(),
--	isCompleted bit default 0,
--	isHidden bit default 0
--)

--create table Answer_options
--(
--	id int primary key identity,
--	answer nvarchar(max),
--	id_Question int references Question(id)
--)

--create table Answer
--(
--	id int primary key identity,
--	id_Answer_options int references Answer_options(id),
--	id_Users int references Users(id),
--)

