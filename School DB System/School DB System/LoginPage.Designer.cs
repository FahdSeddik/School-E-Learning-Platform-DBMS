namespace School_DB_System
{
    partial class LoginPage
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
            this.LoginPage_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Login_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.LoginError_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.ForgetPass_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Login_Btn = new Guna.UI2.WinForms.Guna2GradientButton();
            this.Password_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.Password_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Username_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.Username_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Login_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.LoginPage_Pnl.SuspendLayout();
            this.Login_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginPage_Pnl
            // 
            this.LoginPage_Pnl.BackColor = System.Drawing.Color.Transparent;
            this.LoginPage_Pnl.BorderColor = System.Drawing.Color.White;
            this.LoginPage_Pnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.LoginPage_Pnl.Controls.Add(this.Login_Pnl);
            this.LoginPage_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPage_Pnl.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.LoginPage_Pnl.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.LoginPage_Pnl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.LoginPage_Pnl.Location = new System.Drawing.Point(0, 0);
            this.LoginPage_Pnl.Name = "LoginPage_Pnl";
            this.LoginPage_Pnl.Size = new System.Drawing.Size(1000, 600);
            this.LoginPage_Pnl.TabIndex = 0;
            this.LoginPage_Pnl.UseTransparentBackground = true;
            this.LoginPage_Pnl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LoginPage_Pnl_MouseDown);
            this.LoginPage_Pnl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LoginPage_Pnl_MouseMove);
            this.LoginPage_Pnl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LoginPage_Pnl_MouseUp);
            // 
            // Login_Pnl
            // 
            this.Login_Pnl.BackColor = System.Drawing.Color.Transparent;
            this.Login_Pnl.BorderColor = System.Drawing.Color.White;
            this.Login_Pnl.BorderRadius = 50;
            this.Login_Pnl.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.Login_Pnl.Controls.Add(this.LoginError_Lbl);
            this.Login_Pnl.Controls.Add(this.ForgetPass_Lbl);
            this.Login_Pnl.Controls.Add(this.Login_Btn);
            this.Login_Pnl.Controls.Add(this.Password_Txt);
            this.Login_Pnl.Controls.Add(this.Password_Lbl);
            this.Login_Pnl.Controls.Add(this.Username_Txt);
            this.Login_Pnl.Controls.Add(this.Username_Lbl);
            this.Login_Pnl.Controls.Add(this.Login_Lbl);
            this.Login_Pnl.FillColor = System.Drawing.Color.White;
            this.Login_Pnl.FillColor2 = System.Drawing.Color.White;
            this.Login_Pnl.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Login_Pnl.Location = new System.Drawing.Point(285, 34);
            this.Login_Pnl.Name = "Login_Pnl";
            this.Login_Pnl.Size = new System.Drawing.Size(430, 537);
            this.Login_Pnl.TabIndex = 2;
            this.Login_Pnl.UseTransparentBackground = true;
            // 
            // LoginError_Lbl
            // 
            this.LoginError_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.LoginError_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.LoginError_Lbl.ForeColor = System.Drawing.Color.Red;
            this.LoginError_Lbl.Location = new System.Drawing.Point(35, 346);
            this.LoginError_Lbl.Name = "LoginError_Lbl";
            this.LoginError_Lbl.Size = new System.Drawing.Size(168, 15);
            this.LoginError_Lbl.TabIndex = 8;
            this.LoginError_Lbl.Text = "Incorrect username or password";
            this.LoginError_Lbl.Visible = false;
            // 
            // ForgetPass_Lbl
            // 
            this.ForgetPass_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.ForgetPass_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForgetPass_Lbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ForgetPass_Lbl.Location = new System.Drawing.Point(295, 346);
            this.ForgetPass_Lbl.Name = "ForgetPass_Lbl";
            this.ForgetPass_Lbl.Size = new System.Drawing.Size(95, 15);
            this.ForgetPass_Lbl.TabIndex = 7;
            this.ForgetPass_Lbl.Text = "Forget password?";
            this.ForgetPass_Lbl.MouseLeave += new System.EventHandler(this.ForgetPass_Lbl_MouseLeave);
            this.ForgetPass_Lbl.MouseHover += new System.EventHandler(this.ForgetPass_Lbl_MouseHover);
            // 
            // Login_Btn
            // 
            this.Login_Btn.AutoRoundedCorners = true;
            this.Login_Btn.BorderRadius = 22;
            this.Login_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Login_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Login_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Login_Btn.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Login_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Login_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.Login_Btn.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(87)))), ((int)(((byte)(122)))));
            this.Login_Btn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.Login_Btn.ForeColor = System.Drawing.Color.White;
            this.Login_Btn.Location = new System.Drawing.Point(107, 459);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(216, 47);
            this.Login_Btn.TabIndex = 6;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            // 
            // Password_Txt
            // 
            this.Password_Txt.Animated = true;
            this.Password_Txt.BorderRadius = 5;
            this.Password_Txt.BorderThickness = 0;
            this.Password_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password_Txt.DefaultText = "";
            this.Password_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Password_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Password_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Password_Txt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Password_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Password_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Password_Txt.Location = new System.Drawing.Point(35, 280);
            this.Password_Txt.Name = "Password_Txt";
            this.Password_Txt.PasswordChar = '●';
            this.Password_Txt.PlaceholderText = "Type your password";
            this.Password_Txt.SelectedText = "";
            this.Password_Txt.Size = new System.Drawing.Size(360, 49);
            this.Password_Txt.TabIndex = 5;
            this.Password_Txt.UseSystemPasswordChar = true;
            // 
            // Password_Lbl
            // 
            this.Password_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Password_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Password_Lbl.Location = new System.Drawing.Point(36, 258);
            this.Password_Lbl.Name = "Password_Lbl";
            this.Password_Lbl.Size = new System.Drawing.Size(52, 15);
            this.Password_Lbl.TabIndex = 4;
            this.Password_Lbl.Text = "Password";
            // 
            // Username_Txt
            // 
            this.Username_Txt.Animated = true;
            this.Username_Txt.BorderRadius = 5;
            this.Username_Txt.BorderThickness = 0;
            this.Username_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username_Txt.DefaultText = "";
            this.Username_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Username_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Username_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Username_Txt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Username_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Username_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Username_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Username_Txt.Location = new System.Drawing.Point(37, 183);
            this.Username_Txt.Name = "Username_Txt";
            this.Username_Txt.PasswordChar = '\0';
            this.Username_Txt.PlaceholderText = "Type your username";
            this.Username_Txt.SelectedText = "";
            this.Username_Txt.Size = new System.Drawing.Size(360, 49);
            this.Username_Txt.TabIndex = 3;
            // 
            // Username_Lbl
            // 
            this.Username_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Username_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Username_Lbl.Location = new System.Drawing.Point(38, 161);
            this.Username_Lbl.Name = "Username_Lbl";
            this.Username_Lbl.Size = new System.Drawing.Size(54, 15);
            this.Username_Lbl.TabIndex = 2;
            this.Username_Lbl.Text = "Username";
            // 
            // Login_Lbl
            // 
            this.Login_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Login_Lbl.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Login_Lbl.ForeColor = System.Drawing.Color.Black;
            this.Login_Lbl.Location = new System.Drawing.Point(170, 30);
            this.Login_Lbl.Name = "Login_Lbl";
            this.Login_Lbl.Size = new System.Drawing.Size(87, 47);
            this.Login_Lbl.TabIndex = 1;
            this.Login_Lbl.Text = "Login";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(102)))), ((int)(((byte)(157)))));
            this.Controls.Add(this.LoginPage_Pnl);
            this.Name = "LoginPage";
            this.Size = new System.Drawing.Size(1000, 600);
            this.LoginPage_Pnl.ResumeLayout(false);
            this.Login_Pnl.ResumeLayout(false);
            this.Login_Pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel LoginPage_Pnl;
        private Guna.UI2.WinForms.Guna2HtmlLabel Login_Lbl;
        private Guna.UI2.WinForms.Guna2GradientPanel Login_Pnl;
        private Guna.UI2.WinForms.Guna2TextBox Username_Txt;
        private Guna.UI2.WinForms.Guna2HtmlLabel Username_Lbl;
        private Guna.UI2.WinForms.Guna2TextBox Password_Txt;
        private Guna.UI2.WinForms.Guna2HtmlLabel Password_Lbl;
        private Guna.UI2.WinForms.Guna2GradientButton Login_Btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel ForgetPass_Lbl;
        private Guna.UI2.WinForms.Guna2HtmlLabel LoginError_Lbl;
    }
}
