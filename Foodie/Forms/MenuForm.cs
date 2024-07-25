using Foodie.Database;
using Foodie.Model;
using Foodie.Properties;
using Foodie.Theme;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Foodie
{
    public partial class MenuForm : Form
    {
       

        private string filterCategory;
       
        private List<Dish> allDishes = new List<Dish>();
        public static List<DishItem> dishItems = new List<DishItem>();
        void FillComboBox()
        {
            comboBoxCategoryName.DataSource = DB_Foodie.GetDishCategories();
            comboBoxCategoryName.DisplayMember = "name";
            comboBoxCategoryName.ValueMember = "idDishCategory";
        }

        void FillDataGridView()
        {
            
            dataGridViewDishes.AutoGenerateColumns = false;
            allDishes = DB_Foodie.GetDishes();
            dataGridViewDishes.DataSource = allDishes; 

            
            DataGridViewTextBoxColumn dishNameColumn = new DataGridViewTextBoxColumn();
            dishNameColumn.DataPropertyName = "name";
            dishNameColumn.Name = "DishName";
            dishNameColumn.HeaderText = Resources.dishName;
            dataGridViewDishes.Columns.Add(dishNameColumn);

            DataGridViewTextBoxColumn dishPriceColumn = new DataGridViewTextBoxColumn();
            dishPriceColumn.DataPropertyName = "price";
            dishPriceColumn.Name = "Price";
            dishPriceColumn.HeaderText = Resources.price;
            dataGridViewDishes.Columns.Add(dishPriceColumn);

            DataGridViewTextBoxColumn dishCategoryColumn = new DataGridViewTextBoxColumn();
            dishCategoryColumn.DataPropertyName = "dishCategoryName";
            dishCategoryColumn.Name = "DishCategory";
            dishCategoryColumn.HeaderText = Resources.category;
            dataGridViewDishes.Columns.Add(dishCategoryColumn);

           
            dataGridViewDishes.Columns["DishName"].Width = 210;
            dataGridViewDishes.Columns["DishCategory"].Width = 100;

            dataGridViewDishes.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
           
        }

        public void LoadComponents()
        {
            string cultureName = (LoginForm.employee.language == 1) ? "en" : "sr-Latn-RS";
            CultureInfo culture = new CultureInfo(cultureName);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            InitializeComponent();

            var themeValue = LoginForm.employee.theme;
            var languageValue = LoginForm.employee.language;
            if(languageValue == 1)
            {
                buttonEn.Enabled = false;
            }
            else
            {
                buttonSer.Enabled = false;
            }
            
            LoginForm.theme.ChooseTheme(themeValue);
            UpdateUI();


            FillComboBox();
            FillDataGridView();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            lblEmployeeName.Text = LoginForm.employee.name + " " + LoginForm.employee.surname;

        }

        public MenuForm()
        {
            LoadComponents();
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            panel1.BackColor = LoginForm.theme.accentColor;
            lblEmployeeName.ForeColor = LoginForm.theme.fontColor;
            linkSignOut.LinkColor = LoginForm.theme.fontColor;
            linkLabelReceipts.LinkColor = LoginForm.theme.fontColor;
            lblArticleName.ForeColor = LoginForm.theme.fontColor;
            txtBoxArticleName.ForeColor = LoginForm.theme.fontColor;
            lblCategoryName.ForeColor = LoginForm.theme.fontColor;
            comboBoxCategoryName.ForeColor = LoginForm.theme.fontColor;

            btnFilter.ForeColor = LoginForm.theme.fontColor;
            btnFilter.BackColor = LoginForm.theme.accentColor;

            btnResetFilter.ForeColor = LoginForm.theme.fontColor;
            btnResetFilter.BackColor = LoginForm.theme.accentColor;

            lblReceipt.ForeColor = LoginForm.theme.fontColor;

            pictureBoxRes.Image = LoginForm.theme.restaurant;
            pictureBox.Image = LoginForm.theme.cart;

            dataGridViewDishes.ForeColor = LoginForm.theme.fontColor;

            buttonEn.ForeColor = LoginForm.theme.fontColor;
            buttonEn.BackColor = LoginForm.theme.accentColor;

            buttonSer.ForeColor = LoginForm.theme.fontColor;
            buttonSer.BackColor = LoginForm.theme.accentColor;
        }




        private void txtBoxArticleName_TextChanged(object sender, EventArgs e)
        {
            string name = txtBoxArticleName.Text;


            filterDataGridViewByName(name);
        }

        private void comboBoxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCategoryName.SelectedItem != null)
            {
               
                if (comboBoxCategoryName.SelectedItem is DishCategory selectedCategory)
                {
                    
                    filterCategory = selectedCategory.name;
                }
                else
                {
                   filterCategory = comboBoxCategoryName.SelectedItem.ToString();
                }
            }
            else
            {
                filterCategory = null;
            }
        }


        private void filterDataGridViewByName(string name)
        {
            List<Dish> filteredDishes = allDishes.Where(d => d.name.IndexOf(name, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            dataGridViewDishes.DataSource = filteredDishes;
        }
        private void filterDataGridViewByCategory()
        {
            
            List<Dish> filteredDishes = allDishes.Where(d => d.dishCategoryName == filterCategory).ToList();

            dataGridViewDishes.DataSource = filteredDishes;
     
        }




        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterDataGridViewByCategory();
        }

        

        private void comboBoxCategoryName_TextChanged(object sender, EventArgs e)
        {
            string name = comboBoxCategoryName.Text;

            if (name.Equals(""))
                filterCategory = null;
        }

       

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            dataGridViewDishes.DataSource = allDishes;
        }

       

        private void linkSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }

        private void dataGridViewDishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewDishes.Rows[e.RowIndex];

                Dish selectedDish = (Dish)selectedRow.DataBoundItem;

                AddDishItemForm addDishItemForm = new AddDishItemForm(selectedDish);
                addDishItemForm.ShowDialog();
            }
        }

        private void lblReceipt_Click(object sender, EventArgs e)
        {
            ViewReceiptForm viewReceiptForm = new ViewReceiptForm();
            viewReceiptForm.ShowDialog();
        }

        private void linkLabelReceipts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ReceiptsForm receiptsForm = new ReceiptsForm(LoginForm.employee);
            receiptsForm.ShowDialog();
        }

        private void changeTheme(int themeValue)
        {
            LoginForm.theme.ChooseTheme(themeValue);
            DB_Foodie.UpdateEmployeeTheme(LoginForm.employee.idEmployee, themeValue);
            LoginForm.employee.theme = themeValue;
            UpdateUI();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changeTheme(1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changeTheme(2);
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changeTheme(3);
        }

        private void changeLanguage(int languageValue)
        {
            string language = languageValue == 1 ? "en" : "sr-Latn-RS";
            DB_Foodie.UpdateEmployeeLanguage(LoginForm.employee.idEmployee, languageValue);

            LoginForm.employee.language = languageValue;
            CultureInfo culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            this.Controls.Clear();
            LoadComponents();
        }


        private void buttonEn_Click(object sender, EventArgs e)
        {
            changeLanguage(1);
            buttonEn.Enabled = false;
            buttonSer.Enabled = true;
        }

        private void buttonSer_Click(object sender, EventArgs e)
        {
            changeLanguage(2);
            buttonEn.Enabled = true;
            buttonSer.Enabled = false;
        }
    }
}
