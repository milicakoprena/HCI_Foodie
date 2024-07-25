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
    public partial class AddGroceriesItemForm : Form
    {
        public Groceries selectedGroceries {  get; set; }
        public byte amount = 1;
        public AddGroceriesItemForm(Groceries selectedGroceries)
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.selectedGroceries = selectedGroceries;

            this.lblGroceries.Text = selectedGroceries.name;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           GroceriesItem item = new GroceriesItem()
            {
                amount = amount,
                totalPrice = amount * selectedGroceries.price,
                idGroceries = selectedGroceries.idGroceries,
                groceriesName = selectedGroceries.name
            };

            AddOrderForm.groceriesItems.Add(item);
            this.Close();
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblGroceries.ForeColor = LoginForm.theme.fontColor;
            label1.ForeColor = LoginForm.theme.fontColor;
            numAmount.ForeColor = LoginForm.theme.fontColor;
            btnAdd.BackColor = LoginForm.theme.accentColor;
            btnAdd.ForeColor = LoginForm.theme.fontColor;
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            amount = (byte)numAmount.Value;
        }

       
    }
}
