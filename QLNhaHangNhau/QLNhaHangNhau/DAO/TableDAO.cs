using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static int TableWidth = 90;
        public static int TableHeight = 90;
        public static TableDAO Instance 
        { 
          get { if (instance == null) instance = new TableDAO(); return instance; } 
          private set => instance = value; 
        }

        private TableDAO() { }

        public List<Table> LoadTableList()
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_GetTableList");

            List<Table> tableList = new List<Table>();
            foreach (DataRow row in data.Rows) 
            {
                Table table = new Table(row);
                tableList.Add(table);
            }

            return tableList;
        }

        // Update table status after reservation or the customer has paid and leave
        public bool UpadateTableStatus(Table table)
        {
            string query = """
                            UPDATE Ban
                            SET TrangThai = @tableStatus,
                                TableDetailID = @tableDetailID
                            WHERE id = @tableID
                """;
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@tableStatus", table.Status);
            cmd.Parameters.AddWithValue("@tableDetailID", table.TableDetailID);
            cmd.Parameters.AddWithValue("@tableID", table.Id);

            int affectedRow = (int)DataProvider.Instance.ExecuteNonQuery(cmd);

            return affectedRow > 0;
        }
    }
}
