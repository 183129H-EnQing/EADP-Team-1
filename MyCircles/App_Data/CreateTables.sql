CREATE TABLE [dbo].[User] (

    [Id]            INT           IDENTITY (1, 1) NOT NULL,

    [Username]      VARCHAR (32)  NOT NULL,

    [EmailAddress]  VARCHAR (32)  NOT NULL,

    [Password]      VARCHAR (256) NULL,

    [Name]          VARCHAR (18)  NOT NULL,

    [Bio]           TEXT          NULL,

    [Latitude]      FLOAT (48)    NULL,

    [Longitude]     FLOAT (48)    NULL,

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

    [Id] VARCHAR (64) UNIQUE,

    PRIMARY KEY CLUSTERED ([Id]),

	UNIQUE NONCLUSTERED ([Id] ASC)

);



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



-- Post Table

CREATE TABLE [dbo].[Post] (

    [Id]       INT           IDENTITY (1, 1) NOT NULL,

    [Content]  VARCHAR (128) NOT NULL,

    [Image]    VARCHAR (MAX) NULL,

    [Comment]  VARCHAR (20)  NULL,

    [UserId]   INT           NOT NULL,

    [CircleId] VARCHAR (64)  NOT NULL,

	[DateTime] DATETIME      NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [FK_Post_ToCircle] FOREIGN KEY ([CircleId]) REFERENCES [dbo].[Circle] ([Id]),

    CONSTRAINT [FK_Post_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]) 

);



-- Notification Table
CREATE TABLE [dbo].[Notification] (
    [Id]				INT           IDENTITY (1, 1) NOT NULL,
    [Action]			VARCHAR (128) NULL,
	[Source]			VARCHAR (128) NULL,
    [Type]				VARCHAR (128) NULL,
    [AdditionalMessage] TEXT          NULL,
	[CallToAction]		VARCHAR (128) NULL,
	[CallToActionLink]  VARCHAR (128) NULL,
    [IsRead]			BIT           NOT NULL,
    [CreatedAt]			DATETIME      NOT NULL,
    [UserId]			INT           NOT NULL,
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
    [eventId]                   INT           IDENTITY (1, 1) NOT NULL,
    [eventName]                 VARCHAR (50)  NULL,
    [eventDescription]          VARCHAR (50)  NULL,
    [eventStartTime]            VARCHAR (50)  NULL,
    [eventEndTime]              VARCHAR (50)  NULL,
    [eventStartDate]            VARCHAR (50)  NULL,
    [eventEndDate]              VARCHAR (50)  NULL,
    [eventCategory]             VARCHAR (50)  NULL,
    [eventHolderName]           VARCHAR (50)  NULL,
	[eventHolderId]             Int			  NULl,
    [eventImage]                VARCHAR (MAX) NULL,
    [eventMaxSlot]              VARCHAR (10)  NULL,
    [eventEntryFeesStatus]      VARCHAR (20)  NULL,
    [eventStatus]               VARCHAR (20)  NULL,
    [singleOrRecurring]         VARCHAR (20)  NULL,
    [maxTimeAPersonCanRegister] VARCHAR (10)  NULL,
	[eventLocation]				VARCHAR(50) NULL, 
	[eventTicketCost]		    VARCHAR(10) NULL,
    PRIMARY KEY CLUSTERED ([eventId] ASC),
	CONSTRAINT [FK_Event_userId] FOREIGN KEY ([eventHolderId]) REFERENCES [dbo].[User] ([Id])
);



-- EventSchedule Table

CREATE TABLE [dbo].[EventSchedule] (
    [eventScheduleID]  INT           IDENTITY (1, 1) NOT NULL,
    [eventDescription] VARCHAR (50)  NULL,
    [startDate]        VARCHAR (10)  NULL,
    [startTime]        VARCHAR (10)  NULL,
    [endTime]          VARCHAR (10)  NULL,
    [endDate]          VARCHAR (10)  NULL,
    [eventActivity]    VARCHAR (MAX) NULL,
    [eventId]          INT           NULL,
    [usersOptIn]       VARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([eventScheduleID] ASC),
    CONSTRAINT [eventId_EventSchedule_ToEventTable] FOREIGN KEY ([eventId]) REFERENCES [dbo].[Event] ([eventId])

);



