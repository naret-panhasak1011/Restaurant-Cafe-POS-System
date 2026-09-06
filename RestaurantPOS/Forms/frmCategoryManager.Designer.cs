namespace RestaurantPOS.Forms
{
    partial class frmCategoryManager
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.SuspendLayout();
            //
            // lblTitle
            //
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(16, 14);
            this.lblTitle.Size = new System.Drawing.Size(300, 30);
            this.lblTitle.Text = "Manage Categories";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(340, 18);
            this.txtSearch.Size = new System.Drawing.Size(180, 27);
            this.txtSearch.PlaceholderText = "Search category...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // dgvCategories
            //
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Location = new System.Drawing.Point(16, 56);
            this.dgvCategories.Size = new System.Drawing.Size(504, 340);
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.SelectionChanged += new System.EventHandler(this.dgvCategories_SelectionChanged);
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(16, 410);
            this.lblName.Size = new System.Drawing.Size(140, 22);
            this.lblName.Text = "Category Name";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(16, 434);
            this.txtName.Size = new System.Drawing.Size(300, 27);
            //
            // btnNew
            //
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Location = new System.Drawing.Point(16, 476);
            this.btnNew.Size = new System.Drawing.Size(120, 36);
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0xC0, 0x39, 0x2B);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(146, 476);
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnDelete
            //
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(276, 476);
            this.btnDelete.Size = new System.Drawing.Size(120, 36);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnClose
            //
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(400, 476);
            this.btnClose.Size = new System.Drawing.Size(120, 36);
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            //
            // frmCategoryManager
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 530);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmCategoryManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Categories";
            this.Load += new System.EventHandler(this.frmCategoryManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
