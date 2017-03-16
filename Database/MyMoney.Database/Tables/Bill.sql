CREATE TABLE [dbo].[Bill]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT newsequentialid(),
	[Amount] FLOAT NOT NULL,
	[StartDate] date NOT NULL,
	[UserId] uniqueidentifier NOT NULL,
	[ReoccurringPeriod] int NOT NULL,
	[CategoryId] uniqueidentifier NOT NULL, 
    [Name] NVARCHAR(256) NOT NULL, 

    [CreationTime] DATETIME NOT NULL DEFAULT getdate(), 
    CONSTRAINT [FK_Bill_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Bill_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
