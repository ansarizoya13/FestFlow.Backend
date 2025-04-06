USE FestFlow
GO

ALTER TABLE EventQuestionnaireAnswer
	DROP COLUMN Answer

ALTER TABLE EventQuestionnaireAnswer
	ADD Answer NVARCHAR(200)