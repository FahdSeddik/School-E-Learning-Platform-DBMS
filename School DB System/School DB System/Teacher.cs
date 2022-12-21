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
    //(std -> Teacher) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //Teacher USERCONTROL
    public partial class Teacher : SSSTPageParent //inherits from the base usercontrol which contains the main design and functions (SSSTPageParent)
    {
        //DATA MEMBERS
        ViewController viewController;//viewcontroller object
        Controller controllerObj; // controller object

        //Teacher usercontrol non default constructor
        public Teacher(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            PrepareControls();//adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
            //initially hide subpage panel which contains Add Teacher usercontrol or update Teacher usercontrol or view Teacher information usercontrol
            initializeFilter(); //initialize filter panel components (ComboBoxes)
                                //(Teacher states : Current, Graduated, Years : 1,2,3,...etc)
            initializeDataGridView();//initialize Datagridview data (columns and rows)
                                     //(adding column names, adjusting datagridview style...etc)
        }
        //overriding onPaint function to change derived class (Add Teacher) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            //adjusting the template comboobox style and text
            //note that template comboobox and label holds the standard design to use when creating new items in the panel
            Template_CBox.Name = "Department_CBox";//changing comboobox name to "Department_CBox"
            Template_Lbl.Name = "Department_Lbl";//changing Label name to "Department_Lbl"
            Template_Lbl.Text = "Department";//changing Label Text to "Department"
        }

        //METHODS

        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected override void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable teachersList = new DataTable(); //creating an empty datatable
            //creating empty columns in teacherslist datatable
            teachersList.Columns.Add().ColumnName = "ID";//adding the first column with header text = "ID"
            teachersList.Columns.Add().ColumnName = "Name"; //adding the second column with header text = "Name"
            teachersList.Columns.Add().ColumnName = "Email"; //adding the thhird column with header text = "Email"
            teachersList.Columns.Add().ColumnName = "MobileNumber";//adding the fourth column with header text = "Department"
            Data_Dt.DataSource = teachersList; //linking datagridview data with the created datatable (teacherslist)
            //adjusting teachers datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting teachers datagridview columns properties
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
            DataTable Departmentslist = controllerObj.getDepartmentslist();//retrving years datatable (All, 1, 2, 3...etc)
            Template_CBox.DisplayMember = "dep_Name"; //displaying std_Year column from datatable "Yearslist"
            Template_CBox.ValueMember = "dep_ID"; //linking value to std_year column from datatable "YearsList"
            Template_CBox.BindingContext = this.BindingContext;
            Template_CBox.DataSource = Departmentslist; //linking yearslist comboobox and yearlist datatable
            Template_CBox.SelectedIndex = 0; //initially selecting the first element which is "All"
            //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
        }

        ///////////////////////EVENTS///////////////////////////////

        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected override void Filter_Btn_Click(object sender, EventArgs e)
        {
            //checks if columns count > 1 i.e the first filter click
            //initially empty columns added when the Teacher page is opened first time (constructor)
            if (Data_Dt.Columns.Count > 1)
            {
                //remove columns from datagridview
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
            }

            DataTable DepartmentsList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            DepartmentsList = controllerObj.getteachersOfDepartment(Template_CBox.SelectedValue.ToString()); //sends a query to retrieve all Teachers (ID, Name, Email, Year)
            Data_Dt.DataSource = DepartmentsList; //linking Teacher datagridview with Teachers list datatable
    
            //adjusting Teachers datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting Teachers datagridview columns properties
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

        //delete Teacher button click event
        //deletes selected Teachers
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
                //loop on all selected rows and send a query to delete this Teacher
                foreach (DataGridViewRow row in Data_Dt.SelectedRows)//looping on each selected row
                {
                    string teachID = row.Cells[1].Value.ToString();//gets Teacher ID from selected row
                    int res = controllerObj.deleteTeacher(teachID); //sends a query with the Teacher id to delete
                    if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected Teacher failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                RJMessageBox.Show("deletion of selected Teachers done Successfully",
               "Successfully deleted",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                refreshDatagridView(); //refresh datagrid view after insert or delete Teacher
                return;
            }
            else
            {
                return; //return (do nothing)
            }
        }

        //update Teacher button click event
        //updated selected Teacher information
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
                string teacherID = Convert.ToString(selectedRow.Cells["ID"].Value);//getting data from the selected row (ID) column because its the needed cell value to ened queries
                viewController.ViewUpdateTeacher(teacherID.ToString());//creating new object of update Teacher information
               //viewing Teacher information on new tab
            }
            return; //return
        }

        //view Teacher button click event
        //views selected Teacher information
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
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value); //getting data from the selected row (ID) column because its the needed cell value to ened queries
                //creating new object of view Teacher information
                viewController.ViewViewTeacher(stdID.ToString());//viewing Teacher information on new tab
            }
            return; //return
        }

        //Add Teacher button click event
        //Add selected Teacher information
        protected override void Add_Btn_Click(object sender, EventArgs e)
        {
            //AddTeacher AddTeacher = new AddTeacher(viewController, controllerObj); //creating new object of Add Teacher information
            viewController.ViewAddTeacher();//viewing Add Teacher information on new tab
           //refresh datagrid view after insert or delete Teacher
        }

    }
}
