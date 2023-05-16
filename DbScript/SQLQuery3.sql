use dbPraxe
go
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Prase','jaros','Prase','pig')
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Osel','jaros','Osel','Jaros')
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Tygr','jaros','Tygr','Jaros')
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Mama','jaros','Mama','Jaros')
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Tata','jaros','Tata','Jaros')
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Deda','jaros','Deda','Jaros')
insert into tbUser(Type,Login,Password,Name,LastName) values('User','Strejda','jaros','Strejda','Jaros')
insert into tbUser(Type,Login,Password,Name,LastName) values('Administrator','John','cena','Prase','pig')
select * from tbContract
select * from dbo.tbUser
select * from applications

delete tbContract
delete tbUser

use master
go
drop database dbPraxe
