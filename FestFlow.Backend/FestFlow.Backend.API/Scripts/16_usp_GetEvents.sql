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
    WHERE u.ID = @userId
      AND e.IsDeleted = 0
      AND e.IsLive = 1
      AND NOT EXISTS (
          SELECT 1
          FROM EventQuestionnaireAnswer eqa
          WHERE eqa.UserId = @userId
            AND eqa.EventQuestionnaireId = eq.ID
      )

END

