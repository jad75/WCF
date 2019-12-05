Create Table tblEmployee
(
 Id int,
 Name nvarchar(50),
 Gender nvarchar(50),
 DateOfBirth datetime
)

Insert into tblEmployee values (1, 'Mark', 'Male', '10/10/1980')
Insert into tblEmployee values (2, 'Mary', 'Female', '11/10/1981')
Insert into tblEmployee values (3, 'John', 'Male', '8/10/1979')

Create procedure spGetEmployee
@Id int
as
Begin
 Select Id, Name, Gender, DateOfBirth
 from tblEmployee 
 where Id = @Id
End

Create procedure spSaveEmployee
@Id int,
@Name nvarchar(50),
@Gender nvarchar(50),
@DateOfBirth DateTime
as
Begin
 Insert into tblEmployee
 values (@Id, @Name, @Gender, @DateOfBirth)
End


CREATE PROCEDURE spDeleteEmployee
@Id int
as
Begin
   DELETE FROM tblEmployee 
   where Id = @Id
End