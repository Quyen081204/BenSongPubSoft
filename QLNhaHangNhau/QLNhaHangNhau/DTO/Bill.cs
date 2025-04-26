using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class Bill
    {
        // HoaDon(ID,#MaNV,#ChiTietBanID,GiamGia,ThoiGianLap,PhuongThucThanhToan, TongTien, TrangThai) 
        public int ID { get; set; }
        public int EmployeeID { get; set; }
        public int TableDetailID { get; set; }
        public int Discount { get; set; }
        public string PaymentMethod { get; set; }
        public int Total_price { get; set; }
        public int Status { get; set; }

        public Bill(int employee_id, int tableDetail_id, int discount, string payment_method, int total_price, int status)
        {
            this.EmployeeID = employee_id;
            this.TableDetailID = tableDetail_id;
            this.Discount = discount;
            this.PaymentMethod = payment_method;
            this.Total_price = total_price;
            this.Status = status;
        }
    }
}
