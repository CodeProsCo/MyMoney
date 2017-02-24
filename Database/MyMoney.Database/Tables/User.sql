CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newsequentialid(), 
    [EmailAddress] NVARCHAR(254) NOT NULL, 
    [FirstName] NVARCHAR(64) NOT NULL, 
    [LastName] NVARCHAR(64) NOT NULL, 
    [Password] NVARCHAR(16) NOT NULL, 
    [DateOfBirth] DATE NOT NULL
)
