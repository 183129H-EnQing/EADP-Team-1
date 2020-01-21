-- Mutuals Table
CREATE TABLE [dbo].[Mutual] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [User1Id] INT NOT NULL,
    [User2Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Mutual1_ToUser] FOREIGN KEY ([User1Id]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Mutual2_ToUser] FOREIGN KEY ([User2Id]) REFERENCES [dbo].[User] ([Id])
);