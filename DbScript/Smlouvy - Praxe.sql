create database dbPraxe
go
use dbPraxe

go

CREATE TABLE tbUser (
  Id int identity PRIMARY KEY,
  ContractId int,
  type varchar(50),
  login varchar(50),
  password varchar(50)
);

go

CREATE TABLE tbContract(
  Id int PRIMARY KEY,
  OrgName varchar(100) default(''),
  Registred varchar(100) default(''),
  Based varchar(100) default(''),
  ICO varchar(50) default(''),
  RepresentedBy varchar(30) default(''),
  StreetANumber varchar(100) default(''),
  City varchar(30) default(''),
  PSC varchar(30) default(''),
  FirstName varchar(50) default(''),
  SurName varchar(50) default(''),
  MobileNumber varchar(20) default(''),
  WorkDescription varchar(2000) default(''),
  WorkStart datetime,
  WorkEnd datetime,
  BreakStart datetime,
  BreakEnd datetime
);



alter table tbUser add Foreign key (ContractId) references tbContract(Id);


--insert into tbUser values(1,'test','Marek','Sui')

--select * from tbContract