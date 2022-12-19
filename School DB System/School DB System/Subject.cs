using System;
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
    public partial class Subject : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        public Subject(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            TeachersListMain_Pnl.Hide();
            AddSubjMain_Pnl.Hide();
            UpdateSubjMain_Pnl.Hide();
            AddSubjMain_Pnl.Hide();
            ViewSubjMain_Pnl.Hide();
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.Logout();
        }

        private void AddTeachID_Txt_Click(object sender, EventArgs e)
        {
            TeachersListMain_Pnl.Show();
            TeachersListMain_Pnl.BringToFront();
        }

        private void AddSubj_Btn_Click(object sender, EventArgs e)
        {
            AddSubjMain_Pnl.Show();
        }

        private void UpdateSubj_Btn_Click(object sender, EventArgs e)
        {
            UpdateSubjMain_Pnl.Show();
        }

        private void UpdateSubjBack_btn_Click(object sender, EventArgs e)
        {
            UpdateSubjMain_Pnl.Hide();
        }

        private void AddSubjBack_Btn_Click(object sender, EventArgs e)
        {
            AddSubjMain_Pnl.Hide();
        }

        private void TeachersListBack_Btn_Click(object sender, EventArgs e)
        {
            TeachersListMain_Pnl.Hide();
        }

        private void UpdateTeachID_Txt_Click(object sender, EventArgs e)
        {
            TeachersListMain_Pnl.Show();
            TeachersListMain_Pnl.BringToFront();
        }

        private void ViewSubjBack_Btn_Click(object sender, EventArgs e)
        {
            ViewSubjMain_Pnl.Hide();
        }

        private void ViewSubj_Btn_Click(object sender, EventArgs e)
        {
            ViewSubjMain_Pnl.Show();
        }
    }
}
