CREATE TABLE [dbo].[Expenditure]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newsequentialid(), 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Date] DATE NOT NULL, 
    [Description] NVARCHAR(256) NOT NULL, 
    [CategoryId] UNIQUEIDENTIFIER NOT NULL, 
    [CreationTime] DATETIME NOT NULL DEFAULT getdate(), 
    [DateOccurred] DATE NOT NULL, 
    CONSTRAINT [FK_Expenditure_ToUser] FOREIGN KEY (UserId) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Expenditure_ToCategory] FOREIGN KEY (CategoryId) REFERENCES [Category]([Id])
)
