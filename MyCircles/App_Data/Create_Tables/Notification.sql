-- Notification Table
CREATE TABLE [dbo].[Notification] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [Type]      NCHAR (10) NOT NULL,
    [Title]     NCHAR (20) NULL,
    [Content]   TEXT       NOT NULL,
    [IsRead]    BIT        NOT NULL,
    [CreatedAt] DATETIME   NOT NULL,
    [UserId]    INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Notification_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);