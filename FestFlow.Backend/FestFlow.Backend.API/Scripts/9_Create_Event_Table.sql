USE FestFlow
GO

CREATE TABLE [Events] (
    [ID] UNIQUEIDENTIFIER DEFAULT NEWID(),
    [Name] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(255),
    [IsLive] BIT DEFAULT 0,
    [IsAvailableForFeedback] BIT DEFAULT 0,
    [IsDeleted] BIT DEFAULT 0,
    [CreatedBy] NVARCHAR(100) NOT NULL,
    [CreatedAt] DATETIME DEFAULT GETUTCDATE(),
    [LastModifiedBy] NVARCHAR(100),
    [LastModifiedAt] DATETIME,
	PRIMARY KEY (ID)
);
