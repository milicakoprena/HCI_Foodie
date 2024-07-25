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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Foodie
{
    public partial class EmployeesForm : Form
    {
        private bool filterStatus;
        public List<Employee> allEmployees = new List<Employee>();
        public EmployeesForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            UpdateUI();
            FillComboBox();
            FillDataGridView();
            dataGridViewEmployees.CellFormatting += dataGridViewEmployees_CellFormatting;
            dataGridViewEmployees.CellClick += DataGridViewEmployees_CellClick;
            dataGridViewEmployees.CellDoubleClick += dataGridViewEmployees_CellDoubleClick;

        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblEmployeeName.ForeColor = LoginForm.theme.fontColor;
            lbl.ForeColor = LoginForm.theme.fontColor;
            txtBoxEmployeeName.ForeColor = LoginForm.theme.fontColor;
            comboBoxStatus.ForeColor = LoginForm.theme.fontColor;
            btnFilter.ForeColor = LoginForm.theme.fontColor;
            btnFilter.BackColor = LoginForm.theme.accentColor;

            btnResetFilter.ForeColor = LoginForm.theme.fontColor;
            btnResetFilter.BackColor = LoginForm.theme.accentColor;

            dataGridViewEmployees.ForeColor = LoginForm.theme.fontColor;

            btnAddDish.BackColor = LoginForm.theme.accentColor;
            btnAddEmployee.BackColor = LoginForm.theme.accentColor;

            btnAddDish.ForeColor = LoginForm.theme.fontColor;
            btnAddEmployee.ForeColor = LoginForm.theme.fontColor;
        }

        private void dataGridViewEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewEmployees.Rows[e.RowIndex];

                Employee selectedEmployee = (Employee)selectedRow.DataBoundItem;

                AddEmployeeForm updateEmployeeForm = new AddEmployeeForm(selectedEmployee);
                updateEmployeeForm.ShowDialog();

                
                DialogResult dialogResult = updateEmployeeForm.FormResult;

                
                if (dialogResult == DialogResult.OK)
                {
                     dataGridViewEmployees.DataSource = DB_Foodie.GetEmployees();
                }

            }
        }



        private void DataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewEmployees.Columns["Status"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show(Resources.changeEmployeeStatus, "Aktivnost zaposlenog", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {

                    Employee selectedEmployee = (Employee)dataGridViewEmployees.Rows[e.RowIndex].DataBoundItem;


                    selectedEmployee.status = !selectedEmployee.status;


                    bool updateSuccess = DB_Foodie.UpdateEmployeeStatus(selectedEmployee.idEmployee, selectedEmployee.status);

                    if (updateSuccess)
                    {

                        FillDataGridView();
                    }
                    else
                    {
                        CustomMessageBox customMessageBox = new CustomMessageBox(Resources.notifUpdateStatus);
                        customMessageBox.ShowDialog();
                    }
                }
                

                
            }
        }

        void FillComboBox()
        {
            comboBoxStatus.Items.Add("Aktivan");
            comboBoxStatus.Items.Add("Neaktivan");
        }

        void FillDataGridView()
        {

            dataGridViewEmployees.AutoGenerateColumns = false;
            dataGridViewEmployees.Columns.Clear();
            allEmployees = DB_Foodie.GetEmployees();
            dataGridViewEmployees.DataSource = allEmployees;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "name";
            nameColumn.Name = "Name";
            nameColumn.HeaderText = Resources.name;
            dataGridViewEmployees.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn surnameColumn = new DataGridViewTextBoxColumn();
            surnameColumn.DataPropertyName = "surname";
            surnameColumn.Name = "Surname";
            surnameColumn.HeaderText = Resources.surname;
            dataGridViewEmployees.Columns.Add(surnameColumn);

            DataGridViewTextBoxColumn phoneColumn = new DataGridViewTextBoxColumn();
            phoneColumn.DataPropertyName = "phoneNumber";
            phoneColumn.Name = "PhoneNumber";
            phoneColumn.HeaderText = Resources.phoneNumber;
            dataGridViewEmployees.Columns.Add(phoneColumn);


            DataGridViewTextBoxColumn statusColumn = new DataGridViewTextBoxColumn();
            statusColumn.DataPropertyName = "status";
            statusColumn.Name = "Status";
            statusColumn.HeaderText = "Status";
            dataGridViewEmployees.Columns.Add(statusColumn);


        }

        private void dataGridViewEmployees_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewEmployees.Columns["Status"].Index && e.Value != null)
            {
                bool statusValue = (bool)e.Value;
                e.Value = statusValue ? "Aktivan" : "Neaktivan";
                e.FormattingApplied = true;
            }
        }

        private void txtBoxEmployeeName_TextChanged(object sender, EventArgs e)
        {
            string name = txtBoxEmployeeName.Text;
            filterDataGridViewByName(name);
        }

        private void comboBoxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterStatus = (string)comboBoxStatus.SelectedItem == "Aktivan";
        }

        private void filterDataGridViewByName(string name)
        {
            List<Employee> filteredEmployees = allEmployees.Where(d => d.name.IndexOf(name, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            dataGridViewEmployees.DataSource = filteredEmployees;
        }

        private void filterDataGridViewByStatus()
        {

            List<Employee> filteredEmployees = allEmployees.Where(d => d.status == filterStatus).ToList();

            dataGridViewEmployees.DataSource = filteredEmployees;

        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterDataGridViewByStatus();
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            dataGridViewEmployees.DataSource = allEmployees;
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            AddEmployeeForm addEmployeeForm = new AddEmployeeForm();
            addEmployeeForm.ShowDialog();

            DialogResult dialogResult = addEmployeeForm.FormResult;


            if (dialogResult == DialogResult.OK)
            {
                dataGridViewEmployees.DataSource = DB_Foodie.GetEmployees();
            }
        }

        private void btnAddDish_Click(object sender, EventArgs e)
        {
            AddDishForm addDishForm = new AddDishForm();
            addDishForm.ShowDialog();
        }

    }
}
