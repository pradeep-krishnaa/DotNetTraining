INSERT INTO Users (FullName, Email, UserRole)
VALUES 
('Pradeep', 'pradeep.dev@example.com', 'Developer'),
('Krishnaa', 'krishnaa.qa@example.com', 'Tester'),
('Adhnan', 'adhnan.pm@example.com', 'Project Manager'),
('Jeff', 'jeff.dev@example.com', 'Developer');


INSERT INTO Projects (ProjectName, StartDate, EndDate)
VALUES 
('BugTracker WebApp', '2024-01-01', '2024-06-30'),
('Inventory Management System', '2024-03-15', NULL),         -- ongoing
('E-Commerce Platform', '2024-02-10', '2024-07-20');


INSERT INTO Status (StatusName)
VALUES 
('New'),
('In Progress'),
('Resolved'),
('Closed');


INSERT INTO Bug (Title, Description, CreatedDate, Priority, ProjectId, AssignedTo, StatusId)
VALUES 
('Login page crash', 'App crashes when user enters invalid credentials rapidly.', DEFAULT, 'HIGH', 1, 1, 1), -- Alice, BugTracker
('Missing logout button', 'Logout option not visible on mobile devices.', DEFAULT, 'MEDIUM', 1, 2, 2), -- Bob, BugTracker
('Incorrect stock count', 'Inventory count incorrect after bulk upload.', DEFAULT, 'HIGH', 2, 4, 1), -- David, Inventory System
('UI alignment issues', 'Text overlaps buttons on smaller screens.', DEFAULT, 'LOW', 3, 1, 3), -- Alice, E-Commerce
('Search not working', 'Product search returns empty results for common terms.', DEFAULT, 'MEDIUM', 3, 2, 2); -- Bob, E-Commerce

SELECT * FROM Users;
SELECT * FROM Projects;
SELECT * FROM Status;
SELECT * FROM Bug;
