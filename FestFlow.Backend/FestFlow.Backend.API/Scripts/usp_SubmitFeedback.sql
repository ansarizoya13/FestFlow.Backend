USE FestFlow
GO

CREATE PROCEDURE usp_SubmitFeedback
	@eventId UNIQUEIDENTIFIER,
	@userId UNIQUEIDENTIFIER,
	@rating INT,
	@comments NVARCHAR(MAX)
AS
BEGIN
	INSERT INTO Feedback
		(EventId, Rating, Feedback, UserId)
	VALUES
		(@eventId, @rating, @comments, @userId)
END