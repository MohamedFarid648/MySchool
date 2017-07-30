CREATE TABLE [dbo].[Answers] (
    [Id]          INT  IDENTITY (1, 1) NOT NULL,
    [Text]        TEXT COLLATE Arabic_CI_AI_KS_WS NOT NULL,
    [QuestionID]  INT  NOT NULL,
    [RightAnswer] INT  NOT NULL,
    [Score]       INT  DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Answers_ToTable] FOREIGN KEY ([QuestionID]) REFERENCES [dbo].[Questions] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);



CREATE TABLE [dbo].[Questions] (
    [Id]     INT  IDENTITY (1, 1) NOT NULL,
    [Text]   TEXT COLLATE Arabic_CI_AI_KS_WS NOT NULL,
    [userID] INT  DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Subjects] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Subjects] PRIMARY KEY CLUSTERED ([ID] ASC)
);

CREATE TABLE [dbo].[Users] (
    [ID]              INT            IDENTITY (1, 1) NOT NULL,
    [Name]            NVARCHAR (50)  NOT NULL,
    [Email]           NVARCHAR (50)  NOT NULL,
    [Password]        NVARCHAR (50)  NOT NULL,
    [ConfirmPassword] NVARCHAR (MAX) NULL,
    [Gender]          NVARCHAR (MAX) NOT NULL,
    [DateOfBirth]     DATETIME       NOT NULL,
    [Address]         NVARCHAR (MAX) NOT NULL,
    [PhoneNumber]     INT            NOT NULL,
    [UserTypeID]      INT            NOT NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([ID] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    CONSTRAINT [FK_UserTypeID] FOREIGN KEY ([UserTypeID]) REFERENCES [dbo].[UserTypes] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[UserSubjects] (
    [ID]        INT IDENTITY (1, 1) NOT NULL,
    [UserID]    INT NOT NULL,
    [SubjectID] INT NOT NULL,
    CONSTRAINT [PK_dbo.UserSubjects] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [Unique_UsersSubjects] UNIQUE NONCLUSTERED ([UserID] ASC, [SubjectID] ASC),
    CONSTRAINT [FK_SubjectID] FOREIGN KEY ([SubjectID]) REFERENCES [dbo].[Subjects] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT [FK_UserID] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([ID]) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE [dbo].[UserTypes] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.UserTypes] PRIMARY KEY CLUSTERED ([ID] ASC)
);

