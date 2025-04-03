USE FestFlow
GO

ALTER TABLE EventQuestionnaireAnswer
	DROP COLUMN Answer

ALTER TABLE EventQuestionnaireAnswer
	ADD Answer SQL_VARIANT
