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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceDesk
{
    public partial class ResetPasswordForm : Form
    {
        public ResetPasswordForm()
        {
            InitializeComponent();
        }

        private string GenerateRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_-+=";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string EncryptPassword(string newPassword)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(newPassword);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        private void UpdateUserPassword(string email, string newPassword)
        {
            try
            {
                using (MySqlConnection conn = connection.GetConnection())
                {
                    conn.Open();

                    // Check if email exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(checkCmd.ExecuteScalar());

                        if (count == 0)
                        {
                            MessageBox.Show("No account found with this email.");
                            return;
                        }
                    }

                    // Update password
                    string updateQuery = "UPDATE Users SET Password = @NewPassword WHERE Email = @Email";
                    using (MySqlCommand updateCmd = new MySqlCommand(updateQuery, conn))
                    {
                        updateCmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        updateCmd.Parameters.AddWithValue("@Email", email);
                        updateCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Password updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void SendPasswordToEmail(string email, string newPassword)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("m7m7474@gmail.com");
                message.To.Add(new MailAddress(email));
                message.Subject = "Your New Password";
                message.Body = $"Dear user,\n\nYour new password is: {newPassword}\n\nPlease change it after logging in.\n\nBest regards";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential("m7m7474@gmail.com", "zwwm lvvc klhe ctrg"); // App password
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }



        private void BtnResetPassword_Click_1(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            string newPassword = GenerateRandomPassword(10);
            SendPasswordToEmail(email, newPassword);

            string encryptedPassword = EncryptPassword(newPassword);
            UpdateUserPassword(email, encryptedPassword);

            txtEmail.Clear();

        }

        private void Guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}