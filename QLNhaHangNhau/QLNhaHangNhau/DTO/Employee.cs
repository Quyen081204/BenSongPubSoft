using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaHangNhau.DAO;

namespace QLNhaHangNhau.DTO
{
    public class Employee
    {
        // NhanVien(MaNV, Ho, Ten, GioiTinh, NamSinh, #MaChucVu , NgayBatDauLam) 3
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public string GioiTinh => Sex == 1 ? "Nam" : "Nữ";
        public int RoleID { get; set;}
        public Role Role { get; set; }
        public DateTime JoinedDate { get; set; }
        public Employee(int id, string name, int sex, int roleID, DateTime joinedDate)
        {
            Id = id;
            Name = name;
            Sex = sex;
            RoleID = roleID;
            JoinedDate = joinedDate;
        }   

        public Employee(DataRow row)
        {
            Id = (int)row["id"];
            Name = $"{row["ho"].ToString()} {row["ten"].ToString()}";
            Sex = (int)row["GioiTinh"];
            RoleID = (int)row["ChucVuID"];
            JoinedDate = (DateTime)row["Joined_date"];
            Role = RoleDAO.GetInstance().GetRoleById((int)row["ChucVuID"]);
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
