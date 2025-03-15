USE FestFlow
GO

CREATE PROCEDURE usp_GetDepartments
AS
BEGIN
	Select 
		[ID], [Name]
	FROM
	Departments
END