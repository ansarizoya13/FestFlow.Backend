USE FestFlow
GO

CREATE TABLE Students
(
	ID UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Email NVARCHAR(200) NOT NULL,
	StudenEnrollmentNumber NVARCHAR(20) UNIQUE NOT NULL,
	BranchID UNIQUEIDENTIFIER NOT NULL,
	FOREIGN KEY (BranchID) REFERENCES Departments(ID)
)


INSERT INTO Students 
	(FirstName, LastName, Email, StudenEnrollmentNumber, BranchID)
VALUES 
    ('John', 'Doe', 'john.doe@example.com', '12345678901', '0193B3FB-9088-4374-A0BF-33B3A4B791C9'),  
    ('Jane', 'Smith', 'jane.smith@example.com', '98765432101', 'DC690BC6-71FB-448B-8F73-5B0D0C7F2C86'),  
    ('Alice', 'Johnson', 'alice.johnson@example.com', '45678912345', '0193B3FB-9088-4374-A0BF-33B3A4B791C9'),  
    ('Bob', 'Brown', 'bob.brown@example.com', '65432198765', 'DC690BC6-71FB-448B-8F73-5B0D0C7F2C86'),  
    ('Charlie', 'Davis', 'charlie.davis@example.com', '19283746500', '0193B3FB-9088-4374-A0BF-33B3A4B791C9');  
