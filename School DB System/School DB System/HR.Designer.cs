namespace School_DB_System
{
    partial class HR
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HR));
            this.HRHome_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.Reqs_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Reqs_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Staff_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Staff_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Teach_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Teach_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.HRHome_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // HRHome_Pnl
            // 
            this.HRHome_Pnl.Controls.Add(this.Reqs_IBtn);
            this.HRHome_Pnl.Controls.Add(this.Reqs_Lbl);
            this.HRHome_Pnl.Controls.Add(this.Staff_IBtn);
            this.HRHome_Pnl.Controls.Add(this.Staff_Lbl);
            this.HRHome_Pnl.Controls.Add(this.Teach_IBtn);
            this.HRHome_Pnl.Controls.Add(this.Teach_Lbl);
            this.HRHome_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HRHome_Pnl.Location = new System.Drawing.Point(0, 0);
            this.HRHome_Pnl.Name = "HRHome_Pnl";
            this.HRHome_Pnl.Size = new System.Drawing.Size(955, 514);
            this.HRHome_Pnl.TabIndex = 25;
            // 
            // Reqs_IBtn
            // 
            this.Reqs_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Reqs_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Reqs_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Reqs_IBtn.Image")));
            this.Reqs_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Reqs_IBtn.ImageRotate = 0F;
            this.Reqs_IBtn.Location = new System.Drawing.Point(721, 188);
            this.Reqs_IBtn.Name = "Reqs_IBtn";
            this.Reqs_IBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Reqs_IBtn.Size = new System.Drawing.Size(150, 100);
            this.Reqs_IBtn.TabIndex = 32;
            this.Reqs_IBtn.Click += new System.EventHandler(this.Reqs_IBtn_Click);
            // 
            // Reqs_Lbl
            // 
            this.Reqs_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Reqs_Lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reqs_Lbl.Location = new System.Drawing.Point(772, 294);
            this.Reqs_Lbl.Name = "Reqs_Lbl";
            this.Reqs_Lbl.Size = new System.Drawing.Size(56, 19);
            this.Reqs_Lbl.TabIndex = 31;
            this.Reqs_Lbl.Text = "Requests";
            // 
            // Staff_IBtn
            // 
            this.Staff_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Staff_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Staff_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Staff_IBtn.Image")));
            this.Staff_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Staff_IBtn.ImageRotate = 0F;
            this.Staff_IBtn.Location = new System.Drawing.Point(394, 188);
            this.Staff_IBtn.Name = "Staff_IBtn";
            this.Staff_IBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Staff_IBtn.Size = new System.Drawing.Size(150, 100);
            this.Staff_IBtn.TabIndex = 28;
            this.Staff_IBtn.Click += new System.EventHandler(this.Staff_IBtn_Click);
            // 
            // Staff_Lbl
            // 
            this.Staff_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Staff_Lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Staff_Lbl.Location = new System.Drawing.Point(458, 294);
            this.Staff_Lbl.Name = "Staff_Lbl";
            this.Staff_Lbl.Size = new System.Drawing.Size(29, 19);
            this.Staff_Lbl.TabIndex = 27;
            this.Staff_Lbl.Text = "Staff";
            // 
            // Teach_IBtn
            // 
            this.Teach_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Teach_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Teach_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Teach_IBtn.Image")));
            this.Teach_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Teach_IBtn.ImageRotate = 0F;
            this.Teach_IBtn.Location = new System.Drawing.Point(71, 188);
            this.Teach_IBtn.Name = "Teach_IBtn";
            this.Teach_IBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Teach_IBtn.Size = new System.Drawing.Size(150, 100);
            this.Teach_IBtn.TabIndex = 26;
            this.Teach_IBtn.Click += new System.EventHandler(this.Teach_IBtn_Click);
            // 
            // Teach_Lbl
            // 
            this.Teach_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Teach_Lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Teach_Lbl.Location = new System.Drawing.Point(122, 294);
            this.Teach_Lbl.Name = "Teach_Lbl";
            this.Teach_Lbl.Size = new System.Drawing.Size(55, 19);
            this.Teach_Lbl.TabIndex = 25;
            this.Teach_Lbl.Text = "Teachers";
            // 
            // HR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HRHome_Pnl);
            this.Name = "HR";
            this.Size = new System.Drawing.Size(955, 514);
            this.HRHome_Pnl.ResumeLayout(false);
            this.HRHome_Pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel HRHome_Pnl;
        private Guna.UI2.WinForms.Guna2ImageButton Reqs_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Reqs_Lbl;
        private Guna.UI2.WinForms.Guna2ImageButton Staff_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Staff_Lbl;
        private Guna.UI2.WinForms.Guna2ImageButton Teach_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Teach_Lbl;
    }
}
