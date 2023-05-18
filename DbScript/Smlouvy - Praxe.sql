--create database dbPraxe
--go
--use dbPraxe
--go


--CREATE TABLE tbUser (
--  Id int identity(1,1) PRIMARY KEY,
--  ContractId int,
--  Type varchar(50),
--  Login varchar(50) unique,
--  Password varchar(50),
--  Name varchar(50),
--  LastName varchar(50)
--);

--go
--CREATE TABLE tbContract(

--  Id int identity(1,1) PRIMARY KEY,
--  OrgName varchar(100) default(''),
--  Registred varchar(100) default (''),
--  Based varchar(100) default (''),
--  ICO varchar(50) default (''),
--  RepresentedBy varchar(30) default (''),
--  StreetANumber varchar(100) default (''),
--  City varchar(30) default (''),
--  PSC varchar(30) default (''),
--  RepresentedFirstName varchar(50) default (''),
--  RepresentedLastName varchar(50) default (''),
--  MobileNumber varchar(20) default (''),
--  WorkDescription varchar(2000) default (''),
--  WorkStart varchar(30) default (''),
--  WorkEnd varchar(30) default (''),
--  BreakStart varchar(30) default (''),
--  BreakEnd varchar(30) default (''),
--  LastChanged datetime default null
--)
--go
--ALTER TABLE tbUser ADD FOREIGN KEY (ContractId) REFERENCES tbContract (Id);
--go
drop trigger trUserInsert
drop trigger trRecordInsert
drop procedure InsertworkDays

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
		WHERE Type = 'User'

		INSERT INTO applications (tbUserId)
		SELECT Id
		FROM inserted
		WHERE Type = 'User'

		if((select Type from inserted) != 'Administrator')
		begin
			insert into workRecords (tbUserId)
			select id from inserted where type = 'User'
		end
		
		
	end
go


CREATE Procedure InsertworkDays(@startDate DATE,@workRecordId INT)
AS
BEGIN
    DECLARE @i INT = 0;
    DECLARE @workingDays INT = 0;
	

    WHILE @workingDays < 10
    BEGIN
		if(@workingDays != 0)
			begin
				SET @startDate = DATEADD(DAY, 1, @startDate);
			end
        

        IF DATENAME(WEEKDAY, @startDate) NOT IN ('Saturday', 'Sunday')
        BEGIN
            INSERT INTO workDays (Date,WorkRecordId)
            VALUES (@startDate,@workRecordId);

            SET @workingDays = @workingDays + 1;
        END;
		
    END;
END
go
create trigger trRecordInsert
on workRecords
after insert
as
begin
	 DECLARE @nextMonday DATE;
	 DECLARE @workRecordId INT;

    SELECT @nextMonday = DATEADD(WEEK, DATEDIFF(WEEK, 0, GETDATE()) + 1, 0); -- Calculate next Monday

	SELECT @workRecordId = Id FROM inserted
	
    EXEC InsertWorkDays @nextMonday, @workRecordId;
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