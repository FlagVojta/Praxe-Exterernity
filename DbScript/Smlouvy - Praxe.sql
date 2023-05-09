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
  OrgName varchar(100),
  Registred varchar(100),
  Based varchar(100),
  ICO varchar(50),
  RepresentedBy varchar(30),
  StreetANumber varchar(100),
  City varchar(30),
  PSC varchar(30),
  FirstName varchar(50),
  SurName varchar(50),
  MobileNumber varchar(20),
  WorkDescription varchar(2000),
  WorkStart datetime,
  WorkEnd datetime,
  BreakStart datetime,
  BreakEnd datetime
);



alter table tbUser add Foreign key (ContractId) references tbContract(Id);

insert into tbContract (id) values(1)
insert into tbUser values(1,'test','Marek','Sui')

select * from tbContract