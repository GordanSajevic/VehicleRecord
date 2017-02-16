-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaveRecord] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@VehicleId int,
	@DateFrom date,
	@TimeFrom time,
	@DateTo datetime,
	@TimeTo time,
	@LocationFrom varchar(50),
	@LocationTo varchar(50),
	@DriverName varchar(50),
	@DriverSurname varchar(50),
	@NumberOfPassangers int,
	@StatusId int
AS
BEGIN
	
	DECLARE @message VARCHAR(100);
	SET @message = '';

		BEGIN
			IF NOT EXISTS(SELECT Id FROM Record WHERE VehicleId = @VehicleId AND 
			((DateFrom > @DateFrom AND DateFrom < @DateTo ) 
			OR (DateFrom <= @DateFrom AND DateTo >= @DateTo )
			OR (DateFrom <= @DateFrom AND DateTo >= @DateFrom) 
			OR (DateFrom >= @DateFrom AND DateTo <= @DateTo)
			OR (DateFrom = @DateFrom AND DateFrom <= @DateTo AND TimeFrom > @TimeFrom)
			OR (DateFrom > @DateFrom AND DateFrom = @DateTo AND TimeFrom < @TimeTo) 
			OR (DateFrom = @DateFrom AND DateTo > @DateTo AND TimeFrom < @TimeFrom)
			OR (DateFrom < @DateFrom AND DateTo = @DateFrom AND TimeTo > @TimeFrom) 
			OR (DateFrom = @DateFrom AND DateTo > @DateFrom AND TimeFrom < @TimeFrom) 
			OR (DateFrom < @DateFrom AND DateTo = @DateFrom AND TimeTo > @TimeFrom) 
			OR (DateFrom = @DateFrom AND DateTo < @DateTo AND TimeFrom > @TimeFrom)
			OR (DateFrom > @DateFrom AND DateTo = @DateTo AND TimeTo < @TimeTo)
			))
				BEGIN
					INSERT INTO Record VALUES (@VehicleId, @DateFrom, @DateTo, @LocationFrom, 
						@LocationTo, @DriverName, @DriverSurname, @NumberOfPassangers, 
						(SELECT Id FROM [Status] WHERE StatusName = 'Evidentiran'), @TimeFrom, @TimeTo)

					UPDATE Vehicle SET CanBeDeleted = 0 WHERE Id = @VehicleId
				END
			ELSE
				BEGIN
					SET @Message = 'Vozilo je zauzeto u zadanom periodu. Molim ponovite unos.'
				END

		END

	SELECT @Message AS 'Message'

END