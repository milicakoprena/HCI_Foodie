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
    public partial class ReceiptsForm : Form
    {
        private List<Receipt> allReceipts = new List<Receipt>();
        private Employee employee {  get; set; }
        public ReceiptsForm()
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            allReceipts = DB_Foodie.GetReceipts();
            FillDataGridView();
            dataGridViewReceipts.CellClick += DataGridViewReceipts_CellClick;
        }

        public ReceiptsForm(Employee employee)
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            allReceipts = DB_Foodie.GetReceiptsByEmployeeId(employee.idEmployee);
            FillDataGridView();
            dataGridViewReceipts.Columns.Remove(dataGridViewReceipts.Columns["Employee"]);
            dataGridViewReceipts.Columns["TotalPrice"].Width = 100;
            dataGridViewReceipts.CellClick += DataGridViewReceipts_CellClick;
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            dataGridViewReceipts.ForeColor = LoginForm.theme.fontColor;
            btnFilter.ForeColor = LoginForm.theme.fontColor;
            btnFilter.BackColor = LoginForm.theme.accentColor;
            
            btnResetFilter.ForeColor = LoginForm.theme.fontColor;
            btnResetFilter.BackColor = LoginForm.theme.accentColor;
        }

        private void DataGridViewReceipts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewReceipts.Rows[e.RowIndex];

                Receipt selectedReceipt = (Receipt)selectedRow.DataBoundItem;

                ReceiptInfo receiptInfo = new ReceiptInfo(selectedReceipt);
                receiptInfo.ShowDialog();
            }
        }

        void FillDataGridView()
        {
            dataGridViewReceipts.AutoGenerateColumns = false;
            dataGridViewReceipts.DataSource = allReceipts;

            
            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.DataPropertyName = "idReceipt";
            idColumn.Name = "ReceiptId";
            idColumn.HeaderText = Resources.id;
            idColumn.DefaultCellStyle.Format = "000000";
            
            dataGridViewReceipts.Columns.Add(idColumn);

            
            DataGridViewTextBoxColumn timeColumn = new DataGridViewTextBoxColumn();
            timeColumn.DataPropertyName = "orderTime";
            timeColumn.Name = "OrderTime";
            timeColumn.HeaderText = Resources.receiptTime;
            timeColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; 
            dataGridViewReceipts.Columns.Add(timeColumn);

           
            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "totalPrice";
            priceColumn.Name = "TotalPrice";
            priceColumn.HeaderText = Resources.totalPrice;
            priceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewReceipts.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn employeeColumn = new DataGridViewTextBoxColumn();
            employeeColumn.DataPropertyName = "employee";
            employeeColumn.Name = "Employee";
            employeeColumn.HeaderText = Resources.employee;
            dataGridViewReceipts.Columns.Add(employeeColumn);

            dataGridViewReceipts.Columns["ReceiptId"].Width = 70;
            dataGridViewReceipts.Columns["TotalPrice"].Width = 130;
            dataGridViewReceipts.Columns["Employee"].Width = 140;
        }

        


        private void btnFilter_Click(object sender, EventArgs e)
        {
            
            DateTime startDate = dateTimePicker1.Value.Date;
            DateTime endDate = dateTimePicker2.Value.Date;

            if (startDate < endDate)
            {
                List<Receipt> filteredReceipts = DB_Foodie.FilterReceiptsByDate(startDate, endDate);
                dataGridViewReceipts.DataSource = filteredReceipts;
            }
            else {
                CustomMessageBox customMessageBox = new CustomMessageBox(Resources.dateNotif);
                customMessageBox.ShowDialog();
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            dataGridViewReceipts.DataSource = allReceipts;
        }

       

       
    }
}
