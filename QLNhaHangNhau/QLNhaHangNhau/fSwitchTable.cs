using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLNhaHangNhau.DAO;
using QLNhaHangNhau.DTO;

namespace QLNhaHangNhau
{
    public partial class fSwitchTable : Form
    {
        private Color vacantColor = Color.AliceBlue;
        private Color focusColor = SystemColors.ControlLight;
        private Color fullColor = Color.Orange;
        private Button? prevButton = null;
        
        private Table tableSource;
        private Button btnGoWithTableSource;
        
        private List<Table> emptyTables;
        private List<Button> list_button_empty;

        public fSwitchTable()
        {
            InitializeComponent();
        }

        public fSwitchTable(List<Table> emptyTables, List<Button> all_button_empty,Table tableSource, Button btnGoWithTableSource)
        {
            InitializeComponent();
            this.emptyTables = emptyTables;
            this.list_button_empty = all_button_empty;

            this.tableSource = tableSource;
            this.btnGoWithTableSource = btnGoWithTableSource;
            LoadListTable();
        }

        #region method
        private void LoadListTable()
        {
            foreach (Table table in emptyTables)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = table.Name + Environment.NewLine;
                btn.Click += btnTable_click;  // table_clicked is an event
                btn.Tag = table;
                btn.Text += "Trống" + Environment.NewLine;
                btn.Text += $"SL {table.Capacity}";

                btn.BackColor = vacantColor;

                fpnlSwitchTable.Controls.Add(btn);
            }
        }
        #endregion

        #region event
        private void btnTable_click(object? sender, EventArgs e)
        {
            if (prevButton != null)
            {
                prevButton.BackColor = vacantColor;
            }

            Button btn_clicked = sender as Button;
            Table table_des = btn_clicked.Tag as Table;
            prevButton = btn_clicked;
            btn_clicked.BackColor = focusColor;
            btnSwitch.Tag = table_des;
        }

        private void btnSwitch_Click(object sender, EventArgs e)
        {
            Button btnSwitch = sender as Button;
            Table table_des = btnSwitch.Tag as Table;

            if (table_des == null)
            {
                MessageBox.Show("Vui lòng chọn bàn chuyển tới !!!", "Thông báo");
                return;
            }

            // Switch between temp and table_des
            table_des.Status = 1;
            table_des.TableDetailID = tableSource.TableDetailID;


            // Update in database tableSource reset and table_des update status (temp is tableSource)
            TableDAO.Instance.TableStatusReset(tableSource); // also update in GUI temp.Status = 0 ...
            bool result = TableDAO.Instance.UpadateTableStatus(table_des);
            if (result)
            {
                // Update in GUI of main form
                Table tmp = null;
                foreach(Button btn in list_button_empty)
                {
                    tmp = btn.Tag as Table;
                    
                    if (tmp == table_des)
                    {
                        btn.Text = "";
                        btn.Text = table_des.Name + Environment.NewLine;
                        btn.Text += "Có khách";
                        btn.BackColor = fullColor;
                    }
                }

                btnGoWithTableSource.Text = "";
                btnGoWithTableSource.Text = tableSource.Name + Environment.NewLine;
                btnGoWithTableSource.Text += "Trống" + Environment.NewLine;
                btnGoWithTableSource.Text += $"SL {tableSource.Capacity}";
                btnGoWithTableSource.PerformClick();
                

                MessageBox.Show($"Chuyển qua {table_des.Name} thành công", "Thông báo");
                // Close the form switch table
                this.Close();
            }
            else
            {
                MessageBox.Show("Chuyển bàn thất bại !!!", "Thông báo");
            }
        }
        #endregion
    }
}
