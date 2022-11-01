namespace School_DB_Application
{
    partial class Login_Page
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login_Page));
            this.Profile_List = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Your_Profiles_Label = new System.Windows.Forms.Label();
            this.Create_New_Profile_panel = new System.Windows.Forms.Panel();
            this.Create_Btn = new System.Windows.Forms.Button();
            this.X_CreateNewProfile_Btn = new System.Windows.Forms.Button();
            this.Username_Txt = new System.Windows.Forms.TextBox();
            this.Username_Lbl = new System.Windows.Forms.Label();
            this.ServerToken_Txt = new System.Windows.Forms.TextBox();
            this.Password_Txt = new System.Windows.Forms.TextBox();
            this.ServerToken_Lbl = new System.Windows.Forms.Label();
            this.Password_Lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Login_Panel = new System.Windows.Forms.Panel();
            this.Login_Btn = new System.Windows.Forms.Button();
            this.Login_X_Btn = new System.Windows.Forms.Button();
            this.Login_Password_Txt = new System.Windows.Forms.TextBox();
            this.Login_Password_Lbl = new System.Windows.Forms.Label();
            this.Login_Profile_Icon = new System.Windows.Forms.PictureBox();
            this.Btn_Expand_Timer = new System.Windows.Forms.Timer(this.components);
            this.Btn_Shrink_Timer = new System.Windows.Forms.Timer(this.components);
            this.Create_New_Profile_Btn = new System.Windows.Forms.Button();
            this.Profile_List.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.Create_New_Profile_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Login_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Login_Profile_Icon)).BeginInit();
            this.SuspendLayout();
            // 
            // Profile_List
            // 
            this.Profile_List.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Profile_List.Controls.Add(this.pictureBox2);
            this.Profile_List.Location = new System.Drawing.Point(35, 40);
            this.Profile_List.Name = "Profile_List";
            this.Profile_List.Size = new System.Drawing.Size(706, 306);
            this.Profile_List.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::School_DB_Application.Properties.Resources.User_Profile_Icon;
            this.pictureBox2.Location = new System.Drawing.Point(22, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(151, 122);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // Your_Profiles_Label
            // 
            this.Your_Profiles_Label.AutoSize = true;
            this.Your_Profiles_Label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Your_Profiles_Label.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Your_Profiles_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Your_Profiles_Label.ForeColor = System.Drawing.Color.White;
            this.Your_Profiles_Label.Location = new System.Drawing.Point(33, 9);
            this.Your_Profiles_Label.Name = "Your_Profiles_Label";
            this.Your_Profiles_Label.Size = new System.Drawing.Size(112, 20);
            this.Your_Profiles_Label.TabIndex = 1;
            this.Your_Profiles_Label.Text = "Your Profiles";
            // 
            // Create_New_Profile_panel
            // 
            this.Create_New_Profile_panel.BackColor = System.Drawing.Color.White;
            this.Create_New_Profile_panel.Controls.Add(this.Create_Btn);
            this.Create_New_Profile_panel.Controls.Add(this.X_CreateNewProfile_Btn);
            this.Create_New_Profile_panel.Controls.Add(this.Username_Txt);
            this.Create_New_Profile_panel.Controls.Add(this.Username_Lbl);
            this.Create_New_Profile_panel.Controls.Add(this.ServerToken_Txt);
            this.Create_New_Profile_panel.Controls.Add(this.Password_Txt);
            this.Create_New_Profile_panel.Controls.Add(this.ServerToken_Lbl);
            this.Create_New_Profile_panel.Controls.Add(this.Password_Lbl);
            this.Create_New_Profile_panel.Controls.Add(this.pictureBox1);
            this.Create_New_Profile_panel.Location = new System.Drawing.Point(235, 18);
            this.Create_New_Profile_panel.Name = "Create_New_Profile_panel";
            this.Create_New_Profile_panel.Size = new System.Drawing.Size(331, 365);
            this.Create_New_Profile_panel.TabIndex = 0;
            // 
            // Create_Btn
            // 
            this.Create_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Create_Btn.FlatAppearance.BorderSize = 0;
            this.Create_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_Btn.ForeColor = System.Drawing.Color.White;
            this.Create_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create_Btn.Location = new System.Drawing.Point(106, 315);
            this.Create_Btn.MaximumSize = new System.Drawing.Size(123, 40);
            this.Create_Btn.MinimumSize = new System.Drawing.Size(119, 36);
            this.Create_Btn.Name = "Create_Btn";
            this.Create_Btn.Size = new System.Drawing.Size(119, 36);
            this.Create_Btn.TabIndex = 4;
            this.Create_Btn.Text = "Create";
            this.Create_Btn.UseVisualStyleBackColor = false;
            this.Create_Btn.Click += new System.EventHandler(this.Create_Btn_Click);
            this.Create_Btn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Create_EnterKey);
            this.Create_Btn.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Create_Btn.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // X_CreateNewProfile_Btn
            // 
            this.X_CreateNewProfile_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.X_CreateNewProfile_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.X_CreateNewProfile_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.X_CreateNewProfile_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.X_CreateNewProfile_Btn.Location = new System.Drawing.Point(291, 5);
            this.X_CreateNewProfile_Btn.MaximumSize = new System.Drawing.Size(35, 28);
            this.X_CreateNewProfile_Btn.MinimumSize = new System.Drawing.Size(33, 26);
            this.X_CreateNewProfile_Btn.Name = "X_CreateNewProfile_Btn";
            this.X_CreateNewProfile_Btn.Size = new System.Drawing.Size(33, 26);
            this.X_CreateNewProfile_Btn.TabIndex = 3;
            this.X_CreateNewProfile_Btn.Text = "X";
            this.X_CreateNewProfile_Btn.UseVisualStyleBackColor = false;
            this.X_CreateNewProfile_Btn.Click += new System.EventHandler(this.X_CreateNewProfile_Btn_Click);
            this.X_CreateNewProfile_Btn.MouseLeave += new System.EventHandler(this.X_Btn_MouseLeave);
            this.X_CreateNewProfile_Btn.MouseHover += new System.EventHandler(this.X_Btn_MouseHover);
            // 
            // Username_Txt
            // 
            this.Username_Txt.Location = new System.Drawing.Point(64, 170);
            this.Username_Txt.Name = "Username_Txt";
            this.Username_Txt.Size = new System.Drawing.Size(202, 20);
            this.Username_Txt.TabIndex = 2;
            this.Username_Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Create_EnterKey);
            // 
            // Username_Lbl
            // 
            this.Username_Lbl.AutoSize = true;
            this.Username_Lbl.Location = new System.Drawing.Point(138, 149);
            this.Username_Lbl.Name = "Username_Lbl";
            this.Username_Lbl.Size = new System.Drawing.Size(55, 13);
            this.Username_Lbl.TabIndex = 1;
            this.Username_Lbl.Text = "Username";
            // 
            // ServerToken_Txt
            // 
            this.ServerToken_Txt.Location = new System.Drawing.Point(64, 223);
            this.ServerToken_Txt.Name = "ServerToken_Txt";
            this.ServerToken_Txt.Size = new System.Drawing.Size(202, 20);
            this.ServerToken_Txt.TabIndex = 2;
            this.ServerToken_Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Create_EnterKey);
            // 
            // Password_Txt
            // 
            this.Password_Txt.Location = new System.Drawing.Point(64, 280);
            this.Password_Txt.Name = "Password_Txt";
            this.Password_Txt.Size = new System.Drawing.Size(202, 20);
            this.Password_Txt.TabIndex = 2;
            this.Password_Txt.UseSystemPasswordChar = true;
            this.Password_Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Create_EnterKey);
            // 
            // ServerToken_Lbl
            // 
            this.ServerToken_Lbl.AutoSize = true;
            this.ServerToken_Lbl.Location = new System.Drawing.Point(129, 202);
            this.ServerToken_Lbl.Name = "ServerToken_Lbl";
            this.ServerToken_Lbl.Size = new System.Drawing.Size(72, 13);
            this.ServerToken_Lbl.TabIndex = 1;
            this.ServerToken_Lbl.Text = "Server Token";
            // 
            // Password_Lbl
            // 
            this.Password_Lbl.AutoSize = true;
            this.Password_Lbl.Location = new System.Drawing.Point(139, 259);
            this.Password_Lbl.Name = "Password_Lbl";
            this.Password_Lbl.Size = new System.Drawing.Size(53, 13);
            this.Password_Lbl.TabIndex = 1;
            this.Password_Lbl.Text = "Password";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::School_DB_Application.Properties.Resources.User_Profile_Icon;
            this.pictureBox1.Location = new System.Drawing.Point(90, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Login_Panel
            // 
            this.Login_Panel.BackColor = System.Drawing.Color.White;
            this.Login_Panel.Controls.Add(this.Login_Btn);
            this.Login_Panel.Controls.Add(this.Login_X_Btn);
            this.Login_Panel.Controls.Add(this.Login_Password_Txt);
            this.Login_Panel.Controls.Add(this.Login_Password_Lbl);
            this.Login_Panel.Controls.Add(this.Login_Profile_Icon);
            this.Login_Panel.Location = new System.Drawing.Point(235, 18);
            this.Login_Panel.Name = "Login_Panel";
            this.Login_Panel.Size = new System.Drawing.Size(331, 365);
            this.Login_Panel.TabIndex = 5;
            // 
            // Login_Btn
            // 
            this.Login_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Login_Btn.FlatAppearance.BorderSize = 0;
            this.Login_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_Btn.ForeColor = System.Drawing.Color.White;
            this.Login_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Login_Btn.Location = new System.Drawing.Point(106, 315);
            this.Login_Btn.MaximumSize = new System.Drawing.Size(123, 40);
            this.Login_Btn.MinimumSize = new System.Drawing.Size(119, 36);
            this.Login_Btn.Name = "Login_Btn";
            this.Login_Btn.Size = new System.Drawing.Size(119, 36);
            this.Login_Btn.TabIndex = 4;
            this.Login_Btn.Text = "Login";
            this.Login_Btn.UseVisualStyleBackColor = false;
            this.Login_Btn.Click += new System.EventHandler(this.Login_Btn_Click);
            this.Login_Btn.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Login_Btn.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // Login_X_Btn
            // 
            this.Login_X_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Login_X_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Login_X_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_X_Btn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Login_X_Btn.Location = new System.Drawing.Point(291, 5);
            this.Login_X_Btn.MaximumSize = new System.Drawing.Size(35, 28);
            this.Login_X_Btn.MinimumSize = new System.Drawing.Size(33, 26);
            this.Login_X_Btn.Name = "Login_X_Btn";
            this.Login_X_Btn.Size = new System.Drawing.Size(33, 26);
            this.Login_X_Btn.TabIndex = 3;
            this.Login_X_Btn.Text = "X";
            this.Login_X_Btn.UseVisualStyleBackColor = false;
            this.Login_X_Btn.Click += new System.EventHandler(this.Login_X_Btn_Click);
            this.Login_X_Btn.MouseLeave += new System.EventHandler(this.X_Btn_MouseLeave);
            this.Login_X_Btn.MouseHover += new System.EventHandler(this.X_Btn_MouseHover);
            // 
            // Login_Password_Txt
            // 
            this.Login_Password_Txt.Location = new System.Drawing.Point(64, 213);
            this.Login_Password_Txt.Name = "Login_Password_Txt";
            this.Login_Password_Txt.Size = new System.Drawing.Size(202, 20);
            this.Login_Password_Txt.TabIndex = 2;
            this.Login_Password_Txt.UseSystemPasswordChar = true;
            this.Login_Password_Txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Login_EnterKey);
            // 
            // Login_Password_Lbl
            // 
            this.Login_Password_Lbl.AutoSize = true;
            this.Login_Password_Lbl.Location = new System.Drawing.Point(139, 192);
            this.Login_Password_Lbl.Name = "Login_Password_Lbl";
            this.Login_Password_Lbl.Size = new System.Drawing.Size(53, 13);
            this.Login_Password_Lbl.TabIndex = 1;
            this.Login_Password_Lbl.Text = "Password";
            // 
            // Login_Profile_Icon
            // 
            this.Login_Profile_Icon.Image = ((System.Drawing.Image)(resources.GetObject("Login_Profile_Icon.Image")));
            this.Login_Profile_Icon.Location = new System.Drawing.Point(90, 22);
            this.Login_Profile_Icon.Name = "Login_Profile_Icon";
            this.Login_Profile_Icon.Size = new System.Drawing.Size(151, 114);
            this.Login_Profile_Icon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Login_Profile_Icon.TabIndex = 0;
            this.Login_Profile_Icon.TabStop = false;
            // 
            // Btn_Expand_Timer
            // 
            this.Btn_Expand_Timer.Interval = 5;
            this.Btn_Expand_Timer.Tick += new System.EventHandler(this.Btn_Expand_Timer_Tick);
            // 
            // Btn_Shrink_Timer
            // 
            this.Btn_Shrink_Timer.Interval = 5;
            this.Btn_Shrink_Timer.Tick += new System.EventHandler(this.Btn_Shrink_Timer_Tick);
            // 
            // Create_New_Profile_Btn
            // 
            this.Create_New_Profile_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Create_New_Profile_Btn.FlatAppearance.BorderSize = 0;
            this.Create_New_Profile_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Create_New_Profile_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create_New_Profile_Btn.ForeColor = System.Drawing.Color.White;
            this.Create_New_Profile_Btn.Image = global::School_DB_Application.Properties.Resources.Add_Student_Icon;
            this.Create_New_Profile_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Create_New_Profile_Btn.Location = new System.Drawing.Point(547, 355);
            this.Create_New_Profile_Btn.MaximumSize = new System.Drawing.Size(200, 40);
            this.Create_New_Profile_Btn.MinimumSize = new System.Drawing.Size(194, 36);
            this.Create_New_Profile_Btn.Name = "Create_New_Profile_Btn";
            this.Create_New_Profile_Btn.Size = new System.Drawing.Size(194, 36);
            this.Create_New_Profile_Btn.TabIndex = 2;
            this.Create_New_Profile_Btn.Text = "Create new profile";
            this.Create_New_Profile_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Create_New_Profile_Btn.UseVisualStyleBackColor = false;
            this.Create_New_Profile_Btn.Click += new System.EventHandler(this.Create_New_Profile_Btn_Click);
            this.Create_New_Profile_Btn.MouseLeave += new System.EventHandler(this.Btn_MouseLeave);
            this.Create_New_Profile_Btn.MouseHover += new System.EventHandler(this.Btn_MouseHover);
            // 
            // Login_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.Login_Panel);
            this.Controls.Add(this.Create_New_Profile_panel);
            this.Controls.Add(this.Create_New_Profile_Btn);
            this.Controls.Add(this.Your_Profiles_Label);
            this.Controls.Add(this.Profile_List);
            this.Name = "Login_Page";
            this.Size = new System.Drawing.Size(800, 400);
            this.Profile_List.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.Create_New_Profile_panel.ResumeLayout(false);
            this.Create_New_Profile_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Login_Panel.ResumeLayout(false);
            this.Login_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Login_Profile_Icon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Profile_List;
        private System.Windows.Forms.Label Your_Profiles_Label;
        private System.Windows.Forms.Button Create_New_Profile_Btn;
        private System.Windows.Forms.Panel Create_New_Profile_panel;
        private System.Windows.Forms.Button Create_Btn;
        private System.Windows.Forms.Button X_CreateNewProfile_Btn;
        private System.Windows.Forms.TextBox Username_Txt;
        private System.Windows.Forms.Label Username_Lbl;
        private System.Windows.Forms.TextBox ServerToken_Txt;
        private System.Windows.Forms.TextBox Password_Txt;
        private System.Windows.Forms.Label ServerToken_Lbl;
        private System.Windows.Forms.Label Password_Lbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel Login_Panel;
        private System.Windows.Forms.Button Login_Btn;
        private System.Windows.Forms.Button Login_X_Btn;
        private System.Windows.Forms.TextBox Login_Password_Txt;
        private System.Windows.Forms.Label Login_Password_Lbl;
        private System.Windows.Forms.PictureBox Login_Profile_Icon;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer Btn_Expand_Timer;
        private System.Windows.Forms.Timer Btn_Shrink_Timer;
    }
}
