namespace Foodie
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBoxArticleName = new System.Windows.Forms.TextBox();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelReceipts = new System.Windows.Forms.LinkLabel();
            this.linkSignOut = new System.Windows.Forms.LinkLabel();
            this.pictureBoxRes = new System.Windows.Forms.PictureBox();
            this.lblArticleName = new System.Windows.Forms.Label();
            this.comboBoxCategoryName = new System.Windows.Forms.ComboBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblReceipt = new System.Windows.Forms.Label();
            this.groupBoxReceipt = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.dataGridViewDishes = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.buttonSer = new System.Windows.Forms.Button();
            this.buttonEn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRes)).BeginInit();
            this.groupBoxReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBoxArticleName
            // 
            resources.ApplyResources(this.txtBoxArticleName, "txtBoxArticleName");
            this.txtBoxArticleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.txtBoxArticleName.Name = "txtBoxArticleName";
            this.txtBoxArticleName.TextChanged += new System.EventHandler(this.txtBoxArticleName_TextChanged);
            // 
            // lblEmployeeName
            // 
            resources.ApplyResources(this.lblEmployeeName, "lblEmployeeName");
            this.lblEmployeeName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblEmployeeName.Name = "lblEmployeeName";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(190)))), ((int)(((byte)(121)))));
            this.panel1.Controls.Add(this.linkLabelReceipts);
            this.panel1.Controls.Add(this.linkSignOut);
            this.panel1.Controls.Add(this.pictureBoxRes);
            this.panel1.Controls.Add(this.lblEmployeeName);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // linkLabelReceipts
            // 
            this.linkLabelReceipts.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(31)))), ((int)(((byte)(9)))));
            resources.ApplyResources(this.linkLabelReceipts, "linkLabelReceipts");
            this.linkLabelReceipts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.linkLabelReceipts.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.linkLabelReceipts.Name = "linkLabelReceipts";
            this.linkLabelReceipts.TabStop = true;
            this.linkLabelReceipts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelReceipts_LinkClicked);
            // 
            // linkSignOut
            // 
            this.linkSignOut.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(31)))), ((int)(((byte)(9)))));
            resources.ApplyResources(this.linkSignOut, "linkSignOut");
            this.linkSignOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.linkSignOut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.linkSignOut.Name = "linkSignOut";
            this.linkSignOut.TabStop = true;
            this.linkSignOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSignOut_LinkClicked);
            // 
            // pictureBoxRes
            // 
            this.pictureBoxRes.Image = global::Foodie.Properties.Resources.restoran;
            resources.ApplyResources(this.pictureBoxRes, "pictureBoxRes");
            this.pictureBoxRes.Name = "pictureBoxRes";
            this.pictureBoxRes.TabStop = false;
            // 
            // lblArticleName
            // 
            resources.ApplyResources(this.lblArticleName, "lblArticleName");
            this.lblArticleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblArticleName.Name = "lblArticleName";
            // 
            // comboBoxCategoryName
            // 
            resources.ApplyResources(this.comboBoxCategoryName, "comboBoxCategoryName");
            this.comboBoxCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.comboBoxCategoryName.FormattingEnabled = true;
            this.comboBoxCategoryName.Name = "comboBoxCategoryName";
            this.comboBoxCategoryName.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategoryName_SelectedIndexChanged);
            this.comboBoxCategoryName.TextChanged += new System.EventHandler(this.comboBoxCategoryName_TextChanged);
            // 
            // lblCategoryName
            // 
            resources.ApplyResources(this.lblCategoryName, "lblCategoryName");
            this.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblCategoryName.Name = "lblCategoryName";
            // 
            // lblReceipt
            // 
            resources.ApplyResources(this.lblReceipt, "lblReceipt");
            this.lblReceipt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblReceipt.Name = "lblReceipt";
            this.lblReceipt.Click += new System.EventHandler(this.lblReceipt_Click);
            // 
            // groupBoxReceipt
            // 
            this.groupBoxReceipt.Controls.Add(this.lblReceipt);
            this.groupBoxReceipt.Controls.Add(this.pictureBox);
            resources.ApplyResources(this.groupBoxReceipt, "groupBoxReceipt");
            this.groupBoxReceipt.Name = "groupBoxReceipt";
            this.groupBoxReceipt.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Image = global::Foodie.Properties.Resources.shopping_cart;
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // btnFilter
            // 
            resources.ApplyResources(this.btnFilter, "btnFilter");
            this.btnFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(154)))), ((int)(((byte)(92)))));
            this.btnFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnResetFilter
            // 
            resources.ApplyResources(this.btnResetFilter, "btnResetFilter");
            this.btnResetFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(154)))), ((int)(((byte)(92)))));
            this.btnResetFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.UseVisualStyleBackColor = false;
            this.btnResetFilter.Click += new System.EventHandler(this.btnResetFilter_Click);
            // 
            // dataGridViewDishes
            // 
            this.dataGridViewDishes.AllowUserToAddRows = false;
            this.dataGridViewDishes.AllowUserToDeleteRows = false;
            this.dataGridViewDishes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDishes.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDishes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDishes.EnableHeadersVisualStyles = false;
            this.dataGridViewDishes.GridColor = System.Drawing.SystemColors.ButtonShadow;
            resources.ApplyResources(this.dataGridViewDishes, "dataGridViewDishes");
            this.dataGridViewDishes.Name = "dataGridViewDishes";
            this.dataGridViewDishes.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDishes.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewDishes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDishes.RowTemplate.Height = 24;
            this.dataGridViewDishes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDishes_CellClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Foodie.Properties.Resources.theme1;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Foodie.Properties.Resources.theme2;
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Foodie.Properties.Resources.theme3;
            resources.ApplyResources(this.pictureBox3, "pictureBox3");
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // buttonSer
            // 
            this.buttonSer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(154)))), ((int)(((byte)(92)))));
            resources.ApplyResources(this.buttonSer, "buttonSer");
            this.buttonSer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.buttonSer.Name = "buttonSer";
            this.buttonSer.UseVisualStyleBackColor = false;
            this.buttonSer.Click += new System.EventHandler(this.buttonSer_Click);
            // 
            // buttonEn
            // 
            this.buttonEn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(154)))), ((int)(((byte)(92)))));
            resources.ApplyResources(this.buttonEn, "buttonEn");
            this.buttonEn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.buttonEn.Name = "buttonEn";
            this.buttonEn.UseVisualStyleBackColor = false;
            this.buttonEn.Click += new System.EventHandler(this.buttonEn_Click);
            // 
            // MenuForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(220)))), ((int)(((byte)(164)))));
            this.Controls.Add(this.buttonSer);
            this.Controls.Add(this.buttonEn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.dataGridViewDishes);
            this.Controls.Add(this.btnResetFilter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.groupBoxReceipt);
            this.Controls.Add(this.lblCategoryName);
            this.Controls.Add(this.comboBoxCategoryName);
            this.Controls.Add(this.lblArticleName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBoxArticleName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MenuForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRes)).EndInit();
            this.groupBoxReceipt.ResumeLayout(false);
            this.groupBoxReceipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtBoxArticleName;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxRes;
        private System.Windows.Forms.LinkLabel linkSignOut;
        private System.Windows.Forms.Label lblArticleName;
        private System.Windows.Forms.ComboBox comboBoxCategoryName;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label lblReceipt;
        private System.Windows.Forms.GroupBox groupBoxReceipt;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.DataGridView dataGridViewDishes;
        private System.Windows.Forms.LinkLabel linkLabelReceipts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button buttonSer;
        private System.Windows.Forms.Button buttonEn;
    }
}

