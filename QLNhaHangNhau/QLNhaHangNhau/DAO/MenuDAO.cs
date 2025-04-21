using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new MenuDAO();
            }

            return instance;
        }

        private MenuDAO() { }

        public List<Menu> GetListMenu()
        {
            string query = "SELECT * FROM Menu";
            SqlCommand cmd = new SqlCommand(query);
            DataTable dt = DataProvider.Instance.ExecuteQuery(cmd);
            List<Menu> listMenu = new List<Menu>(); 
            foreach(DataRow row in dt.Rows)
            {
                Menu menu = new Menu(row);
                listMenu.Add(menu);
            }
            return listMenu;
        }
    }
}
