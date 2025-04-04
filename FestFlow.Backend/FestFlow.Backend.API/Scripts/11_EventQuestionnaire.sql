USE FestFlow
GO

CREATE TABLE EventQuestionnaire (
    ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    EventId UNIQUEIDENTIFIER NOT NULL,
    Label NVARCHAR(255) NOT NULL,
    Type INT NOT NULL,
    Mandatory BIT DEFAULT 0,
    IsOptionSet BIT DEFAULT 0,
    FOREIGN KEY (EventId) REFERENCES Events(ID)
);
