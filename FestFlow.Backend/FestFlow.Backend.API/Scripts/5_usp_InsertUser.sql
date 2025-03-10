USE FestFlow
GO

CREATE PROCEDURE usp_InsertUser
	@firstName NVARCHAR(100),
	@lastName NVARCHAR(100),
	@email NVARCHAR(200),
	@studentEnrollmentNumber NVARCHAR(20),
	@branchId UNIQUEIDENTIFIER,
	@password NVARCHAR(200),
	@createdAt DATETIME,
	@createdBy NVARCHAR(200)
AS
BEGIN
	
	DECLARE @studentId uniqueidentifier = null

	-- Get the Student ID
	SELECT @studentId = ID 
	FROM Students 
	WHERE FirstName = @firstName AND LastName = @lastName 
		AND Email = @email AND StudenEnrollmentNumber = @studentEnrollmentNumber AND BranchId = @branchId


	-- Insert in the Users table
	IF @studentId is not null
	BEGIN
		IF(NOT EXISTS(Select ID FROM Users Where StudentID = @studentId))
		BEGIN
			INSERT INTO Users
				(StudentID, PasswordHash, CreatedAt, CreatedBy)
			VALUES
				(@studentId, @password, @createdAt, @createdBy)
		END
	END

	
END

