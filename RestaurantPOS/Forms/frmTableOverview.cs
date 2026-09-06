using System;
using System.Drawing;
using System.Windows.Forms;
using RestaurantPOS.Models;
using RestaurantPOS.Services;

namespace RestaurantPOS.Forms
{
    public partial class frmTableOverview : Form
    {
        private readonly TableService _tableService = new TableService();

        public frmTableOverview()
        {
            InitializeComponent();
        }

        private void frmTableOverview_Load(object sender, EventArgs e) => LoadTables();

        private void LoadTables()
        {
            flowTables.Controls.Clear();
            try
            {
                var tables = _tableService.GetTableOverview();
                var search = txtSearch.Text?.Trim();

                foreach (var table in tables)
                {
                    if (!string.IsNullOrWhiteSpace(search) &&
                        table.TableName.IndexOf(search, StringComparison.OrdinalIgnoreCase) < 0)
                        continue;

                    flowTables.Controls.Add(BuildTableCard(table));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load tables:\n" + ex.Message, "Table Overview",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Control BuildTableCard(RestaurantTable table)
        {
            Color backColor = table.Status switch
            {
                "Occupied" => Color.FromArgb(0xFD, 0xEC, 0xEA),
                "Reserved" => Color.FromArgb(0xFF, 0xF6, 0xE0),
                _ => Color.FromArgb(0xEA, 0xF7, 0xEB)
            };
            Color accentColor = table.Status switch
            {
                "Occupied" => Color.FromArgb(0xC6, 0x28, 0x28),
                "Reserved" => Color.FromArgb(0xF9, 0xA8, 0x25),
                _ => Color.FromArgb(0x2E, 0x7D, 0x32)
            };
            string statusIcon = table.Status switch
            {
                "Occupied" => "🔴",
                "Reserved" => "🟡",
                _ => "🟢"
            };

            var panel = new Panel
            {
                Size = new Size(220, 150),
                Margin = new Padding(0, 0, 16, 16),
                BackColor = backColor,
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                Tag = table
            };

            var lblName = new Label
            {
                Text = table.TableName,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Location = new Point(16, 12),
                Size = new Size(188, 28),
                Tag = table
            };
            var lblStatus = new Label
            {
                Text = $"{statusIcon} {table.Status}",
                ForeColor = accentColor,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(16, 44),
                Size = new Size(188, 22),
                Tag = table
            };
            var lblCapacity = new Label
            {
                Text = $"Capacity: {table.Capacity}",
                Location = new Point(16, 70),
                Size = new Size(188, 20),
                Tag = table
            };
            var lblOrder = new Label
            {
                Text = table.ActiveOrderID.HasValue
                    ? $"Order #{table.ActiveOrderID}  •  {table.ActiveGrandTotal:C2}"
                    : "No active order",
                Location = new Point(16, 92),
                Size = new Size(188, 40),
                ForeColor = Color.DimGray,
                Tag = table
            };

            panel.Controls.Add(lblName);
            panel.Controls.Add(lblStatus);
            panel.Controls.Add(lblCapacity);
            panel.Controls.Add(lblOrder);

            // Any click on the card or its children opens the table for ordering.
            EventHandler openHandler = (s, e) => OpenTable(table);
            panel.Click += openHandler;
            foreach (Control c in panel.Controls) c.Click += openHandler;

            return panel;
        }

        private void OpenTable(RestaurantTable table)
        {
            if (table.IsReserved)
            {
                var confirm = MessageBox.Show(
                    $"{table.TableName} is currently reserved. Seat a customer and start an order here?",
                    "Reserved Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;
            }

            using var billing = new frmPOSBilling(table.TableID, table.TableName);
            billing.ShowDialog();
            LoadTables();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) => LoadTables();

        private void btnRefresh_Click(object sender, EventArgs e) => LoadTables();

        private void btnClose_Click(object sender, EventArgs e) => this.Close();
    }
}
