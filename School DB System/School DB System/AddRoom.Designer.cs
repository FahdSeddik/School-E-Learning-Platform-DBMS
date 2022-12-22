namespace School_DB_System
{
    partial class AddRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddRoom));
            this.RoomMain_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.RoomSubmit_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.RoomSub_Pnl = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.RoomProjector_CHBox = new Guna.UI2.WinForms.Guna2CheckBox();
            this.RoomCap_Nud = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.RoomCap_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RoomFloor_Nud = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.RoomFloor_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.BuildNum_Nud = new Guna.UI2.WinForms.Guna2NumericUpDown();
            this.BuildNum_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Room_Lbl = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RoomNum_Txt = new Guna.UI2.WinForms.Guna2TextBox();
            this.RoomMenu_Pnl = new Guna.UI2.WinForms.Guna2Panel();
            this.RoomBack_Btn = new Guna.UI2.WinForms.Guna2Button();
            this.Title_Txt = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.RoomMain_Pnl.SuspendLayout();
            this.RoomSub_Pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomCap_Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomFloor_Nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildNum_Nud)).BeginInit();
            this.RoomMenu_Pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // RoomMain_Pnl
            // 
            this.RoomMain_Pnl.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.RoomMain_Pnl.BorderThickness = 3;
            this.RoomMain_Pnl.Controls.Add(this.RoomSubmit_Btn);
            this.RoomMain_Pnl.Controls.Add(this.RoomSub_Pnl);
            this.RoomMain_Pnl.Controls.Add(this.RoomMenu_Pnl);
            this.RoomMain_Pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoomMain_Pnl.Location = new System.Drawing.Point(0, 0);
            this.RoomMain_Pnl.Name = "RoomMain_Pnl";
            this.RoomMain_Pnl.Size = new System.Drawing.Size(447, 544);
            this.RoomMain_Pnl.TabIndex = 13;
            // 
            // RoomSubmit_Btn
            // 
            this.RoomSubmit_Btn.BorderRadius = 10;
            this.RoomSubmit_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RoomSubmit_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RoomSubmit_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RoomSubmit_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RoomSubmit_Btn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.RoomSubmit_Btn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RoomSubmit_Btn.ForeColor = System.Drawing.Color.White;
            this.RoomSubmit_Btn.Location = new System.Drawing.Point(124, 482);
            this.RoomSubmit_Btn.Name = "RoomSubmit_Btn";
            this.RoomSubmit_Btn.Size = new System.Drawing.Size(180, 34);
            this.RoomSubmit_Btn.TabIndex = 6;
            this.RoomSubmit_Btn.Text = "Submit";
            this.RoomSubmit_Btn.Click += new System.EventHandler(this.RoomSubmit_Btn_Click);
            // 
            // RoomSub_Pnl
            // 
            this.RoomSub_Pnl.AutoScroll = true;
            this.RoomSub_Pnl.BackColor = System.Drawing.Color.White;
            this.RoomSub_Pnl.Controls.Add(this.RoomProjector_CHBox);
            this.RoomSub_Pnl.Controls.Add(this.RoomCap_Nud);
            this.RoomSub_Pnl.Controls.Add(this.RoomCap_Lbl);
            this.RoomSub_Pnl.Controls.Add(this.RoomFloor_Nud);
            this.RoomSub_Pnl.Controls.Add(this.RoomFloor_Lbl);
            this.RoomSub_Pnl.Controls.Add(this.BuildNum_Nud);
            this.RoomSub_Pnl.Controls.Add(this.BuildNum_Lbl);
            this.RoomSub_Pnl.Controls.Add(this.Room_Lbl);
            this.RoomSub_Pnl.Controls.Add(this.RoomNum_Txt);
            this.RoomSub_Pnl.Location = new System.Drawing.Point(30, 73);
            this.RoomSub_Pnl.Name = "RoomSub_Pnl";
            this.RoomSub_Pnl.Size = new System.Drawing.Size(380, 393);
            this.RoomSub_Pnl.TabIndex = 3;
            // 
            // RoomProjector_CHBox
            // 
            this.RoomProjector_CHBox.AutoSize = true;
            this.RoomProjector_CHBox.CheckedState.BorderColor = System.Drawing.Color.Silver;
            this.RoomProjector_CHBox.CheckedState.BorderRadius = 0;
            this.RoomProjector_CHBox.CheckedState.BorderThickness = 0;
            this.RoomProjector_CHBox.CheckedState.FillColor = System.Drawing.Color.Silver;
            this.RoomProjector_CHBox.CheckMarkColor = System.Drawing.Color.ForestGreen;
            this.RoomProjector_CHBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.RoomProjector_CHBox.ForeColor = System.Drawing.Color.Silver;
            this.RoomProjector_CHBox.Location = new System.Drawing.Point(67, 327);
            this.RoomProjector_CHBox.Name = "RoomProjector_CHBox";
            this.RoomProjector_CHBox.Size = new System.Drawing.Size(73, 17);
            this.RoomProjector_CHBox.TabIndex = 53;
            this.RoomProjector_CHBox.Text = "Projector";
            this.RoomProjector_CHBox.UncheckedState.BorderColor = System.Drawing.Color.Silver;
            this.RoomProjector_CHBox.UncheckedState.BorderRadius = 0;
            this.RoomProjector_CHBox.UncheckedState.BorderThickness = 0;
            this.RoomProjector_CHBox.UncheckedState.FillColor = System.Drawing.Color.Silver;
            // 
            // RoomCap_Nud
            // 
            this.RoomCap_Nud.BackColor = System.Drawing.Color.Transparent;
            this.RoomCap_Nud.BorderColor = System.Drawing.Color.Gray;
            this.RoomCap_Nud.BorderRadius = 3;
            this.RoomCap_Nud.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RoomCap_Nud.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RoomCap_Nud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RoomCap_Nud.Location = new System.Drawing.Point(67, 267);
            this.RoomCap_Nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RoomCap_Nud.Name = "RoomCap_Nud";
            this.RoomCap_Nud.Size = new System.Drawing.Size(249, 36);
            this.RoomCap_Nud.TabIndex = 28;
            this.RoomCap_Nud.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.RoomCap_Nud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RoomCap_Lbl
            // 
            this.RoomCap_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.RoomCap_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomCap_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.RoomCap_Lbl.Location = new System.Drawing.Point(160, 246);
            this.RoomCap_Lbl.Name = "RoomCap_Lbl";
            this.RoomCap_Lbl.Size = new System.Drawing.Size(47, 15);
            this.RoomCap_Lbl.TabIndex = 27;
            this.RoomCap_Lbl.Text = "Capacity";
            // 
            // RoomFloor_Nud
            // 
            this.RoomFloor_Nud.BackColor = System.Drawing.Color.Transparent;
            this.RoomFloor_Nud.BorderColor = System.Drawing.Color.Gray;
            this.RoomFloor_Nud.BorderRadius = 3;
            this.RoomFloor_Nud.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RoomFloor_Nud.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RoomFloor_Nud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.RoomFloor_Nud.Location = new System.Drawing.Point(67, 194);
            this.RoomFloor_Nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RoomFloor_Nud.Name = "RoomFloor_Nud";
            this.RoomFloor_Nud.Size = new System.Drawing.Size(249, 36);
            this.RoomFloor_Nud.TabIndex = 28;
            this.RoomFloor_Nud.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.RoomFloor_Nud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RoomFloor_Lbl
            // 
            this.RoomFloor_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.RoomFloor_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomFloor_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.RoomFloor_Lbl.Location = new System.Drawing.Point(152, 173);
            this.RoomFloor_Lbl.Name = "RoomFloor_Lbl";
            this.RoomFloor_Lbl.Size = new System.Drawing.Size(62, 15);
            this.RoomFloor_Lbl.TabIndex = 27;
            this.RoomFloor_Lbl.Text = "Room floor";
            // 
            // BuildNum_Nud
            // 
            this.BuildNum_Nud.BackColor = System.Drawing.Color.Transparent;
            this.BuildNum_Nud.BorderColor = System.Drawing.Color.Gray;
            this.BuildNum_Nud.BorderRadius = 3;
            this.BuildNum_Nud.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.BuildNum_Nud.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BuildNum_Nud.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.BuildNum_Nud.Location = new System.Drawing.Point(67, 123);
            this.BuildNum_Nud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BuildNum_Nud.Name = "BuildNum_Nud";
            this.BuildNum_Nud.Size = new System.Drawing.Size(249, 36);
            this.BuildNum_Nud.TabIndex = 28;
            this.BuildNum_Nud.UpDownButtonFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.BuildNum_Nud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // BuildNum_Lbl
            // 
            this.BuildNum_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.BuildNum_Lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuildNum_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.BuildNum_Lbl.Location = new System.Drawing.Point(139, 102);
            this.BuildNum_Lbl.Name = "BuildNum_Lbl";
            this.BuildNum_Lbl.Size = new System.Drawing.Size(93, 15);
            this.BuildNum_Lbl.TabIndex = 27;
            this.BuildNum_Lbl.Text = "Building Number";
            // 
            // Room_Lbl
            // 
            this.Room_Lbl.BackColor = System.Drawing.Color.Transparent;
            this.Room_Lbl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Room_Lbl.ForeColor = System.Drawing.Color.Gray;
            this.Room_Lbl.Location = new System.Drawing.Point(151, 4);
            this.Room_Lbl.Name = "Room_Lbl";
            this.Room_Lbl.Size = new System.Drawing.Size(62, 32);
            this.Room_Lbl.TabIndex = 24;
            this.Room_Lbl.Text = "Room";
            // 
            // RoomNum_Txt
            // 
            this.RoomNum_Txt.BorderColor = System.Drawing.Color.Gray;
            this.RoomNum_Txt.BorderRadius = 3;
            this.RoomNum_Txt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RoomNum_Txt.DefaultText = "";
            this.RoomNum_Txt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.RoomNum_Txt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.RoomNum_Txt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RoomNum_Txt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.RoomNum_Txt.Enabled = false;
            this.RoomNum_Txt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RoomNum_Txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.RoomNum_Txt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.RoomNum_Txt.Location = new System.Drawing.Point(67, 62);
            this.RoomNum_Txt.Name = "RoomNum_Txt";
            this.RoomNum_Txt.PasswordChar = '\0';
            this.RoomNum_Txt.PlaceholderText = "Room Number";
            this.RoomNum_Txt.SelectedText = "";
            this.RoomNum_Txt.Size = new System.Drawing.Size(249, 31);
            this.RoomNum_Txt.TabIndex = 1;
            this.RoomNum_Txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RoomMenu_Pnl
            // 
            this.RoomMenu_Pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.RoomMenu_Pnl.Controls.Add(this.RoomBack_Btn);
            this.RoomMenu_Pnl.Controls.Add(this.Title_Txt);
            this.RoomMenu_Pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.RoomMenu_Pnl.Location = new System.Drawing.Point(0, 0);
            this.RoomMenu_Pnl.Name = "RoomMenu_Pnl";
            this.RoomMenu_Pnl.Size = new System.Drawing.Size(447, 52);
            this.RoomMenu_Pnl.TabIndex = 0;
            // 
            // RoomBack_Btn
            // 
            this.RoomBack_Btn.BorderColor = System.Drawing.Color.Silver;
            this.RoomBack_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.RoomBack_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.RoomBack_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.RoomBack_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.RoomBack_Btn.Dock = System.Windows.Forms.DockStyle.Left;
            this.RoomBack_Btn.FillColor = System.Drawing.Color.Silver;
            this.RoomBack_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoomBack_Btn.ForeColor = System.Drawing.Color.White;
            this.RoomBack_Btn.Image = ((System.Drawing.Image)(resources.GetObject("RoomBack_Btn.Image")));
            this.RoomBack_Btn.Location = new System.Drawing.Point(0, 0);
            this.RoomBack_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.RoomBack_Btn.Name = "RoomBack_Btn";
            this.RoomBack_Btn.Size = new System.Drawing.Size(61, 52);
            this.RoomBack_Btn.TabIndex = 1;
            // 
            // Title_Txt
            // 
            this.Title_Txt.BackColor = System.Drawing.Color.Transparent;
            this.Title_Txt.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Title_Txt.ForeColor = System.Drawing.Color.Transparent;
            this.Title_Txt.Location = new System.Drawing.Point(147, 6);
            this.Title_Txt.Name = "Title_Txt";
            this.Title_Txt.Size = new System.Drawing.Size(140, 39);
            this.Title_Txt.TabIndex = 2;
            this.Title_Txt.Text = "Add Room";
            // 
            // AddRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RoomMain_Pnl);
            this.Name = "AddRoom";
            this.Size = new System.Drawing.Size(447, 544);
            this.RoomMain_Pnl.ResumeLayout(false);
            this.RoomSub_Pnl.ResumeLayout(false);
            this.RoomSub_Pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RoomCap_Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoomFloor_Nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BuildNum_Nud)).EndInit();
            this.RoomMenu_Pnl.ResumeLayout(false);
            this.RoomMenu_Pnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected Guna.UI2.WinForms.Guna2Panel RoomMain_Pnl;
        protected Guna.UI2.WinForms.Guna2Button RoomSubmit_Btn;
        protected Guna.UI2.WinForms.Guna2GradientPanel RoomSub_Pnl;
        protected Guna.UI2.WinForms.Guna2NumericUpDown BuildNum_Nud;
        private Guna.UI2.WinForms.Guna2HtmlLabel BuildNum_Lbl;
        protected Guna.UI2.WinForms.Guna2HtmlLabel Room_Lbl;
        protected Guna.UI2.WinForms.Guna2TextBox RoomNum_Txt;
        protected Guna.UI2.WinForms.Guna2Panel RoomMenu_Pnl;
        protected Guna.UI2.WinForms.Guna2Button RoomBack_Btn;
        protected Guna.UI2.WinForms.Guna2HtmlLabel Title_Txt;
        protected Guna.UI2.WinForms.Guna2NumericUpDown RoomCap_Nud;
        private Guna.UI2.WinForms.Guna2HtmlLabel RoomCap_Lbl;
        protected Guna.UI2.WinForms.Guna2NumericUpDown RoomFloor_Nud;
        private Guna.UI2.WinForms.Guna2HtmlLabel RoomFloor_Lbl;
        protected Guna.UI2.WinForms.Guna2CheckBox RoomProjector_CHBox;
    }
}
