-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[usp_DeleteVehicle] 
	-- Add the parameters for the stored procedure here
	@Id int

AS
BEGIN
	
	--Delete vehicle only if it is not in records
	IF NOT EXISTS(SELECT Id FROM Record WHERE VehicleId = @Id)
		BEGIN
			DELETE FROM Vehicle WHERE Id = @Id;
		END

END