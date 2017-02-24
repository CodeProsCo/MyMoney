CREATE TABLE [dbo].[Category]
(
	[Id] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT newsequentialid(),
	[Name] nvarchar(32) NOT NULL
)
