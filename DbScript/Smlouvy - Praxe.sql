create database dbPraxe
go
use dbPraxe
go


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
  OrgName varchar(100) default(''),
  Registred varchar(100) default (''),
  Based varchar(100) default (''),
  ICO varchar(50) default (''),
  RepresentedBy varchar(30) default (''),
  StreetANumber varchar(100) default (''),
  City varchar(30) default (''),
  PSC varchar(30) default (''),
  RepresentedFirstName varchar(50) default (''),
  RepresentedLastName varchar(50) default (''),
  MobileNumber varchar(20) default (''),
  WorkDescription varchar(2000) default (''),
  WorkStart varchar(30) default (''),
  WorkEnd varchar(30) default (''),
  BreakStart varchar(30) default (''),
  BreakEnd varchar(30) default (''),
  LastChanged datetime default null
)
go
ALTER TABLE tbUser ADD FOREIGN KEY (ContractId) REFERENCES tbContract (Id);
go
create trigger trUserInsert
on tbUser
after insert
as
	begin
		--declare @type varchar(50)
		--set @type = (select Type from inserted)
		--if(@type = 'User')
		--	begin
		--		insert into tbContract default values
		--		update tbContract 
		--		set UserId = (select Id from inserted)
		--		where Id = SCOPE_IDENTITY()
		--		print 'Funguje to'
		--	end
		INSERT INTO tbContract (tbUserId)
		SELECT Id
		FROM inserted
		WHERE Type = 'User';
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