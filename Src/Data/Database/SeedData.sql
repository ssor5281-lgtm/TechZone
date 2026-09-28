USE TechZoneDb;
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Name = 'Admin')
    INSERT INTO Roles (Name)
    VALUES ('Admin');
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Name = 'Staff')
    INSERT INTO Roles (Name)
    VALUES ('Staff');
GO

IF NOT EXISTS (SELECT 1 FROM Roles WHERE Name = 'Manager')
    INSERT INTO Roles (Name)
    VALUES ('Manager');
GO