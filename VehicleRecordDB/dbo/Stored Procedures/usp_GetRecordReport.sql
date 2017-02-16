-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetRecordReport] 
	-- Add the parameters for the stored procedure here
	@VehicleId int,
	@DateFrom datetime,
	@TimeFrom time,
	@DateTo datetime,
	@TimeTo time
AS
BEGIN
	
	SELECT r.Id, r.DateFrom, r.DateTo, r.LocationFrom, r.LocationTo, r.DriverName, 
		r.DriverSurname, r.NumberOfPassangers, s.StatusName FROM Record r
	LEFT JOIN [Status] s ON s.Id = r.StatusId
	WHERE VehicleId = @VehicleId AND (DateFrom >= @DateFrom OR (DateFrom >= @DateFrom AND TimeFrom > @TimeFrom)) 
			AND (DateTo <= @DateTo OR (DateTo = @DateTo AND TimeTo <= @TimeTo))

		SELECT v.Id, b.Id AS 'BrandId', b.BrandName, bm.Id AS 'BrandModelId', bm.ModelName, 
			v.ChassisNumber, v.MotorNumber, v.MotorPower, v.MotorPower_Hp, ft.Id AS 'FuelTypeId', 
			ft.TypeName, v.YearOfProduction, v.CanBeDeleted FROM Vehicle v
	LEFT JOIN Brand b ON b.Id = v.BrandId
	LEFT JOIN BrandModel bm ON bm.Id = v.BrandModelld
	LEFT JOIN FuelType ft ON ft.Id = v.FuelTypeId

END