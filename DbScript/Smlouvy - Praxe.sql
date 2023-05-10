create database dbPraxe
go
use dbPraxe

go

CREATE TABLE tbUser (
  Id int identity(1,1) PRIMARY KEY,
  ContractId int,
  Type varchar(50),
  Login varchar(50),
  Password varchar(50)
);

go
CREATE TABLE tbContract(

  Id int identity(1,1) PRIMARY KEY,
  OrgName varchar(100) default(''),
  Registred varchar(100) default(''),
  Based varchar(100) default(''),
  ICO varchar(50) default(''),
  RepresentedBy varchar(30) default(''),
  StreetANumber varchar(100) default(''),
  City varchar(30) default(''),
  PSC varchar(30) default(''),
  FirstName varchar(50) default(''),
  LastName varchar(50) default(''),
  MobileNumber varchar(20) default(''),
  WorkDescription varchar(2000) default(''),
  WorkStart varchar(50) default(''),
  WorkEnd varchar(50) default(''),
  BreakStart varchar(50) default(''),
  BreakEnd varchar(50) default('')
);

go


create trigger trUserInsert
on tbUser
after insert
as
	begin
		declare @ContractId int
		DECLARE @UserId INT;
		insert into tbContract default values
		update tbUser 
		set ContractId = SCOPE_IDENTITY()
		where Id = (select Id from inserted)
		print 'Funguje to'
	end
go

select * from tbUser


--insert into tbUser(type,login,password) values ('User','Marek','Cena')
--select * from tbUser
--select * from tbContract
--insert into tbContract (Id,OrgName,Registred,Based,ICO,RepresentedBy,StreetANumber,City,PSC,FirstName,SurName,MobileNumber,WorkDescription) values(2,'test','test1','test3','test4','test5','test6','test7','test8','test9','test10','test11','test12')
--insert into tbUser values(2,'test','Cristiano','Ronaldo')
--delete tbContract
--delete tbUser

--select * from tbContract
--select * from tbUser