Create table Employees 
(ID BIGINT NOT NULL    IDENTITY    PRIMARY KEY
,[Name] VARCHAR(255)
,Email VARCHAR(255)
,JobTitle VARCHAR(255)
,JoiningDate datetime)


CREATE PROCEDURE USP_GetAllEmployees   
AS   
    SELECT ID, [NAME], Email, JobTitle, JoiningDate
    FROM Employees  
GO  


CREATE PROCEDURE USP_InsertEmployee
@Name VARCHAR(255)
,@Email VARCHAR(255)
,@JobTitle VARCHAR(255)
,@JoiningDate datetime 
AS  
BEGIN   
    INSERT INTO Employees([NAME], Email, JobTitle, JoiningDate)   
           Values (@Name,@Email, @JobTitle, @JoiningDate)  
	SELECT SCOPE_IDENTITY() as EmployeeID
END 

CREATE PROCEDURE USP_GetEmployee  
@EmployeeID BIGINT
AS   
    SELECT ID, [NAME], Email, JobTitle, JoiningDate
    FROM Employees where ID = @EmployeeID
GO 

CREATE PROCEDURE USP_UpdateEmployee
@EmployeeID BIGINT
,@Name VARCHAR(255)
,@Email VARCHAR(255)
,@JobTitle VARCHAR(255)
,@JoiningDate datetime 
AS  
BEGIN   
    UPDATE Employees set 
	[Name]= @Name,
	Email = @Email,
	JobTitle = @JobTitle,
	JoiningDate = @JoiningDate 
	where ID = @EmployeeID
END 


CREATE PROCEDURE USP_DeleteEmployee  
@EmployeeID BIGINT
AS   
   DELETE FROM Employees
	WHERE ID = @EmployeeID;
GO 
