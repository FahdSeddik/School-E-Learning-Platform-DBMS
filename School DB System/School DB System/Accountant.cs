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
    public partial class Accountant : UserControl
    {
        ViewController viewController;
        public Accountant(ViewController viewController)
        {
            InitializeComponent();
            this.viewController = viewController;
        }

        private void Stud_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewStudent();
        }

        private void Teach_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewTeacher();
        }

        private void Stat_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewStatistics();
        }

        private void Reqs_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewMail();
        }
    }
}
