CREATE PROCEDURE [dbo].[SetDefaultProductQuantity]
AS
	SELECT *
	FROM FridgeProducts
	WHERE Quantity = 0