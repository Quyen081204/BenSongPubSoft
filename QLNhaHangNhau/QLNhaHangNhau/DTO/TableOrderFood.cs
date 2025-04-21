using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class TableOrderFood
    {
        public string FoodName { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public double TotalPrice { get; set; }

        public TableOrderFood(string foodName, int count, double price, double totalPrice)
        {
            this.FoodName = foodName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;   
        }

        public TableOrderFood(DataRow row)
        {
            this.FoodName = row["foodName"].ToString();
            this.Count = (int)row["SL"];
            this.Price = (double)row["price"];
            this.TotalPrice = (double)row["totalPrice"];
        }
    }
}
