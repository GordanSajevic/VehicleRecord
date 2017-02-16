-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAllRecords] 

AS
BEGIN
	
	SELECT r.Id, r.VehicleId, b.BrandName, bm.ModelName, v.ChassisNumber, ft.Id AS 'FuelTypeId', 
			ft.TypeName, v.MotorNumber, v.MotorPower, v.YearOfProduction, r.DateFrom, r.DateTo, 
			r.TimeFrom, r.TimeTo, r.LocationFrom, r.LocationTo, r.DriverName, r.DriverSurname, 
			r.NumberOfPassangers, s.Id AS 'StatusId', s.StatusName FROM Record r
	LEFT JOIN Vehicle v ON v.Id = r.VehicleId
	LEFT JOIN Brand b ON b.Id = v.BrandId
	LEFT JOIN BrandModel bm ON bm.Id = v.BrandModelld
	LEFT JOIN FuelType ft ON ft.Id = v.FuelTypeId
	LEFT JOIN [Status] s ON s.Id = r.StatusId

	SELECT v.Id, b.Id AS 'BrandId', b.BrandName, bm.Id AS 'BrandModelId', bm.ModelName, 
			v.ChassisNumber, v.MotorNumber, v.MotorPower, v.MotorPower_Hp, ft.Id AS 'FuelTypeId', 
			ft.TypeName, v.YearOfProduction, v.CanBeDeleted FROM Vehicle v
	LEFT JOIN Brand b ON b.Id = v.BrandId
	LEFT JOIN BrandModel bm ON bm.Id = v.BrandModelld
	LEFT JOIN FuelType ft ON ft.Id = v.FuelTypeId

	SELECT Id, StatusName FROM [Status]

END