using Foodie.Database;
using Foodie.Model;
using Foodie.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodie
{
    public partial class AddDishForm : Form
    {
        public int selectedCategory = 0;
        public AddDishForm()
        {
            InitializeComponent();
            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            UpdateUI();
            FillComboBox();
        }

        void FillComboBox()
        {
            comboBoxDishCategory.DataSource = DB_Foodie.GetDishCategories();
            comboBoxDishCategory.DisplayMember = "name";
            comboBoxDishCategory.ValueMember = "idDishCategory";
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblDishName.ForeColor = LoginForm.theme.fontColor;
            lblPrice.ForeColor = LoginForm.theme.fontColor;
            lblDishCategory.ForeColor = LoginForm.theme.fontColor;
            txtBoxDishName.ForeColor= LoginForm.theme.fontColor;
            txtBoxPrice.ForeColor= LoginForm.theme.fontColor;
            comboBoxDishCategory.ForeColor= LoginForm.theme.fontColor;
            btnAddDish.BackColor = LoginForm.theme.accentColor;
            btnAddDish.ForeColor = LoginForm.theme.fontColor;
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            if(txtBoxDishName.Text.Length > 0 && txtBoxPrice.Text.Length > 0 && selectedCategory > 0)
            {
                
                Dish dish = new Dish()
                {
                    name = txtBoxDishName.Text,
                    price = double.Parse(txtBoxPrice.Text, CultureInfo.InvariantCulture),
                    idDishCategory = selectedCategory
                };
                bool add = DB_Foodie.InsertDish(dish);
                string notif = add ? Resources.notifAddDishSuc : Resources.notifAddDishFail;
                
                CustomMessageBox customMessageBox = new CustomMessageBox(notif);
                customMessageBox.ShowDialog();
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(Resources.notifMissingData);
                customMessageBox.ShowDialog();
            }
        }

        private void comboBoxDishCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCategory = comboBoxDishCategory.SelectedIndex;
        }
    }
}
