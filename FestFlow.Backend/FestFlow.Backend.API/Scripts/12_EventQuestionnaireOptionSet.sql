USE FestFlow
GO

CREATE TABLE EventQuestionnaireOptionSet (
    ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    EventQuestionnaireId UNIQUEIDENTIFIER NOT NULL,
    Options NVARCHAR(100) NOT NULL,
    FOREIGN KEY (EventQuestionnaireId) REFERENCES EventQuestionnaire(ID)
);
