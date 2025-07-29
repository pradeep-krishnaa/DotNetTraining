CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    UserRole NVARCHAR(50) NOT NULL
);

CREATE TABLE Projects (
    ProjectId INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate DATE,
    EndDate DATE
);

CREATE TABLE Status (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50) NOT NULL
);

CREATE TABLE Bug (
    BugId INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),                       -- Optional, long text
    CreatedDate DATETIME DEFAULT GETDATE(),          -- Defaults to current date/time
    Priority NVARCHAR(10) NOT NULL,
    
    ProjectId INT NOT NULL,
    AssignedTo INT NOT NULL,
    StatusId INT NOT NULL,

    -- Foreign Key Constraints
    CONSTRAINT FK_Bug_Project FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId),
    CONSTRAINT FK_Bug_User FOREIGN KEY (AssignedTo) REFERENCES Users(UserId),
    CONSTRAINT FK_Bug_Status FOREIGN KEY (StatusId) REFERENCES Status(StatusId)
);

SELECT * FROM INFORMATION_SCHEMA.TABLES;