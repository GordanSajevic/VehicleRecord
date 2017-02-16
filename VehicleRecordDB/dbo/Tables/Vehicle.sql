CREATE TABLE [dbo].[Vehicle] (
    [Id]               INT        IDENTITY (1, 1) NOT NULL,
    [BrandId]          INT        NOT NULL,
    [BrandModelld]     INT        NULL,
    [ChassisNumber]    INT        NOT NULL,
    [MotorNumber]      INT        NOT NULL,
    [MotorPower]       FLOAT (53) NOT NULL,
    [FuelTypeId]       INT        NOT NULL,
    [YearOfProduction] INT        NOT NULL,
    [CanBeDeleted]     BIT        DEFAULT ((1)) NOT NULL,
    [MotorPower_Hp]    FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brand] ([Id]),
    FOREIGN KEY ([BrandModelld]) REFERENCES [dbo].[BrandModel] ([Id]),
    FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[FuelType] ([Id])
);

