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
    public partial class AddOrderForm : Form
    {
        public List<Groceries> allGroceries = new List<Groceries>();
        public static List<GroceriesItem> groceriesItems = new List<GroceriesItem>();
        public AddOrderForm()
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

            FillDataGridView();
            dataGridViewGroceries.CellClick += dataGridViewGroceries_CellClick;
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblGroceries.ForeColor = LoginForm.theme.fontColor;
            txtBoxGroceriesName.ForeColor= LoginForm.theme.fontColor;
            dataGridViewGroceries.ForeColor = LoginForm.theme.fontColor;
            btnViewOrder.BackColor = LoginForm.theme.accentColor;
            btnViewOrder.ForeColor = LoginForm.theme.fontColor;
        }

        void FillDataGridView()
        {

            dataGridViewGroceries.AutoGenerateColumns = false;
            allGroceries = DB_Foodie.GetGroceries();
            dataGridViewGroceries.DataSource = allGroceries;


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "name";
            nameColumn.Name = "GroceriesName";
            nameColumn.HeaderText = Resources.groceriesName;
            dataGridViewGroceries.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "price";
            priceColumn.Name = "Price";
            priceColumn.HeaderText = Resources.price;
            dataGridViewGroceries.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn unitColumn = new DataGridViewTextBoxColumn();
            unitColumn.DataPropertyName = "unitName";
            unitColumn.Name = "GroceriesUnit";
            unitColumn.HeaderText = Resources.groceriesUnit;
            dataGridViewGroceries.Columns.Add(unitColumn);

            dataGridViewGroceries.Columns["GroceriesName"].Width = 150;
        }

        private void txtBoxGroceriesName_TextChanged(object sender, EventArgs e)
        {
            string name = txtBoxGroceriesName.Text;


            filterDataGridViewByName(name);
        }

        private void filterDataGridViewByName(string name)
        {
            List<Groceries> filteredGroceries = allGroceries.Where(d => d.name.IndexOf(name, StringComparison.OrdinalIgnoreCase) != -1).ToList();

            dataGridViewGroceries.DataSource = filteredGroceries;
        }

        private void dataGridViewGroceries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewGroceries.Rows[e.RowIndex];

                Groceries selectedG = (Groceries)selectedRow.DataBoundItem;

                AddGroceriesItemForm addGroceriesItemForm = new AddGroceriesItemForm(selectedG);
                addGroceriesItemForm.ShowDialog();
            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            ViewOrderForm viewOrderForm = new ViewOrderForm();
            viewOrderForm.ShowDialog();
        }
    }


}
