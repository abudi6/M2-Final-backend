CREATE PROCEDURE [dbo].[spItems_Insert]
@Name nvarchar (150),
@Code nvarchar (50),
@Brand nvarchar (150),
@UnitPrice decimal(18,2),
@DateAdded datetime2
AS
begin
INSERT INTO dbo.Items

(Name, Code, Brand, UnitPrice, DateAdded)
VALUES

(@Name, @Code, @Brand, @UnitPrice, @DateAdded)
end