-- SignUpEventDetails Table

CREATE TABLE [dbo].[SignUpEventDetails] (
    [Id]                         INT           IDENTITY (1, 1) NOT NULL,
    [name]                       VARCHAR (50)  NULL,
    [date]                       VARCHAR (50)  NULL,
    [contactNumber]              VARCHAR (8)   NULL,
    [numberOfBookingSlot]        VARCHAR (10)  NULL,
    [selectedEventToParticipate] VARCHAR (MAX) NULL,
    [eventId]                    INT           NULL,
    [userId]					 INT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [eventID_SignUpEventDetails_ToEventTable] FOREIGN KEY ([eventId]) REFERENCES [dbo].[Event] ([eventId]),
	CONSTRAINT [userId_SignUpEventDetails_ToUserTable] FOREIGN KEY ([userId]) REFERENCES [dbo].[User] ([Id])
);





-- Itinerary Table
CREATE TABLE [dbo].[Itinerary] (
    [itineraryId]   INT          IDENTITY (1, 1) NOT NULL,
    [userId]        INT          NOT NULL,
    [itineraryName] VARCHAR (50) NOT NULL,
    [startDate]     DATETIME     NOT NULL,
    [endDate]       DATETIME     NOT NULL,
    [groupSize]     VARCHAR (3)  NOT NULL,
    PRIMARY KEY CLUSTERED ([itineraryId] ASC)
);




-- Pref Table

CREATE TABLE [dbo].[Pref] (

    [prefId]   INT          NOT NULL IDENTITY,

    [prefName] VARCHAR (20) NOT NULL,

    PRIMARY KEY CLUSTERED ([prefId] ASC)

);



-- Location Table

CREATE TABLE [dbo].[Location] (

    [locaId]          INT            IDENTITY (1, 1) NOT NULL,

    [landmarkType]    INT            NOT NULL,

    [locaPic]         VARCHAR (MAX)  NOT NULL,

    [locaName]        NCHAR (50)     NOT NULL,

    [locaDesc]        NCHAR (1000)    NOT NULL,

    [locaRating]      DECIMAL (2, 1) NOT NULL,

	[locaAddress]		NCHAR (50)	NULL,

	[locaPostalCode]	NCHAR(20)		NULL,

    [locaContact]     NCHAR(15)            NULL,

    [locaWeb]         NCHAR (100)    NULL,

    [locaOpenHour]    NCHAR (10)     NOT NULL,

    [locaCloseHour]   NCHAR (10)     NULL,

    [locaRecom]       NCHAR (6)      NOT NULL,

    [locaLatitude]  FLOAT(53)    NULL,

    [locaLongitude]  FLOAT(53)    NULL,

    PRIMARY KEY CLUSTERED ([locaId] ASC),

    CONSTRAINT [FK_Location_ToPref] FOREIGN KEY ([landmarkType]) REFERENCES [dbo].[Pref] ([prefId])

);

-- ItineraryPref Table

CREATE TABLE [dbo].[ItineraryPref] (

    [itineraryPrefId] INT NOT NULL IDENTITY(1,1),

    [itineraryId]     INT NOT NULL,

    [prefId]          INT NOT NULL,

    PRIMARY KEY CLUSTERED ([itineraryPrefId] ASC),

    CONSTRAINT [FK_ItineraryPref_ToItinerary] FOREIGN KEY ([itineraryId]) REFERENCES [dbo].[Itinerary] ([itineraryId]),

    CONSTRAINT [FK_ItineraryPref_ToPref] FOREIGN KEY ([prefId]) REFERENCES [dbo].[Pref] ([prefId])

);



-- DayByDay Table

CREATE TABLE [dbo].[DayByDay] (

    [dayBydayId]  INT		   IDENTITY(1,1) NOT NULL ,

    [itineraryId] INT          NOT NULL,

	[date]        VARCHAR (10) NOT NULL

    PRIMARY KEY CLUSTERED ([dayBydayId] ASC),

    CONSTRAINT [FK_DayByDay_ToItinerary] FOREIGN KEY ([itineraryId]) REFERENCES [dbo].[Itinerary] ([itineraryId])

);



