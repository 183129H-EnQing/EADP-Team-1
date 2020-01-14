CREATE TABLE [dbo].[User] (
    [Id]           INT         IDENTITY (1, 1) NOT NULL,
    [Username]     NCHAR (20)  NOT NULL,
    [EmailAddress] NCHAR (30)  NOT NULL,
    [Password]     NCHAR (256) NULL,
    [Name]         NCHAR (20)  NOT NULL,
    [Bio]          TEXT        NULL,
    [Latitude]     FLOAT (53)  NULL,
    [Longitude]    FLOAT (53)  NULL,
    [ProfileImage] IMAGE       NULL,
    [HeaderImage]  IMAGE       NULL,
    [IsLoggedIn]   BIT         DEFAULT ((0)) NOT NULL,
    [IsPrivileged] BIT         DEFAULT ((0)) NOT NULL,
    [IsDeleted]    BIT         DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([EmailAddress] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC)
);

-- POST Table
CREATE TABLE [dbo].[POST] (
    [Id]      INT         IDENTITY (1, 1) NOT NULL,
    [Content] NCHAR (120) NOT NULL,
    [Picture] IMAGE       NULL,
    [Comment] NCHAR (20)  NOT NULL,
    [UserId]  INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_POST_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

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

-- Friend Table
CREATE TABLE [dbo].[Friend] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [IsDeleted]  BIT      NOT NULL,
    [CreatedAt]  DATETIME NOT NULL,
    [SourceId]   INT      NOT NULL,
    [RecieverId] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_SourceFriend_ToUser] FOREIGN KEY ([SourceId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_RecieverFriend_ToUser] FOREIGN KEY ([RecieverId]) REFERENCES [dbo].[User] ([Id])
);

-- Event Table
CREATE TABLE [dbo].[Event] (
    [eventId]          INT        IDENTITY (1, 1) NOT NULL,
    [eventName]        NCHAR (50) NULL,
    [eventDescription] NCHAR (50) NULL,
    [eventStartDate]   NCHAR (50) NULL,
    [eventEndDate]     NCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([eventId] ASC)
);

