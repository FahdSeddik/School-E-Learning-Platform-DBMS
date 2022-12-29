using Guna.UI2.WinForms;
using School_DB_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format(abbreviation -> word)
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //STUDENT USERCONTROL
    public partial class Request : SecondaryTabBase //inherits from the base usercontrol which contains the main design and functions (SSSTPageParent)
    {
        //DATA MEMBERS
        protected ViewController viewController; //viewcontroller object
        protected Controller controllerObj; // controller object
        bool inInbox;
        string SSN;

        //Student usercontrol non default constructor
        public Request(ViewController viewController, Controller controllerObj, string username) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            PrepareControls();//adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
            //initially hide subpage panel which contains Add Student usercontrol or update Student usercontrol or view student information usercontrol
            initializeFilter(); //initialize filter panel components (ComboBoxes)
                                //(Student states : Current, Graduated, Years : 1,2,3,...etc)
            initializeDataGridView();//initialize Datagridview data (columns and rows)
                                     //(adding column names, adjusting datagridview style...etc)
            inInbox = false;
            DataTable SSNDt = controllerObj.getSSNFromUsername(username);
            SSN = SSNDt.Rows[0][0].ToString();
            EditControls();
        }

        //overriding onPaint function to change derived class (Add student) design
        protected override void EditControls()
        {

            Template_CBox.Name = "StateList_CBox";//changing comboobox name to "StateList_CBox"
            Template_Lbl.Name = "StateList_Lbl";//changing Label name to "StateList_Lbl"
            Template_Lbl.Text = "State";//changing Label Text to "State"
            Update_Btn.Text = "Respond";
            Update_Btn.Name = "Respond_Btn";
        }


        //METHODS

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            Menu_Pnl.Controls.Remove(Add_Btn);
        }


        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected override void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable RequestList = new DataTable(); //creating an empty datatable
                                                     //creating empty columns in RequestList datatable
            RequestList.Columns.Add().ColumnName = "ID";//adding the first column with header text = "ID"
            RequestList.Columns.Add().ColumnName = "Date";//adding the first column with header text = "ID"
            RequestList.Columns.Add().ColumnName = "Email"; //adding the second column with header text = "Name"
            RequestList.Columns.Add().ColumnName = "Title"; //adding the thhird column with header text = "Email"
            RequestList.Columns.Add().ColumnName = "Request";//adding the fourth column with header text = "Year"
            Data_Dt.DataSource = RequestList; //linking datagridview data with the created datatable (RequestList)
            //adjusting students datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            Data_Dt.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting students datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[5].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Data_Dt.ClearSelection(); //selecting 0 rows (clearing selection) 
            Data_Dt.Refresh(); //refresh datagridview
        }

        //initialize filter panel components (ComboBoxes)
        //linking combooboxes with data
        protected override void initializeFilter()
        {

            //initializing student state comboobox with (current, Graduated)
            Template_CBox.Items.Add("Inbox"); //adding item at row index = 0 (first item)
            Template_CBox.Items.Add("Sent");//adding item at row index = 1 (second item)
            Template_CBox.Items.Add("Pending");//adding item at row index = 1 (second item)
            Template_CBox.SelectedIndex = 0; //initially selecting the first element which is "Current"
                                             //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)

        }

        //changes to graduate student view
        //mainly used when the user filters graudated students
        //hides year comboobox and label in view and update panels as graduate student have no year
        //shows uinversity textbox and label in view and update panels
        private void InboxView()
        {
            //changing datagridview columns names because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].Name = "ID"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].Name = "Date"; //changes column name because in database it is named std_id
            Data_Dt.Columns[3].Name = "From"; //changes column name text because in database it is named std_name
            Data_Dt.Columns[4].Name = "Title"; //changes column name text because in database it is named std_email
            Data_Dt.Columns[5].Name = "Request"; //changes name header text because in database it is named std_year
                                                 //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "ID"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].HeaderText = "Date"; //changes column header text because in database it is named std_id
            Data_Dt.Columns[3].HeaderText = "From"; //changes column header text because in database it is named std_name
            Data_Dt.Columns[4].HeaderText = "Title"; //changes column header text because in database it is named std_email
            Data_Dt.Columns[5].HeaderText = "Request"; //changes column header text because in database it is named std_year
            inInbox = true;
        }

        //changes to current student view
        //mainly used when the user filters current students
        //hides university textbox and label in view and update panels as current student have no university
        //shows year textbox and label in view and update panels
        private void SentView()
        { //changing datagridview columns names because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].Name = "ID"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].Name = "Date"; //changes column name because in database it is named std_id
            Data_Dt.Columns[3].Name = "To"; //changes column name text because in database it is named std_name
            Data_Dt.Columns[4].Name = "Title"; //changes column name text because in database it is named std_email
            Data_Dt.Columns[5].Name = "Request"; //changes name header text because in database it is named std_year
                                                 //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "ID"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].HeaderText = "Date"; //changes column header text because in database it is named std_id
            Data_Dt.Columns[3].HeaderText = "To"; //changes column header text because in database it is named std_name
            Data_Dt.Columns[4].HeaderText = "Title"; //changes column header text because in database it is named std_email
            Data_Dt.Columns[5].HeaderText = "Request"; //changes column header text because in database it is named std_year
            inInbox = false;
        }


        ////////////////////////EVENTS///////////////////////////////


        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected override void Filter_Btn_Click(object sender, EventArgs e)
        {
            DataTable RequestList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            if (Template_CBox.Text.ToString() == "Inbox")
            {
                RequestList = controllerObj.getInboxOf(SSN); //sends a query to retrieve all students (ID, Name, Email, Year)
                if (RequestList == null)
                {
                    RJMessageBox.Show("There are no emails in your inbox.",
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                InboxView(); //changes to current student view
            }
            else if (Template_CBox.Text.ToString() == "Sent") //check if selected state is = "Graduated
            {
                RequestList = controllerObj.getSentOf(SSN);
                if (RequestList == null)
                {
                    RJMessageBox.Show("Sent is empty.",
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                SentView();
            }
            else //check if selected state is = "current" and selected year is = 1,2,3...etc (not all)
            {
                RequestList = controllerObj.getPendingInboxOf(SSN); //sends a query to retrieve all students (ID, Name, Email, Year)
                if (RequestList == null)
                {
                    RJMessageBox.Show("There are no pending emails.",
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                InboxView(); //changes to current student view
            }

            //adjusting students datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            Data_Dt.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting students datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[5].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Data_Dt.ClearSelection(); //selecting 0 rows (clearing selection) 
            Data_Dt.Refresh(); //refresh datagridview
            return;

        }


        //delete student button click event
        //deletes selected students
        protected override void Delete_Btn_Click(object sender, EventArgs e)
        {
            //checks if no rows are selected
            if (Data_Dt.SelectedRows.Count < 1) //if selected rows count < 1 i.e no rows are selected
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
                foreach (DataGridViewRow row in Data_Dt.SelectedRows)//looping on each selected row
                {                                    ////////////////////////////////////////////////

                    string reqID = row.Cells["ID"].Value.ToString();//getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                    int res = controllerObj.DeleteReq(reqID); //sends a query with the student SSN to delete
                    if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected student failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                if (Data_Dt.SelectedRows.Count == Data_Dt.Rows.Count)
                {
                    initializeDataGridView();
                    SelectAll_Btn.PerformClick();
                    return;
                }
                else
                {
                    refreshDatagridView(); //refresh datagrid view after insert or delete student
                    return;
                }
            }
            else
            {
                return; //return (do nothing)
            }
        }



        //view student button click event
        //views selected student information
        protected override void ViewProf_Btn_Click(object sender, EventArgs e)
        {


            if (Data_Dt.SelectedRows.Count > 1) //checks if more than one rows are selected
            {
                //inform the user that there are more than one rows selected
                RJMessageBox.Show("Can't update more than one row, please select only one row and try again.",
                     "Invalid Operation",
                     MessageBoxButtons.OK);
                return; //return (do nothing)
            }
            else if (Data_Dt.SelectedRows.Count < 1) //checks if no rows are selected
            {
                //inform the user that there are no rows selected
                RJMessageBox.Show("There are no rows selected, please select only one row and try again.",
                     "Invalid Operation",
                     MessageBoxButtons.OK);
                return; //return (do nothing)
            }
            else
            {
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex; //getting the selected row index
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex];//getting the selcted row from the row index                                                      ////////////////////////////////////////////////

                string title = selectedRow.Cells["Title"].Value.ToString();//getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                string message = selectedRow.Cells["Request"].Value.ToString();//getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                DateTime date = DateTime.Parse(selectedRow.Cells["Date"].Value.ToString());//getting data from the selected row (ID) column because its the needed cell value to ened queries
                string Email;

                if (inInbox) // on sent tab
                {
                    //getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                    Email = selectedRow.Cells["From"].Value.ToString();
                    viewController.ViewViewRequest(Email, title, message, 0);
                }
                else
                {
                    ///getting data from the selected row(ID.ToString() column because its the needed cell value to ened queries
                    Email = selectedRow.Cells["To"].Value.ToString();
                    viewController.ViewViewRequest(Email, title, message, 1);
                }

            }
            return; //return
        }

        //update student button click event
        //updated selected student information
        protected override void Update_Btn_Click(object sender, EventArgs e)
        {
            //checks if no rows are selected
            if (Data_Dt.SelectedRows.Count > 1) //if selected rows count > 1 i.e more than one row are selected
            {
                //inform the user that there are more than one rows selected
                RJMessageBox.Show("Can't update more than one row, please select only one row and try again.",
                         "Invalid Operation",
                         MessageBoxButtons.OK);
                return; //return (do nothing)
            }
            //checks if more than one rows are selected
            else if (Data_Dt.SelectedRows.Count < 1) //if selected rows count < 1 i.e no rows are selected
            {
                //inform the user that there are no rows selected
                RJMessageBox.Show("There are no rows selected, please select only one row and try again.",
                         "Invalid Operation",
                         MessageBoxButtons.OK);
                return; //return (do nothing)
            }
            else if (!inInbox)
            {
                //inform the user that there are no rows selected
                RJMessageBox.Show("you can't respond to yourself.",
                         "Invalid Operation",
                         MessageBoxButtons.OK);
                return; //return (do nothing)
            }
            else
            {
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex; //getting the selected row index
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex];//getting the selcted row from the row index                                                      ////////////////////////////////////////////////
                string senderSSN = SSN;//////getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                DataTable reciverSSNDt = controllerObj.getSSNFromEmail(selectedRow.Cells["From"].Value.ToString());//getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                string reciverSSN = reciverSSNDt.Rows[0][0].ToString();
                string reqID = selectedRow.Cells["ID"].Value.ToString();//getting data from the selected row (ID.ToString() column because its the needed cell value to ened queries
                viewController.RespondToReq(senderSSN, reciverSSN, reqID);
                viewController.RespondToReq(senderSSN, reciverSSN, reqID);
                // senderID,reciverEmail
                return; //return
            }

        }
    }
}
