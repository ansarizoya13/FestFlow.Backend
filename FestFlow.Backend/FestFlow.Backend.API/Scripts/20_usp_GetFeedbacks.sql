USE FestFlow
Go

CREATE PROCEDURE usp_GetFeedbacks
	@userId UNIQUEIDENTIFIER
AS
BEGIN
	
	SELECT 
		e.ID as EventId, 
		e.Name, 
		e.Description,
		e.IsAvailableForFeedback
	FROM Events e
	WHERE 
	e.IsAvailableForFeedback = 1
	AND EXISTS (
		SELECT 1
		FROM EventQuestionnaire eq
		JOIN EventQuestionnaireAnswer eqa ON eq.ID = eqa.EventQuestionnaireId
		WHERE eq.EventId = e.ID AND eqa.UserId = @userId
	)
	AND NOT EXISTS (
		SELECT 1 
		FROM Feedback f 
		WHERE f.EventId = e.ID AND f.UserId = @userId
	)

END







