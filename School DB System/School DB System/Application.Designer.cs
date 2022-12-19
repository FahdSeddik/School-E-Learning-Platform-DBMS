namespace School_DB_System
{
    partial class Application
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
            this.components = new System.ComponentModel.Container();
            this.MainPage_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.BorderlessDesign = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.Exit_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.MainTab_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.SubTab_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.TempTab_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.SuspendLayout();
            // 
            // MainPage_Pnl
            // 
            this.MainPage_Pnl.AutoRoundedCorners = true;
            this.MainPage_Pnl.BorderRadius = 299;
            this.MainPage_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPage_Pnl.Location = new System.Drawing.Point(0, 0);
            this.MainPage_Pnl.Name = "MainPage_Pnl";
            this.MainPage_Pnl.Size = new System.Drawing.Size(1000, 600);
            this.MainPage_Pnl.TabIndex = 0;
            // 
            // BorderlessDesign
            // 
            this.BorderlessDesign.BorderRadius = 50;
            this.BorderlessDesign.ContainerControl = this;
            this.BorderlessDesign.DockIndicatorTransparencyValue = 0.6D;
            this.BorderlessDesign.TransparentWhileDrag = true;
            // 
            // Exit_Btn
            // 
            this.Exit_Btn.AutoRoundedCorners = true;
            this.Exit_Btn.BackColor = System.Drawing.Color.Transparent;
            this.Exit_Btn.BorderColor = System.Drawing.Color.Transparent;
            this.Exit_Btn.BorderRadius = 12;
            this.Exit_Btn.CustomBorderColor = System.Drawing.Color.Transparent;
            this.Exit_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Exit_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Exit_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Exit_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Exit_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Exit_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(142)))));
            this.Exit_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(142)))));
            this.Exit_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Exit_Btn.ForeColor = System.Drawing.Color.White;
            this.Exit_Btn.Location = new System.Drawing.Point(956, 12);
            this.Exit_Btn.Name = "Exit_Btn";
            this.Exit_Btn.Size = new System.Drawing.Size(32, 27);
            this.Exit_Btn.TabIndex = 7;
            this.Exit_Btn.Text = "X";
            this.Exit_Btn.Click += new System.EventHandler(this.Exit_Btn_Click);
            // 
            // MainTab_Pnl
            // 
            this.MainTab_Pnl.AutoRoundedCorners = true;
            this.MainTab_Pnl.BorderRadius = 299;
            this.MainTab_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTab_Pnl.Location = new System.Drawing.Point(0, 0);
            this.MainTab_Pnl.Name = "MainTab_Pnl";
            this.MainTab_Pnl.Size = new System.Drawing.Size(1000, 600);
            this.MainTab_Pnl.TabIndex = 8;
            // 
            // SubTab_Pnl
            // 
            this.SubTab_Pnl.AutoRoundedCorners = true;
            this.SubTab_Pnl.BorderRadius = 268;
            this.SubTab_Pnl.Location = new System.Drawing.Point(64, 31);
            this.SubTab_Pnl.Name = "SubTab_Pnl";
            this.SubTab_Pnl.Size = new System.Drawing.Size(873, 539);
            this.SubTab_Pnl.TabIndex = 9;
            // 
            // TempTab_Pnl
            // 
            this.TempTab_Pnl.AutoRoundedCorners = true;
            this.TempTab_Pnl.BorderRadius = 268;
            this.TempTab_Pnl.Location = new System.Drawing.Point(64, 31);
            this.TempTab_Pnl.Name = "TempTab_Pnl";
            this.TempTab_Pnl.Size = new System.Drawing.Size(873, 539);
            this.TempTab_Pnl.TabIndex = 10;
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.Exit_Btn);
            this.Controls.Add(this.TempTab_Pnl);
            this.Controls.Add(this.SubTab_Pnl);
            this.Controls.Add(this.MainTab_Pnl);
            this.Controls.Add(this.MainPage_Pnl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Application";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "School DB System";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Application_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Application_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Application_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel MainPage_Pnl;
        private Guna.UI2.WinForms.Guna2BorderlessForm BorderlessDesign;
        private Guna.UI2.WinForms.Guna2GradientButton Exit_Btn;
        private Guna.UI2.WinForms.Guna2Panel TempTab_Pnl;
        private Guna.UI2.WinForms.Guna2Panel SubTab_Pnl;
        private Guna.UI2.WinForms.Guna2Panel MainTab_Pnl;
    }
}

