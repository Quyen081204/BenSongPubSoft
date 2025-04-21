SELECT TOP (1000) [id]
      ,[ChiTietBanID]
      ,[MonAnID]
      ,[ThoiGianOrder]
      ,[SoLuong]
  FROM [QLQuanNhau].[dbo].[OrderMon]

-- Tao 1 order mon
-- 2, 12, 11, 6, 15 (6), 17 (5)
INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	10, 
	2,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	10, 
	12,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	10, 
	11,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	10, 
	6,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	10, 
	15,
	6
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	10, 
	17,
	5
)



INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	11, 
	11,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	11, 
	6,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	15, 
	15,
	6
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	15, 
	17,
	5
)



INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	12, 
	2,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	14, 
	3,
	1
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	14, 
	1,
	6
)

INSERT INTO OrderMon (ChiTietBanID, MonAnID, SoLuong) VALUES (
	15, 
	18,
	5
)



SELECT TenMonAn as foodName, SoLuong as SL,GiaBan as price, SoLuong * GiaBan as totalPrice
FROM MonAn, OrderMon
WHERE OrderMon.MonAnID = MonAn.id and OrderMon.ChiTietBanID = 15



