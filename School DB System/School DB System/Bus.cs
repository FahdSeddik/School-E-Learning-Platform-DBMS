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
    public partial class Bus : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        public Bus(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            DList_Pnl.Hide();
            AddStudList_Pnl.Hide();
            BStudList_Pnl.Hide();
            ViewProf_Pnl.Hide();
            BInfoMain_Pnl.Hide();
            Update_Pnl.Hide();
            Add_Pnl.Hide();
            this.controllerObj = controllerObj;
        }

        private void Add_B_ID_Txt_Click(object sender, EventArgs e)
        {
            DList_Pnl.Show();
            DList_Pnl.BringToFront();
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.viewMainPage();
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            Add_Pnl.Show();
        }

        private void Update_Btn_Click(object sender, EventArgs e)
        {
            Update_Pnl.Show();
        }

        private void ViewInfo_Btn_Click(object sender, EventArgs e)
        {
            BInfoMain_Pnl.Show();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            BStudList_Pnl.Show();
            BStudList_Pnl.BringToFront();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            AddStudList_Pnl.Show();
            AddStudList_Pnl.BringToFront();
        }

        private void ViewProf_Btn_Click(object sender, EventArgs e)
        {
            ViewProf_Pnl.Show();
            ViewProf_Pnl.BringToFront();
        }


        private void BStudL_Back_Btn_Click(object sender, EventArgs e)
        {
            BStudList_Pnl.Hide();
        }

        private void BInfo_Back_Btn_Click(object sender, EventArgs e)
        {
            BInfoMain_Pnl.Hide();
        }

        private void BUpdate_Back_Btn_Click(object sender, EventArgs e)
        {
            Update_Pnl.Hide();
        }

        private void B_Add_Back_Btn_Click(object sender, EventArgs e)
        {
            Add_Pnl.Hide();
        }

        private void StudL_Back_Btn_Click(object sender, EventArgs e)
        {
            AddStudList_Pnl.Hide();
        }

        private void View_Back_Btn_Click(object sender, EventArgs e)
        {
            ViewProf_Pnl.Hide();
        }

        private void DL_Back_Btn_Click(object sender, EventArgs e)
        {
            DList_Pnl.Hide();
        }
    }
}
