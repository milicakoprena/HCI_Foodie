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
    public partial class AddEmployeeForm : Form
    {
        private Employee selectedEmployee {  get; set; }
        public DialogResult FormResult { get; private set; }

        public AddEmployeeForm(Employee selectedEmployee)
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.selectedEmployee = selectedEmployee;
            btnAddEmployee.Text = Resources.update;
            txtBoxPassword.UseSystemPasswordChar = true;

            txtBoxFirstName.Text = selectedEmployee.name;
            txtBoxLastName.Text = selectedEmployee.surname;
            txtBoxUsername.Text = selectedEmployee.username;
            txtBoxPassword.Text = selectedEmployee.password;
            txtBoxPhone.Text = selectedEmployee.phoneNumber;

            this.btnAddEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
        }
        public AddEmployeeForm()
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            txtBoxPassword.UseSystemPasswordChar = true;
            btnAddEmployee.Text = Resources.add;
            this.btnAddEmployee.Click += new System.EventHandler(this.btnAddEmployee_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblFirstName.ForeColor = LoginForm.theme.fontColor;
            lblLastName.ForeColor = LoginForm.theme.fontColor;
            lblPassword.ForeColor = LoginForm.theme.fontColor;
            lblPhone.ForeColor = LoginForm.theme.fontColor;
            lblUsername.ForeColor = LoginForm.theme.fontColor;
            txtBoxFirstName.ForeColor= LoginForm.theme.fontColor;
            txtBoxLastName.ForeColor= LoginForm.theme.fontColor;
            txtBoxPassword.ForeColor= LoginForm.theme.fontColor;
            txtBoxPhone.ForeColor= LoginForm.theme.fontColor;
            txtBoxPhone.ForeColor= LoginForm.theme.fontColor;
            showHidePass.Image = txtBoxPassword.UseSystemPasswordChar ? LoginForm.theme.eye : LoginForm.theme.hidden;
            btnAddEmployee.BackColor = LoginForm.theme.accentColor;
            btnAddEmployee.ForeColor = LoginForm.theme.fontColor;
        }


        private void showHidePass_Click(object sender, EventArgs e)
        {
            txtBoxPassword.UseSystemPasswordChar = !txtBoxPassword.UseSystemPasswordChar;
            showHidePass.Image = txtBoxPassword.UseSystemPasswordChar ? Properties.Resources.eye : Properties.Resources.hidden;

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            if(txtBoxFirstName.Text.Length > 0 && txtBoxLastName.Text.Length > 0
                && txtBoxPassword.Text.Length > 0 && txtBoxUsername.Text.Length > 0
                && txtBoxPhone.Text.Length > 0) {
                Employee employee = new Employee()
                {
                    name = txtBoxFirstName.Text,
                    surname = txtBoxLastName.Text,
                    username = txtBoxUsername.Text,
                    password = txtBoxPassword.Text,
                    phoneNumber = txtBoxPhone.Text 
                };

                bool add = DB_Foodie.InsertEmployee(employee);
                string notif = add ? Resources.notifAddEmployeeSuc : Resources.notifAddEmployeeFail;
                FormResult = add ? DialogResult.OK : DialogResult.Cancel;
                CustomMessageBox customMessageBox = new CustomMessageBox(notif);
                customMessageBox.ShowDialog();
                
            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(Resources.notifMissingData);
                FormResult = DialogResult.Cancel;
                customMessageBox.ShowDialog();
                
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (txtBoxFirstName.Text.Length > 0 && txtBoxLastName.Text.Length > 0
                 && txtBoxPassword.Text.Length > 0 && txtBoxUsername.Text.Length > 0
                 && txtBoxPhone.Text.Length > 0)
            {
                Employee employee = new Employee()
                {
                    name = txtBoxFirstName.Text,
                    surname = txtBoxLastName.Text,
                    username = txtBoxUsername.Text,
                    password = txtBoxPassword.Text,
                    phoneNumber = txtBoxPhone.Text,
                    idEmployee = selectedEmployee.idEmployee,
                    idRole = selectedEmployee.idRole,
                    status = selectedEmployee.status,
                };
                string notif;
                if (!IsEmployeeDataChanged(selectedEmployee, employee))
                {

                    notif = Resources.notifDataNotChanged;
                    FormResult = DialogResult.Cancel;
                }
                else
                {
                    bool update = DB_Foodie.UpdateEmployee(employee);
                    notif = update ? Resources.notifUpdateEmployeeSuc : Resources.notifUpdateEmployeeFail;
                    FormResult = update ? DialogResult.OK : DialogResult.Cancel;
                }
                CustomMessageBox customMessageBox = new CustomMessageBox(notif);
                customMessageBox.ShowDialog();


            }
            else
            {
                CustomMessageBox customMessageBox = new CustomMessageBox(Resources.notifMissingData);
                FormResult = DialogResult.Cancel;
                customMessageBox.ShowDialog();
            }
        }
        private bool IsEmployeeDataChanged(Employee originalEmployee, Employee updatedEmployee)
        {
           
            if (originalEmployee.name != updatedEmployee.name ||
                originalEmployee.surname != updatedEmployee.surname ||
                originalEmployee.username != updatedEmployee.username ||
                originalEmployee.password != updatedEmployee.password ||
                originalEmployee.phoneNumber != updatedEmployee.phoneNumber ||
                originalEmployee.idRole != updatedEmployee.idRole ||
                originalEmployee.idEmployee != updatedEmployee.idEmployee ||
                originalEmployee.status != updatedEmployee.status)
            {
                
                return true;
            }

            
            return false;
        }

    }
}
