using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;


namespace MaintenanceDesk
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboardData();
        }
        private void LoadDashboardData()
        {
            lblUsersCount.Text = GetCount("SELECT COUNT(*) FROM Users").ToString();
            lblTechCount.Text = GetCount("SELECT COUNT(*) FROM Technicians").ToString();
            lblReqCount.Text = GetCount("SELECT COUNT(*) FROM Requests").ToString();
            lblWarehouseCount.Text = GetCount("SELECT COUNT(*) FROM Warehouses").ToString();
            lblPartsCount.Text = GetCount("SELECT COUNT(*) FROM Parts").ToString();
            lblPaymentsCount.Text = GetCount("SELECT COUNT(*) FROM Payments").ToString();

            FillPieChart();
            FillBarChart();
            LoadRecentRequests();
        }

        private int GetCount(string query)
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void FillPieChart()
        {
            pieChart.Series.Clear();
            pieChart.Titles.Clear();
            pieChart.Titles.Add("Requests by Status");

            Series series = new Series
            {
                Name = "Requests",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie
            };

            pieChart.Series.Add(series);

            using (MySqlConnection conn = connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT Status, COUNT(*) AS Count FROM Requests GROUP BY Status";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    series.Points.AddXY(reader["Status"].ToString(), Convert.ToInt32(reader["Count"]));
                }
            }
        }

        private void FillBarChart()
        {
            barChart.Series.Clear();
            barChart.Titles.Clear();
            barChart.Titles.Add("Payments by Month");

            Series series = new Series
            {
                Name = "Payments",
                ChartType = SeriesChartType.Column
            };

            barChart.Series.Add(series);

            using (MySqlConnection conn = connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT DATE_FORMAT(PaymentDate, '%b') AS Month, SUM(Amount) AS Total FROM Payments GROUP BY Month ORDER BY MONTH(PaymentDate)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    series.Points.AddXY(reader["Month"].ToString(), Convert.ToDecimal(reader["Total"]));
                }
            }
        }

        private void LoadRecentRequests()
        {
            using (MySqlConnection conn = connection.GetConnection())
            {
                conn.Open();
                string query = "SELECT RequestID, Title, Status, CreatedDate FROM Requests ORDER BY CreatedDate DESC LIMIT 10";
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvRecentRequests.DataSource = dt;
            }
        }

    }
}
