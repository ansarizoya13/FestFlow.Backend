USE FestFlow
GO

CREATE PROCEDURE usp_GetStatistics
AS
BEGIN

	DECLARE @usersCount INT = 0
	Select @usersCount = count(*) from Users;

	DECLARE @studentsCount INT = 0
	Select @studentsCount = count(*) from Students;

	DECLARE @eventsCount INT = 0
	Select @eventsCount = count(*) from Events;

	DECLARE @feedbacksCount INT = 0
	Select @feedbacksCount = count(*) from Feedback;

	DECLARE @questionsCount INT = 0
	Select @questionsCount = count(*) from EventQuestionnaire;

	DECLARE @anwersCount INT = 0
	Select @anwersCount = count(*) from EventQuestionnaireAnswer;

	DECLARE @departmentsCount INT = 0
	Select @departmentsCount = count(*) from Departments;

	DECLARE @adminsCount INT = 0
	Select @adminsCount = count(*) from Users WHERE IsAdmin = 1;
	
	select 
		@usersCount as users, 
		@studentsCount as students, 
		@eventsCount as events,
		@feedbacksCount as feedbacks,
		@questionsCount as questions,
		@anwersCount as answers,
		@departmentsCount as departments,
		@adminsCount as admins


END