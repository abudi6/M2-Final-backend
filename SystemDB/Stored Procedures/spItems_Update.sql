CREATE PROCEDURE [dbo].[spItems_Update]
	@Name nvarchar (150),
	@Code nvarchar (50),
	@Brand nvarchar (150),
	@UnitPrice decimal(18,2)
AS

begin
	UPDATE dbo.Items
	SET
		Name = ISNULL(@Name, Name),
		Brand = ISNULL(@Brand, Brand),
		UnitPrice = ISNULL(@UnitPrice,UnitPrice)
	WHERE Code = @Code;
end
