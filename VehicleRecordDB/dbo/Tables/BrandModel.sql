CREATE TABLE [dbo].[BrandModel] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [BrandId]   INT          NOT NULL,
    [ModelName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id])
);

