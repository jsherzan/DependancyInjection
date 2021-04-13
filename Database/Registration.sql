CREATE TABLE [dbo].[Registration]
(
	[Id] INT identity(1,1) NOT NULL PRIMARY KEY, 
    [FirstName] VARCHAR(256) NOT NULL, 
    [Address] VARCHAR(512) NOT NULL, 
    [PhoneNumber] VARCHAR(12) NOT NULL, 
    [Email] VARCHAR(256) NOT NULL, 
    [Age] INT NOT NULL, 
    [ContactPreference] INT NOT NULL
)
