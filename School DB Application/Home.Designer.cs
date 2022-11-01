namespace School_DB_Application
{
    partial class Home
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
            this.P_Username_Lbl = new System.Windows.Forms.Label();
            this.Add_Btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Profile_Panel = new System.Windows.Forms.Panel();
            this.Profile_Img = new System.Windows.Forms.PictureBox();
            this.Add_Dropdown_Panel = new System.Windows.Forms.Panel();
            this.Assign_Teacher_Room_Schedule_Btn = new System.Windows.Forms.Button();
            this.Add_Bus_Btn = new System.Windows.Forms.Button();
            this.Add_Student_Btn = new System.Windows.Forms.Button();
            this.Add_New_Teacher_Staff_Btn = new System.Windows.Forms.Button();
            this.Update_Dropdown_Panel = new System.Windows.Forms.Panel();
            this.Update_Subject_Btn = new System.Windows.Forms.Button();
            this.Update_Student_Btn = new System.Windows.Forms.Button();
            this.Update_Teacher_Btn = new System.Windows.Forms.Button();
            this.Update_Btn = new System.Windows.Forms.Button();
            this.View_Dropdown_Panel = new System.Windows.Forms.Panel();
            this.View_teacher_payroll_Btn = new System.Windows.Forms.Button();
            this.View_Staff_Btn = new System.Windows.Forms.Button();
            this.View_Btn = new System.Windows.Forms.Button();
            this.Remove_Dropdown_Panel = new System.Windows.Forms.Panel();
            this.Remove_Student_Btn = new System.Windows.Forms.Button();
            this.Remove_Btn = new System.Windows.Forms.Button();
            this.Op_View_Panel = new System.Windows.Forms.Panel();
            this.ToolBar_Panel = new System.Windows.Forms.Panel();
            this.Dropdown_Menu_Timer = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1.SuspendLayout();
            this.Profile_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profile_Img)).BeginInit();
            this.Add_Dropdown_Panel.SuspendLayout();
            this.Update_Dropdown_Panel.SuspendLayout();
            this.View_Dropdown_Panel.SuspendLayout();
            this.Remove_Dropdown_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_Username_Lbl
            // 
            this.P_Username_Lbl.AutoSize = true;
            this.P_Username_Lbl.Font = new System.Drawing.Font("Hacen Beirut", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P_Username_Lbl.ForeColor = System.Drawing.Color.GhostWhite;
            this.P_Username_Lbl.Location = new System.Drawing.Point(69, 10);
            this.P_Username_Lbl.Name = "P_Username_Lbl";
            this.P_Username_Lbl.Size = new System.Drawing.Size(62, 18);
            this.P_Username_Lbl.TabIndex = 1;
            this.P_Username_Lbl.Text = "Username";
            // 
            // Add_Btn
            // 
            this.Add_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Add_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Add_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Add_Btn.FlatAppearance.BorderSize = 0;
            this.Add_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Btn.Font = new System.Drawing.Font("Stencil Std", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Btn.ForeColor = System.Drawing.Color.GhostWhite;
            this.Add_Btn.Image = global::School_DB_Application.Properties.Resources.Down_Arrow;
            this.Add_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_Btn.Location = new System.Drawing.Point(0, 0);
            this.Add_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Add_Btn.MaximumSize = new System.Drawing.Size(204, 32);
            this.Add_Btn.MinimumSize = new System.Drawing.Size(200, 29);
            this.Add_Btn.Name = "Add_Btn";
            this.Add_Btn.Size = new System.Drawing.Size(200, 29);
            this.Add_Btn.TabIndex = 3;
            this.Add_Btn.Text = "Add";
            this.Add_Btn.UseVisualStyleBackColor = false;
            this.Add_Btn.Click += new System.EventHandler(this.Add_Btn_Click);
            this.Add_Btn.MouseLeave += new System.EventHandler(this.Menu_Btn_Leave);
            this.Add_Btn.MouseHover += new System.EventHandler(this.Menu_Btn_Hover);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.flowLayoutPanel1.Controls.Add(this.Profile_Panel);
            this.flowLayoutPanel1.Controls.Add(this.Add_Dropdown_Panel);
            this.flowLayoutPanel1.Controls.Add(this.Update_Dropdown_Panel);
            this.flowLayoutPanel1.Controls.Add(this.View_Dropdown_Panel);
            this.flowLayoutPanel1.Controls.Add(this.Remove_Dropdown_Panel);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 600);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // Profile_Panel
            // 
            this.Profile_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.Profile_Panel.Controls.Add(this.Profile_Img);
            this.Profile_Panel.Controls.Add(this.P_Username_Lbl);
            this.Profile_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Profile_Panel.Location = new System.Drawing.Point(0, 0);
            this.Profile_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Profile_Panel.Name = "Profile_Panel";
            this.Profile_Panel.Size = new System.Drawing.Size(200, 35);
            this.Profile_Panel.TabIndex = 0;
            // 
            // Profile_Img
            // 
            this.Profile_Img.Image = global::School_DB_Application.Properties.Resources.User_Profile_Icon;
            this.Profile_Img.Location = new System.Drawing.Point(6, 5);
            this.Profile_Img.Name = "Profile_Img";
            this.Profile_Img.Size = new System.Drawing.Size(29, 23);
            this.Profile_Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Profile_Img.TabIndex = 0;
            this.Profile_Img.TabStop = false;
            // 
            // Add_Dropdown_Panel
            // 
            this.Add_Dropdown_Panel.Controls.Add(this.Assign_Teacher_Room_Schedule_Btn);
            this.Add_Dropdown_Panel.Controls.Add(this.Add_Bus_Btn);
            this.Add_Dropdown_Panel.Controls.Add(this.Add_Student_Btn);
            this.Add_Dropdown_Panel.Controls.Add(this.Add_New_Teacher_Staff_Btn);
            this.Add_Dropdown_Panel.Controls.Add(this.Add_Btn);
            this.Add_Dropdown_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Add_Dropdown_Panel.Location = new System.Drawing.Point(0, 35);
            this.Add_Dropdown_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Add_Dropdown_Panel.MaximumSize = new System.Drawing.Size(200, 140);
            this.Add_Dropdown_Panel.MinimumSize = new System.Drawing.Size(200, 29);
            this.Add_Dropdown_Panel.Name = "Add_Dropdown_Panel";
            this.Add_Dropdown_Panel.Size = new System.Drawing.Size(200, 29);
            this.Add_Dropdown_Panel.TabIndex = 5;
            // 
            // Assign_Teacher_Room_Schedule_Btn
            // 
            this.Assign_Teacher_Room_Schedule_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Assign_Teacher_Room_Schedule_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Assign_Teacher_Room_Schedule_Btn.FlatAppearance.BorderSize = 0;
            this.Assign_Teacher_Room_Schedule_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Assign_Teacher_Room_Schedule_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assign_Teacher_Room_Schedule_Btn.ForeColor = System.Drawing.Color.White;
            this.Assign_Teacher_Room_Schedule_Btn.Image = global::School_DB_Application.Properties.Resources.Assign_To_Schedule_Icon;
            this.Assign_Teacher_Room_Schedule_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Assign_Teacher_Room_Schedule_Btn.Location = new System.Drawing.Point(0, 113);
            this.Assign_Teacher_Room_Schedule_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Assign_Teacher_Room_Schedule_Btn.Name = "Assign_Teacher_Room_Schedule_Btn";
            this.Assign_Teacher_Room_Schedule_Btn.Size = new System.Drawing.Size(200, 28);
            this.Assign_Teacher_Room_Schedule_Btn.TabIndex = 3;
            this.Assign_Teacher_Room_Schedule_Btn.Text = "Assign teacher room";
            this.Assign_Teacher_Room_Schedule_Btn.UseVisualStyleBackColor = false;
            // 
            // Add_Bus_Btn
            // 
            this.Add_Bus_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Add_Bus_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Add_Bus_Btn.FlatAppearance.BorderSize = 0;
            this.Add_Bus_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Bus_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Bus_Btn.ForeColor = System.Drawing.Color.White;
            this.Add_Bus_Btn.Image = global::School_DB_Application.Properties.Resources.Add_Bus_Icon;
            this.Add_Bus_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_Bus_Btn.Location = new System.Drawing.Point(0, 85);
            this.Add_Bus_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Add_Bus_Btn.Name = "Add_Bus_Btn";
            this.Add_Bus_Btn.Size = new System.Drawing.Size(200, 28);
            this.Add_Bus_Btn.TabIndex = 3;
            this.Add_Bus_Btn.Text = "Add new bus";
            this.Add_Bus_Btn.UseVisualStyleBackColor = false;
            // 
            // Add_Student_Btn
            // 
            this.Add_Student_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Add_Student_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Add_Student_Btn.FlatAppearance.BorderSize = 0;
            this.Add_Student_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_Student_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_Student_Btn.ForeColor = System.Drawing.Color.White;
            this.Add_Student_Btn.Image = global::School_DB_Application.Properties.Resources.Add_Student_Icon;
            this.Add_Student_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_Student_Btn.Location = new System.Drawing.Point(0, 57);
            this.Add_Student_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Add_Student_Btn.Name = "Add_Student_Btn";
            this.Add_Student_Btn.Size = new System.Drawing.Size(200, 28);
            this.Add_Student_Btn.TabIndex = 3;
            this.Add_Student_Btn.Text = "Add new student";
            this.Add_Student_Btn.UseVisualStyleBackColor = false;
            // 
            // Add_New_Teacher_Staff_Btn
            // 
            this.Add_New_Teacher_Staff_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Add_New_Teacher_Staff_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Add_New_Teacher_Staff_Btn.FlatAppearance.BorderSize = 0;
            this.Add_New_Teacher_Staff_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Add_New_Teacher_Staff_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Add_New_Teacher_Staff_Btn.ForeColor = System.Drawing.Color.White;
            this.Add_New_Teacher_Staff_Btn.Image = global::School_DB_Application.Properties.Resources.Add_Teacher_Icon;
            this.Add_New_Teacher_Staff_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Add_New_Teacher_Staff_Btn.Location = new System.Drawing.Point(0, 29);
            this.Add_New_Teacher_Staff_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Add_New_Teacher_Staff_Btn.Name = "Add_New_Teacher_Staff_Btn";
            this.Add_New_Teacher_Staff_Btn.Size = new System.Drawing.Size(200, 28);
            this.Add_New_Teacher_Staff_Btn.TabIndex = 3;
            this.Add_New_Teacher_Staff_Btn.Text = "Add new teacher";
            this.Add_New_Teacher_Staff_Btn.UseVisualStyleBackColor = false;
            // 
            // Update_Dropdown_Panel
            // 
            this.Update_Dropdown_Panel.Controls.Add(this.Update_Subject_Btn);
            this.Update_Dropdown_Panel.Controls.Add(this.Update_Student_Btn);
            this.Update_Dropdown_Panel.Controls.Add(this.Update_Teacher_Btn);
            this.Update_Dropdown_Panel.Controls.Add(this.Update_Btn);
            this.Update_Dropdown_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Update_Dropdown_Panel.Location = new System.Drawing.Point(0, 64);
            this.Update_Dropdown_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Update_Dropdown_Panel.MaximumSize = new System.Drawing.Size(200, 113);
            this.Update_Dropdown_Panel.MinimumSize = new System.Drawing.Size(200, 29);
            this.Update_Dropdown_Panel.Name = "Update_Dropdown_Panel";
            this.Update_Dropdown_Panel.Size = new System.Drawing.Size(200, 29);
            this.Update_Dropdown_Panel.TabIndex = 6;
            // 
            // Update_Subject_Btn
            // 
            this.Update_Subject_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Update_Subject_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Update_Subject_Btn.FlatAppearance.BorderSize = 0;
            this.Update_Subject_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_Subject_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Subject_Btn.ForeColor = System.Drawing.Color.White;
            this.Update_Subject_Btn.Image = global::School_DB_Application.Properties.Resources.Upd_Subj_Avail_Icon;
            this.Update_Subject_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Update_Subject_Btn.Location = new System.Drawing.Point(0, 85);
            this.Update_Subject_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Update_Subject_Btn.Name = "Update_Subject_Btn";
            this.Update_Subject_Btn.Size = new System.Drawing.Size(200, 28);
            this.Update_Subject_Btn.TabIndex = 3;
            this.Update_Subject_Btn.Text = "Update subject availability";
            this.Update_Subject_Btn.UseVisualStyleBackColor = false;
            // 
            // Update_Student_Btn
            // 
            this.Update_Student_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Update_Student_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Update_Student_Btn.FlatAppearance.BorderSize = 0;
            this.Update_Student_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_Student_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Student_Btn.ForeColor = System.Drawing.Color.White;
            this.Update_Student_Btn.Image = global::School_DB_Application.Properties.Resources.Update_Information_Icon;
            this.Update_Student_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Update_Student_Btn.Location = new System.Drawing.Point(0, 57);
            this.Update_Student_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Update_Student_Btn.Name = "Update_Student_Btn";
            this.Update_Student_Btn.Size = new System.Drawing.Size(200, 28);
            this.Update_Student_Btn.TabIndex = 3;
            this.Update_Student_Btn.Text = "Update student information";
            this.Update_Student_Btn.UseVisualStyleBackColor = false;
            // 
            // Update_Teacher_Btn
            // 
            this.Update_Teacher_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Update_Teacher_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Update_Teacher_Btn.FlatAppearance.BorderSize = 0;
            this.Update_Teacher_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_Teacher_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Update_Teacher_Btn.ForeColor = System.Drawing.Color.White;
            this.Update_Teacher_Btn.Image = global::School_DB_Application.Properties.Resources.Update_Information_Icon;
            this.Update_Teacher_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Update_Teacher_Btn.Location = new System.Drawing.Point(0, 29);
            this.Update_Teacher_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Update_Teacher_Btn.Name = "Update_Teacher_Btn";
            this.Update_Teacher_Btn.Size = new System.Drawing.Size(200, 28);
            this.Update_Teacher_Btn.TabIndex = 3;
            this.Update_Teacher_Btn.Text = "Update teacher information";
            this.Update_Teacher_Btn.UseVisualStyleBackColor = false;
            // 
            // Update_Btn
            // 
            this.Update_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Update_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Update_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Update_Btn.FlatAppearance.BorderSize = 0;
            this.Update_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Update_Btn.Font = new System.Drawing.Font("Stencil Std", 8.25F, System.Drawing.FontStyle.Bold);
            this.Update_Btn.ForeColor = System.Drawing.Color.GhostWhite;
            this.Update_Btn.Image = global::School_DB_Application.Properties.Resources.Down_Arrow;
            this.Update_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Update_Btn.Location = new System.Drawing.Point(0, 0);
            this.Update_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Update_Btn.MaximumSize = new System.Drawing.Size(204, 32);
            this.Update_Btn.MinimumSize = new System.Drawing.Size(200, 29);
            this.Update_Btn.Name = "Update_Btn";
            this.Update_Btn.Size = new System.Drawing.Size(200, 29);
            this.Update_Btn.TabIndex = 3;
            this.Update_Btn.Text = "Update";
            this.Update_Btn.UseVisualStyleBackColor = false;
            this.Update_Btn.Click += new System.EventHandler(this.Update_Btn_Click);
            this.Update_Btn.MouseLeave += new System.EventHandler(this.Menu_Btn_Leave);
            this.Update_Btn.MouseHover += new System.EventHandler(this.Menu_Btn_Hover);
            // 
            // View_Dropdown_Panel
            // 
            this.View_Dropdown_Panel.Controls.Add(this.View_teacher_payroll_Btn);
            this.View_Dropdown_Panel.Controls.Add(this.View_Staff_Btn);
            this.View_Dropdown_Panel.Controls.Add(this.View_Btn);
            this.View_Dropdown_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.View_Dropdown_Panel.Location = new System.Drawing.Point(0, 93);
            this.View_Dropdown_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.View_Dropdown_Panel.MaximumSize = new System.Drawing.Size(200, 85);
            this.View_Dropdown_Panel.MinimumSize = new System.Drawing.Size(200, 28);
            this.View_Dropdown_Panel.Name = "View_Dropdown_Panel";
            this.View_Dropdown_Panel.Size = new System.Drawing.Size(200, 28);
            this.View_Dropdown_Panel.TabIndex = 7;
            // 
            // View_teacher_payroll_Btn
            // 
            this.View_teacher_payroll_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.View_teacher_payroll_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.View_teacher_payroll_Btn.FlatAppearance.BorderSize = 0;
            this.View_teacher_payroll_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View_teacher_payroll_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_teacher_payroll_Btn.ForeColor = System.Drawing.Color.White;
            this.View_teacher_payroll_Btn.Image = global::School_DB_Application.Properties.Resources.View_Payroll_Icon;
            this.View_teacher_payroll_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.View_teacher_payroll_Btn.Location = new System.Drawing.Point(0, 57);
            this.View_teacher_payroll_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.View_teacher_payroll_Btn.Name = "View_teacher_payroll_Btn";
            this.View_teacher_payroll_Btn.Size = new System.Drawing.Size(200, 28);
            this.View_teacher_payroll_Btn.TabIndex = 3;
            this.View_teacher_payroll_Btn.Text = "View teacher payroll";
            this.View_teacher_payroll_Btn.UseVisualStyleBackColor = false;
            // 
            // View_Staff_Btn
            // 
            this.View_Staff_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.View_Staff_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.View_Staff_Btn.FlatAppearance.BorderSize = 0;
            this.View_Staff_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View_Staff_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.View_Staff_Btn.ForeColor = System.Drawing.Color.White;
            this.View_Staff_Btn.Image = global::School_DB_Application.Properties.Resources.View_Staff_Icon;
            this.View_Staff_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.View_Staff_Btn.Location = new System.Drawing.Point(0, 29);
            this.View_Staff_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.View_Staff_Btn.Name = "View_Staff_Btn";
            this.View_Staff_Btn.Size = new System.Drawing.Size(200, 28);
            this.View_Staff_Btn.TabIndex = 3;
            this.View_Staff_Btn.Text = "View staff";
            this.View_Staff_Btn.UseVisualStyleBackColor = false;
            // 
            // View_Btn
            // 
            this.View_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.View_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.View_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.View_Btn.FlatAppearance.BorderSize = 0;
            this.View_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.View_Btn.Font = new System.Drawing.Font("Stencil Std", 8.25F, System.Drawing.FontStyle.Bold);
            this.View_Btn.ForeColor = System.Drawing.Color.GhostWhite;
            this.View_Btn.Image = global::School_DB_Application.Properties.Resources.Down_Arrow;
            this.View_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.View_Btn.Location = new System.Drawing.Point(0, 0);
            this.View_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.View_Btn.MaximumSize = new System.Drawing.Size(204, 32);
            this.View_Btn.MinimumSize = new System.Drawing.Size(200, 29);
            this.View_Btn.Name = "View_Btn";
            this.View_Btn.Size = new System.Drawing.Size(200, 29);
            this.View_Btn.TabIndex = 3;
            this.View_Btn.Text = "View";
            this.View_Btn.UseVisualStyleBackColor = false;
            this.View_Btn.Click += new System.EventHandler(this.View_Btn_Click);
            this.View_Btn.MouseLeave += new System.EventHandler(this.Menu_Btn_Leave);
            this.View_Btn.MouseHover += new System.EventHandler(this.Menu_Btn_Hover);
            // 
            // Remove_Dropdown_Panel
            // 
            this.Remove_Dropdown_Panel.Controls.Add(this.Remove_Student_Btn);
            this.Remove_Dropdown_Panel.Controls.Add(this.Remove_Btn);
            this.Remove_Dropdown_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Remove_Dropdown_Panel.Location = new System.Drawing.Point(0, 121);
            this.Remove_Dropdown_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.Remove_Dropdown_Panel.MaximumSize = new System.Drawing.Size(200, 57);
            this.Remove_Dropdown_Panel.MinimumSize = new System.Drawing.Size(200, 28);
            this.Remove_Dropdown_Panel.Name = "Remove_Dropdown_Panel";
            this.Remove_Dropdown_Panel.Size = new System.Drawing.Size(200, 28);
            this.Remove_Dropdown_Panel.TabIndex = 8;
            // 
            // Remove_Student_Btn
            // 
            this.Remove_Student_Btn.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.Remove_Student_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Remove_Student_Btn.FlatAppearance.BorderSize = 0;
            this.Remove_Student_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove_Student_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove_Student_Btn.ForeColor = System.Drawing.Color.White;
            this.Remove_Student_Btn.Image = global::School_DB_Application.Properties.Resources.Remove_Stud_Icon;
            this.Remove_Student_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Remove_Student_Btn.Location = new System.Drawing.Point(0, 29);
            this.Remove_Student_Btn.Name = "Remove_Student_Btn";
            this.Remove_Student_Btn.Size = new System.Drawing.Size(200, 28);
            this.Remove_Student_Btn.TabIndex = 3;
            this.Remove_Student_Btn.Text = "Remove student";
            this.Remove_Student_Btn.UseVisualStyleBackColor = false;
            // 
            // Remove_Btn
            // 
            this.Remove_Btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.Remove_Btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Remove_Btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.Remove_Btn.FlatAppearance.BorderSize = 0;
            this.Remove_Btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Remove_Btn.Font = new System.Drawing.Font("Stencil Std", 8.25F, System.Drawing.FontStyle.Bold);
            this.Remove_Btn.ForeColor = System.Drawing.Color.GhostWhite;
            this.Remove_Btn.Image = global::School_DB_Application.Properties.Resources.Down_Arrow;
            this.Remove_Btn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Remove_Btn.Location = new System.Drawing.Point(0, 0);
            this.Remove_Btn.Margin = new System.Windows.Forms.Padding(0);
            this.Remove_Btn.MaximumSize = new System.Drawing.Size(204, 32);
            this.Remove_Btn.MinimumSize = new System.Drawing.Size(200, 29);
            this.Remove_Btn.Name = "Remove_Btn";
            this.Remove_Btn.Size = new System.Drawing.Size(200, 29);
            this.Remove_Btn.TabIndex = 3;
            this.Remove_Btn.Text = "Remove";
            this.Remove_Btn.UseVisualStyleBackColor = false;
            this.Remove_Btn.Click += new System.EventHandler(this.Remove_Btn_Click);
            this.Remove_Btn.MouseLeave += new System.EventHandler(this.Menu_Btn_Leave);
            this.Remove_Btn.MouseHover += new System.EventHandler(this.Menu_Btn_Hover);
            // 
            // Op_View_Panel
            // 
            this.Op_View_Panel.BackColor = System.Drawing.Color.White;
            this.Op_View_Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Op_View_Panel.Location = new System.Drawing.Point(226, 54);
            this.Op_View_Panel.Name = "Op_View_Panel";
            this.Op_View_Panel.Size = new System.Drawing.Size(751, 528);
            this.Op_View_Panel.TabIndex = 5;
            // 
            // ToolBar_Panel
            // 
            this.ToolBar_Panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.ToolBar_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolBar_Panel.Location = new System.Drawing.Point(200, 0);
            this.ToolBar_Panel.Margin = new System.Windows.Forms.Padding(0);
            this.ToolBar_Panel.Name = "ToolBar_Panel";
            this.ToolBar_Panel.Size = new System.Drawing.Size(800, 35);
            this.ToolBar_Panel.TabIndex = 6;
            // 
            // Dropdown_Menu_Timer
            // 
            this.Dropdown_Menu_Timer.Interval = 5;
            this.Dropdown_Menu_Timer.Tick += new System.EventHandler(this.Dropdown_Menu_Timer_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.Controls.Add(this.ToolBar_Panel);
            this.Controls.Add(this.Op_View_Panel);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(1000, 600);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.Profile_Panel.ResumeLayout(false);
            this.Profile_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Profile_Img)).EndInit();
            this.Add_Dropdown_Panel.ResumeLayout(false);
            this.Update_Dropdown_Panel.ResumeLayout(false);
            this.View_Dropdown_Panel.ResumeLayout(false);
            this.Remove_Dropdown_Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label P_Username_Lbl;
        private System.Windows.Forms.PictureBox Profile_Img;
        private System.Windows.Forms.Button Add_Btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel Profile_Panel;
        private System.Windows.Forms.Panel Add_Dropdown_Panel;
        private System.Windows.Forms.Button Add_Bus_Btn;
        private System.Windows.Forms.Button Add_Student_Btn;
        private System.Windows.Forms.Button Add_New_Teacher_Staff_Btn;
        private System.Windows.Forms.Button Assign_Teacher_Room_Schedule_Btn;
        private System.Windows.Forms.Panel Update_Dropdown_Panel;
        private System.Windows.Forms.Button Update_Subject_Btn;
        private System.Windows.Forms.Button Update_Student_Btn;
        private System.Windows.Forms.Button Update_Teacher_Btn;
        private System.Windows.Forms.Button Update_Btn;
        private System.Windows.Forms.Panel View_Dropdown_Panel;
        private System.Windows.Forms.Button View_teacher_payroll_Btn;
        private System.Windows.Forms.Button View_Staff_Btn;
        private System.Windows.Forms.Button View_Btn;
        private System.Windows.Forms.Panel Remove_Dropdown_Panel;
        private System.Windows.Forms.Button Remove_Student_Btn;
        private System.Windows.Forms.Button Remove_Btn;
        private System.Windows.Forms.Panel Op_View_Panel;
        private System.Windows.Forms.Panel ToolBar_Panel;
        private System.Windows.Forms.Timer Dropdown_Menu_Timer;
    }
}
