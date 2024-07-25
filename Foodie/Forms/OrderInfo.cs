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
    public partial class OrderInfo : Form
    {
        public Order order {  get; set; }
        public OrderInfo(Order order)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.order = order;
            UpdateUI();
            lblId.Text = "Šifra: " + order.idOrder.ToString("D6");

            FillDataGridView();
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblId.ForeColor = LoginForm.theme.fontColor;
            dataGridViewGroceriesItems.ForeColor = LoginForm.theme.fontColor;
        }

        public void FillDataGridView()
        {
            dataGridViewGroceriesItems.AutoGenerateColumns = false;
            dataGridViewGroceriesItems.DataSource = order.groceriesItems;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "groceriesName";
            nameColumn.Name = "GroceriesName";
            nameColumn.HeaderText = Resources.groceriesName;
            dataGridViewGroceriesItems.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn amountColumn = new DataGridViewTextBoxColumn();
            amountColumn.DataPropertyName = "amount";
            amountColumn.Name = "Amount";
            amountColumn.HeaderText = Resources.amount;
            dataGridViewGroceriesItems.Columns.Add(amountColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "totalPrice";
            priceColumn.Name = "Total price";
            priceColumn.HeaderText = Resources.totalPrice;
            dataGridViewGroceriesItems.Columns.Add(priceColumn);

           

            dataGridViewGroceriesItems.Columns["Total price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewGroceriesItems.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


    }
}
