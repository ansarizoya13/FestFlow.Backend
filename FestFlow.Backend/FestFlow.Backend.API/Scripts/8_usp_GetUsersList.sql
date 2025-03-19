USE FestFlow
GO

CREATE PROCEDURE usp_GetUsersList
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT
		u.ID as UserId,
		s.FirstName, s.LastName, s.Email, 
		s.StudenEnrollmentNumber, 
		u.IsDeleted, u.IsAdmin, 
		d.Name as Branch
	FROM Students s 
	JOIN Users u ON s.Id = u.StudentID
	JOIN Departments d ON d.ID = s.BranchID
	Where u.ID <> @userId
END