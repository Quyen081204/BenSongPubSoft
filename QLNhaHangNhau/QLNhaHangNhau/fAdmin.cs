using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq.Expressions;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using QLNhaHangNhau.DAO;
using QLNhaHangNhau.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNhaHangNhau
{
    public partial class fAdmin : Form
    {
        private BindingSource foodList = new BindingSource();
        private BindingSource menuListBindingSource = new BindingSource();
        private BindingSource accountListBindingSource = new BindingSource();
        private BindingSource employeeListBindingSource = new BindingSource();
        private BindingSource roleListBindingSource = new BindingSource();
        private BindingSource tableListBindingSource = new BindingSource();
        private DataTable foodDataSource;

        private BindingList<Menu> listMenu; // Su dung binding list de neu co thay doi trong list -> binding source -> control
        private BindingList<Account> listAccount; // Su dung binding list de neu co thay doi trong list -> binding source -> control
        private BindingList<Employee> listEmployee;
        private BindingList<Role> listRole;
        private BindingList<Table> listTable;
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        #region methods 
        private void Load()
        {
            LoadDateTimePickerBill();
            LoadIncome(dtpkFromDate.Value, dtpkToDate.Value);
            LoadFood();
            LoadMenu();
            LoadAccount();
            LoadRole();
            LoadEmployee();
            LoadTable();
            AddBindings();
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
        private void LoadFood()
        {
            foodDataSource = FoodDAO.GetInstance().GetAllFood();
            foodList.DataSource = foodDataSource;

            ReLoadCbMenu_of_Food();
            cbFoodProperties.DataSource = new List<string> { "Tên món", "Gía bán", "Tình trạng" };
        }
        private void LoadMenu()
        {
            listMenu = new BindingList<Menu>(MenuDAO.GetInstance().GetListMenuAdmin());
            menuListBindingSource.DataSource = listMenu;

            LoadMenuToComboBox(cbFood_Menu);
            LoadMenuToComboBox(cbAdd_Food_Menu);
        }

        private void LoadEmployee()
        {
            listEmployee = new BindingList<Employee>(EmployeeDAO.GetInstance().GetAllEmployeeAdmin());
            employeeListBindingSource.DataSource = listEmployee;
            // Nap du lieu cho chuc vu combobox
            LoadDataToCbEmployeeRole();
            cbEmployeeSex.DataSource = new List<string> { "Nam", "Nữ" };
            cbEmploySex.DataSource = cbEmployeeSex.DataSource;
        }

        private void LoadDataToCbEmployeeRole()
        {
            cbEmployRole.DataSource = RoleDAO.GetInstance().GetAllRole();
            cbEmployRole.DisplayMember = "Name";
            cbRoleEmploy.DataSource = cbEmployRole.DataSource;
            cbRoleEmploy.DisplayMember = "Name";
        }

        private void LoadAccount()
        {
            listAccount = new BindingList<Account>(AccountDAO.Instance.GetAllAccountAdmin());
            accountListBindingSource.DataSource = listAccount;
        }

        private void LoadRole()
        {
            listRole = new BindingList<Role>(RoleDAO.GetInstance().GetAllRole());
            roleListBindingSource.DataSource = listRole;
        }

        private void LoadTable()
        {
            listTable = new BindingList<Table>(TableDAO.Instance.LoadTableList());
            tableListBindingSource.DataSource = listTable;
        }
        private void ReLoadCbMenu_of_Food()
        {
            List<string> listNameMenu = MenuDAO.GetInstance().GetNameOfMenu();
            listNameMenu.Add("All");
            cbMenu_Of_Food.DataSource = listNameMenu;
        }
        private void AddBindings()
        {
            // Food
            dtgvListFood.DataSource = foodList;
            txbIDFood.DataBindings.Add(new Binding("Text", foodList, "id"));
            txbFoodName.DataBindings.Add(new Binding("Text", foodList, "Tên món"));
            txbFoodPrice.DataBindings.Add(new Binding("Text", foodList, "Gía bán"));
            txbFoodStatus.DataBindings.Add(new Binding("Text", foodList, "Tình trạng"));

            // Menu
            dtgvListMenu.DataSource = menuListBindingSource;
            dtgvListMenu.Columns["ID"].DisplayIndex = 0;
            dtgvListMenu.Columns["ID"].HeaderText = "id";
            dtgvListMenu.Columns["Name"].HeaderText = "Loại menu";
            dtgvListMenu.Columns["Active"].HeaderText = "Tình trạng";
            // Biding textbox of menu
            txbMenuID.DataBindings.Add(new Binding("Text", menuListBindingSource, "ID"));
            txbMenuName.DataBindings.Add(new Binding("Text", menuListBindingSource, "Name"));
            txbMenuStatus.DataBindings.Add(new Binding("Text", menuListBindingSource, "Active"));

            // Account
            dtgvAcc.DataSource = accountListBindingSource;
            dtgvAcc.Columns["ID"].HeaderText = "id";
            dtgvAcc.Columns["Active"].HeaderText = "Trạng thái";
            dtgvAcc.Columns["Employee"].HeaderText = "Nhân viên";

            txbAccID.DataBindings.Add(new Binding("Text", accountListBindingSource, "ID"));
            txbAccUsername.DataBindings.Add(new Binding("Text", accountListBindingSource, "Username"));
            txbAccPass.DataBindings.Add(new Binding("Text", accountListBindingSource, "Password"));
            txbAccStatus.DataBindings.Add(new Binding("Text", accountListBindingSource, "Active"));

            // Employee
            dtgvListEmploy.DataSource = employeeListBindingSource;
            dtgvListEmploy.Columns["ID"].HeaderText = "id";
            dtgvListEmploy.Columns["Name"].HeaderText = "Họ và tên";
            dtgvListEmploy.Columns["GioiTinh"].HeaderText = "Giới tính";
            dtgvListEmploy.Columns["Role"].HeaderText = "Chức vụ";
            dtgvListEmploy.Columns["JoinedDate"].HeaderText = "Ngày bắt đầu làm";
            dtgvListEmploy.Columns["Sex"].Visible = false;
            dtgvListEmploy.Columns["RoleID"].Visible = false;

            txbEmployID.DataBindings.Add(new Binding("Text", employeeListBindingSource, "ID"));
            txbEmployName.DataBindings.Add(new Binding("Text", employeeListBindingSource, "Name"));
            dtpkEmployStartDate.DataBindings.Add(new Binding("Value", employeeListBindingSource, "JoinedDate"));

            // Role
            dtgvRole.DataSource = roleListBindingSource;
            dtgvRole.Columns["ID"].HeaderText = "id";
            dtgvRole.Columns["Name"].HeaderText = "Tên chức vụ";

            txbRoleID.DataBindings.Add(new Binding("Text", roleListBindingSource, "ID"));
            txbRoleName.DataBindings.Add(new Binding("Text", roleListBindingSource, "Name"));

            // Table
            dtgvTable.DataSource = tableListBindingSource;
            dtgvTable.Columns["ID"].HeaderText = "id";
            dtgvTable.Columns["Name"].HeaderText = "Tên bàn";
            dtgvTable.Columns["Capacity"].HeaderText = "Sức chứa";
            dtgvTable.Columns["Status"].Visible = false;
            dtgvTable.Columns["TableDetailID"].Visible = false;

            txbTableID.DataBindings.Add(new Binding("Text", tableListBindingSource, "ID"));
            txbTableName.DataBindings.Add(new Binding("Text", tableListBindingSource, "Name"));
            numCus.DataBindings.Add(new Binding("Value", tableListBindingSource, "Capacity"));
        }

        private void LoadMenuToComboBox(ComboBox cb)
        {
            cb.DataSource = MenuDAO.GetInstance().GetListMenu();
            cb.DisplayMember = "Name";
        }

        private bool CheckTextOrDigit(string verifyText)
        {
            return verifyText.All(c => char.IsLetterOrDigit(c) || c == ' ');
        }

        private bool CheckTextOnly(string verifyText)
        {
            return verifyText.All(c => char.IsLetter(c) || c == ' ');
        }
        private bool CheckOnlyDigit(string verifytext)
        {
            Console.WriteLine(verifytext);
            return verifytext.All(c => char.IsDigit(c));
        }

        private void UpdateCbFoodParentForm()
        {
            // Upadate lai cb food tren form table manager
            fTableManager parentForm = (fTableManager)this.Owner;
            parentForm.ReloadCbFood();
        }

        private void UpdateCbMenuParentForm()
        {
            // Upadate lai cb food tren form table manager
            fTableManager parentForm = (fTableManager)this.Owner;
            parentForm.ReloadCbMenu();
        }

        private void ReloadFoodDataSource()
        {
            foodDataSource = FoodDAO.GetInstance().GetAllFood();
            foodList.DataSource = foodDataSource;
        }
        private void UpdateAccInParentForm(Account newAcc)
        {
            // Upadate lai cb food tren form table manager
            fTableManager parentForm = (fTableManager)this.Owner;
            parentForm.ReloadCurrentAdmin(newAcc);
        }

        private void AddTableInParentForm(Table newTable)
        {
            // Upadate lai man hinh ban tren form table manager
            fTableManager parentForm = (fTableManager)this.Owner;
            parentForm.ReloadAddNewTable(newTable);
        }

        #endregion


        #region event
        // page Doanh thu
        private void btnViewIncome_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpkFromDate.Value;
            DateTime toDate = dtpkToDate.Value;
            LoadIncome(fromDate, toDate);
        }

        //

        // Page MonAn
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            int idFood = int.Parse(txbIDFood.Text);
            string name = txbFoodName.Text;
            int menuID = ((Menu)cbFood_Menu.SelectedItem).ID;

            if (CheckTextOrDigit(name) && CheckOnlyDigit(txbFoodPrice.Text))
            {
                double price = double.Parse(txbFoodPrice.Text);
                bool result = FoodDAO.GetInstance().UpdateFood(idFood, name, price, menuID);

                if (result)
                {
                    // Update in datasouce
                    // Lấy dòng hiện tại
                    DataRowView currentRow = (DataRowView)foodList.Current;
                    currentRow["Menu"] = ((Menu)cbFood_Menu.SelectedItem).Name;

                    // Upadate lai cb food tren form table manager
                    fTableManager parentForm = (fTableManager)this.Owner;
                    parentForm.ReloadCbFood();

                    MessageBox.Show("Update thành công", "Thông báo");
                }
                else
                    MessageBox.Show("Update thất bại", "Thông báo");
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra dữ liệu nhập", "Thông báo");
            }

        }
        private void btnXemFood_Click(object sender, EventArgs e)
        {
            LoadFood();
        }
        private void txbIDFood_TextChanged(object sender, EventArgs e)
        {
            Console.WriteLine("===== TEXT CHANGE ====");
            if (int.TryParse(txbIDFood.Text, out int idFood))
            {
                Food food = FoodDAO.GetInstance().GetFoodById(idFood);

                for (int i = 0; i < cbFood_Menu.Items.Count; i++)
                {
                    var menu = (Menu)cbFood_Menu.Items[i];

                    if (menu.ID == food.MenuID)
                    {
                        cbFood_Menu.SelectedIndex = i;
                        return;
                    }
                }
            }
        }
        private void btnStopSellingFood_Click(object sender, EventArgs e)
        {
            int idFood = int.Parse(txbIDFood.Text);
            if (FoodDAO.GetInstance().StopSellingFood(idFood))
            {
                // Lấy dòng hiện tại
                DataRowView currentRow = (DataRowView)foodList.Current;
                currentRow["Tình trạng"] = "Ngưng bán";
                txbFoodStatus.Text = "Ngưng bán";

                // Lấy ra dòng trong data table gốc ứng với dòng đang được thay đổi
                DataRow? rowDt = foodDataSource.AsEnumerable().FirstOrDefault(row => row.Field<int>("id") == idFood);
                if (rowDt != null)
                {
                    rowDt["Tình trạng"] = "Ngưng bán";
                }

                // Upadate lai cb food tren form table manager
                fTableManager parentForm = (fTableManager)this.Owner;
                parentForm.ReloadCbFood();

                MessageBox.Show("Thay đổi tình trạng món ăn thành công", "Thông báo");
            }
            else
                MessageBox.Show("Thay đổi tình trạng món ăn thất bại", "Thông báo");
        }
        private void btnReSellingFood_Click(object sender, EventArgs e)
        {
            int idFood = int.Parse(txbIDFood.Text);
            if (FoodDAO.GetInstance().ReSellingFood(idFood))
            {
                // Lấy dòng hiện tại
                DataRowView currentRow = (DataRowView)foodList.Current;
                currentRow["Tình trạng"] = "Đang bán";
                txbFoodStatus.Text = "Đang bán";

                // Lấy ra dòng trong data table gốc ứng với dòng đang được thay đổi
                DataRow? rowDt = foodDataSource.AsEnumerable().FirstOrDefault(row => row.Field<int>("id") == idFood);
                if (rowDt != null)
                {
                    rowDt["Tình trạng"] = "Đang bán";
                }

                // Upadate lai cb food tren form table manager
                fTableManager parentForm = (fTableManager)this.Owner;
                parentForm.ReloadCbFood();

                MessageBox.Show("Thay đổi tình trạng món ăn thành công", "Thông báo");
            }
            else
                MessageBox.Show("Thay đổi tình trạng món ăn thất bại", "Thông báo");
        }
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            // Reset with full data table
            foodList.DataSource = foodDataSource;

            string menu = cbMenu_Of_Food.SelectedItem?.ToString();
            string prop = cbFoodProperties.SelectedItem.ToString();
            string keyword = txbSearchFood.Text?.ToString();
            DataTable dt = foodList.DataSource as DataTable;

            DataTable filterDataTable = FoodDAO.GetInstance().SearchFoodByKeyWord(menu, prop, keyword, dt);
            foodList.DataSource = filterDataTable;
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (CheckTextOrDigit(txbAddFoodName.Text) && CheckOnlyDigit(txbAddFoodPrice.Text))
            {
                Menu selectedMenu = cbAdd_Food_Menu.SelectedItem as Menu;
                double price = double.Parse(txbAddFoodPrice.Text);

                Food newFood = FoodDAO.GetInstance().CreateFood(txbAddFoodName.Text, price, selectedMenu.ID);

                // Add new row to data table food data source
                DataRow newRow = foodDataSource.NewRow();
                newRow["id"] = newFood.ID;
                newRow["Tên món"] = newFood.Name;
                newRow["Gía bán"] = newFood.Price;
                newRow["Menu"] = MenuDAO.GetInstance().GetMenuById(newFood.MenuID).Name;
                newRow["Tình trạng"] = newFood.Active;
                foodDataSource.Rows.Add(newRow);

                // Update parent form
                UpdateCbFoodParentForm();

                MessageBox.Show("Tạo món mới thành công", "Thông báo");

            }
            else
            {
                MessageBox.Show("Có lỗi !!!", "Thông báo");
            }
        }
        private void btnCancelAddFood_Click(object sender, EventArgs e)
        {

        }

        //

        // Page Menu

        private void btnEditMenu_Click(object sender, EventArgs e)
        {
            if (txbMenuName.Text != "")
            {
                // Update in database because in data binding allow sync control -> object (sync between controls)
                if (MenuDAO.GetInstance().UpdateMenuById(menuListBindingSource.Current as Menu))
                {
                    UpdateCbMenuParentForm();
                    // Update in page of Food
                    ReloadFoodDataSource();
                    LoadMenuToComboBox(cbFood_Menu);
                    LoadMenuToComboBox(cbAdd_Food_Menu);

                    MessageBox.Show("Update menu thành công", "Thông báo");
                }
                else
                    MessageBox.Show("Update menu thất bại", "Thông báo");
            }

        }
        private void btnStopMenu_Click(object sender, EventArgs e)
        {
            // Update in GUI
            Menu currentMenu = menuListBindingSource.Current as Menu;
            if (currentMenu != null)
            {
                txbMenuStatus.Text = "Ngưng bán";
                currentMenu.Active = "Ngưng bán";

                // Update in database
                if (MenuDAO.GetInstance().UpdateMenuById(currentMenu))
                {
                    // Update in table Food the food belong to menu will be deactived
                    MenuDAO.GetInstance().DeactiveFoodBelongToMenuId(currentMenu.ID);
                    // Update in parent form
                    UpdateCbMenuParentForm();
                    // Update in page Food
                    ReLoadCbMenu_of_Food();
                    ReloadFoodDataSource();
                    LoadMenuToComboBox(cbFood_Menu);
                    LoadMenuToComboBox(cbAdd_Food_Menu);

                    MessageBox.Show("Đã dừng bán menu", "Thông báo");
                }
                else
                    MessageBox.Show("Dừng bán thất bại", "Thông báo");
            }
        }
        private void btnReSellingMenu_Click(object sender, EventArgs e)
        {
            // Update in GUI
            Menu currentMenu = menuListBindingSource.Current as Menu;
            if (currentMenu != null)
            {
                txbMenuStatus.Text = "Đang bán";
                currentMenu.Active = "Đang bán";

                // Update in database
                if (MenuDAO.GetInstance().UpdateMenuById(currentMenu))
                {
                    // Update in table Food the food belong to menu will be actived
                    MenuDAO.GetInstance().ActiveFoodBelongToMenuId(currentMenu.ID);
                    // Update in parent form
                    UpdateCbMenuParentForm();
                    // Update in page Food
                    ReLoadCbMenu_of_Food();
                    ReloadFoodDataSource();
                    LoadMenuToComboBox(cbFood_Menu);
                    LoadMenuToComboBox(cbAdd_Food_Menu);
                    MessageBox.Show("Đã bán lại menu", "Thông báo");
                }
                else
                    MessageBox.Show("Bán lại thất bại", "Thông báo");
            }
        }
        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            if (txbAddMenuName.Text != "")
            {
                Menu newMenu = MenuDAO.GetInstance().CreateMenu(txbAddMenuName.Text);
                // Add to binding list
                listMenu.Add(newMenu);
                // Update in cbSearchFoodMenu ...
                ReLoadCbMenu_of_Food();
                // Update in parent form
                UpdateCbMenuParentForm();
                // Update in page Food
                LoadMenuToComboBox(cbFood_Menu);
                LoadMenuToComboBox(cbAdd_Food_Menu);
            }
        }
        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            if (txbSearchMenu.Text != "")
            {
                var listFilterMenu = listMenu.Where(m => m.Name.Contains(txbSearchMenu.Text)).ToList();
                menuListBindingSource.DataSource = listFilterMenu;
            }
            else
                menuListBindingSource.DataSource = listMenu;
        }

        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            if (txbAccUsername.Text != "")
            {
                // Update GUI
                Account currentAcc = accountListBindingSource.Current as Account;
                currentAcc.Username = txbAccUsername.Text;

                // Update database
                if (AccountDAO.Instance.UpdateUsernameAccount(currentAcc.ID, currentAcc.Username))
                {
                    // If current acc is Admin then update in the parent form
                    UpdateAccInParentForm(currentAcc);

                    MessageBox.Show("Update username account thành công", "Thông báo");
                }
                else
                    MessageBox.Show("Update username account thất bại", "Thông báo");
            }
        }

        private void btnActivateAcc_Click(object sender, EventArgs e)
        {
            Account currentAcc = accountListBindingSource.Current as Account;
            if (currentAcc != null)
            {
                currentAcc.Active = "Đang hoạt động";
                txbAccStatus.Text = "Đang hoạt động";

                if (AccountDAO.Instance.ActiveAccount(currentAcc.ID))
                {
                    MessageBox.Show("Kích hoạt tài khoản thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Kích hoạt tài khoản thất bại", "Thông báo");
                }
            }
        }

        private void btnDeactivateAcc_Click(object sender, EventArgs e)
        {
            Account currentAcc = accountListBindingSource.Current as Account;
            if (currentAcc != null)
            {
                currentAcc.Active = "Ngưng hoạt động";
                txbAccStatus.Text = "Ngưng hoạt động";

                if (AccountDAO.Instance.DeactiveAccount(currentAcc.ID))
                {
                    MessageBox.Show("Ngưng tài khoản thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Ngưng tài khoản thất bại", "Thông báo");
                }
            }
        }

        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            if (txbSearchAcc.Text != "")
            {
                var listFilterAcc = listAccount.Where(acc => acc.Username.Contains(txbSearchAcc.Text)).ToList();
                accountListBindingSource.DataSource = listFilterAcc;
            }
            else
                accountListBindingSource.DataSource = listAccount;
        }

        // Page NhanVien
        private void txbEmployID_TextChanged(object sender, EventArgs e)
        {
            Employee currentEmployee = employeeListBindingSource.Current as Employee;

            if (currentEmployee != null)
            {
                // Binding sex and role
                cbEmployeeSex.SelectedItem = currentEmployee.Sex == 1 ? "Nam" : "Nữ";

                for (int i = 0; i < cbRoleEmploy.Items.Count; i++)
                {
                    var role = (Role)cbRoleEmploy.Items[i];

                    if (role.ID == currentEmployee.RoleID)
                    {
                        cbRoleEmploy.SelectedIndex = i;
                        return;
                    }
                }
            }
        }

        private void btnEditEmploy_Click(object sender, EventArgs e)
        {
            Role selectedRole = cbRoleEmploy.SelectedItem as Role;

            Employee currentEmployee = employeeListBindingSource.Current as Employee;

            if (currentEmployee != null)
            {
                currentEmployee.RoleID = selectedRole.ID;
                currentEmployee.Role = selectedRole;

                // Update in database
                if (EmployeeDAO.GetInstance().UpdateRoleOfEmployee(currentEmployee.Id, currentEmployee.RoleID))
                {
                    MessageBox.Show("Upadte chức vụ thành công", "Thông báo");
                }
                else
                    MessageBox.Show("Upadte chức vụ thất bại", "Thông báo");

            }
        }

        private void btnSearchEmploy_Click(object sender, EventArgs e)
        {
            if (txbSearchEmploy.Text != "")
            {
                var listFilterEmploy = listEmployee.Where(e => e.Name.Contains(txbSearchEmploy.Text)).ToList();
                employeeListBindingSource.DataSource = listFilterEmploy;
            }
            else
                employeeListBindingSource.DataSource = listEmployee;
        }

        private void btnAddEmploy_Click(object sender, EventArgs e)
        {
            string firstName = txbEmAddFirstName.Text;
            string lastName = txbEmAddLastName.Text;
            string userName = txbEmAddUsername.Text;
            string pass = txbEmAddEmployPass.Text;
            if (firstName != "" && lastName != "" && userName != "" && pass != "")
            {
                if (CheckTextOnly(firstName) && CheckTextOnly(lastName) && userName.All(c => char.IsLetterOrDigit(c)))
                {
                    if (AccountDAO.Instance.CheckExistUserName(userName))
                    {
                        MessageBox.Show("Username đã tồn tại !!!", "Thông báo");
                        return;
                    }
                    Role selectedRole = cbEmployRole.SelectedItem as Role;
                    string fullName = firstName + " " + lastName;
                    int sex = cbEmploySex.SelectedItem.ToString() == "Nam" ? 1 : 0;
                    DateTime date = DateTime.Now;
                    // Create employee
                    int idEm = EmployeeDAO.GetInstance().CreateEmployee(firstName, lastName, sex, selectedRole.ID, date);
                    Employee newEm = new Employee(idEm, fullName, sex, selectedRole.ID, date);
                    newEm.Role = selectedRole;
                    listEmployee.Add(newEm);
                    // Create Account
                    int newAccId = AccountDAO.Instance.CreateAccount(userName, pass, idEm);
                    Account newAccount = AccountDAO.Instance.GetAccountById(newAccId);
                    if (newAccount != null)
                    {
                        listAccount.Add(newAccount);
                        MessageBox.Show("Tạo nhân viên thành công", "Thông báo");
                    }
                    else
                        MessageBox.Show("Tạo nhân viên thất bại", "Thông báo");
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo");
        }

        // Page Chuc Vu
        private void btnEditRole_Click(object sender, EventArgs e)
        {
            if (txbRoleName.Text != "")
            {
                Role currentRole = roleListBindingSource.Current as Role;
                if (currentRole != null)
                {
                    if (CheckTextOrDigit(txbRoleName.Text))
                    {
                        currentRole.Name = txbRoleName.Text;
                        if (RoleDAO.GetInstance().UpdateRole(currentRole.ID, currentRole.Name))
                        {
                            LoadDataToCbEmployeeRole();
                            MessageBox.Show("Update chức vụ", "Thông báo");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            if (txbAddRole.Text != "")
            {
                if (CheckTextOrDigit(txbAddRole.Text))
                {
                    int idNewRole = RoleDAO.GetInstance().CreateRole(txbAddRole.Text);
                    Role newRole = new Role(idNewRole, txbAddRole.Text);
                    listRole.Add(newRole);
                    LoadDataToCbEmployeeRole();
                    MessageBox.Show("Thêm chức vụ thành công", "Thông báo");
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đủ thông tin", "Thông báo");
        }

        private void btnSearchRole_Click(object sender, EventArgs e)
        {
            if (txbSearchRole.Text != "")
            {
                var filterListRole = listRole.Where(r => r.Name.Contains(txbSearchRole.Text)).ToList();
                roleListBindingSource.DataSource = filterListRole;
            }
            else
                roleListBindingSource.DataSource = listRole;
        }

        // Page Ban
        private void btnSearchTable_Click(object sender, EventArgs e)
        {
            if (txbSearchTable.Text != "")
            {
                var filterListTable = listTable.Where(t => t.Name.Contains(txbSearchTable.Text)).ToList();
                tableListBindingSource.DataSource = filterListTable;
            }
            else
                tableListBindingSource.DataSource = listTable;
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (txbAddTableName.Text != "")
            {
                if (CheckTextOrDigit(txbAddTableName.Text))
                {
                    int capacity = (int)numCusTableAdd.Value;
                    int idNewTable = TableDAO.Instance.CreateTable(txbAddTableName.Text, capacity);

                    // Update in page Table
                    Table newTable = new Table(idNewTable, txbAddTableName.Text, capacity);
                    listTable.Add(newTable);

                    // Update in parent form
                    AddTableInParentForm(newTable);

                    // Reset 
                    txbAddTableName.Text = "";
                    numCusTableAdd.Value = numCusTableAdd.Minimum;

                    MessageBox.Show($"Thêm {newTable.Name} thành công", "Thông báo");
                }
            }
            else
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo");
        }

        #endregion
    }
}