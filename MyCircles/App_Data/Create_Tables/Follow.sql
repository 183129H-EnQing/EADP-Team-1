-- Follow Table
CREATE TABLE [dbo].[Follow] (
    [Id]          INT      IDENTITY (1, 1) NOT NULL,
    [IsDeleted]   BIT      NOT NULL,
    [CreatedAt]   DATETIME NOT NULL,
    [FollowerId]  INT      NOT NULL,
    [FollowingId] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Follower_ToUser] FOREIGN KEY ([FollowerId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Following_ToUser] FOREIGN KEY ([FollowingId]) REFERENCES [dbo].[User] ([Id])
);