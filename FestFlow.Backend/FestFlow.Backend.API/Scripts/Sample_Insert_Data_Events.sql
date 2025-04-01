INSERT INTO [dbo].[EventQuestionnaire]
	(EventId, Label, Type, Mandatory, IsOptionSet, HasMultipleAnswers)
VALUES
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Full Name', 0, 1, 0, 0),
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Email Address', 1 , 1, 0, 0),
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Contact Number', 2, 1, 0, 0),
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Date of Birth', 3, 1, 0, 0),
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Preferred timing', 4, 1, 0, 0),
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Preferred Date and timing', 5, 0, 0, 0),
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Gender', 6, 1, 1, 0), -- optionset
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Select Your Interests', 7, 0, 1, 1), -- optionset
	('A695ECAE-EA72-4099-9005-00DCEAF5B17E', 'Select Your Courses', 8, 1, 1, 0) -- optionset


INSERT INTO [EventQuestionnaireOptionSet]
	(EventQuestionnaireId, Options)
VALUES
	('BA53BF52-B59B-4A20-A2F4-FC0EE098BA16', 'Male'),
	('BA53BF52-B59B-4A20-A2F4-FC0EE098BA16', 'Female')