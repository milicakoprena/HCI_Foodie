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
using Foodie.Theme;
using System.Collections.ObjectModel;
using System.Configuration;

namespace Foodie
{
    public partial class LoginForm : Form
    {
        public static ThemePicker theme = new ThemePicker();

        public static Employee employee {  get; set; }
        public LoginForm()
        {
            theme.ChooseTheme(1);
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            txtBoxPassword.UseSystemPasswordChar = true;
            

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            employee = DB_Foodie.AuthenticateEmployee(txtBoxUsername.Text, txtBoxPassword.Text);
            if (employee != null)
            {
                if(employee.status == true) {
                    this.Hide();
                    if (employee.idRole == 1)
                    {
                        AdminMenuForm adminMenuForm = new AdminMenuForm();
                        adminMenuForm.ShowDialog();
                    }
                    else if (employee.idRole == 2)
                    {
                        MenuForm menuForm = new MenuForm();
                        menuForm.ShowDialog();
                    }

                    this.Close();
                }
                else
                {
                    CustomMessageBox cmb = new CustomMessageBox(Resources.notifDeact);
                    cmb.ShowDialog();
                }
                
            }

            else
            {
                CustomMessageBox cmb = new CustomMessageBox(Resources.notifWrong);
                cmb.ShowDialog();
            }
            

           

        }

       

        private void showHidePass_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = !txtBoxPassword.UseSystemPasswordChar;
            showHidePass.Image = txtBoxPassword.UseSystemPasswordChar ? Resources.eye : Resources.hidden;
        }

       

        



    }
}
