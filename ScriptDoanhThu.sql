
USE QLQuanNhau
GO

-- Hien thi doanh thu trong ngay
-- SoHD - Thoi gian - Nhan Vien - Giam Gia - Tong tien - Ban

-- hd (nhan vien, ngay) -> chiTietban -> ban

CREATE PROC DoanhThu 
(@fromDate DATETIME, @toDate DATETIME)
AS
BEGIN
	SELECT HoaDon.id AS [Mã HĐ], HoaDon.ThoiGianLap AS [Thời gian], NhanVien.ten AS [Nhân viên], HoaDon.Discount AS [Giảm giá], HoaDon.TongTien AS [Tổng tiền], Ban.TenBan AS [Tên bàn]
	FROM HoaDon, ChiTietBan, NhanVien, Ban
	WHERE HoaDon.Status = 1 AND HoaDon.ChiTietBanID = ChiTietBan.id 
	  AND HoaDon.NhanVienID = NhanVien.id 
	  AND ChiTietBan.BanID = Ban.id
	  AND HoaDon.ThoiGianLap >= @fromDate
	  AND HoaDon.ThoiGianLap <= @toDate
END

go
exec DoanhThu '2025-04-1', '2025-04-30'
go
