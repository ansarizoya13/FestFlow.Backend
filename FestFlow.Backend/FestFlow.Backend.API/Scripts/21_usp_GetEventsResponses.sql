USE FestFlow
GO

CREATE PROCEDURE usp_GetEventsResponses
	@eventId UNIQUEIDENTIFIER
AS
BEGIN
	SELECT
    eq.ID AS EventQuestionnaireID,
    eq.Label AS QuestionLabel,
    eq.Type,
    eq.IsOptionSet,
    eq.Sequence,

    eqa.ID AS AnswerID,
    eqa.UserId,

    -- If type 6/7/8, pull OptionSet label, else use text answer
    CASE
        WHEN eq.Type IN (6, 7, 8) THEN eqo.Options
        ELSE eqa.Answer
    END AS Answer,

    COUNT(eqa.ID) OVER (PARTITION BY eq.ID) AS AnswerCount

FROM EventQuestionnaire eq
JOIN Events e ON eq.EventId = e.ID
LEFT JOIN EventQuestionnaireAnswer eqa ON eqa.EventQuestionnaireId = eq.ID
LEFT JOIN EventQuestionnaireOptionSet eqo ON eqo.ID = eqa.EventQuestionnaireOptionSetId

WHERE e.ID = @eventId

ORDER BY eq.Sequence, eqa.UserId;
END


