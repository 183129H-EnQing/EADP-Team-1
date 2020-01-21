--UserCircle Table (also may change)
CREATE TABLE [dbo].[UserCircles] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [UserId]    INT NOT NULL, 
    [CircleId]  VARCHAR (64) NOT NULL, 
    [Points]    INT DEFAULT 0 NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserCircles_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_UserCircles_ToCircle] FOREIGN KEY ([CircleId]) REFERENCES [Circle]([Id])
);