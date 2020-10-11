
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/11/2020 15:20:40
-- Generated from EDMX file: D:\FIT5032---S3\5032_JiancongLei_30310016\FIT5032_studio\Assignment\Assignment\Models\AssignmentModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-Assignment-20200831121220];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------



-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------


-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityName] nvarchar(max)  NOT NULL,
    [ActivityStartDate] nvarchar(max)  NOT NULL,
    [ActivityDescription] nvarchar(max)  NOT NULL,
    [ActivityStatus] nvarchar(max)  NOT NULL,
    [ActivityRating] nvarchar(max)  NOT NULL,
    [ActivityTypeId] int  NOT NULL,
    [ActivityPlaceId] int  NOT NULL
);
GO

-- Creating table 'ActivityTypes'
CREATE TABLE [dbo].[ActivityTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityTypeName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ActivityPlaces'
CREATE TABLE [dbo].[ActivityPlaces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityPlaceName] nvarchar(max)  NOT NULL,
    [ActivityPlaceLongitude] nvarchar(max)  NOT NULL,
    [ActivityPlaceLatitude] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'RatingLogs'
CREATE TABLE [dbo].[RatingLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Rating] nvarchar(max)  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL,
    [ActivityId] int  NOT NULL
);
GO

-- Creating table 'JoinLogs'
CREATE TABLE [dbo].[JoinLogs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [JoinDate] nvarchar(max)  NOT NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL,
    [ActivityId] int  NOT NULL
);
GO



-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------



-- Creating primary key on [Id] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActivityTypes'
ALTER TABLE [dbo].[ActivityTypes]
ADD CONSTRAINT [PK_ActivityTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ActivityPlaces'
ALTER TABLE [dbo].[ActivityPlaces]
ADD CONSTRAINT [PK_ActivityPlaces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RatingLogs'
ALTER TABLE [dbo].[RatingLogs]
ADD CONSTRAINT [PK_RatingLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JoinLogs'
ALTER TABLE [dbo].[JoinLogs]
ADD CONSTRAINT [PK_JoinLogs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------




-- Creating foreign key on [ActivityTypeId] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [FK_ActivityActivityType]
    FOREIGN KEY ([ActivityTypeId])
    REFERENCES [dbo].[ActivityTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityActivityType'
CREATE INDEX [IX_FK_ActivityActivityType]
ON [dbo].[Activities]
    ([ActivityTypeId]);
GO

-- Creating foreign key on [ActivityPlaceId] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [FK_ActivityActivityPlace]
    FOREIGN KEY ([ActivityPlaceId])
    REFERENCES [dbo].[ActivityPlaces]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityActivityPlace'
CREATE INDEX [IX_FK_ActivityActivityPlace]
ON [dbo].[Activities]
    ([ActivityPlaceId]);
GO

-- Creating foreign key on [AspNetUserId] in table 'JoinLogs'
ALTER TABLE [dbo].[JoinLogs]
ADD CONSTRAINT [FK_AspNetUserJoinLog]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserJoinLog'
CREATE INDEX [IX_FK_AspNetUserJoinLog]
ON [dbo].[JoinLogs]
    ([AspNetUserId]);
GO

-- Creating foreign key on [ActivityId] in table 'JoinLogs'
ALTER TABLE [dbo].[JoinLogs]
ADD CONSTRAINT [FK_ActivityJoinLog]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityJoinLog'
CREATE INDEX [IX_FK_ActivityJoinLog]
ON [dbo].[JoinLogs]
    ([ActivityId]);
GO

-- Creating foreign key on [AspNetUserId] in table 'RatingLogs'
ALTER TABLE [dbo].[RatingLogs]
ADD CONSTRAINT [FK_AspNetUserRatingLog]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRatingLog'
CREATE INDEX [IX_FK_AspNetUserRatingLog]
ON [dbo].[RatingLogs]
    ([AspNetUserId]);
GO

-- Creating foreign key on [ActivityId] in table 'RatingLogs'
ALTER TABLE [dbo].[RatingLogs]
ADD CONSTRAINT [FK_RatingLogActivity]
    FOREIGN KEY ([ActivityId])
    REFERENCES [dbo].[Activities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RatingLogActivity'
CREATE INDEX [IX_FK_RatingLogActivity]
ON [dbo].[RatingLogs]
    ([ActivityId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------