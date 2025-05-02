using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Role(int id , string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public Role(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["TenChucVu"].ToString();
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
