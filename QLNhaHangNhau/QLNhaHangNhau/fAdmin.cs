using System.Data;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNhaHangNhau
{
    public partial class fAdmin : Form
    {
        public fAdmin()
        {
            InitializeComponent();
            LoadDateTimePickerBill();
            LoadIncome(dtpkFromDate.Value, dtpkToDate.Value);
        }

        private void btnViewIncome_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpkFromDate.Value;
            DateTime toDate = dtpkToDate.Value;
            LoadIncome(fromDate, toDate);
        }

        private void LoadIncome(DateTime fromDate, DateTime toDate)
        {
            dtgvIncome.DataSource = BillDAO.GetInstance().ShowInCome(fromDate, toDate);
        }
        private void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
    }
}
