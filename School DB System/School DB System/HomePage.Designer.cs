namespace School_DB_System
{
    partial class HomePage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.HomePage_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.profile_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Logout_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.Profile_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.Home_pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.kryptonContextMenuItems1 = new Krypton.Toolkit.KryptonContextMenuItems();
            this.kryptonContextMenuHeading1 = new Krypton.Toolkit.KryptonContextMenuHeading();
            this.kryptonContextMenuRadioButton1 = new Krypton.Toolkit.KryptonContextMenuRadioButton();
            this.kryptonContextMenuCheckBox1 = new Krypton.Toolkit.KryptonContextMenuCheckBox();
            this.kryptonContextMenuItem1 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.kryptonContextMenuItem2 = new Krypton.Toolkit.KryptonContextMenuItem();
            this.HomePage_Pnl.SuspendLayout();
            this.profile_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // HomePage_Pnl
            // 
            this.HomePage_Pnl.Controls.Add(this.profile_Pnl);
            this.HomePage_Pnl.Controls.Add(this.Home_pnl);
            this.HomePage_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HomePage_Pnl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.HomePage_Pnl.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.HomePage_Pnl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.HomePage_Pnl.Location = new System.Drawing.Point(0, 0);
            this.HomePage_Pnl.Name = "HomePage_Pnl";
            this.HomePage_Pnl.Size = new System.Drawing.Size(1000, 600);
            this.HomePage_Pnl.TabIndex = 0;
            // 
            // profile_Pnl
            // 
            this.profile_Pnl.BackColor = System.Drawing.Color.Transparent;
            this.profile_Pnl.BorderRadius = 20;
            this.profile_Pnl.Controls.Add(this.Logout_Btn);
            this.profile_Pnl.Controls.Add(this.Profile_Btn);
            this.profile_Pnl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(142)))));
            this.profile_Pnl.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(142)))));
            this.profile_Pnl.ForeColor = System.Drawing.Color.Black;
            this.profile_Pnl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.profile_Pnl.Location = new System.Drawing.Point(22, -43);
            this.profile_Pnl.MaximumSize = new System.Drawing.Size(188, 138);
            this.profile_Pnl.MinimumSize = new System.Drawing.Size(188, 82);
            this.profile_Pnl.Name = "profile_Pnl";
            this.profile_Pnl.Size = new System.Drawing.Size(188, 82);
            this.profile_Pnl.TabIndex = 0;
            this.profile_Pnl.UseTransparentBackground = true;
            // 
            // Logout_Btn
            // 
            this.Logout_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Logout_Btn.BorderRadius = 20;
            this.Logout_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Logout_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Logout_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Logout_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Logout_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Logout_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(142)))));
            this.Logout_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_Btn.ForeColor = System.Drawing.Color.White;
            this.Logout_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Logout_Btn.Image")));
            this.Logout_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Logout_Btn.ImageOffset = new System.Drawing.Point(15, 0);
            this.Logout_Btn.Location = new System.Drawing.Point(0, 83);
            this.Logout_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Logout_Btn.Name = "Logout_Btn";
            this.Logout_Btn.Size = new System.Drawing.Size(188, 53);
            this.Logout_Btn.TabIndex = 2;
            this.Logout_Btn.Text = "Logout";
            this.Logout_Btn.TextOffset = new System.Drawing.Point(15, 0);
            this.Logout_Btn.Click += new System.EventHandler(this.Logout_Btn_Click);
            // 
            // Profile_Btn
            // 
            this.Profile_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Profile_Btn.BorderRadius = 20;
            this.Profile_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Profile_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Profile_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Profile_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Profile_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Profile_Btn.FillColor = System.Drawing.Color.White;
            this.Profile_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.Profile_Btn.ForeColor = System.Drawing.Color.DimGray;
            this.Profile_Btn.Image = global::School_DB_System.Properties.Resources.Down_Arrow;
            this.Profile_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Profile_Btn.ImageOffset = new System.Drawing.Point(15, 20);
            this.Profile_Btn.Location = new System.Drawing.Point(0, 0);
            this.Profile_Btn.Name = "Profile_Btn";
            this.Profile_Btn.Size = new System.Drawing.Size(188, 83);
            this.Profile_Btn.TabIndex = 0;
            this.Profile_Btn.Text = "Username";
            this.Profile_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Profile_Btn.TextOffset = new System.Drawing.Point(30, 20);
            this.Profile_Btn.Click += new System.EventHandler(this.Profile_DBtn_Click);
            // 
            // Home_pnl
            // 
            this.Home_pnl.BackColor = System.Drawing.Color.Transparent;
            this.Home_pnl.BorderRadius = 15;
            this.Home_pnl.FillColor = System.Drawing.Color.White;
            this.Home_pnl.FillColor2 = System.Drawing.Color.White;
            this.Home_pnl.ForeColor = System.Drawing.Color.Black;
            this.Home_pnl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Home_pnl.Location = new System.Drawing.Point(22, 56);
            this.Home_pnl.Name = "Home_pnl";
            this.Home_pnl.Size = new System.Drawing.Size(955, 514);
            this.Home_pnl.TabIndex = 1;
            this.Home_pnl.UseTransparentBackground = true;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(132, 55);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(54, 15);
            this.guna2HtmlLabel2.TabIndex = 5;
            this.guna2HtmlLabel2.Text = "Username";
            // 
            // kryptonContextMenuHeading1
            // 
            this.kryptonContextMenuHeading1.ExtraText = "";
            // 
            // kryptonContextMenuRadioButton1
            // 
            this.kryptonContextMenuRadioButton1.ExtraText = "";
            // 
            // kryptonContextMenuCheckBox1
            // 
            this.kryptonContextMenuCheckBox1.ExtraText = "";
            // 
            // kryptonContextMenuItem1
            // 
            this.kryptonContextMenuItem1.Text = "Setting";
            // 
            // kryptonContextMenuItem2
            // 
            this.kryptonContextMenuItem2.Text = "Logout";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.HomePage_Pnl);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(1000, 600);
            this.HomePage_Pnl.ResumeLayout(false);
            this.profile_Pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel HomePage_Pnl;
        private Guna.UI2.WinForms.Guna2GradientPanel Home_pnl;
        private Guna.UI2.WinForms.Guna2GradientPanel profile_Pnl;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Krypton.Toolkit.KryptonContextMenuItems kryptonContextMenuItems1;
        private Krypton.Toolkit.KryptonContextMenuHeading kryptonContextMenuHeading1;
        private Krypton.Toolkit.KryptonContextMenuRadioButton kryptonContextMenuRadioButton1;
        private Krypton.Toolkit.KryptonContextMenuCheckBox kryptonContextMenuCheckBox1;
        private Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem1;
        private Krypton.Toolkit.KryptonContextMenuItem kryptonContextMenuItem2;
        private Guna.UI2.WinForms.Guna2Button Logout_Btn;
        private Guna.UI2.WinForms.Guna2Button Profile_Btn;
    }
}
