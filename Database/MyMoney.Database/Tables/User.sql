CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newsequentialid(), 
    [EmailAddress] NVARCHAR(254) NOT NULL, 
    [FirstName] NVARCHAR(64) NOT NULL, 
    [LastName] NVARCHAR(64) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Salt] VARBINARY(50) NOT NULL, 
    [Hash] VARBINARY(50) NOT NULL, 
    [Iterations] INT NOT NULL
)
