namespace Foodie
{
    partial class AddDishForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDishForm));
            this.btnAddDish = new System.Windows.Forms.Button();
            this.txtBoxDishName = new System.Windows.Forms.TextBox();
            this.lblDishName = new System.Windows.Forms.Label();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.comboBoxDishCategory = new System.Windows.Forms.ComboBox();
            this.lblDishCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAddDish
            // 
            resources.ApplyResources(this.btnAddDish, "btnAddDish");
            this.btnAddDish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(154)))), ((int)(((byte)(92)))));
            this.btnAddDish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.btnAddDish.Name = "btnAddDish";
            this.btnAddDish.UseVisualStyleBackColor = false;
            this.btnAddDish.Click += new System.EventHandler(this.btnAddDish_Click);
            // 
            // txtBoxDishName
            // 
            resources.ApplyResources(this.txtBoxDishName, "txtBoxDishName");
            this.txtBoxDishName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.txtBoxDishName.Name = "txtBoxDishName";
            // 
            // lblDishName
            // 
            resources.ApplyResources(this.lblDishName, "lblDishName");
            this.lblDishName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblDishName.Name = "lblDishName";
            // 
            // txtBoxPrice
            // 
            resources.ApplyResources(this.txtBoxPrice, "txtBoxPrice");
            this.txtBoxPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.txtBoxPrice.Name = "txtBoxPrice";
            // 
            // lblPrice
            // 
            resources.ApplyResources(this.lblPrice, "lblPrice");
            this.lblPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblPrice.Name = "lblPrice";
            // 
            // comboBoxDishCategory
            // 
            resources.ApplyResources(this.comboBoxDishCategory, "comboBoxDishCategory");
            this.comboBoxDishCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.comboBoxDishCategory.FormattingEnabled = true;
            this.comboBoxDishCategory.Name = "comboBoxDishCategory";
            this.comboBoxDishCategory.SelectedIndexChanged += new System.EventHandler(this.comboBoxDishCategory_SelectedIndexChanged);
            // 
            // lblDishCategory
            // 
            resources.ApplyResources(this.lblDishCategory, "lblDishCategory");
            this.lblDishCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(61)))), ((int)(((byte)(18)))));
            this.lblDishCategory.Name = "lblDishCategory";
            // 
            // AddDishForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(220)))), ((int)(((byte)(164)))));
            this.Controls.Add(this.lblDishCategory);
            this.Controls.Add(this.comboBoxDishCategory);
            this.Controls.Add(this.btnAddDish);
            this.Controls.Add(this.txtBoxDishName);
            this.Controls.Add(this.lblDishName);
            this.Controls.Add(this.txtBoxPrice);
            this.Controls.Add(this.lblPrice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddDishForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddDish;
        private System.Windows.Forms.TextBox txtBoxDishName;
        private System.Windows.Forms.Label lblDishName;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.ComboBox comboBoxDishCategory;
        private System.Windows.Forms.Label lblDishCategory;
    }
}

