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
    public partial class AddDishItemForm : Form
    {
        public Dish dish;
        public byte dishAmount = 1;
        public AddDishItemForm(Dish dish)
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.dish = dish;

            lblDish.Text = dish.name;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DishItem dishItem = new DishItem()
            {
                amount = dishAmount,
                totalPrice = dishAmount * dish.price,
                idDish = dish.idDish,
                dishName = dish.name
            };

            MenuForm.dishItems.Add(dishItem);
            this.Close();
        }

        private void numAmount_ValueChanged(object sender, EventArgs e)
        {
            dishAmount = (byte)numAmount.Value;

        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblDish.ForeColor = LoginForm.theme.fontColor;
            label1.ForeColor = LoginForm.theme.fontColor;
            numAmount.ForeColor = LoginForm.theme.fontColor;
            btnAdd.BackColor = LoginForm.theme.accentColor;
            btnAdd.ForeColor = LoginForm.theme.fontColor;
        }
    }
}
