create database dbPraxe
go
use dbPraxe


CREATE TABLE tbUser (
  Id int identity(1,1) PRIMARY KEY,
  ContractId int,
  Type varchar(50),
  Login varchar(50) unique,
  Password varchar(50),
  Name varchar(50),
  LastName varchar(50)
);

go
CREATE TABLE tbContract(

  Id int identity(1,1) PRIMARY KEY,
  OrgName varchar(100) default null,
  Registred varchar(100) default null,
  Based varchar(100) default null,
  ICO varchar(50) default null,
  RepresentedBy varchar(30) default null,
  StreetANumber varchar(100) default null,
  City varchar(30) default null,
  PSC varchar(30) default null,
  FirstName varchar(50) default null,
  LastName varchar(50) default null,
  MobileNumber varchar(20) default null,
  WorkDescription varchar(2000) default null,
  WorkStart varchar(30) default null,
  WorkEnd varchar(30) default null,
  BreakStart varchar(30) default null,
  BreakEnd varchar(30) default null,
  LastChanged datetime default null
)

go

create trigger trUserInsert
on tbUser
after insert
as
	begin
		declare @type varchar(50)
		set @type = (select Type from inserted)
		if(@type = 'User')
			begin
				declare @ContractId int
				DECLARE @UserId INT;
				insert into tbContract default values
				update tbUser 
				set ContractId = SCOPE_IDENTITY()
				where Id = (select Id from inserted)
				print 'Funguje to'
			end
	end
go

--insert into tbUser(type,login,password) values ('User','Marek','Cena')
--select * from tbUser
--select * from tbContract
--insert into tbContract (Id,OrgName,Registred,Based,ICO,RepresentedBy,StreetANumber,City,PSC,FirstName,SurName,MobileNumber,WorkDescription) values(2,'test','test1','test3','test4','test5','test6','test7','test8','test9','test10','test11','test12')
--insert into tbUser values(2,'test','Cristiano','Ronaldo')
--delete tbContract
--delete tbUser

--select * from tbContract
--select * from tbUser