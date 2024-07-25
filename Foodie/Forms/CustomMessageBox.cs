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
    public partial class CustomMessageBox : Form
    {
        public string notif;
        public CustomMessageBox(string notif)
        {
            InitializeComponent();
            UpdateUI();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.notif=notif;
            lblNotif.Text = notif;
        }

        private void UpdateUI()
        {
            this.BackColor = LoginForm.theme.backgroundColor;
            lblNotif.ForeColor = LoginForm.theme.fontColor;
        }



    }
}
