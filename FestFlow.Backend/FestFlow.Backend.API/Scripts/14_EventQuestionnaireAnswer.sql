USE FestFlow
GO

CREATE TABLE EventQuestionnaireAnswer (
    ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    EventQuestionnaireId UNIQUEIDENTIFIER NOT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Answer NVARCHAR(MAX) NULL,
    EventQuestionnaireOptionSetId UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (EventQuestionnaireId) REFERENCES EventQuestionnaire(ID),
    FOREIGN KEY (UserId) REFERENCES Users(ID),
    FOREIGN KEY (EventQuestionnaireOptionSetId) REFERENCES EventQuestionnaireOptionSet(ID)
);
