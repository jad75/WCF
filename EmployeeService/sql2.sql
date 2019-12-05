select * from tblEmployee

delete from tblEmployee

Alter table tblEmployee Add 
EmployeeType int, AnnualSalary int, HourlyPay int, HoursWorked int


Alter procedure spGetEmployee  
@Id int  
as  
Begin  
 Select Id, Name, Gender, DateOfBirth, 
  EmployeeType, AnnualSalary, HourlyPay, 
  HoursWorked  
 from tblEmployee where Id = @Id  
End

Alter procedure spSaveEmployee  
@Id int,  
@Name nvarchar(50),  
@Gender nvarchar(50),  
@DateOfBirth DateTime,
@EmployeeType int,
@AnnualSalary int = null,
@HourlyPay int = null,
@HoursWorked int = null
as  
Begin  
 Insert into tblEmployee  
 values (@Id, @Name, @Gender, @DateOfBirth, 
   @EmployeeType, @AnnualSalary, @HourlyPay, 
   @HoursWorked)  
End