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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace School_DB_System
{
    public partial class Request1 : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        string ID;
        public Request1(ViewController viewController,Controller controllerObj,string username)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            DataTable IDDt = controllerObj.getIDFromUsername(username);
            ID = IDDt.Rows[0][0].ToString();

            Inbox_Tab.PerformClick();
        }

        

        private void Sent_Tab_Click(object sender, EventArgs e)
        {
            Sent_Tab.FillColor = Color.White;
            Sent_Tab.ForeColor = Color.Black;
            Inbox_Tab.FillColor = Color.FromArgb(64, 66, 88);
            Inbox_Tab.ForeColor = Color.White;

            DataTable ReqsList = null; //create an empty datatable
            ReqsList = controllerObj.getSentOf(ID); //sends a query to retrieve all students (ID, Name, Email, Year)
            Reqs_Dgv.DataSource = ReqsList; //linking student datagridview with students list datatable
            if (ReqsList == null)
            {
                return;
            }
            Reqs_Dgv.Columns[1].Name = "Date";
            Reqs_Dgv.Columns[2].Name = "Email";
            Reqs_Dgv.Columns[3].Name = "Title";
            Reqs_Dgv.Columns[4].Name = "Request";

            Reqs_Dgv.Columns[1].HeaderText = "Date";
            Reqs_Dgv.Columns[2].HeaderText = "To";
            Reqs_Dgv.Columns[3].HeaderText = "Title";
            Reqs_Dgv.Columns[4].HeaderText = "Request";


            //adjusting students datagridview columns style
            Reqs_Dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Reqs_Dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Reqs_Dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Reqs_Dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting students datagridview columns properties
            Reqs_Dgv.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Reqs_Dgv.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Reqs_Dgv.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Reqs_Dgv.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Reqs_Dgv.ClearSelection(); //selecting 0 rows (clearing selection) 
            Reqs_Dgv.Refresh(); //refresh datagridview
            return;
        }

        private void Inbox_Tab_Click(object sender, EventArgs e)
        {
            Inbox_Tab.FillColor = Color.White;
            Inbox_Tab.ForeColor = Color.Black;
            Sent_Tab.FillColor = Color.FromArgb(64, 66, 88);
            Sent_Tab.ForeColor = Color.White;
            DataTable ReqsList = null; //create an empty datatable
            ReqsList = controllerObj.getInboxOf(ID); //sends a query to retrieve all students (ID, Name, Email, Year)
            Reqs_Dgv.DataSource = ReqsList; //linking student datagridview with students list datatable
            if(ReqsList == null)
            {
                return;
            }
            Reqs_Dgv.Columns[1].Name = "Date";
            Reqs_Dgv.Columns[2].Name = "Email";
            Reqs_Dgv.Columns[3].Name = "Title";
            Reqs_Dgv.Columns[4].Name = "Request";

            Reqs_Dgv.Columns[1].HeaderText = "Date";
            Reqs_Dgv.Columns[2].HeaderText = "From";
            Reqs_Dgv.Columns[3].HeaderText = "Title";
            Reqs_Dgv.Columns[4].HeaderText = "Request";


            //adjusting students datagridview columns style
            Reqs_Dgv.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Reqs_Dgv.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Reqs_Dgv.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Reqs_Dgv.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting students datagridview columns properties
            Reqs_Dgv.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Reqs_Dgv.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Reqs_Dgv.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Reqs_Dgv.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Reqs_Dgv.ClearSelection(); //selecting 0 rows (clearing selection) 
            Reqs_Dgv.Refresh(); //refresh datagridview
            return;
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.CloseMainTab();
        }

        private void ViewReq_Btn_Click(object sender, EventArgs e)
        {
            //viewController.ViewViewRequest(ID);
        }

        private void Respond_Btn_Click(object sender, EventArgs e)
        {
           // viewController.RespondToReq(ID);
        }

        private void DeleteReq_Btn_Click(object sender, EventArgs e)
        {
            
            //checks if no rows are selected
           // if (Reqs_Dgv.SelectedRows.Count < 1) //if selected rows count < 1 i.e no rows are selected
            {

                //inform the user that there are no rows selected
                RJMessageBox.Show("There are no rows selected, please select at lease one row and try again.",
                "Invalid Operation",
                MessageBoxButtons.OK);
                return; //return (do nothing)

            }
            //if there is at least one row selected
            //view warning message to ask for confrimation
            var result = RJMessageBox.Show("are you sure you want to delete selected rows?, note that this operation cannot not be undone.",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                //loop on all selected rows and send a query to delete this student
                foreach (DataGridViewRow row in Reqs_Dgv.SelectedRows)//looping on each selected row
                {

                    

                    //int res = controllerObj.DeleteReq(senderID, reciverID, title, message, date); //sends a query with the student id to delete
                   // if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected student failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                RJMessageBox.Show("deletion of selected students done Successfully",
               "Successfully deleted",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
               
                return;
            }
            else
            {
                return; //return (do nothing)
            }
            
        }
    }
}
