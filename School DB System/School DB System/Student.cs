using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format(abbreviation -> word)
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //STUDENT USERCONTROL
    public partial class Student : SSSTPageParent //inherits from the base usercontrol which contains the main design and functions (SSSTPageParent)
    {
        //DATA MEMBERS
        protected ViewController viewController; //viewcontroller object
        protected Controller controllerObj; // controller object

        //Student usercontrol non default constructor
        public Student(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            //initially hide subpage panel which contains Add Student usercontrol or update Student usercontrol or view student information usercontrol
            initializeFilter(); //initialize filter panel components (ComboBoxes)
                                //(Student states : Current, Graduated, Years : 1,2,3,...etc)
            initializeDataGridView();//initialize Datagridview data (columns and rows)
                                     //(adding column names, adjusting datagridview style...etc)
        }

        //METHODS

        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected virtual void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable studentsList = new DataTable(); //creating an empty datatable
            //creating empty columns in studentslist datatable
            studentsList.Columns.Add().ColumnName = "ID";//adding the first column with header text = "ID"
            studentsList.Columns.Add().ColumnName = "Name"; //adding the second column with header text = "Name"
            studentsList.Columns.Add().ColumnName = "Email"; //adding the thhird column with header text = "Email"
            studentsList.Columns.Add().ColumnName = "Year";//adding the fourth column with header text = "Year"
            //adjusting students datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting students datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Data_Dt.ClearSelection(); //selecting 0 rows (clearing selection) 
            Data_Dt.Refresh(); //refresh datagridview
        }

        //initialize filter panel components (ComboBoxes)
        //linking combooboxes with data
        protected override void initializeFilter()
        {
            //initializing years comboobox with years (All, 1, 2, 3...etc) 
            DataTable yearslist = getYearslist();//retrving years datatable (All, 1, 2, 3...etc)
            YearList_CBox.DisplayMember = "std_Year"; //displaying std_Year column from datatable "Yearslist"
            YearList_CBox.ValueMember = "std_Year"; //linking value to std_year column from datatable "YearsList"
            YearList_CBox.DataSource = yearslist; //linking yearslist comboobox and yearlist datatable
            YearList_CBox.SelectedIndex = 0; //initially selecting the first element which is "All"
            //initializing student state comboobox with (current, Graduated)
            StateList_CBox.Items.Add("Current"); //adding item at row index = 0 (first item)
            StateList_CBox.Items.Add("Graduated");//adding item at row index = 1 (second item)
            StateList_CBox.SelectedIndex = 0; //initially selecting the first element which is "Current"
        }

        //changes to graduate student view
        //mainly used when the user filters graudated students
        //hides year comboobox and label in view and update panels as graduate student have no year
        //shows uinversity textbox and label in view and update panels
        private void GraduateStudentView()
        {
            //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "ID"; //changes column header text because in database it is named std_id
            Data_Dt.Columns[2].HeaderText = "Name"; //changes column header text because in database it is named std_name
            Data_Dt.Columns[3].HeaderText = "Email"; //changes column header text because in database it is named std_email
            Data_Dt.Columns[4].HeaderText = "University"; //changes column header text because in database it is named std_year
        }

        //changes to current student view
        //mainly used when the user filters current students
        //hides university textbox and label in view and update panels as current student have no university
        //shows year textbox and label in view and update panels
        private void CurrentStudentView()
        {
            //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "ID"; //changes column header text because in database it is named std_id
            Data_Dt.Columns[2].HeaderText = "Name"; //changes column header text because in database it is named std_name
            Data_Dt.Columns[3].HeaderText = "Email"; //changes column header text because in database it is named std_email
            Data_Dt.Columns[4].HeaderText = "Year"; //changes column header text because in database it is named std_year
        }

        //creating filter years list (All,1,2,3,4...etc)
        //gets years list (1,2,3,...etc)
        //converting list to string to add "All" in the first row
        private DataTable getYearslist()
        {
            DataTable tempYearsList = controllerObj.getYears(); //gets years in datatable column type int 
            //creating a new years datatable but column type string because we need to add 'all' row in the top of years (can't add string and int in same column)
            int YearsC = tempYearsList.Rows.Count; //getting yearslist count to loop on it
            DataTable yearsList = new DataTable(); //creating a new list
            yearsList.Columns.Add("std_Year", typeof(string)); //creating a column of name 'std_year' and of type string
            yearsList.Rows.Add("All"); //adding the first item in the list 'all' to allow choosing all years for filter
            for (int i = 0; i < YearsC; i++) //looping in the integer list and converting each row value to string and adding on the string list
            {
                yearsList.Rows.Add(tempYearsList.Rows[i][0].ToString()); //converting each row value to string and adding on the string list
            }
            return yearsList; //returns the string list (All,1,2,3,4...etc)
        }

        //EVENTS

        //filter panel state list comboobox index changed
        //i.e selected a diffrent item from items list
        private void StateList_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (StateList_CBox.Text.ToString() == "Graduated")
            {
                YearList_CBox.Enabled = false; //disable years list comboobox data as graduated student does not have a year
            }
            else
            {
                YearList_CBox.Enabled = true;
            }
        } //end function

        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected override void Filter_Btn_Click(object sender, EventArgs e)
        {
            //checks if columns count > 1 i.e the first filter click
            //initially empty columns added when the student page is opened first time (constructor)
            if (Data_Dt.Columns.Count > 1)
            {
                //remove columns from datagridview
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
            }

            DataTable StudentsList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            if (StateList_CBox.Text.ToString() == "Current" && YearList_CBox.SelectedValue.ToString() == "All")
            {
                StudentsList = controllerObj.getAllStudents(); //sends a query to retrieve all students (ID, Name, Email, Year)
                Data_Dt.DataSource = StudentsList; //linking student datagridview with students list datatable
                CurrentStudentView(); //changes to current student view
            }
            else if (StateList_CBox.Text.ToString() == "Graduated") //check if selected state is = "Graduated
            {
                StudentsList = controllerObj.getAllGraduatedStudents();
                Data_Dt.DataSource = StudentsList; //linking student datagridview with students list datatable
                GraduateStudentView();
            }
            else //check if selected state is = "current" and selected year is = 1,2,3...etc (not all)
            {
                StudentsList = controllerObj.getStudentsOfYear(int.Parse(YearList_CBox.Text));
                Data_Dt.DataSource = StudentsList; //linking student datagridview with students list datatable
                CurrentStudentView();
            }

            //adjusting students datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting students datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
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
                {
                    Int64 stdID = Int64.Parse(row.Cells[1].Value.ToString());//gets student ID from selected row
                    int res = controllerObj.deleteStudent(stdID); //sends a query with the student id to delete
                    if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected student failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                Filter_Btn.PerformClick();
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
            else
            {
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex];
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value);
                DataTable studentInformation = controllerObj.getStudentData(Int64.Parse(stdID));
                return; //return
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
            if (Data_Dt.SelectedRows.Count < 1) //checks if no rows are selected
            {
                //inform the user that there are no rows selected
                RJMessageBox.Show("There are no rows selected, please select only one row and try again.",
                     "Invalid Operation",
                     MessageBoxButtons.OK);
                return; //return (do nothing)
            }
            {

            }

        }

    }
}
