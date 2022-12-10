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
    public partial class Mail : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        public Mail(ViewController viewController,Controller controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            MainNewReq_Pnl.Hide();
            ViewReqMain_Pnl.Hide();
            Inbox_Tab.PerformClick();
        }

        

        private void Sent_Tab_Click(object sender, EventArgs e)
        {
            Sent_Tab.FillColor = Color.White;
            Sent_Tab.ForeColor = Color.Black;
            Inbox_Tab.FillColor = Color.FromArgb(64, 66, 88);
            Inbox_Tab.ForeColor = Color.White;
        }

        private void Inbox_Tab_Click(object sender, EventArgs e)
        {
            Inbox_Tab.FillColor = Color.White;
            Inbox_Tab.ForeColor = Color.Black;
            Sent_Tab.FillColor = Color.FromArgb(64, 66, 88);
            Sent_Tab.ForeColor = Color.White;
        }

        private void Compose_Btn_Click(object sender, EventArgs e)
        {
            MainNewReq_Pnl.Show();
        }

        private void NewReq_Back_Btn_Click(object sender, EventArgs e)
        {
            MainNewReq_Pnl.Hide();
        }

        private void View_Req_Btn_Click(object sender, EventArgs e)
        {
            ViewReqMain_Pnl.Show();
        }

        private void ViewReqBack_Btn_Click(object sender, EventArgs e)
        {
            ViewReqMain_Pnl.Hide();
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.viewMainPage();
        }
    }
}
