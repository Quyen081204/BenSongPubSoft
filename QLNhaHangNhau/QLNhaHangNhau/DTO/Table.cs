using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLNhaHangNhau.DTO
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Status { get; set; } = 0;

        public int Capacity { get; set; }

        public int? TableDetailID { get; set; } = null;

        public Table(int id, string name, int status, int capacity, int tableDetailID)
        {
            Id = id;
            Name = name;
            Status = status;
            Capacity = capacity;
            TableDetailID = tableDetailID;
        }

        public Table(int id, string name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }   

        public Table(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["TenBan"].ToString();
            this.Status = (int)row["TrangThai"];
            this.Capacity = (int)row["SLChua"];
            this.TableDetailID = Convert.IsDBNull(row["TableDetailID"]) ? null : (int?)row["TableDetailID"];
        }
    }
}
