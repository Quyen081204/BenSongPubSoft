using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class Menu
    {
        public string Name { get; set; }
        public int ID { get; set;}

        public Menu(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Menu(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["TenMenu"].ToString();
        }
    }
}
