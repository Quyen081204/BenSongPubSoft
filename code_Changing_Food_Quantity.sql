USE QLQuanNhau
GO

SELECT * FROM OrderMon WHERE ChiTietBanID = 10
SELECT * FROM MonAn
GO

CREATE PROC AddFoodForATable(
	@tableDetailID int, @foodID int, @sl int
)
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM OrderMon WHERE ChiTietBanID = @tableDetailID AND MonAnID = @foodID)
	BEGIN
		INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) 
		VALUES (@tableDetailID, @foodID, @sl)
	END
	ELSE 
	BEGIN
		UPDATE OrderMon
		SET SoLuong = SoLuong + @sl
		WHERE ChiTietBanID = @tableDetailID AND MonAnID = @foodID
	END
END
GO

EXEC AddFoodForATable 10, 2, 2
EXEC AddFoodForATable 10, 18, 2

GO

CREATE PROC ReduceFoodForATable(
	@tableDetailID int, @foodID int, @sl int
)
AS
BEGIN
	Declare @quantity int;
	SELECT @quantity = SoLuong FROM OrderMon WHERE ChiTietBanID = @tableDetailID AND MonAnID = @foodID
	
	-- Table havent ordered that food yet
	IF @quantity IS NULL
	BEGIN;
		THROW 50001, 'Bàn hiện tại chưa đặt món cần giảm', 1
	END;
	-- If @sl > SoLuong then it will be a bug 
	IF @sl > @quantity
	BEGIN;
		THROW 50002, 'Số lượng món giảm vượt quá số lượng hiện tại', 1;
	END;
	
	UPDATE OrderMon
	SET SoLuong = SoLuong - @sl
	WHERE ChiTietBanID = @tableDetailID AND MonAnID = @foodID
END
GO

EXEC ReduceFoodForATable 10,3 , 2
EXEC ReduceFoodForATable 10, 18, 3

GO

SELECT ChiTietBanID, TenMonAn
FROM OrderMon, ChiTietBan, MonAn 
WHERE OrderMon.ChiTietBanID = ChiTietBan.id AND OrderMon.MonAnID = MonAn.id AND ChiTietBanID = 10



DELETE OrderMon WHERE ChiTietBanID = 10 and MonAnID = 15

SELECT * FROM Ban
SELECT * FROM MonAn
SELECT * FROM OrderMon










