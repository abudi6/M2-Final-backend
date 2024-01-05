CREATE PROCEDURE [dbo].[spItems_Delete]
	@Code nvarchar(50)
AS

begin
	set nocount on;
	delete from dbo.Items
	where code = @Code;
end
