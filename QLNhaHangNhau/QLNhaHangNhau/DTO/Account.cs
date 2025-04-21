using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNhaHangNhau.DAO;

namespace QLNhaHangNhau.DTO
{
    public class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }

        public Account(string username, string password, Employee employee)
        {
            this.Username = username;
            this.Password = password;
            Employee = employee;
        }

        public Account(DataRow row)
        {
            this.Username = row["username"].ToString();
            this.Password = row["password"].ToString();
            this.Employee = EmployeeDAO.GetInstance().GetEmployeeByID((int)row["NhanVienID"]);
        }

        public override string ToString()
        {
            return $"Username: {Username}\n Password: {Password}\nNhanVienID: {Employee.Id}";
        }

    }
}
