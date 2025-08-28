using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceDesk
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
           
        }
        // ✅ Validate Email (Allow only Gmail or Yahoo)
        private bool IsValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@(gmail|yahoo)\.com$");
            return regex.IsMatch(email);
        }

        private bool IsValidPassword(string password)
        {
            bool hasSmallLetter = false;
            bool hasCapitalLetters = false;
            bool hasSymbol = false;
            bool hasNumber = false;
            bool hasMinLength = password.Length >= 8;

            foreach (char c in password)
            {
                if (char.IsLower(c)) hasSmallLetter = true;
                else if (char.IsUpper(c)) hasCapitalLetters = true;
                else if (!char.IsLetterOrDigit(c)) hasSymbol = true;
                else if (char.IsDigit(c)) hasNumber = true;
            }

            return hasSmallLetter && hasCapitalLetters && hasSymbol && hasNumber && hasMinLength;
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
            txtFullName.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

        private void SendConfirmationEmail(string toEmail, string fullName)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("m7m7474@gmail.com");
                message.To.Add(new MailAddress(toEmail));
                message.Subject = "Registration Confirmation";
                message.Body = $"Dear {fullName},\n\nYou have been successfully registered in the Maintenance System.\n\nBest Regards.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("m7m7474@gmail.com", "zwwm lvvc klhe ctrg"); // Replace with Gmail app password
                smtp.EnableSsl = true;

                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Email could not be sent: " + ex.Message);
            }
        }

        private void BtnRegister_Click_1(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string email = txtEmail.Text.Trim();
           

            if (string.IsNullOrWhiteSpace(fullName) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("All fields are required!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidEmailAddress(email))
            {
                MessageBox.Show("Email must be Gmail or Yahoo and end with .com");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Password must be at least 8 characters and include uppercase, lowercase, number, and symbol.");
                return;
            }

            string hashedPassword = EncryptPassword(password);

            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    conn.Open();

                    string query = "INSERT INTO Users (FullName, Username, Password, Email) VALUES (@fullName, @username, @password, @email)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
                        cmd.Parameters.AddWithValue("@email", email);
                       

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("we sent a confirm Message to you");

                SendConfirmationEmail(email, fullName);

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during registration: " + ex.Message);
            }
        }
        private void Guna2HtmlLabel6_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }

        private void Guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}