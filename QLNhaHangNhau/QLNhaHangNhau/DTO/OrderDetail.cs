using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class OrderDetail
    {
        public int ID { get; set; }
        public int TableDetailID { get; set; }

        public int FoodID { get; set; } 

        public TimeSpan TimeOrder { get; set; }

        public int Count { get; set; }

        public OrderDetail(int id, int tableDetailID, int foodID, TimeSpan timeOrder, int count)
        {
            this.ID = id;
            this.TableDetailID = tableDetailID;
            this.FoodID = foodID;
            this.TimeOrder = timeOrder;
            this.Count = count;
        }

        public OrderDetail(DataRow row)
        {
            this.ID = (int)row["id"];
            this.TableDetailID = (int)row["ChiTietBanID"];
            this.FoodID = (int)row["MonAnID"];
            this.TimeOrder = (TimeSpan)row["ThoiGianOrder"];
            this.Count = (int)row["SoLuong"];
        }
    }
}
