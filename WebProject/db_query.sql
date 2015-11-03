USE webprojectDB
CREATE TABLE [User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NCHAR(50) NOT NULL, 
    [LastName] NCHAR(50) NOT NULL, 
    [BirthDate] DATETIME NOT NULL, 
    [Email] NCHAR(50) NOT NULL, 
	[Phone] NCHAR(50) NULL,
    [AddDate] DATETIME NOT NULL, 
    [ModifiedDate] DATETIME NULL, 
    [IsActive] BIT NOT NULL DEFAULT 0, 
    [IsAdmin] BIT NOT NULL DEFAULT 0,

)

CREATE TABLE [Country]
(
    [CountryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NOT NULL,
    [Code] NCHAR(50) NOT NULL,   
)

CREATE TABLE [Place]
(
    [PlaceId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(50) NOT NULL,
    [Content] NTEXT NOT NULL,
    [Photo_URI] NCHAR(150) NULL,
    [CountryId] INT NOT NULL,
    [UserId] INT NOT NULL,
    [IsAccepted] BIT NOT NULL DEFAULT 0,
    
)
ALTER TABLE [Place]
    ADD CONSTRAINT FKPCountryId FOREIGN KEY ([CountryId]) REFERENCES [Country] ([CountryId])
ALTER TABLE [Place]
    ADD CONSTRAINT FKPUserId FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
    
CREATE TABLE [COMMENT]
(
    [CommentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Date] DATETIME NOT NULL,
    [Content] NVARCHAR(250) NOT NULL,
    [PlaceId] INT NOT NULL,
    [UserId] INT NOT NULL,
)
ALTER TABLE [COMMENT]
    ADD CONSTRAINT FKCUserId FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
ALTER TABLE [COMMENT]
    ADD CONSTRAINT FKCPlaceId FOREIGN KEY ([PlaceId]) REFERENCES [Place] ([PlaceId])  
    
CREATE TABLE [TRAVELS]
(
    [PlaceId] INT NOT NULL,
    [UserId] INT NOT NULL,
) 
ALTER TABLE [TRAVELS]
    ADD CONSTRAINT FKTUserId FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId])
ALTER TABLE [TRAVELS]
    ADD CONSTRAINT FKTPlaceId FOREIGN KEY ([PlaceId]) REFERENCES [Place] ([PlaceId])  