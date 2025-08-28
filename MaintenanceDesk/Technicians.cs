using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
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
    public partial class Technicians : Form
    {
        private int selectedTechId = -1;
        public Technicians()
        {
            InitializeComponent();

            guna2ComboBox1.SelectedIndex = 0;

            LoadTechnicians();
        }
        private void LoadTechnicians(string search = "")
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT TechnicianID, FullName, Specialization, Phone, Status FROM Technicians " +
                               "WHERE FullName LIKE @search OR Specialization LIKE @search";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTechnicians.DataSource = dt;
            }
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Technicians (FullName, Specialization, Phone, Status) VALUES (@FullName, @Specialization, @Phone, @Status)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Status", guna2ComboBox1.Text);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Technician added successfully!");
                LoadTechnicians();
                ClearFields();
            }
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedTechId == -1) return;

            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Technicians SET FullName=@FullName, Specialization=@Specialization, Phone=@Phone, Status=@Status WHERE TechnicianID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Specialization", txtSpecialization.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Status", guna2ComboBox1.Text);
                cmd.Parameters.AddWithValue("@id", selectedTechId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Technician updated successfully!");
                LoadTechnicians();
                ClearFields();
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedTechId == -1) return;

            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Technicians WHERE TechnicianID=@id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", selectedTechId);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Technician deleted successfully!");
                LoadTechnicians();
                ClearFields();
            }
           
        }

        private void dgvTechnicians_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTechnicians.Rows[e.RowIndex];
                selectedTechId = Convert.ToInt32(row.Cells["TechnicianID"].Value);
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtSpecialization.Text = row.Cells["Specialization"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                guna2ComboBox1.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadTechnicians(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtFullName.Clear();
            txtSpecialization.Clear();
            txtPhone.Clear();
            guna2ComboBox1.SelectedIndex = 0;
            selectedTechId = -1;
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            AdminDashboard dashboard = new AdminDashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
