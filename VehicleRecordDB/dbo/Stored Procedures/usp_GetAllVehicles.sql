-- =============================================
-- Author:	
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_GetAllVehicles] 

AS
BEGIN
	
	SELECT v.Id, b.Id AS 'BrandId', b.BrandName, bm.Id AS 'BrandModelId', bm.ModelName, 
			v.ChassisNumber, v.MotorNumber, v.MotorPower, v.MotorPower_Hp, ft.Id AS 'FuelTypeId', 
			ft.TypeName, v.YearOfProduction, v.CanBeDeleted FROM Vehicle v
	LEFT JOIN Brand b ON b.Id = v.BrandId
	LEFT JOIN BrandModel bm ON bm.Id = v.BrandModelld
	LEFT JOIN FuelType ft ON ft.Id = v.FuelTypeId

	SELECT Id, BrandName FROM Brand

	SELECT Id, BrandId, ModelName FROM BrandModel

	SELECT Id, TypeName FROM FuelType

END