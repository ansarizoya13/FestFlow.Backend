CREATE PROCEDURE usp_GetUser
	@email NVARCHAR(200)
AS
BEGIN
	SELECT
		u.Id, s.FirstName, s.LastName, s.Email, 
		s.StudenEnrollmentNumber, u.PasswordHash, u.IsAdmin
	FROM Students s JOIN Users u ON s.Id = u.StudentID
	Where s.Email = @email
END