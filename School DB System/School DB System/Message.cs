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
    public partial class Message1 : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        string Email;
        string ID;
 
        public Message1(ViewController viewController, Controller controllerObj,int View, string email,string ID)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            Email = email;
            this.ID = ID;
            
            switch (View)
            {
                case 1:
                    InboxViewView();
                    break;
                case 2:
                    SentViewView();
                    break;
                case 3:
                    NewMessageView();
                    break;
                default:
                    break;
            }

        }

        public Message1(ViewController viewController, Controller controllerObj,string From, string To, string title,string request,int state,string date)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            
           // switch (View)
            //{
              //  case 1:
              //      InboxViewView();
              //      break;
             //   case 2:
             //      SentViewView();
              //      break;
             //   case 3:
              //      NewMessageView();
             //       break;
             //   default:
             //       break;
          //  }

        }

        private void InboxViewView()
        {
            NewReqSenderOrReciver_Lbl.Text = "from";
            NewReqSenderOrReciver_Txt.Enabled = false;
            ReqTitle_Txt.Enabled = false;
            ReqMessage_Txt.Enabled = false;
            Approve_Btn.Visible = false;
            Disapprove_Btn.Visible = false;
        }

        private void SentViewView()
        {
            NewReqSenderOrReciver_Lbl.Text = "To";
            NewReqSenderOrReciver_Txt.Enabled = false;
            ReqTitle_Txt.Enabled = false;
            ReqMessage_Txt.Enabled = false;
            Approve_Btn.Visible = false;
            Disapprove_Btn.Visible = false;

        }

        private void NewMessageView()
        {
            NewReqSenderOrReciver_Lbl.Text = "To";
            NewReqSenderOrReciver_Txt.Enabled = true;
            ReqTitle_Txt.Enabled = true;
            Approve_Btn.Visible = true;
            Disapprove_Btn.Visible = true;
        }

        private void Back_Btn_Click(object sender, EventArgs e)
        {
            viewController.CloseSubTab();
        }

        private void Disapprove_Btn_Click(object sender, EventArgs e)
        { 
            DataTable reciverDt = controllerObj.getStdIDFromEmail(NewReqSenderOrReciver_Txt.Text.ToString());
            if(reciverDt == null)
            {
                return;
            }
            string  reciver = reciverDt.Rows[0][0].ToString();
            int res = controllerObj.Respond(ID, reciver, ReqTitle_Txt.Text.ToString(), ReqMessage_Txt.Text.ToString(), 0);
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
                return;
            }
        }

        private void Approve_Btn_Click(object sender, EventArgs e)
        {
            DataTable reciverDt = controllerObj.getStdIDFromEmail(NewReqSenderOrReciver_Txt.Text.ToString());
            if (reciverDt == null)
            {
                return;
            }
            string reciver = reciverDt.Rows[0][0].ToString();
            int res = controllerObj.Respond(ID, reciver, ReqTitle_Txt.Text.ToString(), ReqMessage_Txt.Text.ToString(), 1);
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
                return;
            }
        }

    }
}
