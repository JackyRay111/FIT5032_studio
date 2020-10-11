CREATE TABLE [dbo].[Activities] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [ActivityName]        NVARCHAR (MAX) NOT NULL,
    [ActivityStartDate]   DATE           NOT NULL,
    [ActivityDuration]    INT  NOT NULL,
    [ActivityDescription] NVARCHAR (MAX) NOT NULL,
    [ActivityStatus]      NVARCHAR (MAX) NOT NULL,
    [ActivityRating]      INT            NOT NULL,
    [ActivityTypeId]      INT            NOT NULL,
    [ActivityPlaceId]     INT            NOT NULL,
	[ActivityCategoryId] INT            NOT NULL,
    CONSTRAINT [PK_Activities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ActivityActivityPlace] FOREIGN KEY ([ActivityPlaceId]) REFERENCES [dbo].[ActivityPlaces] ([Id]),
	CONSTRAINT [FK_ActivityActivityType] FOREIGN KEY ([ActivityTypeId]) REFERENCES [dbo].[ActivityTypes] ([Id]),
	CONSTRAINT [FK_ActivityCategoryActivity] FOREIGN KEY ([ActivityCategoryId]) REFERENCES [dbo].[ActivityCategories] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_FK_ActivityActivityType]
    ON [dbo].[Activities]([ActivityTypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_FK_ActivityActivityPlace]
    ON [dbo].[Activities]([ActivityPlaceId] ASC);

GO
CREATE NONCLUSTERED INDEX [IX_FK_ActivityType]
    ON [dbo].[Activities]([ActivityCategoryId] ASC);

