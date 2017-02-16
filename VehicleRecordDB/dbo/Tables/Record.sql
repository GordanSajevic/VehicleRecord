CREATE TABLE [dbo].[Record] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [VehicleId]          INT          NOT NULL,
    [DateFrom]           DATE         NOT NULL,
    [DateTo]             DATE         NOT NULL,
    [LocationFrom]       VARCHAR (50) NOT NULL,
    [LocationTo]         VARCHAR (50) NOT NULL,
    [DriverName]         VARCHAR (50) NOT NULL,
    [DriverSurname]      VARCHAR (50) NOT NULL,
    [NumberOfPassangers] INT          NOT NULL,
    [StatusId]           INT          NULL,
    [TimeFrom]           TIME (7)     NULL,
    [TimeTo]             TIME (7)     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([StatusId]) REFERENCES [dbo].[Status] ([Id]),
    FOREIGN KEY ([VehicleId]) REFERENCES [dbo].[Vehicle] ([Id])
);

