using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class Food
    {
        public string Name { get; set; }
        public int ID { get; set; }
        
        public int MenuID { get; set; }
        public double Price { get; set; }

        public string Active { get; set; } = "Đang bán";
        public Food() { }
        public Food(int id, string name,int menuID ,double price)
        {
            this.ID = id;
            this.Name = name;
            this.MenuID = menuID;
            this.Price = price;
        }

        public Food(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["TenMonAn"].ToString();
            this.MenuID = (int)row["MenuID"];
            this.Price = (double)row["GiaBan"];
        }
    }
}
