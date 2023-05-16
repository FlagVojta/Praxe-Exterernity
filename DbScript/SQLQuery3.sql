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
Update dbo.tbContract set OrgName = '{contract.OrgName}',Registred = '{contract.Registred}', Based = '{contract.Based}', ICO = '{contract.ICO}', RepresentedBy = '{contract.RepresentedBy}', StreetANumber = '{contract.StreetANumber}', City = '{contract.City}', PSC = '{contract.PSC}', RepresentedFirstName = '{contract.RepresentedFirstName}', RepresentedLastName = '{contract.RepresentedLastName}',MobileNumber = '{contract.MobileNumber}', WorkDescription = '{contract.WorkDescription}', WorkStart = '{contract.WorkStart}', WorkEnd = '{contract.WorkEnd}', BreakStart = '{contract.BreakStart}', BreakEnd = '{contract.BreakEnd}', LastChanged = '{contract.LastChanged}'  where Id = 27
select * from tbContract
select * from dbo.tbUser

delete tbContract
delete tbUser

use master
go
drop database dbPraxe
