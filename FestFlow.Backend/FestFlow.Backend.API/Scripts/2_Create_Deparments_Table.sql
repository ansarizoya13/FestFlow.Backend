USE FestFlow
GO

CREATE TABLE Departments
(
	[ID] UNIQUEIDENTIFIER DEFAULT NEWID(),
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(200),
	PRIMARY KEY(ID)
)


INSERT INTO Departments
	(Name, Description)
VALUES
	('BSC.IT', 'Bachelors of Science in IT'),
	('BSC.CS', 'Bachelors of Science in Computer Science')