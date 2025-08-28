using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceDesk
{
    public partial class AdminDashboard : Form
    {
        DataTable currentTable;
        public AdminDashboard()
        {
            InitializeComponent();




        }






        private void Guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Guna2HtmlLabel6_Click(object sender, EventArgs e)
        {

        }

        private void Guna2CircleButton1_Click(object sender, EventArgs e)
        {
            DashboardForm f = new DashboardForm();
            this.Hide();
            f.Show();
        }

        private void guna2Panel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel14_Click(object sender, EventArgs e)
        {
            Users u = new Users();
            this.Hide();
            u.Show();
        }

        private void guna2CircleButton16_Click(object sender, EventArgs e)
        {
             
            
            Users u = new Users();
            this.Hide();
            u.Show();
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

            }

        }

        private void guna2Panel3_MouseHover(object sender, EventArgs e)
        {
            LoadUsers();



        }

        private void guna2Panel4_MouseHover(object sender, EventArgs e)
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT TechnicianID, FullName, Specialization, Phone, Status
                 FROM Technicians
                 ORDER BY TechnicianID DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;   
                conn.Close();
            }
        }

        private void guna2Panel5_MouseHover(object sender, EventArgs e)
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT RequestID,	Title,	Description	,Status,	CreatedDate,	CreatedBy,	IsPaid	

                 FROM Requests
                 ORDER BY RequestID DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;   
                conn.Close();
            }
        }

        private void guna2Panel6_MouseHover(object sender, EventArgs e)
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT WarehouseID, Location,  Manager,WarehouseName
                 FROM Warehouses
                 ORDER BY WarehouseID DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
                conn.Close();

            }
        }

        private void guna2Panel8_MouseHover(object sender, EventArgs e)
        {
            using (var conn = connection.GetConnection())
            {
                conn.Open();
                string query = @"SELECT PartID, PartName,  Quantity, WarehouseID
                 FROM Parts
                 ORDER BY PartID DESC";

                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvUsers.DataSource = dt;
                conn.Close();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (currentTable != null)
            {
                DataView dv = new DataView(currentTable);

                string filter = "";
                foreach (DataColumn col in currentTable.Columns)
                {
                    if (filter != "")
                        filter += " OR ";
                    filter += $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{keyword}%'";
                }

                dv.RowFilter = filter;
                dgvUsers.DataSource = dv;
            }

        }

        private void NumUser_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            label1.Text = Session.FullName;

            using (var conn = connection.GetConnection())
            {


                try
                {
                    conn.Open();
                    string query = @"
            SELECT 
              (SELECT COUNT(*) FROM Users) AS UsersCount,
              (SELECT COUNT(*) FROM Technicians) AS TechniciansCount,
              (SELECT COUNT(*) FROM Requests) AS RequestsCount,
              (SELECT COUNT(*) FROM Warehouses) AS WarehousesCount,
              (SELECT COUNT(*) FROM Parts) AS PartsCount";
                

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            NumUser.Text = reader["UsersCount"].ToString();
                            TNum.Text = reader["TechniciansCount"].ToString();
                            RNum.Text = reader["RequestsCount"].ToString();
                            WNum.Text = reader["WarehousesCount"].ToString();
                            Pnum.Text = reader["PartsCount"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void guna2CircleButton10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {
            Technicians technicians = new Technicians();
            this.Hide();
            technicians.Show();
        }

        private void guna2CircleButton17_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton15_Click(object sender, EventArgs e)
        {
            Technicians technicians = new Technicians();
            this.Hide();
            technicians.Show();
        }
    }
}
