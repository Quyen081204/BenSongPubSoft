using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class BillDAO
    {
        private static BillDAO instance = null;

        public static BillDAO GetInstance()
        {
            if (instance == null)
                instance = new BillDAO();
            
            return instance;
        }
        private BillDAO() { }

        public int CreateBillCash(Bill bill)
        {
            string query = """
                INSERT INTO HoaDon (NhanVienID, ChiTietBanID, PTThanhToan, TongTien, Discount, Status)
                VALUES (@nhanvien_id,@tabledetail_id,@payment_method,@total_price,@discount,@status)   
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@nhanvien_id", bill.EmployeeID);
            cmd.Parameters.AddWithValue("@tabledetail_id", bill.TableDetailID);
            cmd.Parameters.AddWithValue("@payment_method", bill.PaymentMethod);
            cmd.Parameters.AddWithValue("@total_price", bill.Total_price);
            cmd.Parameters.AddWithValue("@discount", bill.Discount);
            cmd.Parameters.AddWithValue("@status", bill.Status);

            int rowAffected = DataProvider.Instance.ExecuteNonQuery(cmd);
            if (rowAffected > 0)
            {
                Console.WriteLine("== Insert bill successfully");
            }
            else
            {
                Console.WriteLine("== Insert bill fail");
            }
            return rowAffected;
        }


    }
}
