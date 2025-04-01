USE FestFLow
GO

CREATE PROCEDURE usp_GetEvents
	@userId UNIQUEIDENTIFIER
AS
BEGIN

	SELECT DISTINCT
		e.Id AS EventId, 
		e.Name, 
		e.Description
	FROM Users u 
	JOIN Students s ON u.StudentID = s.ID
	JOIN EventDepartmentMapping edm ON edm.DepartmentId = s.BranchID
	JOIN Events e ON edm.EventId = e.ID
	JOIN EventQuestionnaire eq ON e.ID = eq.EventId
	LEFT JOIN EventQuestionnaireAnswer eqa ON eqa.EventQuestionnaireId = eq.ID 
		AND eqa.UserId = @userId -- Ensure filtering happens in the join
	WHERE 
		u.ID = @userId 
		AND e.IsDeleted = 0 
		AND e.IsLive = 1 
		AND eqa.UserId IS NULL; -- Exclude events where the user has already answered

END

