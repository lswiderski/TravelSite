USE webprojectDB
BEGIN TRANSACTION
GO
DROP TABLE [dbo].[TRAVELS]
GO
CREATE TABLE [Travels]
(
    [PlaceId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [Date] datetime NOT NULL,
) 
ALTER TABLE [Travels]
    ADD CONSTRAINT FKTUserId FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
ALTER TABLE [Travels]
    ADD CONSTRAINT FKTPlaceId FOREIGN KEY ([PlaceId]) REFERENCES [Place] ([PlaceId])
    COMMIT  