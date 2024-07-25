using Foodie.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foodie
{
    public partial class AdminMenuForm : Form
    {
        public void LoadComponents()
        {
            string cultureName = (LoginForm.employee.language == 1) ? "en" : "sr-Latn-RS";
            CultureInfo culture = new CultureInfo(cultureName);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            InitializeComponent();
            var themeValue = LoginForm.employee.theme;

            var languageValue = LoginForm.employee.language;
            if (languageValue == 1)
            {
                buttonEn.Enabled = false;
            }
            else
            {
                buttonSer.Enabled = false;
            }

            LoginForm.theme.ChooseTheme(themeValue);
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
        }


        public AdminMenuForm()
        {
            LoadComponents();

        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            label1.ForeColor = LoginForm.theme.fontColor;
            pictureBoxLogo.Image = LoginForm.theme.logo;
            btnAddOrder.ForeColor = LoginForm.theme.fontColor;
            btnEmployees.ForeColor = LoginForm.theme.fontColor;
            btnReceipts.ForeColor = LoginForm.theme.fontColor;
            buttonOrders.ForeColor = LoginForm.theme.fontColor;

            
            btnAddOrder.BackColor = LoginForm.theme.accentColor;
            btnEmployees.BackColor = LoginForm.theme.accentColor;
            btnReceipts.BackColor = LoginForm.theme.accentColor;
            buttonOrders.BackColor = LoginForm.theme.accentColor;

            linkSignOut.LinkColor = LoginForm.theme.fontColor;

            buttonSer.BackColor = LoginForm.theme.accentColor;
            buttonEn.BackColor = LoginForm.theme.accentColor;

            buttonSer.ForeColor = LoginForm.theme.fontColor;
            buttonEn.ForeColor = LoginForm.theme.fontColor;
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeesForm employeesForm = new EmployeesForm();
            employeesForm.ShowDialog();
        }

       

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            ReceiptsForm receiptsForm = new ReceiptsForm();
            receiptsForm.ShowDialog();
        }

        private void buttonOrders_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            ordersForm.ShowDialog();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            AddOrderForm addOrderForm = new AddOrderForm();
            addOrderForm.ShowDialog();
        }

        
        private void linkSignOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
            this.Close();
        }
        private void changeTheme(int themeValue)
        {
            LoginForm.theme.ChooseTheme(themeValue);
            DB_Foodie.UpdateEmployeeTheme(LoginForm.employee.idEmployee, themeValue);
            LoginForm.employee.theme = themeValue;
            UpdateUI();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            changeTheme(1);
        }

        private void buttonSer_Click(object sender, EventArgs e)
        {
            changeLanguage(2);
            buttonEn.Enabled = true;
            buttonSer.Enabled = false;
        }

        private void buttonEn_Click(object sender, EventArgs e)
        {
            changeLanguage(1);
            buttonEn.Enabled = false;
            buttonSer.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            changeTheme(2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            changeTheme(3);
        }
    }
}
