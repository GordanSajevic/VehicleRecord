-- =============================================
-- Author:		Name
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE usp_UpdateRecordStatus 
	-- Add the parameters for the stored procedure here
	@Id int,
	@StatusId int
AS
BEGIN
	
	UPDATE Record SET [StatusId] = @StatusId WHERE Id = @Id;

END