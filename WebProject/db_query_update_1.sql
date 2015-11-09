USE webprojectDB
BEGIN TRANSACTION
GO
ALTER TABLE dbo.[User] ADD
	Country nchar(50) NULL
GO
ALTER TABLE dbo.[User]
	DROP COLUMN Phone
GO
ALTER TABLE dbo.Place ADD
	Ranking int NULL
GO
CREATE TABLE [Ranking]
(
    [PlaceId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Score] INT NOT NULL,
) 
ALTER TABLE [Ranking]
    ADD CONSTRAINT FKRUserId FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
ALTER TABLE [Ranking]
    ADD CONSTRAINT FKRPlaceId FOREIGN KEY ([PlaceId]) REFERENCES [Place] ([PlaceId])  
GO
ALTER TABLE dbo.[User] ADD
	Password nvarchar(128) NOT NULL DEFAULT 'qwe'
GO
ALTER TABLE dbo.TRAVELS ADD
	Date datetime NULL
GO
COMMIT