-- Day Table
CREATE TABLE [dbo].[Day] (
    [dayId]       INT          IDENTITY (1, 1) NOT NULL,
    [date]        DATETIME     NULL,
    [dayByDayId]  INT          NOT NULL,
    [itineraryId] INT          NOT NULL,
    [startTime]   DATETIME     NOT NULL,
    [endTime]     DATETIME     NOT NULL,
    [locationId]  INT          NOT NULL,
    CONSTRAINT [PK_dbo.Day] PRIMARY KEY CLUSTERED ([dayId] ASC),
    CONSTRAINT [FK_dbo.Day_dbo.Location_locationId] FOREIGN KEY ([locationId]) REFERENCES [dbo].[Location] ([locaId]),
    CONSTRAINT [FK_dbo.Day_dbo.DayByDay_dayByDayId] FOREIGN KEY ([dayByDayId]) REFERENCES [dbo].[DayByDay] ([dayBydayId])
);





-- Activity Table

CREATE TABLE [dbo].[Activity] (

    [activityId]   INT IDENTITY (1, 1) NOT NULL,

    [activityName] VARCHAR (50)        NULL,

    [startTime]    TIME (7)			   NULL,

    [endTime]      TIME (7)			   NULL,

    [date]         DATE				   NULL,

    [locaId]       INT				   NOT NULL,

    PRIMARY KEY CLUSTERED ([activityId] ASC)

);



-- Admin Table

CREATE TABLE [dbo].[Admin] (

    [Id]     INT IDENTITY (1, 1) NOT NULL,

    [UserId] INT                 NOT NULL,

    PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [FK_Admin_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])

);



-- ReportedPosts Table

CREATE TABLE [dbo].[ReportedPosts] (

    [Id]             INT           IDENTITY (1, 1) NOT NULL,

    [reason]         VARCHAR (MAX) NOT NULL,

    [postId]         INT           NOT NULL,

    [reporterUserId] INT           NOT NULL,

    [dateCreated]    DATE          NOT NULL,

	PRIMARY KEY CLUSTERED ([Id] ASC),

    CONSTRAINT [FK_ReportedPosts_ToTable] FOREIGN KEY ([postId]) REFERENCES [dbo].[Post] ([Id]),

    CONSTRAINT [FK_ReporterUserId_ToUserTable] FOREIGN KEY ([reporterUserId]) REFERENCES [dbo].[User] ([Id])

);


CREATE TABLE [dbo].[Comment] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [PostId]       INT           NULL,
    [comment_text] VARCHAR (500) NULL,
    [comment_by]   VARCHAR (50)  NULL,
    [comment_date] DATETIME      NULL,
	[UserId]       INT           NOT NULL,
	PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT [FK_Comment_ToPost] FOREIGN KEY ([PostId]) REFERENCES [dbo].[Post] ([Id]),
    CONSTRAINT [FK_Comment_ToUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

CREATE TABLE [dbo].[ChatRoom] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [CreatedAt] DATETIME     NOT NULL,
    [User1Id]   INT          NOT NULL,
    [User2Id]   INT          NOT NULL,
	[HasUnseenMessages] BIT  NOT NULL DEFAULT ((0)),
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ChatUser1_ToUser] FOREIGN KEY ([User1Id]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_ChatUser2_ToUser] FOREIGN KEY ([User2Id]) REFERENCES [dbo].[User] ([Id])
);


CREATE TABLE [dbo].[Message] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [CreatedAt]      DATETIME      NOT NULL,
    [ChatRoomId]     INT           NOT NULL,
    [Content]        VARCHAR (MAX) NULL,
    [HasGeolocation] BIT           DEFAULT ((0)) NOT NULL,
    [Latitude]       FLOAT (53)    NULL,
    [Longitude]      FLOAT (53)    NULL,
    [Image]          VARCHAR (MAX) NULL,
	[SenderId]       INT           NOT NULL,
	[RecieverId]     INT           NOT NULL,
	[IsSeen]         BIT           DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Message_ToChatRoom] FOREIGN KEY ([ChatRoomId]) REFERENCES [dbo].[ChatRoom] ([Id]),
	CONSTRAINT [FK_Sender_ToUser] FOREIGN KEY ([SenderId]) REFERENCES [dbo].[User] ([Id]),
	CONSTRAINT [FK_Reciever_ToUser] FOREIGN KEY ([RecieverId]) REFERENCES [dbo].[User] ([Id]),
);
