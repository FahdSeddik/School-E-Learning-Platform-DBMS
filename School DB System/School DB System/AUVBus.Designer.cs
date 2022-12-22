namespace School_DB_System
{
    partial class AUVBus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AUVBus));
            this.BMain_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.Submit_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.BSub_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.Bus_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Add_Route_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.BNum_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.BMenu_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.Title_Txt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.BBack_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.BStudList_Txt = new Guna.UI2.WinForms.Guna2Button();
            this.BDriver_CBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.BDriver_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.BCap_Nud = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Note_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.BMain_Pnl.SuspendLayout();
            this.BSub_Pnl.SuspendLayout();
            this.BMenu_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCap_Nud)).BeginInit();
            this.SuspendLayout();
            // 
            // BMain_Pnl
            // 
            this.BMain_Pnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.BMain_Pnl.BorderThickness = 3;
            this.BMain_Pnl.Controls.Add(this.Submit_Btn);
            this.BMain_Pnl.Controls.Add(this.BSub_Pnl);
            this.BMain_Pnl.Controls.Add(this.BMenu_Pnl);
            this.BMain_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BMain_Pnl.Location = new System.Drawing.Point(0, 0);
            this.BMain_Pnl.Name = "BMain_Pnl";
            this.BMain_Pnl.Size = new System.Drawing.Size(447, 544);
            this.BMain_Pnl.TabIndex = 12;
            // 
            // Submit_Btn
            // 
            this.Submit_Btn.BorderRadius = 10;
            this.Submit_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Submit_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Submit_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Submit_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Submit_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.Submit_Btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Submit_Btn.ForeColor = System.Drawing.Color.White;
            this.Submit_Btn.Location = new System.Drawing.Point(124, 482);
            this.Submit_Btn.Name = "Submit_Btn";
            this.Submit_Btn.Size = new System.Drawing.Size(180, 34);
            this.Submit_Btn.TabIndex = 6;
            this.Submit_Btn.Text = "Submit";
            this.Submit_Btn.Click += new System.EventHandler(this.Submit_Btn_Click);
            // 
            // BSub_Pnl
            // 
            this.BSub_Pnl.AutoScroll = true;
            this.BSub_Pnl.BackColor = System.Drawing.Color.White;
            this.BSub_Pnl.Controls.Add(this.Note_Lbl);
            this.BSub_Pnl.Controls.Add(this.BCap_Nud);
            this.BSub_Pnl.Controls.Add(this.guna2HtmlLabel1);
            this.BSub_Pnl.Controls.Add(this.BDriver_Lbl);
            this.BSub_Pnl.Controls.Add(this.BDriver_CBox);
            this.BSub_Pnl.Controls.Add(this.BStudList_Txt);
            this.BSub_Pnl.Controls.Add(this.Bus_Lbl);
            this.BSub_Pnl.Controls.Add(this.Add_Route_Txt);
            this.BSub_Pnl.Controls.Add(this.BNum_Txt);
            this.BSub_Pnl.Location = new System.Drawing.Point(30, 73);
            this.BSub_Pnl.Name = "BSub_Pnl";
            this.BSub_Pnl.Size = new System.Drawing.Size(380, 393);
            this.BSub_Pnl.TabIndex = 3;
            // 
            // Bus_Lbl
            // 
            this.Bus_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Bus_Lbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bus_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.Bus_Lbl.Location = new System.Drawing.Point(169, 2);
            this.Bus_Lbl.Name = "Bus_Lbl";
            this.Bus_Lbl.Size = new System.Drawing.Size(38, 32);
            this.Bus_Lbl.TabIndex = 24;
            this.Bus_Lbl.Text = "Bus";
            // 
            // Add_Route_Txt
            // 
            this.Add_Route_Txt.BorderColor = System.Drawing.Color.Gray;
            this.Add_Route_Txt.BorderRadius = 3;
            this.Add_Route_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Add_Route_Txt.DefaultText = "";
            this.Add_Route_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.Add_Route_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.Add_Route_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Add_Route_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.Add_Route_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Add_Route_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Add_Route_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.Add_Route_Txt.Location = new System.Drawing.Point(67, 222);
            this.Add_Route_Txt.Name = "Add_Route_Txt";
            this.Add_Route_Txt.PasswordChar = '\0';
            this.Add_Route_Txt.PlaceholderText = "Bus Route";
            this.Add_Route_Txt.SelectedText = "";
            this.Add_Route_Txt.Size = new System.Drawing.Size(249, 87);
            this.Add_Route_Txt.TabIndex = 9;
            this.Add_Route_Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BNum_Txt
            // 
            this.BNum_Txt.BorderColor = System.Drawing.Color.Gray;
            this.BNum_Txt.BorderRadius = 3;
            this.BNum_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BNum_Txt.DefaultText = "";
            this.BNum_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.BNum_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.BNum_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BNum_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.BNum_Txt.Enabled = false;
            this.BNum_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BNum_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BNum_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BNum_Txt.Location = new System.Drawing.Point(67, 40);
            this.BNum_Txt.Name = "BNum_Txt";
            this.BNum_Txt.PasswordChar = '\0';
            this.BNum_Txt.PlaceholderText = "Bus Number";
            this.BNum_Txt.SelectedText = "";
            this.BNum_Txt.Size = new System.Drawing.Size(249, 31);
            this.BNum_Txt.TabIndex = 1;
            this.BNum_Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BMenu_Pnl
            // 
            this.BMenu_Pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.BMenu_Pnl.Controls.Add(this.BBack_Btn);
            this.BMenu_Pnl.Controls.Add(this.Title_Txt);
            this.BMenu_Pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.BMenu_Pnl.Location = new System.Drawing.Point(0, 0);
            this.BMenu_Pnl.Name = "BMenu_Pnl";
            this.BMenu_Pnl.Size = new System.Drawing.Size(447, 52);
            this.BMenu_Pnl.TabIndex = 0;
            // 
            // Title_Txt
            // 
            this.Title_Txt.BackColor = System.Drawing.Color.Transparent;
            this.Title_Txt.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Title_Txt.ForeColor = System.Drawing.Color.Transparent;
            this.Title_Txt.Location = new System.Drawing.Point(181, 3);
            this.Title_Txt.Name = "Title_Txt";
            this.Title_Txt.Size = new System.Drawing.Size(61, 39);
            this.Title_Txt.TabIndex = 2;
            this.Title_Txt.Text = "Title";
            // 
            // BBack_Btn
            // 
            this.BBack_Btn.BorderColor = System.Drawing.Color.Silver;
            this.BBack_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BBack_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BBack_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BBack_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BBack_Btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.BBack_Btn.FillColor = System.Drawing.Color.Silver;
            this.BBack_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BBack_Btn.ForeColor = System.Drawing.Color.White;
            this.BBack_Btn.Image = ((System.Drawing.Image)(resources.GetObject("BBack_Btn.Image")));
            this.BBack_Btn.Location = new System.Drawing.Point(0, 0);
            this.BBack_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.BBack_Btn.Name = "BBack_Btn";
            this.BBack_Btn.Size = new System.Drawing.Size(61, 52);
            this.BBack_Btn.TabIndex = 1;
            // 
            // BStudList_Txt
            // 
            this.BStudList_Txt.BorderRadius = 10;
            this.BStudList_Txt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BStudList_Txt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BStudList_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BStudList_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BStudList_Txt.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.BStudList_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BStudList_Txt.ForeColor = System.Drawing.Color.White;
            this.BStudList_Txt.Location = new System.Drawing.Point(67, 325);
            this.BStudList_Txt.Name = "BStudList_Txt";
            this.BStudList_Txt.Size = new System.Drawing.Size(252, 34);
            this.BStudList_Txt.TabIndex = 25;
            this.BStudList_Txt.Text = "Student List";
            this.BStudList_Txt.Click += new System.EventHandler(this.BStudList_Txt_Click);
            // 
            // BDriver_CBox
            // 
            this.BDriver_CBox.BackColor = System.Drawing.Color.Transparent;
            this.BDriver_CBox.BorderColor = System.Drawing.Color.Gray;
            this.BDriver_CBox.BorderRadius = 3;
            this.BDriver_CBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.BDriver_CBox.DropDownHeight = 120;
            this.BDriver_CBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BDriver_CBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BDriver_CBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.BDriver_CBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BDriver_CBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.BDriver_CBox.IntegralHeight = false;
            this.BDriver_CBox.ItemHeight = 30;
            this.BDriver_CBox.Location = new System.Drawing.Point(67, 165);
            this.BDriver_CBox.Name = "BDriver_CBox";
            this.BDriver_CBox.Size = new System.Drawing.Size(249, 36);
            this.BDriver_CBox.TabIndex = 26;
            // 
            // BDriver_Lbl
            // 
            this.BDriver_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.BDriver_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BDriver_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.BDriver_Lbl.Location = new System.Drawing.Point(172, 143);
            this.BDriver_Lbl.Name = "BDriver_Lbl";
            this.BDriver_Lbl.Size = new System.Drawing.Size(34, 15);
            this.BDriver_Lbl.TabIndex = 27;
            this.BDriver_Lbl.Text = "Driver";
            // 
            // BCap_Nud
            // 
            this.BCap_Nud.BackColor = System.Drawing.Color.Transparent;
            this.BCap_Nud.BorderColor = System.Drawing.Color.Gray;
            this.BCap_Nud.BorderRadius = 3;
            this.BCap_Nud.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BCap_Nud.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BCap_Nud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.BCap_Nud.Location = new System.Drawing.Point(67, 101);
            this.BCap_Nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BCap_Nud.Name = "BCap_Nud";
            this.BCap_Nud.Size = new System.Drawing.Size(249, 36);
            this.BCap_Nud.TabIndex = 28;
            this.BCap_Nud.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.BCap_Nud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.Gray;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(163, 80);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(47, 15);
            this.guna2HtmlLabel1.TabIndex = 27;
            this.guna2HtmlLabel1.Text = "Capacity";
            // 
            // Note_Lbl
            // 
            this.Note_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Note_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.Note_Lbl.Location = new System.Drawing.Point(51, 367);
            this.Note_Lbl.Name = "Note_Lbl";
            this.Note_Lbl.Size = new System.Drawing.Size(294, 15);
            this.Note_Lbl.TabIndex = 29;
            this.Note_Lbl.Text = "Note: Students list is available on update or view bus info only";
            this.Note_Lbl.Visible = false;
            // 
            // AUVBus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BMain_Pnl);
            this.Name = "AUVBus";
            this.Size = new System.Drawing.Size(447, 544);
            this.BMain_Pnl.ResumeLayout(false);
            this.BSub_Pnl.ResumeLayout(false);
            this.BSub_Pnl.PerformLayout();
            this.BMenu_Pnl.ResumeLayout(false);
            this.BMenu_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BCap_Nud)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel BDriver_Lbl;
        protected Guna.UI2.WinForms.Guna2ComboBox BDriver_CBox;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        protected Guna.UI2.WinForms.Guna2Panel BMain_Pnl;
        protected Guna.UI2.WinForms.Guna2Button Submit_Btn;
        protected Guna.UI2.WinForms.Guna2GradientPanel BSub_Pnl;
        protected Guna.UI2.WinForms.Guna2HtmlLabel Bus_Lbl;
        protected Guna.UI2.WinForms.Guna2TextBox Add_Route_Txt;
        protected Guna.UI2.WinForms.Guna2TextBox BNum_Txt;
        protected Guna.UI2.WinForms.Guna2Panel BMenu_Pnl;
        protected Guna.UI2.WinForms.Guna2Button BBack_Btn;
        protected Guna.UI2.WinForms.Guna2HtmlLabel Title_Txt;
        protected Guna.UI2.WinForms.Guna2Button BStudList_Txt;
        protected Guna.UI2.WinForms.Guna2NumericUpDown BCap_Nud;
        protected Guna.UI2.WinForms.Guna2HtmlLabel Note_Lbl;
    }
}
