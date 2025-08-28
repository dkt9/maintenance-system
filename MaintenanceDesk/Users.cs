using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceDesk
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            if (cmbRole.Items.Count == 0)
            {
                cmbRole.Items.Add("Admin");
                cmbRole.Items.Add("staff");
                cmbRole.SelectedIndex = 0;
            }

            LoadUsers();
        }

        private void LoadUsers()
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserID, FullName, Username, Role, Phone, Email
                                 FROM Users
                                 ORDER BY UserID DESC";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
                FormatGrid();
            }
            ClearInputs();
        }

        private void FormatGrid()
        {
            if (dgvUsers.Columns.Count == 0) return;

            dgvUsers.Columns["UserID"].HeaderText = "ID";
            dgvUsers.Columns["FullName"].HeaderText = "Full Name";
            dgvUsers.Columns["Username"].HeaderText = "Username";
            dgvUsers.Columns["Role"].HeaderText = "Role";
            dgvUsers.Columns["Phone"].HeaderText = "Phone";
            dgvUsers.Columns["Email"].HeaderText = "Email";

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.ReadOnly = true; // التعديل من خلال الحقول فقط
        }
       
      

       

     

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {

        }

       
        

        private void DgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        private void ClearInputs()
        {
            txtFullName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cmbRole.SelectedIndex = 0;
        }

        // تحقق الحقول
        private bool ValidateInputs(bool requirePassword)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("Full name, Username, and Role are required.");
                return false;
            }

            if (requirePassword && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password is required.");
                return false;
            }

            return true;
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            if (!ValidateInputs(requirePassword: true)) return;

            using (var conn = connection.GetConnection())
            {
                conn.Open();

                // تأكد أن اسم المستخدم غير مكرر
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@Username";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    long exists = (long)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Username already exists. Choose another one.");
                        return;
                    }
                }

                string insert = @"INSERT INTO Users
                                  (FullName, Username, Password, Role, Phone, Email)
                                  VALUES (@FullName, @Username, @Password, @Role, @Phone, @Email)";
                using (var cmd = new MySqlCommand(insert, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text); // حالياً نص عادي ليتوافق مع كود تسجيل الدخول الحالي
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem?.ToString() ?? "Requester");
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User added successfully.");
            LoadUsers();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update from the table.");
                return;
            }

            // كلمة المرور اختيارية أثناء التعديل: إذا تركتها فاضية لن نغيّرها
            if (!ValidateInputs(requirePassword: false)) return;

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

            using (var conn = connection.GetConnection())
            {
                conn.Open();

                // تحقق من عدم تكرار اسم المستخدم لمستخدم آخر
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username=@Username AND UserID<>@UserID";
                using (var checkCmd = new MySqlCommand(checkQuery, conn))
                {
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    checkCmd.Parameters.AddWithValue("@UserID", userId);
                    long exists = (long)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Username already in use by another user.");
                        return;
                    }
                }

                // نبني الاستعلام حسب إدخال كلمة المرور
                string update;
                if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    update = @"UPDATE Users
                               SET FullName=@FullName, Username=@Username, Password=@Password, Role=@Role, Phone=@Phone, Email=@Email
                               WHERE UserID=@UserID";
                }
                else
                {
                    update = @"UPDATE Users
                               SET FullName=@FullName, Username=@Username, Role=@Role, Phone=@Phone, Email=@Email
                               WHERE UserID=@UserID";
                }

                using (var cmd = new MySqlCommand(update, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", cmbRole.SelectedItem?.ToString() ?? "Requester");
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());

                    if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User updated successfully.");
            LoadUsers();
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.");
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);

            if (MessageBox.Show("Are you sure you want to delete this user?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string delete = "DELETE FROM Users WHERE UserID=@UserID";
                using (var cmd = new MySqlCommand(delete, conn))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User deleted successfully.");
            LoadUsers();
        
    }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadUsers();
                return;
            }

            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT UserID, FullName, Username, Role, Phone, Email
                                 FROM Users
                                 WHERE FullName LIKE @kw OR Username LIKE @kw
                                 ORDER BY UserID DESC";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvUsers.DataSource = dt;
                        FormatGrid();
                    }
                }
            }
        }

        private void dgvUsers_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0) return;

            txtFullName.Text = dgvUsers.SelectedRows[0].Cells["FullName"]?.Value?.ToString();
            txtUsername.Text = dgvUsers.SelectedRows[0].Cells["Username"]?.Value?.ToString();
            txtPhone.Text = dgvUsers.SelectedRows[0].Cells["Phone"]?.Value?.ToString();
            txtEmail.Text = dgvUsers.SelectedRows[0].Cells["Email"]?.Value?.ToString();
            cmbRole.Text = dgvUsers.SelectedRows[0].Cells["Role"]?.Value?.ToString();

            // للحفاظ على الأمان، لا نعرض كلمة المرور. اترك txtPassword فارغًا.
            txtPassword.Clear();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminDashboard dashboard = new AdminDashboard();
            dashboard.Show();
        }
    }
}
