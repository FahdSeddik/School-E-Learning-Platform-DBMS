namespace School_DB_System
{
    partial class Accountant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Accountant));
            this.AccHome_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.Stat_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Stat_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Teach_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Teach_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Stud_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Stud_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Reqs_IBtn = new Guna.UI2.WinForms.Guna2ImageButton();
            this.Reqs_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.AccHome_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // AccHome_Pnl
            // 
            this.AccHome_Pnl.Controls.Add(this.Reqs_IBtn);
            this.AccHome_Pnl.Controls.Add(this.Reqs_Lbl);
            this.AccHome_Pnl.Controls.Add(this.Stat_IBtn);
            this.AccHome_Pnl.Controls.Add(this.Stat_Lbl);
            this.AccHome_Pnl.Controls.Add(this.Teach_IBtn);
            this.AccHome_Pnl.Controls.Add(this.Teach_Lbl);
            this.AccHome_Pnl.Controls.Add(this.Stud_IBtn);
            this.AccHome_Pnl.Controls.Add(this.Stud_Lbl);
            this.AccHome_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccHome_Pnl.Location = new System.Drawing.Point(0, 0);
            this.AccHome_Pnl.Name = "AccHome_Pnl";
            this.AccHome_Pnl.Size = new System.Drawing.Size(955, 514);
            this.AccHome_Pnl.TabIndex = 25;
            // 
            // Stat_IBtn
            // 
            this.Stat_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Stat_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Stat_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Stat_IBtn.Image")));
            this.Stat_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Stat_IBtn.ImageRotate = 0F;
            this.Stat_IBtn.Location = new System.Drawing.Point(523, 193);
            this.Stat_IBtn.Name = "Stat_IBtn";
            this.Stat_IBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Stat_IBtn.Size = new System.Drawing.Size(150, 100);
            this.Stat_IBtn.TabIndex = 36;
            this.Stat_IBtn.Click += new System.EventHandler(this.Stat_IBtn_Click);
            // 
            // Stat_Lbl
            // 
            this.Stat_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Stat_Lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stat_Lbl.Location = new System.Drawing.Point(574, 299);
            this.Stat_Lbl.Name = "Stat_Lbl";
            this.Stat_Lbl.Size = new System.Drawing.Size(53, 19);
            this.Stat_Lbl.TabIndex = 35;
            this.Stat_Lbl.Text = "Statistics";
            // 
            // Teach_IBtn
            // 
            this.Teach_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Teach_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Teach_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Teach_IBtn.Image")));
            this.Teach_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Teach_IBtn.ImageRotate = 0F;
            this.Teach_IBtn.Location = new System.Drawing.Point(275, 193);
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
            this.Teach_Lbl.Location = new System.Drawing.Point(326, 299);
            this.Teach_Lbl.Name = "Teach_Lbl";
            this.Teach_Lbl.Size = new System.Drawing.Size(55, 19);
            this.Teach_Lbl.TabIndex = 25;
            this.Teach_Lbl.Text = "Teachers";
            // 
            // Stud_IBtn
            // 
            this.Stud_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Stud_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Stud_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Stud_IBtn.Image")));
            this.Stud_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Stud_IBtn.ImageRotate = 0F;
            this.Stud_IBtn.Location = new System.Drawing.Point(37, 193);
            this.Stud_IBtn.Name = "Stud_IBtn";
            this.Stud_IBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Stud_IBtn.Size = new System.Drawing.Size(150, 100);
            this.Stud_IBtn.TabIndex = 24;
            this.Stud_IBtn.Click += new System.EventHandler(this.Stud_IBtn_Click);
            // 
            // Stud_Lbl
            // 
            this.Stud_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Stud_Lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Stud_Lbl.Location = new System.Drawing.Point(88, 299);
            this.Stud_Lbl.Name = "Stud_Lbl";
            this.Stud_Lbl.Size = new System.Drawing.Size(53, 19);
            this.Stud_Lbl.TabIndex = 9;
            this.Stud_Lbl.Text = "Students";
            // 
            // Reqs_IBtn
            // 
            this.Reqs_IBtn.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Reqs_IBtn.HoverState.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            this.Reqs_IBtn.HoverState.ImageSize = new System.Drawing.Size(84, 84);
            this.Reqs_IBtn.Image = ((System.Drawing.Image)(resources.GetObject("Reqs_IBtn.Image")));
            this.Reqs_IBtn.ImageOffset = new System.Drawing.Point(0, 0);
            this.Reqs_IBtn.ImageRotate = 0F;
            this.Reqs_IBtn.Location = new System.Drawing.Point(753, 193);
            this.Reqs_IBtn.Name = "Reqs_IBtn";
            this.Reqs_IBtn.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Reqs_IBtn.Size = new System.Drawing.Size(150, 100);
            this.Reqs_IBtn.TabIndex = 38;
            this.Reqs_IBtn.Click += new System.EventHandler(this.Reqs_IBtn_Click);
            // 
            // Reqs_Lbl
            // 
            this.Reqs_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Reqs_Lbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reqs_Lbl.Location = new System.Drawing.Point(804, 299);
            this.Reqs_Lbl.Name = "Reqs_Lbl";
            this.Reqs_Lbl.Size = new System.Drawing.Size(56, 19);
            this.Reqs_Lbl.TabIndex = 37;
            this.Reqs_Lbl.Text = "Requests";
            // 
            // Accountant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AccHome_Pnl);
            this.Name = "Accountant";
            this.Size = new System.Drawing.Size(955, 514);
            this.AccHome_Pnl.ResumeLayout(false);
            this.AccHome_Pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel AccHome_Pnl;
        private Guna.UI2.WinForms.Guna2ImageButton Teach_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Teach_Lbl;
        private Guna.UI2.WinForms.Guna2ImageButton Stud_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Stud_Lbl;
        private Guna.UI2.WinForms.Guna2ImageButton Stat_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Stat_Lbl;
        private Guna.UI2.WinForms.Guna2ImageButton Reqs_IBtn;
        private Guna.UI2.WinForms.Guna2HtmlLabel Reqs_Lbl;
    }
}
