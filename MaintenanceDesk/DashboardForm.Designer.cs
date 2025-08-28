namespace MaintenanceDesk
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.mainPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.headerPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelUsers = new System.Windows.Forms.Panel();
            this.panelTech = new System.Windows.Forms.Panel();
            this.panelWare = new System.Windows.Forms.Panel();
            this.panelReq = new System.Windows.Forms.Panel();
            this.panelParts = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panelPay = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUsersCount = new System.Windows.Forms.Label();
            this.lblTechCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblReqCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblWarehouseCount = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblPartsCount = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblPaymentsCount = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.barChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bottomPanel = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dgvRecentRequests = new System.Windows.Forms.DataGridView();
            this.Refresh = new Guna.UI2.WinForms.Guna2Button();
            this.pieChar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.mainPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelUsers.SuspendLayout();
            this.panelTech.SuspendLayout();
            this.panelWare.SuspendLayout();
            this.panelReq.SuspendLayout();
            this.panelParts.SuspendLayout();
            this.panelPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).BeginInit();
            this.bottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mainPanel.Controls.Add(this.bottomPanel);
            this.mainPanel.Controls.Add(this.splitContainer1);
            this.mainPanel.Controls.Add(this.flowLayoutPanel1);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.FillColor = System.Drawing.SystemColors.WindowFrame;
            this.mainPanel.FillColor2 = System.Drawing.Color.Yellow;
            this.mainPanel.FillColor3 = System.Drawing.SystemColors.WindowFrame;
            this.mainPanel.FillColor4 = System.Drawing.SystemColors.WindowFrame;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1374, 598);
            this.mainPanel.TabIndex = 0;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.panel6);
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.FillColor = System.Drawing.Color.YellowGreen;
            this.headerPanel.FillColor2 = System.Drawing.SystemColors.ActiveBorder;
            this.headerPanel.FillColor3 = System.Drawing.SystemColors.WindowFrame;
            this.headerPanel.FillColor4 = System.Drawing.SystemColors.WindowFrame;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1374, 66);
            this.headerPanel.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tempus Sans ITC", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(607, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            this.label1.UseMnemonic = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.panelUsers);
            this.flowLayoutPanel1.Controls.Add(this.panelTech);
            this.flowLayoutPanel1.Controls.Add(this.panelReq);
            this.flowLayoutPanel1.Controls.Add(this.panelWare);
            this.flowLayoutPanel1.Controls.Add(this.panelParts);
            this.flowLayoutPanel1.Controls.Add(this.panelPay);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 66);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1374, 130);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panelUsers
            // 
            this.panelUsers.Controls.Add(this.lblUsersCount);
            this.panelUsers.Controls.Add(this.label2);
            this.panelUsers.Location = new System.Drawing.Point(3, 3);
            this.panelUsers.Name = "panelUsers";
            this.panelUsers.Size = new System.Drawing.Size(180, 100);
            this.panelUsers.TabIndex = 0;
            // 
            // panelTech
            // 
            this.panelTech.Controls.Add(this.lblTechCount);
            this.panelTech.Controls.Add(this.label5);
            this.panelTech.Location = new System.Drawing.Point(189, 3);
            this.panelTech.Name = "panelTech";
            this.panelTech.Size = new System.Drawing.Size(180, 100);
            this.panelTech.TabIndex = 1;
            // 
            // panelWare
            // 
            this.panelWare.Controls.Add(this.lblWarehouseCount);
            this.panelWare.Controls.Add(this.label8);
            this.panelWare.Location = new System.Drawing.Point(561, 3);
            this.panelWare.Name = "panelWare";
            this.panelWare.Size = new System.Drawing.Size(180, 100);
            this.panelWare.TabIndex = 1;
            // 
            // panelReq
            // 
            this.panelReq.Controls.Add(this.lblReqCount);
            this.panelReq.Controls.Add(this.label6);
            this.panelReq.Location = new System.Drawing.Point(375, 3);
            this.panelReq.Name = "panelReq";
            this.panelReq.Size = new System.Drawing.Size(180, 100);
            this.panelReq.TabIndex = 1;
            // 
            // panelParts
            // 
            this.panelParts.Controls.Add(this.lblPartsCount);
            this.panelParts.Controls.Add(this.label10);
            this.panelParts.Location = new System.Drawing.Point(747, 3);
            this.panelParts.Name = "panelParts";
            this.panelParts.Size = new System.Drawing.Size(180, 100);
            this.panelParts.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Location = new System.Drawing.Point(950, 66);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(180, 100);
            this.panel6.TabIndex = 1;
            // 
            // panelPay
            // 
            this.panelPay.Controls.Add(this.lblPaymentsCount);
            this.panelPay.Controls.Add(this.label12);
            this.panelPay.Location = new System.Drawing.Point(933, 3);
            this.panelPay.Name = "panelPay";
            this.panelPay.Size = new System.Drawing.Size(180, 100);
            this.panelPay.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Users";
            // 
            // lblUsersCount
            // 
            this.lblUsersCount.AutoSize = true;
            this.lblUsersCount.Location = new System.Drawing.Point(64, 65);
            this.lblUsersCount.Name = "lblUsersCount";
            this.lblUsersCount.Size = new System.Drawing.Size(16, 17);
            this.lblUsersCount.TabIndex = 4;
            this.lblUsersCount.Text = "0";
            // 
            // lblTechCount
            // 
            this.lblTechCount.AutoSize = true;
            this.lblTechCount.Location = new System.Drawing.Point(66, 65);
            this.lblTechCount.Name = "lblTechCount";
            this.lblTechCount.Size = new System.Drawing.Size(16, 17);
            this.lblTechCount.TabIndex = 5;
            this.lblTechCount.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Technicians";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Requests";
            // 
            // lblReqCount
            // 
            this.lblReqCount.AutoSize = true;
            this.lblReqCount.Location = new System.Drawing.Point(60, 65);
            this.lblReqCount.Name = "lblReqCount";
            this.lblReqCount.Size = new System.Drawing.Size(16, 17);
            this.lblReqCount.TabIndex = 7;
            this.lblReqCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(64, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Warehouses";
            // 
            // lblWarehouseCount
            // 
            this.lblWarehouseCount.AutoSize = true;
            this.lblWarehouseCount.Location = new System.Drawing.Point(64, 65);
            this.lblWarehouseCount.Name = "lblWarehouseCount";
            this.lblWarehouseCount.Size = new System.Drawing.Size(16, 17);
            this.lblWarehouseCount.TabIndex = 9;
            this.lblWarehouseCount.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(59, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 17);
            this.label10.TabIndex = 10;
            this.label10.Text = "Parts";
            // 
            // lblPartsCount
            // 
            this.lblPartsCount.AutoSize = true;
            this.lblPartsCount.Location = new System.Drawing.Point(59, 65);
            this.lblPartsCount.Name = "lblPartsCount";
            this.lblPartsCount.Size = new System.Drawing.Size(16, 17);
            this.lblPartsCount.TabIndex = 11;
            this.lblPartsCount.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(60, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Payments";
            // 
            // lblPaymentsCount
            // 
            this.lblPaymentsCount.AutoSize = true;
            this.lblPaymentsCount.Location = new System.Drawing.Point(60, 65);
            this.lblPaymentsCount.Name = "lblPaymentsCount";
            this.lblPaymentsCount.Size = new System.Drawing.Size(16, 17);
            this.lblPaymentsCount.TabIndex = 13;
            this.lblPaymentsCount.Text = "0";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.splitContainer1.Location = new System.Drawing.Point(0, 196);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pieChar);
            this.splitContainer1.Panel1.Controls.Add(this.pieChart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.barChart);
            this.splitContainer1.Size = new System.Drawing.Size(1374, 300);
            this.splitContainer1.SplitterDistance = 565;
            this.splitContainer1.TabIndex = 2;
            // 
            // pieChart
            // 
            this.pieChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            chartArea2.Name = "ChartArea1";
            this.pieChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.pieChart.Legends.Add(legend2);
            this.pieChart.Location = new System.Drawing.Point(128, 0);
            this.pieChart.Name = "pieChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.pieChart.Series.Add(series2);
            this.pieChart.Size = new System.Drawing.Size(284, 581);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "chart1";
            // 
            // barChart
            // 
            chartArea3.Name = "ChartArea1";
            this.barChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.barChart.Legends.Add(legend3);
            this.barChart.Location = new System.Drawing.Point(3, 3);
            this.barChart.Name = "barChart";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.barChart.Series.Add(series3);
            this.barChart.Size = new System.Drawing.Size(792, 207);
            this.barChart.TabIndex = 0;
            this.barChart.Text = "chart1";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.Refresh);
            this.bottomPanel.Controls.Add(this.dgvRecentRequests);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 412);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1374, 186);
            this.bottomPanel.TabIndex = 3;
            // 
            // dgvRecentRequests
            // 
            this.dgvRecentRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecentRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecentRequests.Location = new System.Drawing.Point(0, 0);
            this.dgvRecentRequests.Name = "dgvRecentRequests";
            this.dgvRecentRequests.ReadOnly = true;
            this.dgvRecentRequests.RowTemplate.Height = 26;
            this.dgvRecentRequests.Size = new System.Drawing.Size(1374, 186);
            this.dgvRecentRequests.TabIndex = 0;
            // 
            // Refresh
            // 
            this.Refresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Refresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Refresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Refresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Refresh.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Refresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Refresh.ForeColor = System.Drawing.Color.White;
            this.Refresh.Location = new System.Drawing.Point(0, 141);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(1374, 45);
            this.Refresh.TabIndex = 1;
            this.Refresh.Text = "Refresh";
            // 
            // pieChar
            // 
            chartArea1.Name = "ChartArea1";
            this.pieChar.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pieChar.Legends.Add(legend1);
            this.pieChar.Location = new System.Drawing.Point(0, 0);
            this.pieChar.Name = "pieChar";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.pieChar.Series.Add(series1);
            this.pieChar.Size = new System.Drawing.Size(300, 300);
            this.pieChar.TabIndex = 1;
            this.pieChar.Text = "chart1";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 598);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.mainPanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panelUsers.ResumeLayout(false);
            this.panelUsers.PerformLayout();
            this.panelTech.ResumeLayout(false);
            this.panelTech.PerformLayout();
            this.panelWare.ResumeLayout(false);
            this.panelWare.PerformLayout();
            this.panelReq.ResumeLayout(false);
            this.panelReq.PerformLayout();
            this.panelParts.ResumeLayout(false);
            this.panelParts.PerformLayout();
            this.panelPay.ResumeLayout(false);
            this.panelPay.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barChart)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecentRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2CustomGradientPanel mainPanel;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel headerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panelUsers;
        private System.Windows.Forms.Label lblUsersCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTech;
        private System.Windows.Forms.Label lblTechCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelReq;
        private System.Windows.Forms.Label lblReqCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelWare;
        private System.Windows.Forms.Label lblWarehouseCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelParts;
        private System.Windows.Forms.Label lblPartsCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panelPay;
        private System.Windows.Forms.Label lblPaymentsCount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChart;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel bottomPanel;
        private System.Windows.Forms.DataVisualization.Charting.Chart barChart;
        private System.Windows.Forms.DataGridView dgvRecentRequests;
        private Guna.UI2.WinForms.Guna2Button Refresh;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChar;
    }
}