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
    public partial class Requests : UserControl
    {
        ViewController viewController;
        public Requests(ViewController viewController,int authority)
        {
            InitializeComponent();
            this.viewController = viewController;
            MainNewReq_Pnl.Hide();
            ViewReqMain_Pnl.Hide();
            Inbox_Tab.PerformClick();
            if(authority != 1)
            {
                NormalView();
            }
        }

        private void NormalView()
        {
            ApproveReq_Btn.Hide();
            Req_DT.Columns.RemoveAt(2);
            Req_DT.Columns[2].HeaderText = "Email";
            int LblX = SenderEmail_Lbl.Location.X;
            int LblY = SenderEmail_Lbl.Location.Y;
            ReceiverEmail_Lbl.Location = new Point(LblX, LblY);
            LblX = SenderEmail_Txt.Location.X;
            LblY = SenderEmail_Txt.Location.Y;
            ReceiverEmail_Txt.Location = new Point(LblX, LblY);
            SenderEmail_Lbl.Hide();
            SenderEmail_Txt.Hide();
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
