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
    public partial class ViewOrderForm : Form
    {
        public double totalPrice { get; set; }
        public ViewOrderForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            UpdateUI();
            FillDataGridView();
            totalPrice = AddOrderForm.groceriesItems.Sum(item => item.totalPrice);
            lblTotalPrice.Text = Resources.totalOrderPrice + ": " + totalPrice.ToString() + " KM";
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            dataGridViewGroceriesItems.ForeColor = LoginForm.theme.fontColor;
            lblTotalPrice.ForeColor = LoginForm.theme.fontColor;
            btnOrder.ForeColor = LoginForm.theme.fontColor;
            btnOrder.BackColor = LoginForm.theme.accentColor;
        }

        public void FillDataGridView()
        {
            dataGridViewGroceriesItems.AutoGenerateColumns = false;
            dataGridViewGroceriesItems.DataSource = AddOrderForm.groceriesItems;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "groceriesName";
            nameColumn.Name = "Name";
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
            dataGridViewGroceriesItems.Columns["Name"].Width = 150;
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            DB_Foodie.InsertOrderWithGroceriesItems(totalPrice, AddOrderForm.groceriesItems);
            AddOrderForm.groceriesItems.Clear();
            this.Close();
        }

        private void dataGridViewGroceriesItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex >= 0 && AddOrderForm.groceriesItems.Count > 0)
            {
                DialogResult result = MessageBox.Show(Resources.deleteItem, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    GroceriesItem selectedItem = (GroceriesItem)dataGridViewGroceriesItems.Rows[e.RowIndex].DataBoundItem;

                    AddOrderForm.groceriesItems.Remove(selectedItem);
                    dataGridViewGroceriesItems.DataSource = null;
                    dataGridViewGroceriesItems.DataSource = AddOrderForm.groceriesItems;
                }

            }
            
        }
    }
}
