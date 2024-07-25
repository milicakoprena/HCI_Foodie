using Foodie.Database;
using Foodie.Model;
using Foodie.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodie
{
    public partial class OrdersForm : Form
    {
        private List<Order> allOrders = new List<Order>();
        public OrdersForm()
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            FillDataGridView();
            dataGridViewOrders.CellClick += DataGridViewOrders_CellClick;
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            dataGridViewOrders.ForeColor = LoginForm.theme.fontColor;

            btnFilter.ForeColor = LoginForm.theme.fontColor;
            btnFilter.BackColor = LoginForm.theme.accentColor;

            btnResetFilter.ForeColor = LoginForm.theme.fontColor;
            btnResetFilter.BackColor = LoginForm.theme.accentColor;
        }
        private void DataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewOrders.Rows[e.RowIndex];

                Order selectedOrder = (Order)selectedRow.DataBoundItem;

                OrderInfo orderInfo = new OrderInfo(selectedOrder);
                orderInfo.ShowDialog();
            }
        }

        void FillDataGridView()
        {
            dataGridViewOrders.AutoGenerateColumns = false;
            allOrders = DB_Foodie.GetOrders();
            dataGridViewOrders.DataSource = allOrders;


            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "idOrder";
            idColumn.Name = "OrderId";
            idColumn.HeaderText = Resources.id;
            idColumn.DefaultCellStyle.Format = "000000";

            dataGridViewOrders.Columns.Add(idColumn);


            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.DataPropertyName = "orderTime";
            timeColumn.Name = "OrderTime";
            timeColumn.HeaderText = Resources.orderTime;
            timeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewOrders.Columns.Add(timeColumn);


            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "totalPrice";
            priceColumn.Name = "TotalPrice";
            priceColumn.HeaderText = Resources.totalPrice;
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewOrders.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn employeeColumn = new DataGridViewTextBoxColumn();
            employeeColumn.DataPropertyName = "employee";
            employeeColumn.Name = "Employee";
            employeeColumn.HeaderText = Resources.employee;
            dataGridViewOrders.Columns.Add(employeeColumn);

            dataGridViewOrders.Columns["OrderId"].Width = 70;
            dataGridViewOrders.Columns["TotalPrice"].Width = 160;
            dataGridViewOrders.Columns["Employee"].Width = 140;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {

            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            if (startDate < endDate)
            {
                List<Order> filteredOrders = DB_Foodie.FilterOrdersByDate(startDate, endDate);
                dataGridViewOrders.DataSource = filteredOrders;
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(Resources.dateNotif);
                customMessageBox.ShowDialog();
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            dataGridViewOrders.DataSource = allOrders;
        }
    }
}
