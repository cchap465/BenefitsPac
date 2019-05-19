USE master
GO

--dropping database if it exists
IF EXISTS(select * from sys.databases where name='BenefitsPac')
DROP DATABASE BenefitsPac
GO

--creating the database
CREATE DATABASE BenefitsPac
GO

USE BenefitsPac
GO

--Dropping tables if they exist
IF EXISTS(SELECT * FROM sys.tables WHERE name='BenefitCosts')
	DROP TABLE BenefitCosts
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='EmployeeSalaryBreakdowns')
	DROP TABLE EmployeeSalaryBreakdowns
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Dependents')
	DROP TABLE Dependents
GO

IF EXISTS(SELECT * FROM sys.tables WHERE name='Employees')
	DROP TABLE Employees
GO

CREATE TABLE Employees(
	EmployeeId INT NOT NULL IDENTITY(1,1),
	EmployeeName VARCHAR(30),
	CONSTRAINT PK_Employees_EmployeeId
	PRIMARY KEY (EmployeeId)
)
GO

CREATE TABLE Dependents(
	DependentId INT NOT NULL IDENTITY(1,1),
	DependentName VARCHAR(30),
	EmployeeId INT NOT NULL,
	CONSTRAINT PK_Dependents_DependentId PRIMARY KEY (DependentId),
	CONSTRAINT FK_Dependents_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
)
GO

CREATE TABLE EmployeeSalaryBreakdowns(
	Id INT NOT NULL IDENTITY(1,1),
	PaymentFrequency INT NOT NULL,
	SalaryByPayPeriod DECIMAL(18,4) NOT NULL,
	EmployeeId INT NOT NULL,
	CONSTRAINT PK_EmployeeSalaryBreakdowns_Id PRIMARY KEY (Id),
	CONSTRAINT FK_EmployeeSalaryBreakdowns_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
)
GO

CREATE TABLE BenefitCosts(
	Id INT NOT NULL IDENTITY(1,1),
	IsEmployee BIT NOT NULL,
	IsDependent BIT NOT NULL,
	DiscountAmount DECIMAL(18,4) NOT NULL,
	BaseDeductionCost DECIMAL(18,4) NOT NULL,
	EmployeeId INT NOT NULL,
	DependentId INT, 
	CONSTRAINT PK_BenefitCosts_Id PRIMARY KEY (Id),
	CONSTRAINT FK_BenefitCosts_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees(EmployeeId),
	CONSTRAINT FK_BenefitCosts_DependentId FOREIGN KEY (DependentId) REFERENCES Dependents(DependentId),
)
GO

