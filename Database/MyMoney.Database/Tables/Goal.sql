CREATE TABLE [dbo].[Goal]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newsequentialid(), 
    [Name] NVARCHAR(32) NOT NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [Amount] FLOAT NOT NULL, 
    [Complete] BIT NOT NULL DEFAULT 0, 

    CONSTRAINT [FK_Goal_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
