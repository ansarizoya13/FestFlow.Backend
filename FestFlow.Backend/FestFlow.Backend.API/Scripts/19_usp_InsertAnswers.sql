USE FestFlow 
GO

CREATE PROCEDURE usp_InsertAnswers
	@questionId UNIQUEIDENTIFIER,
	@userId UNIQUEIDENTIFIER,
	@optionSetId UNIQUEIDENTIFIER = NULL,
	@answer NVARCHAR(200) = NULL
AS 
BEGIN
	IF (@answer IS NULL)
	begin
		insert into EventQuestionnaireAnswer
			(EventQuestionnaireId, UserId, EventQuestionnaireOptionSetId, Answer)
		values
			(@questionId, @userId, @optionSetId, null);
	end
	ELSE
	begin
		insert into EventQuestionnaireAnswer
			(EventQuestionnaireId, UserId, EventQuestionnaireOptionSetId, Answer)
		values
			(@questionId, @userId, null, @answer);
	end
	
END