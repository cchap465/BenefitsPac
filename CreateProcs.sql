USE BenefitsPac
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetEmployees')
	DROP PROCEDURE GetEmployees
GO

CREATE PROCEDURE GetEmployees 
	as
BEGIN	
	SELECT * 
	FROM Employees
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetEmployeeById')
	DROP PROCEDURE GetEmployeeById
GO

CREATE PROCEDURE GetEmployeeById (
	@EmployeeId INT
	)
	as
BEGIN	
	SELECT * 
	FROM Employees
	WHERE EmployeeId = @EmployeeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteEmployeeById')
	DROP PROCEDURE DeleteEmployeeById
GO

CREATE PROCEDURE DeleteEmployeeById (
	@EmployeeId INT
	)
	as
BEGIN	
	DELETE FROM BenefitCosts
	WHERE EmployeeId = @EmployeeId

	DELETE FROM EmployeeSalaryBreakdowns
	WHERE EmployeeId = @EmployeeId

	DELETE FROM Dependents
	WHERE EmployeeId = @EmployeeId

	DELETE FROM Employees
	WHERE EmployeeId = @EmployeeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'UpdateEmployeeById')
	DROP PROCEDURE UpdateEmployeeById
GO

CREATE PROCEDURE UpdateEmployeeById (
	@EmployeeId INT,
	@EmployeeName VARCHAR(30)
	)
	as
BEGIN	
	UPDATE Employees
	SET EmployeeName = @EmployeeName
	WHERE EmployeeId = @EmployeeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateEmployee')
	DROP PROCEDURE CreateEmployee
GO

CREATE PROCEDURE CreateEmployee (
	@EmployeeName VARCHAR(30),
	@DiscountAmount DECIMAL(18,4),
	@BaseDeductionCost DECIMAL(18,4),
	@PaymentFrequency INT,
	@SalaryByPayPeriod DECIMAL(18,4)
	)
	as
BEGIN	
	INSERT INTO Employees(EmployeeName)
	VALUES(@EmployeeName)

	DECLARE @EmployeeId INT = SCOPE_IDENTITY();

	INSERT INTO BenefitCosts(IsEmployee, IsDependent, DiscountAmount, BaseDeductionCost, EmployeeId)
	VALUES(1, 0, @DiscountAmount, @BaseDeductionCost, @EmployeeId)

	INSERT INTO EmployeeSalaryBreakdowns(PaymentFrequency, SalaryByPayPeriod, EmployeeId)
	VALUES(@PaymentFrequency, @SalaryByPayPeriod, @EmployeeId)

	RETURN @EmployeeId
END
GO

----Dependents
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetDependentsByEmployeeId')
	DROP PROCEDURE GetDependentsByEmployeeId
GO

CREATE PROCEDURE GetDependentsByEmployeeId (
	@EmployeeId INT
	)
	as
BEGIN	
	SELECT * 
	FROM Dependents
	WHERE EmployeeId = @EmployeeId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'DeleteDependentById')
	DROP PROCEDURE DeleteDependentById
GO

CREATE PROCEDURE DeleteDependentById (
	@DependentId INT
	)
	as
BEGIN	
	DELETE FROM BenefitCosts
	WHERE DependentId = @DependentId

	DELETE FROM Dependents
	WHERE DependentId = @DependentId
END
GO

IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'CreateDependent')
	DROP PROCEDURE CreateDependent
GO

CREATE PROCEDURE CreateDependent (
	@DependentName VARCHAR(30),
	@EmployeeId INT,
	@DiscountAmount DECIMAL(18,4),
	@BaseDeductionCost DECIMAL(18,4)
	)
	as
BEGIN	
	INSERT INTO Dependents(DependentName, EmployeeId)
	VALUES(@DependentName, @EmployeeId)

	DECLARE @DependentId INT = SCOPE_IDENTITY();

	INSERT INTO BenefitCosts(IsEmployee, IsDependent, DiscountAmount, BaseDeductionCost, EmployeeId, DependentId)
	VALUES(0, 1, @DiscountAmount, @BaseDeductionCost, @EmployeeId, @DependentId)

	return @DependentId;
END
GO

---BenefitCosts
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetBenefitCostsByEmployeeId')
	DROP PROCEDURE GetBenefitCostsByEmployeeId
GO

CREATE PROCEDURE GetBenefitCostsByEmployeeId (
	@EmployeeId INT
	)
	as
BEGIN	
	SELECT * 
	FROM BenefitCosts
	WHERE EmployeeId = @EmployeeId
END
GO


--EmployeeSalaryBreakdowns
IF EXISTS(SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GetEmployeeSalaryBreakdownByEmployeeId')
	DROP PROCEDURE GetEmployeeSalaryBreakdownByEmployeeId
GO

CREATE PROCEDURE GetEmployeeSalaryBreakdownByEmployeeId (
	@EmployeeId INT
	)
	as
BEGIN	
	SELECT * 
	FROM EmployeeSalaryBreakdowns
	WHERE EmployeeId = @EmployeeId
END
GO