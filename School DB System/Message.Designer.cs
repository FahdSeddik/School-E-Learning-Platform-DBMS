namespace School_DB_System
{
    partial class Message
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Message));
            this.Main_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.Sub_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.ReqMessage_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.ReqTitle_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.ReqSubj_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.NewReqSenderOrReciver_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.NewReqSenderOrReciver_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Menu_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.NewMsg_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Back_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.Disapprove_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.Approve_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.Main_Pnl.SuspendLayout();
            this.Sub_Pnl.SuspendLayout();
            this.Menu_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // Main_Pnl
            // 
            this.Main_Pnl.Controls.Add(this.Approve_Btn);
            this.Main_Pnl.Controls.Add(this.Disapprove_Btn);
            this.Main_Pnl.Controls.Add(this.Sub_Pnl);
            this.Main_Pnl.Controls.Add(this.Menu_Pnl);
            this.Main_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Main_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Main_Pnl.Name = "Main_Pnl";
            this.Main_Pnl.Size = new System.Drawing.Size(873, 539);
            this.Main_Pnl.TabIndex = 12;
            // 
            // Sub_Pnl
            // 
            this.Sub_Pnl.AutoScroll = true;
            this.Sub_Pnl.BackColor = System.Drawing.Color.White;
            this.Sub_Pnl.Controls.Add(this.ReqMessage_Txt);
            this.Sub_Pnl.Controls.Add(this.ReqTitle_Txt);
            this.Sub_Pnl.Controls.Add(this.ReqSubj_Lbl);
            this.Sub_Pnl.Controls.Add(this.NewReqSenderOrReciver_Txt);
            this.Sub_Pnl.Controls.Add(this.NewReqSenderOrReciver_Lbl);
            this.Sub_Pnl.Location = new System.Drawing.Point(28, 69);
            this.Sub_Pnl.Name = "Sub_Pnl";
            this.Sub_Pnl.Size = new System.Drawing.Size(822, 418);
            this.Sub_Pnl.TabIndex = 3;
            // 
            // ReqMessage_Txt
            // 
            this.ReqMessage_Txt.BorderColor = System.Drawing.Color.Gray;
            this.ReqMessage_Txt.BorderRadius = 3;
            this.ReqMessage_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ReqMessage_Txt.DefaultText = "";
            this.ReqMessage_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ReqMessage_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ReqMessage_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ReqMessage_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ReqMessage_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ReqMessage_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ReqMessage_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ReqMessage_Txt.Location = new System.Drawing.Point(83, 114);
            this.ReqMessage_Txt.Name = "ReqMessage_Txt";
            this.ReqMessage_Txt.PasswordChar = '\0';
            this.ReqMessage_Txt.PlaceholderText = "Type your message...";
            this.ReqMessage_Txt.SelectedText = "";
            this.ReqMessage_Txt.Size = new System.Drawing.Size(707, 273);
            this.ReqMessage_Txt.TabIndex = 12;
            this.ReqMessage_Txt.TextOffset = new System.Drawing.Point(0, -116);
            // 
            // ReqTitle_Txt
            // 
            this.ReqTitle_Txt.BorderColor = System.Drawing.Color.Gray;
            this.ReqTitle_Txt.BorderRadius = 3;
            this.ReqTitle_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ReqTitle_Txt.DefaultText = "";
            this.ReqTitle_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.ReqTitle_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.ReqTitle_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ReqTitle_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.ReqTitle_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ReqTitle_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ReqTitle_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.ReqTitle_Txt.Location = new System.Drawing.Point(83, 61);
            this.ReqTitle_Txt.Name = "ReqTitle_Txt";
            this.ReqTitle_Txt.PasswordChar = '\0';
            this.ReqTitle_Txt.PlaceholderText = "Subject";
            this.ReqTitle_Txt.SelectedText = "";
            this.ReqTitle_Txt.Size = new System.Drawing.Size(707, 31);
            this.ReqTitle_Txt.TabIndex = 11;
            // 
            // ReqSubj_Lbl
            // 
            this.ReqSubj_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.ReqSubj_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReqSubj_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.ReqSubj_Lbl.Location = new System.Drawing.Point(23, 68);
            this.ReqSubj_Lbl.Name = "ReqSubj_Lbl";
            this.ReqSubj_Lbl.Size = new System.Drawing.Size(41, 15);
            this.ReqSubj_Lbl.TabIndex = 10;
            this.ReqSubj_Lbl.Text = "Subject";
            // 
            // NewReqSenderOrReciver_Txt
            // 
            this.NewReqSenderOrReciver_Txt.BorderColor = System.Drawing.Color.Gray;
            this.NewReqSenderOrReciver_Txt.BorderRadius = 3;
            this.NewReqSenderOrReciver_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.NewReqSenderOrReciver_Txt.DefaultText = "";
            this.NewReqSenderOrReciver_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.NewReqSenderOrReciver_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.NewReqSenderOrReciver_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewReqSenderOrReciver_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.NewReqSenderOrReciver_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NewReqSenderOrReciver_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.NewReqSenderOrReciver_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.NewReqSenderOrReciver_Txt.Location = new System.Drawing.Point(83, 19);
            this.NewReqSenderOrReciver_Txt.Name = "NewReqSenderOrReciver_Txt";
            this.NewReqSenderOrReciver_Txt.PasswordChar = '\0';
            this.NewReqSenderOrReciver_Txt.PlaceholderText = "Email Adress";
            this.NewReqSenderOrReciver_Txt.SelectedText = "";
            this.NewReqSenderOrReciver_Txt.Size = new System.Drawing.Size(707, 31);
            this.NewReqSenderOrReciver_Txt.TabIndex = 9;
            // 
            // NewReqSenderOrReciver_Lbl
            // 
            this.NewReqSenderOrReciver_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.NewReqSenderOrReciver_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewReqSenderOrReciver_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.NewReqSenderOrReciver_Lbl.Location = new System.Drawing.Point(23, 25);
            this.NewReqSenderOrReciver_Lbl.Name = "NewReqSenderOrReciver_Lbl";
            this.NewReqSenderOrReciver_Lbl.Size = new System.Drawing.Size(16, 15);
            this.NewReqSenderOrReciver_Lbl.TabIndex = 2;
            this.NewReqSenderOrReciver_Lbl.Text = "To";
            // 
            // Menu_Pnl
            // 
            this.Menu_Pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.Menu_Pnl.Controls.Add(this.Back_Btn);
            this.Menu_Pnl.Controls.Add(this.NewMsg_Lbl);
            this.Menu_Pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Menu_Pnl.Location = new System.Drawing.Point(0, 0);
            this.Menu_Pnl.Name = "Menu_Pnl";
            this.Menu_Pnl.Size = new System.Drawing.Size(873, 52);
            this.Menu_Pnl.TabIndex = 0;
            // 
            // NewMsg_Lbl
            // 
            this.NewMsg_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.NewMsg_Lbl.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.NewMsg_Lbl.ForeColor = System.Drawing.Color.Transparent;
            this.NewMsg_Lbl.Location = new System.Drawing.Point(347, 6);
            this.NewMsg_Lbl.Name = "NewMsg_Lbl";
            this.NewMsg_Lbl.Size = new System.Drawing.Size(180, 39);
            this.NewMsg_Lbl.TabIndex = 2;
            this.NewMsg_Lbl.Text = "New Message";
            // 
            // Back_Btn
            // 
            this.Back_Btn.BorderColor = System.Drawing.Color.Silver;
            this.Back_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Back_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Back_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Back_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Back_Btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.Back_Btn.FillColor = System.Drawing.Color.Silver;
            this.Back_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_Btn.ForeColor = System.Drawing.Color.White;
            this.Back_Btn.Image = ((System.Drawing.Image)(resources.GetObject("Back_Btn.Image")));
            this.Back_Btn.Location = new System.Drawing.Point(0, 0);
            this.Back_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Back_Btn.Name = "Back_Btn";
            this.Back_Btn.Size = new System.Drawing.Size(144, 52);
            this.Back_Btn.TabIndex = 1;
            this.Back_Btn.Click += new System.EventHandler(this.Back_Btn_Click);
            // 
            // Disapprove_Btn
            // 
            this.Disapprove_Btn.BorderRadius = 10;
            this.Disapprove_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Disapprove_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Disapprove_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Disapprove_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Disapprove_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.Disapprove_Btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Disapprove_Btn.ForeColor = System.Drawing.Color.White;
            this.Disapprove_Btn.Location = new System.Drawing.Point(28, 493);
            this.Disapprove_Btn.Name = "Disapprove_Btn";
            this.Disapprove_Btn.Size = new System.Drawing.Size(180, 34);
            this.Disapprove_Btn.TabIndex = 6;
            this.Disapprove_Btn.Text = "Disapprove";
            this.Disapprove_Btn.Click += new System.EventHandler(this.Disapprove_Btn_Click);
            // 
            // Approve_Btn
            // 
            this.Approve_Btn.BorderRadius = 10;
            this.Approve_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Approve_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Approve_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Approve_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Approve_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.Approve_Btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Approve_Btn.ForeColor = System.Drawing.Color.White;
            this.Approve_Btn.Location = new System.Drawing.Point(666, 493);
            this.Approve_Btn.Name = "Approve_Btn";
            this.Approve_Btn.Size = new System.Drawing.Size(180, 34);
            this.Approve_Btn.TabIndex = 7;
            this.Approve_Btn.Text = "Approve";
            this.Approve_Btn.Click += new System.EventHandler(this.Approve_Btn_Click);
            // 
            // Message
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Main_Pnl);
            this.Name = "Message";
            this.Size = new System.Drawing.Size(873, 539);
            this.Main_Pnl.ResumeLayout(false);
            this.Sub_Pnl.ResumeLayout(false);
            this.Sub_Pnl.PerformLayout();
            this.Menu_Pnl.ResumeLayout(false);
            this.Menu_Pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel Main_Pnl;
        private Guna.UI2.WinForms.Guna2GradientPanel Sub_Pnl;
        private Guna.UI2.WinForms.Guna2TextBox ReqMessage_Txt;
        private Guna.UI2.WinForms.Guna2TextBox ReqTitle_Txt;
        private Guna.UI2.WinForms.Guna2HtmlLabel ReqSubj_Lbl;
        private Guna.UI2.WinForms.Guna2TextBox NewReqSenderOrReciver_Txt;
        private Guna.UI2.WinForms.Guna2HtmlLabel NewReqSenderOrReciver_Lbl;
        private Guna.UI2.WinForms.Guna2Panel Menu_Pnl;
        private Guna.UI2.WinForms.Guna2Button Back_Btn;
        private Guna.UI2.WinForms.Guna2HtmlLabel NewMsg_Lbl;
        private Guna.UI2.WinForms.Guna2Button Approve_Btn;
        private Guna.UI2.WinForms.Guna2Button Disapprove_Btn;
    }
}
