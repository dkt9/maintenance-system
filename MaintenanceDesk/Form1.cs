using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceDesk
{
    public partial class Login : Form
    {


        private void Login_Load(object sender, EventArgs e)
        {

        }
        public Login()
        {
            InitializeComponent();
        }
        private string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private void ClearInputFields()
        {
            txtEmail.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

     

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in both fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string encryptedPassword = EncryptPassword(password);

            try
            {
                string connStr = "server=localhost;user=root;database=maintenancesystem;password=;";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    string query = "SELECT FullName, Role FROM Users WHERE Email = @Email AND Password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", encryptedPassword);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // ✅ Save user details into Session
                                Session.FullName = reader["FullName"].ToString();
                                Session.Role = reader["Role"].ToString();

                                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                ClearInputFields();
                                this.Hide();

                                if (Session.Role == "Admin")
                                {
                                    AdminDashboard adminForm = new AdminDashboard();
                                    adminForm.Show();
                                }
                                else if (Session.Role == "staff")
                                {
                                    Staff staffForm = new Staff();
                                    staffForm.Show();
                                }
                                else
                                {
                                    MessageBox.Show("Unknown role. Please contact support.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Show();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void LnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                ResetPasswordForm resetForm = new ResetPasswordForm();
                resetForm.ShowDialog();
            }

        private void Label1_Click(object sender, EventArgs e)
        {
            RegisterForm r = new RegisterForm();
            this.Hide();
            r.Show();
        }

        private void Guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2HtmlLabel3_Click(object sender, EventArgs e)
        {

        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void Guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}