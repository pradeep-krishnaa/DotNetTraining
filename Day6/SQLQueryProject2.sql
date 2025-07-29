-- CREATE DATABASE BugTrackerDB;
-- USE BugTrackerDB;



-- ALTER TABLE Bugs DROP CONSTRAINT FK_Bugs_AssignedTo;   -- drop constraints to drop tables
-- ALTER TABLE Bugs DROP CONSTRAINT FK_Bugs_ProjectId;
-- ALTER TABLE Bugs DROP CONSTRAINT FK_Bugs_StatusId;


-- DROP TABLE IF EXISTS Bugs;
-- DROP TABLE IF EXISTS Users;
-- DROP TABLE IF EXISTS Projects;
-- DROP TABLE IF EXISTS Status;


CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    UserRole NVARCHAR(50) NOT NULL
);

INSERT INTO Users (FullName, Email, UserRole)
VALUES 
('Pradeep', 'pradeep.dev@example.com', 'Developer'),
('Krishnaa', 'krishnaa.qa@example.com', 'Tester'),
('Adhnan', 'adhnan.pm@example.com', 'Project Manager'),
('Jeff', 'jeff.dev@example.com', 'Developer');

CREATE TABLE Projects (
    ProjectId INT PRIMARY KEY IDENTITY(1,1),
    ProjectName NVARCHAR(100) NOT NULL,
    StartDate DATE,
    EndDate DATE
);

INSERT INTO Projects (ProjectName, StartDate, EndDate)
VALUES 
('BugTracker WebApp', '2024-01-01', '2024-06-30'),
('Inventory Management System', '2024-03-15', NULL),         -- ongoing
('E-Commerce Platform', '2024-02-10', '2024-07-20');

CREATE TABLE Status (
    StatusId INT PRIMARY KEY IDENTITY(1,1),
    StatusName NVARCHAR(50) NOT NULL
);

INSERT INTO Status (StatusName)
VALUES 
('New'),
('In Progress'),
('Resolved'),
('Closed');


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



INSERT INTO Bug (Title, Description, CreatedDate, Priority, ProjectId, AssignedTo, StatusId)
VALUES 
('Login page crash', 'App crashes when user enters invalid credentials rapidly.', DEFAULT, 'HIGH', 1, 1, 1), -- Alice, BugTracker
('Missing logout button', 'Logout option not visible on mobile devices.', DEFAULT, 'MEDIUM', 1, 2, 2), -- Bob, BugTracker
('Incorrect stock count', 'Inventory count incorrect after bulk upload.', DEFAULT, 'HIGH', 2, 4, 1), -- David, Inventory System
('UI alignment issues', 'Text overlaps buttons on smaller screens.', DEFAULT, 'LOW', 3, 1, 3), -- Alice, E-Commerce
('Search not working', 'Product search returns empty results for common terms.', DEFAULT, 'MEDIUM', 3, 2, 2); -- Bob, E-Commerce


SELECT * FROM Users
SELECT * FROM Projects;
SELECT * FROM Status;
SELECT * FROM Bug;


-- SELECT TABLE_NAME 
-- FROM INFORMATION_SCHEMA.TABLES 
-- WHERE TABLE_TYPE = 'BASE TABLE';

