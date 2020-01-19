CREATE TABLE [dbo].[User] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Username]      NCHAR (20)    NOT NULL,
    [EmailAddress]  NCHAR (30)    NOT NULL,
    [Password]      NCHAR (256)   NULL,
    [Name]          NCHAR (20)    NOT NULL,
    [Bio]           TEXT          NULL,
    [Latitude]      FLOAT (53)    NULL,
    [Longitude]     FLOAT (53)    NULL,
    [City]          VARCHAR (MAX) NULL,
    [ProfileImage]  VARCHAR (MAX) NULL,
    [HeaderImage]   VARCHAR (MAX) NULL,
    [IsLoggedIn]    BIT           DEFAULT ((0)) NOT NULL,
    [IsGoogleUser]  BIT           DEFAULT ((0)) NOT NULL,
    [IsPrivileged]  BIT           DEFAULT ((0)) NOT NULL,
    [IsDeleted]     BIT           DEFAULT ((0)) NOT NULL,
    [IsEventHolder] BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Username] ASC),
    UNIQUE NONCLUSTERED ([EmailAddress] ASC)
);

-- Circle Table (may change later)
CREATE TABLE [dbo].[Circle] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

-- UserCircle Table (also may change)
CREATE TABLE [dbo].[UserCircles] (
    [Id]       INT NOT NULL,
    [UserId]   INT NOT NULL,
    [CircleId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UserCircles_ToCircle] FOREIGN KEY ([CircleId]) REFERENCES [dbo].[Circle] ([Id]),
    CONSTRAINT [FK_UserCircles_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

-- Post Table
CREATE TABLE [dbo].[Post] (
    [Id]      INT         IDENTITY (1, 1) NOT NULL,
    [Content] NCHAR (120) NOT NULL,
    [Image]   IMAGE       NULL,
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

-- Mutuals Table
CREATE TABLE [dbo].[Mutual] (
    [Id]      INT IDENTITY (1, 1) NOT NULL,
    [User1Id] INT NOT NULL,
    [User2Id] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Mutual1_ToUser] FOREIGN KEY ([User1Id]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_Mutual2_ToUser] FOREIGN KEY ([User2Id]) REFERENCES [dbo].[User] ([Id])
);

-- Event Table
CREATE TABLE [dbo].[Event] (
    [eventId]          INT           IDENTITY (1, 1) NOT NULL,
    [eventName]        NCHAR (50)    NULL,
    [eventDescription] NCHAR (50)    NULL,
    [eventStartDate]   NCHAR (50)    NULL,
    [eventEndDate]     NCHAR (50)    NULL,
    [eventCategory]    NCHAR (50)    NULL,
    [eventHolderName]  NCHAR (50)    NULL,
    [eventImage]       VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([eventId] ASC)
);

-- EventSchedule Table
CREATE TABLE [dbo].[EventSchedule] (
    [eventScheduleID]  INT            IDENTITY (1, 1) NOT NULL,
    [eventDescription] NVARCHAR (50)  NULL,
    [startDate]        NCHAR (10)     NULL,
    [startTime]        NCHAR (10)     NULL,
    [endTime]          NCHAR (10)     NULL,
    [endDate]          NCHAR (10)     NULL,
    [eventActivity]    NVARCHAR (MAX) NULL,
    [eventId]          INT            NULL,
    PRIMARY KEY CLUSTERED ([eventScheduleID] ASC),
    CONSTRAINT [eventId_EventSchedule_ToEventTable] FOREIGN KEY ([eventId]) REFERENCES [dbo].[Event] ([eventId])
);

-- SignUpEventDetails Table
CREATE TABLE [dbo].[SignUpEventDetails] (
    [Id]                         INT           NOT NULL,
    [name]                       VARCHAR (50)  NULL,
    [date]                       VARCHAR (50)  NULL,
    [contactNumber]              VARCHAR (8)   NULL,
    [numberOfBookingSlot]        VARCHAR (1)   NULL,
    [selectedEventToParticipate] VARCHAR (MAX) NULL,
    [eventId]                    INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [eventID_SignUpEventDetails_ToEventTable] FOREIGN KEY ([eventId]) REFERENCES [dbo].[Event] ([eventId])
);

-- Itinerary Table
CREATE TABLE [dbo].[Itinerary] (
    [itineraryId] INT        IDENTITY (1, 1) NOT NULL,
    [userId]      INT        NOT NULL,
	[itineraryName]      NCHAR(50)        NOT NULL,
    [startDate]   NCHAR (15) NOT NULL,
    [endDate]     NCHAR (15) NOT NULL,
    [groupSize]   NCHAR (3)  NOT NULL,
    PRIMARY KEY CLUSTERED ([itineraryId] ASC)
);
-- Pref Table
CREATE TABLE [dbo].[Pref] (
    [prefId]   INT        NOT NULL IDENTITY,
    [prefName] NCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([prefId] ASC)
);

-- Location Table
CREATE TABLE [dbo].[Location] (
    [locaId]       INT           NOT NULL IDENTITY,
    [landmarkType] INT    NOT NULL,
    [locaPic]      VARCHAR (MAX) NOT NULL,
    [locaName]     NCHAR (50)    NOT NULL,
    [locaDesc]     NCHAR (500)   NOT NULL,
    [locaRating]   DECIMAL(2, 1) NOT NULL,
    [locaContact]  INT           NULL,
    [locaWeb]      NCHAR (100)   NULL,
	[locaOpenHour] NCHAR(10) NOT NULL, 
    [locaCloseHour] NCHAR(10) NULL, 
    PRIMARY KEY CLUSTERED ([locaId] ASC), 
    CONSTRAINT [FK_Location_ToPref] FOREIGN KEY ([landmarkType]) REFERENCES [Pref]([prefId])
);

-- ItineraryPref Table
CREATE TABLE [dbo].[ItineraryPref] (
    [itineraryPrefId] INT NOT NULL,
    [itineraryId]     INT NOT NULL,
    [prefId]          INT NOT NULL,
    PRIMARY KEY CLUSTERED ([itineraryPrefId] ASC),
    CONSTRAINT [FK_ItineraryPref_ToItinerary] FOREIGN KEY ([itineraryId]) REFERENCES [dbo].[Itinerary] ([itineraryId]),
    CONSTRAINT [FK_ItineraryPref_ToPref] FOREIGN KEY ([prefId]) REFERENCES [dbo].[Pref] ([prefId])
);

-- DayByDay Table
CREATE TABLE [dbo].[DayByDay] (
    [dayBydayId]  INT        IDENTITY (1, 1) NOT NULL,
    [itineraryId] INT        NOT NULL,
    [date]        NCHAR (10) NOT NULL,
    [startTime]   NCHAR (10) NOT NULL,
    [endTime]     NCHAR (10) NOT NULL,
    [activityId]  INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([dayBydayId] ASC),
    CONSTRAINT [FK_DayByDay_ToLocation] FOREIGN KEY ([activityId]) REFERENCES [dbo].[Location] ([locaId]),
    CONSTRAINT [FK_DayByDay_ToItinerary] FOREIGN KEY ([itineraryId]) REFERENCES [dbo].[Itinerary] ([itineraryId])
);

-- Day Table
CREATE TABLE [dbo].[Day] (
    [dayByDayId] INT        IDENTITY (1, 1) NOT NULL,
    [date]       NCHAR (10) NOT NULL,
    [timeStamp]  NCHAR (10) NOT NULL,
    [activityId] INT        NOT NULL,
    PRIMARY KEY CLUSTERED ([dayByDayId] ASC)
);

-- Day Table
CREATE TABLE [dbo].[Activity] (
    [activityId]   INT IDENTITY (1, 1) NOT NULL,
    [activityName] VARCHAR (50) NULL,
    [startTime]    TIME (7)     NULL,
    [endTime]      TIME (7)     NULL,
    [date]         DATE         NULL,
    [locaId]       INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([activityId] ASC)
);

-- Admin Table
CREATE TABLE [dbo].[Admin] (
    [Id]     INT IDENTITY (1, 1) NOT NULL,
    [UserId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Admin_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

-- ReportedPosts Table
CREATE TABLE [dbo].[ReportedPosts]
(
    [Id] INT IDENTITY (1, 1) NOT NULL, 
    [reason] VARCHAR(MAX) NOT NULL, 
    [postId] INT NOT NULL, 
    CONSTRAINT [FK_ReportedPosts_ToTable] FOREIGN KEY ([postId]) REFERENCES [Post]([Id]),
);