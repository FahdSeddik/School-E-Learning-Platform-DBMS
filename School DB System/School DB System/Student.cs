﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_DB_System
{
    public partial class Student : UserControl
    {
        ViewController viewController;
        public Student(ViewController viewController)
        {
            InitializeComponent();
            this.viewController = viewController;
            Stud_DT.Rows.Add(0, "12302", "Abaymooooon", "abaymoon@abaymoon.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Abaymooooon", "abaymoon@abaymoon.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Abaymooooon", "abaymoon@abaymoon.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Abaymooooon", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Amr Ashraf", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Abaymooooon", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Fahd Seddik", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Gaser Sami", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Amr Ashraf", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Amr Ashraf", "amrashraf@amrashraf.com", "1", "CS");
            Stud_DT.Rows.Add(0, "12302", "Amr Ashraf", "amrashraf@amrashraf.com", "1", "CS");
            ViewProf_Pnl.Hide();
            Add_Pnl.Hide();
            Update_Pnl.Hide();
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.viewMainPage();
        }

        private void View_Back_Btn_Click(object sender, EventArgs e)
        {
            ViewProf_Pnl.Hide();
        }

        private void Update_Back_Btn_Click(object sender, EventArgs e)
        {
            Update_Pnl.Hide();
        }

        private void Add_Back_Btn_Click(object sender, EventArgs e)
        {
            Add_Pnl.Hide();
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            Add_Pnl.Show();
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {

        }

        private void Update_Btn_Click(object sender, EventArgs e)
        {
            Update_Pnl.Show();
        }

        private void ViewProf_Btn_Click(object sender, EventArgs e)
        {
            ViewProf_Pnl.Show();
        }
    }
}