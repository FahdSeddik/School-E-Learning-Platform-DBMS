using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format(abbreviation -> word)
    //(std -> Staff) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //Staff USERCONTROL
    public partial class Staff : SecondaryTabBase //inherits from the base usercontrol which contains the main design and functions (SSSTPageParent)
    {
        //DATA MEMBERS
        ViewController viewController;//viewcontroller object
        Controller controllerObj; // controller object

        //Staff usercontrol non default constructor
        public Staff(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            PrepareControls();//adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
            //initially hide subpage panel which contains Add Staff usercontrol or update Staff usercontrol or view Staff information usercontrol
            initializeFilter(); //initialize filter panel components (ComboBoxes)
                                //(Staff states : Current, Graduated, Years : 1,2,3,...etc)
            initializeDataGridView();//initialize Datagridview data (columns and rows)
                                     //(adding column names, adjusting datagridview style...etc)
            EditControls();
        }
        //overriding onPaint function to change derived class (Add Staff) design
       protected override void EditControls()
        {
            //adjusting the template comboobox style and text
            //note that template comboobox and label holds the standard design to use when creating new items in the panel
            Template_CBox.Name = "stfPosition_CBox";//changing comboobox name to "Department_CBox"
            Template_Lbl.Name = "stfPosition_Lbl";//changing Label name to "Department_Lbl"
            Template_Lbl.Text = "Position";//changing Label Text to "Department"
        }

        //METHODS

        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected override void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable staffList = new DataTable(); //creating an empty datatable
            //creating empty columns in stafflist datatable
            staffList.Columns.Add().ColumnName = "ID";//adding the first column with header text = "ID"
            staffList.Columns.Add().ColumnName = "Name"; //adding the second column with header text = "Name"
            staffList.Columns.Add().ColumnName = "Email"; //adding the thhird column with header text = "Email"
            staffList.Columns.Add().ColumnName = "MobileNum";//adding the fourth column with header text = "Department"
            Data_Dt.DataSource = staffList; //linking datagridview data with the created datatable (stafflist)
            //adjusting staff datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting staff datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Data_Dt.ClearSelection(); //selecting 0 rows (clearing selection) 
            Data_Dt.Refresh(); //refresh datagridview
        }

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {

        }

        //initialize filter panel components(ComboBoxes)
        //linking combooboxes with data
        protected override void initializeFilter()
        {
            //initializing years comboobox with years (All, 1, 2, 3...etc) 
            DataTable Positionslist = controllerObj.getStaffPostionslist();//retrving years datatable (All, 1, 2, 3...etc)
            Template_CBox.DisplayMember = "staff_Position"; //displaying std_Year column from datatable "Yearslist"
            Template_CBox.ValueMember = "staff_Position"; //linking value to std_year column from datatable "YearsList"
            Template_CBox.BindingContext = this.BindingContext;
            Template_CBox.DataSource = Positionslist; //linking yearslist comboobox and yearlist datatable
            Template_CBox.SelectedIndex = 0; //initially selecting the first element which is "All"
            //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
        }

        ///////////////////////EVENTS///////////////////////////////

        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected override void Filter_Btn_Click(object sender, EventArgs e)
        {
            //checks if columns count > 1 i.e the first filter click
            //initially empty columns added when the Staff page is opened first time (constructor)
            if (Data_Dt.Columns.Count > 1)
            {
                //remove columns from datagridview
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
            }

            DataTable StaffList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            StaffList = controllerObj.getStaffOfPosition(Template_CBox.SelectedValue.ToString()); //sends a query to retrieve all staff (ID, Name, Email, Year)
            Data_Dt.DataSource = StaffList; //linking Staff datagridview with staff list datatable

            //adjusting staff datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting staff datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //changing datagridview columns names because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].Name = "ID"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].Name = "Name"; //changes column name text because in database it is named std_name
            Data_Dt.Columns[3].Name = "Email"; //changes column name text because in database it is named std_email
            Data_Dt.Columns[4].Name = "MobileNumber"; //changes name header text because in database it is named std_year
            //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "ID"; //changes column header text because in database it is named std_id
            Data_Dt.Columns[2].HeaderText = "Name"; //changes column header text because in database it is named std_name
            Data_Dt.Columns[3].HeaderText = "Email"; //changes column header text because in database it is named std_email
            Data_Dt.Columns[4].HeaderText = "Mobile number"; //changes column header text because in database it is named std_year
            //refreshing datagridview
            Data_Dt.ClearSelection(); //selecting 0 rows (clearing selection) 
            Data_Dt.Refresh(); //refresh datagridview
            return;

        }

        //delete Staff button click event
        //deletes selected staff
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
                //loop on all selected rows and send a query to delete this Staff
                foreach (DataGridViewRow row in Data_Dt.SelectedRows)//looping on each selected row
                {
                    string staffID = row.Cells[1].Value.ToString();//gets Staff ID from selected row
                    DataTable TeacherData = controllerObj.getTeacherData(staffID);
                    int res;
                    if (TeacherData != null)
                    {
                        res = controllerObj.deleteTeacher(staffID); //sends a query with the Staff id to delete
                    }
                    else
                    {
                        res = controllerObj.deleteStaff(staffID); //sends a query with the Staff id to delete}
                    }
                    if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected Staff failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                RJMessageBox.Show("deletion of selected staff done Successfully",
               "Successfully deleted",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                refreshDatagridView(); //refresh datagrid view after insert or delete Staff
                return;
            }
            else
            {
                return; //return (do nothing)
            }
        }

        //update Staff button click event
        //updated selected Staff information
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
            else
            {
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex; //getting the selected row index
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex];//getting the selcted row from the row index
                string staffID = Convert.ToString(selectedRow.Cells["ID"].Value);//getting data from the selected row (ID) column because its the needed cell value to ened queries

                //viewing Staff information on new tab
                DataTable TeacherData = controllerObj.getTeacherData(staffID);

                if (TeacherData != null)
                {
                    viewController.ViewUpdateTeacher(staffID.ToString());//creating new object of update Staff information
                }
                else
                {
                    viewController.ViewUpdateStaff(staffID.ToString());//creating new object of update Staff information
                }
            }
            return; //return
        }

        //view Staff button click event
        //views selected Staff information
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
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex]; //getting the selcted row from the row index
                string staffID = Convert.ToString(selectedRow.Cells["ID"].Value); //getting data from the selected row (ID) column because its the needed cell value to ened queries
                                                                                  //creating new object of view Staff information

                DataTable TeacherData = controllerObj.getTeacherData(staffID);
                if (TeacherData != null)
                {
                    viewController.ViewViewTeacher(staffID.ToString());//creating new object of update Staff information
                }
                else
                {
                    viewController.ViewViewStaff(staffID.ToString());//viewing Staff information on new tab
                }
            }
            return; //return
        }

        //Add Staff button click event
        //Add selected Staff information
        protected override void Add_Btn_Click(object sender, EventArgs e)
        {
            //AddStaff AddStaff = new AddStaff(viewController, controllerObj); //creating new object of Add Staff information
            viewController.ViewAddStaff();//viewing Add Staff information on new tab
                                          //refresh datagrid view after insert or delete Staff
        }

    }
}
