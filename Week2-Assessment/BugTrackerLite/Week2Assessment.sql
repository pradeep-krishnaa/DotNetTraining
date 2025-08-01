CREATE DATABASE BugTrackerLiteDB;
use BugTrackerLiteDB;

create Table Users(
    UserID INT PRIMARY KEY,
    UserName NVARCHAR(100) NOT NULL
);

create Table Tickets(
    TicketID INT PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(MAX) NOT NULL,                       -- Optional, long text
    CreatedDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(100) NOT NULL,
    UserID INT NOT NULL,

    FOREIGN KEY (UserID) REFERENCES Users(UserID)
);

CREATE TABLE Tags(
    TagID INT PRIMARY KEY,
    TagName NVARCHAR(100) NOT NULL
)

CREATE TABLE TicketTags (
    TicketId INT NOT NULL,
    TagId INT NOT NULL,
    PRIMARY KEY (TicketId, TagId), --- combination of both should be unique - composite primary key
    FOREIGN KEY (TicketId) REFERENCES Tickets(TicketId) ON DELETE CASCADE,  --- ensures when a ticket is deleted associated records in TicketTags are also deleted
    FOREIGN KEY (TagId) REFERENCES Tags(TagId) ON DELETE CASCADE --- ensures when a tag is deleted associated records in TicketTags are also deleted
);

-- select * from INFORMATION_SCHEMA.TABLES;
-- select * from Users;

-- -- Disable all foreign key constraints
-- EXEC sp_MSforeachtable "ALTER TABLE ? NOCHECK CONSTRAINT ALL"

-- -- Delete all data from all tables
-- EXEC sp_MSforeachtable "DELETE FROM ?"

-- -- Re-enable all foreign key constraints
-- EXEC sp_MSforeachtable "ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL"
