-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_SaveVehicle] 
	-- Add the parameters for the stored procedure here
	@Id int,
	@BrandId int,
	@BrandModelId int,
	@ChassisNumber int,
	@MotorNumber int,
	@MotorPower float,
	@MotorPower_Hp float,
	@FuelTypeId int,
	@YearOfProduction int

AS
BEGIN
	
	IF (@Id < 1)
	--Insert new vehicle
		BEGIN
			INSERT INTO Vehicle VALUES(@BrandId, @BrandModelId, @ChassisNumber, @MotorNumber, 
					@MotorPower, @FuelTypeId, @YearOfProduction, 1, @MotorPower_Hp)
		END
	ELSE
	--Edit existing vehicle
		BEGIN
			UPDATE Vehicle SET BrandId = @BrandId, BrandModelld = @BrandModelId, 
				ChassisNumber = @ChassisNumber, MotorNumber = @MotorNumber, MotorPower_Hp = @MotorPower_Hp,
				FuelTypeId = @FuelTypeId, YearOfProduction = @YearOfProduction WHERE Id = @Id;
		END

END