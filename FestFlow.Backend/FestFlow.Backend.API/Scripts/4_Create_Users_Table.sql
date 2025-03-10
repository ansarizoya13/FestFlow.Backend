USE FestFlow
GO

CREATE TABLE Users
(
	ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	StudentID UNIQUEIDENTIFIER NOT NULL UNIQUE,
	[PasswordHash] NVARCHAR(200) NOT NULL, 
	IsDeleted BIT DEFAULT(0) NOT NULL,
	IsAdmin BIT DEFAULT(0) NOT NULL,
	CreatedAt DATETIME NOT NULL,
	CreatedBy NVARCHAR(200) NOT NULL,
	ModifiedAt DATETIME,
	ModifiedBy NVARCHAR(200),
	FOREIGN KEY(StudentID) REFERENCES Students(ID)
)