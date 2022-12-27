using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace School_DB_System
{
    public partial class Message : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        string Email;
        string SSN;
        string oldTitle;
        string oldReq;


        public Message(ViewController viewController, Controller controllerObj, string Email, string Title, string Message, int view)//view
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            NewReqSenderOrReciver_Txt.Text = Email;
            ReqTitle_Txt.Text = Title;
            ReqMessage_Txt.Text = Message;
            switch (view)
            {
                case 0:
                    InboxViewView();
                    break;
                case 1:
                    SentViewView();
                    break;
                default:
                    break;
            }


        }

        public Message(ViewController viewController, Controller controllerObj, string senderSSN, string reciverSSN,string oldTitle,string oldReq)//respond 
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            NewMessageView();
            SSN = senderSSN;
            DataTable reciverEmailDt = controllerObj.getEmailFromSSN(reciverSSN);
            string reciverEmail = reciverEmailDt.Rows[0][0].ToString();
            NewReqSenderOrReciver_Txt.Text = reciverEmail;
            this.oldTitle = oldTitle;
            this.oldReq = oldReq;

        }

        private void InboxViewView()
        {
            NewReqSenderOrReciver_Lbl.Text = "from";
            NewReqSenderOrReciver_Txt.Enabled = false;
            ReqTitle_Txt.Enabled = false;
            ReqMessage_Txt.Enabled = false;
            Approve_Btn.Visible = false;
            Disapprove_Btn.Visible = false;
            NewMsg_Lbl.Text = "Request";
        }

        private void SentViewView()
        {
            NewReqSenderOrReciver_Lbl.Text = "To";
            NewReqSenderOrReciver_Txt.Enabled = false;
            ReqTitle_Txt.Enabled = false;
            ReqMessage_Txt.Enabled = false;
            Approve_Btn.Visible = false;
            Disapprove_Btn.Visible = false;
            NewMsg_Lbl.Text = "Request";

        }

        private void NewMessageView()
        {
            NewReqSenderOrReciver_Lbl.Text = "To";
            NewReqSenderOrReciver_Txt.Enabled = true;
            ReqTitle_Txt.Enabled = true;
            Approve_Btn.Visible = true;
            Disapprove_Btn.Visible = true;
            NewReqSenderOrReciver_Txt.Enabled = false;
        }

        private void reset()
        {
            viewController.CloseSubTab();
        }

        private void Back_Btn_Click(object sender, EventArgs e)
        {
            viewController.CloseSubTab();
        }

        private void Disapprove_Btn_Click(object sender, EventArgs e)
        { 
            DataTable reciverDt = controllerObj.getSSNFromEmail(NewReqSenderOrReciver_Txt.Text.ToString());
            if(reciverDt == null)
            {
                return;
            }
            string  reciver = reciverDt.Rows[0][0].ToString();
            int res = controllerObj.Respond(SSN, reciver, ReqTitle_Txt.Text.ToString(), ReqMessage_Txt.Text.ToString(), 0,oldTitle,oldReq);
            if (res == 0)
            {
                RJMessageBox.Show("Failed, please try again.",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            else
            {
                RJMessageBox.Show("Respond sent successfully.",
              "information",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);
                reset();
                return;
            }
        }

        private void Approve_Btn_Click(object sender, EventArgs e)
        {
            DataTable reciverDt = controllerObj.getSSNFromEmail(NewReqSenderOrReciver_Txt.Text.ToString());
            if (reciverDt == null)
            {
                return;
            }
            string reciver = reciverDt.Rows[0][0].ToString();
            int res = controllerObj.Respond(SSN, reciver, ReqTitle_Txt.Text.ToString(), ReqMessage_Txt.Text.ToString(), 1, oldTitle, oldReq);
            if (res == 0)
            {
                RJMessageBox.Show("Failed, please try again.",
               "Error",
               MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            else
            {
                RJMessageBox.Show("Respond sent successfully.",
              "information",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information);
                reset();
                return;
            }
        }

    }
}
