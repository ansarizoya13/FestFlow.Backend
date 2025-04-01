USE FestFlow
GO

CREATE PROCEDURE usp_GetEvent
	@eventId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT 
		e.ID AS EventId, 
		e.Name AS EventName, 
		eq.ID AS EventQuestionnaireId, 
		eq.Label, 
		eq.Type, 
		eq.Mandatory,
		eqo.ID AS EventQuestionnaireOptionSetId, 
		eqo.Options as 'Option',  
		eq.HasMultipleAnswers,
		eq.sequence
	FROM Events e
	JOIN EventQuestionnaire eq ON e.ID = eq.EventId
	LEFT JOIN EventQuestionnaireOptionSet eqo ON eq.ID = eqo.EventQuestionnaireId 
	WHERE e.ID = @eventId
	order by eq.sequence
END


