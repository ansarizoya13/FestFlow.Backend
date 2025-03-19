CREATE PROCEDURE usp_GetUser
	@email NVARCHAR(200)
AS
BEGIN
	SELECT
		u.Id, s.FirstName, s.LastName, s.Email, 
		s.StudenEnrollmentNumber, u.PasswordHash, u.IsAdmin, d.Name as DepartmentName
	FROM Students s JOIN Users u ON s.Id = u.StudentID
	JOIN Departments d ON d.ID = s.BranchID
	Where s.Email = @email AND u.IsDeleted = 0
END