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
    public partial class ReceiptInfo : Form
    {
        public Receipt receipt {  get; set; }
        public ReceiptInfo(Receipt receipt)
        {
            InitializeComponent();
            this.receipt = receipt;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            lblId.Text = "Šifra: " + receipt.idReceipt.ToString("D6");
            UpdateUI();
            FillDataGridView();
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblId.ForeColor = LoginForm.theme.fontColor;
            dataGridViewDishItems.ForeColor = LoginForm.theme.fontColor;
        }

        public void FillDataGridView()
        {
            dataGridViewDishItems.AutoGenerateColumns = false;
            dataGridViewDishItems.DataSource = receipt.dishItems;


            DataGridViewTextBoxColumn dishNameColumn = new DataGridViewTextBoxColumn();
            dishNameColumn.DataPropertyName = "dishName";
            dishNameColumn.Name = "DishName";
            dishNameColumn.HeaderText = Resources.dishName;
            dataGridViewDishItems.Columns.Add(dishNameColumn);

            DataGridViewTextBoxColumn dishNameAmount = new DataGridViewTextBoxColumn();
            dishNameAmount.DataPropertyName = "amount";
            dishNameAmount.Name = "Amount";
            dishNameAmount.HeaderText = Resources.amount;
            dataGridViewDishItems.Columns.Add(dishNameAmount);

            DataGridViewTextBoxColumn dishPriceColumn = new DataGridViewTextBoxColumn();
            dishPriceColumn.DataPropertyName = "totalPrice";
            dishPriceColumn.Name = "Total price";
            dishPriceColumn.HeaderText = Resources.totalPrice;
            dataGridViewDishItems.Columns.Add(dishPriceColumn);


            dataGridViewDishItems.Columns["Total price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewDishItems.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }



    }
}
