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
    public partial class ViewReceiptForm : Form
    {
        public double totalPrice {  get; set; }
        public ViewReceiptForm()
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            FillDataGridView();
            totalPrice = MenuForm.dishItems.Sum(item => item.totalPrice);
            lblTotalPrice.Text = Resources.totalReceiptPrice + ": " + totalPrice.ToString() + " KM";

        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            dataGridViewDishItems.ForeColor = LoginForm.theme.fontColor;
            lblTotalPrice.ForeColor = LoginForm.theme.fontColor;
            btnReceipt.ForeColor = LoginForm.theme.fontColor;
            btnReceipt.BackColor = LoginForm.theme.accentColor;
        }

        public void FillDataGridView()
        {
            dataGridViewDishItems.AutoGenerateColumns = false;
            dataGridViewDishItems.DataSource = MenuForm.dishItems;


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

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            var insert = DB_Foodie.InsertReceiptWithDishItems(totalPrice, MenuForm.dishItems);
            string notif = insert ? Resources.receiptSuccess : Resources.receiptFail; 
            MenuForm.dishItems.Clear();
            this.Close();
            CustomMessageBox cmb = new CustomMessageBox(notif);
            cmb.ShowDialog();
        }

        private void dataGridViewDishItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && MenuForm.dishItems.Count > 0)
            {
                DialogResult result = MessageBox.Show(Resources.deleteItem, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    DishItem selectedItem = (DishItem)dataGridViewDishItems.Rows[e.RowIndex].DataBoundItem;

                    MenuForm.dishItems.Remove(selectedItem);

                    dataGridViewDishItems.DataSource = null;
                    dataGridViewDishItems.DataSource = MenuForm.dishItems;
                }

            }
        }
    }
}
