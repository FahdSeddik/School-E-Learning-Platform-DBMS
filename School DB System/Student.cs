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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format(abbreviation -> word)
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //STUDENT USERCONTROL
    public partial class Student : SecondaryTabBase //inherits from the base usercontrol which contains the main design and functions (SSSTPageParent)
    {
        //DATA MEMBERS
        protected ViewController viewController; //viewcontroller object
        protected Controller controllerObj; // controller object
        Guna2ComboBox YearList_CBox;
        Guna2HtmlLabel YearList_Lbl;
        Guna2Button MoveToNextYear_Btn;

        //Student usercontrol non default constructor
        public Student(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
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
            EditControls();
        }

        protected override void EditControls()
        {
            Filter_Pnl.Controls.Add(YearList_Lbl);//adding the Label to the filter panel
            Filter_Pnl.Controls.Add(YearList_CBox);//adding the comboobox to the filter panel
            Menu_Pnl.Controls.Add(MoveToNextYear_Btn);
            String[] CBoxPropertiesToClone = new String[] { "Size", "BorderRadius", "BorderColor" };//properties to clone from the source (template)
            PropertyInfo[] CBoxcontrolProperties = Template_CBox.GetType().GetProperties();
            //adjusting comboobox style depending on the template comboobox "Template_CBox"
            foreach (String Property in CBoxPropertiesToClone) //loop on each property in string array properties to clone in the source control (template control)
            {
                PropertyInfo ObjPropertyInfo = CBoxcontrolProperties.First(a => a.Name == Property);//get the property value from the source control (template)
                ObjPropertyInfo.SetValue(YearList_CBox, ObjPropertyInfo.GetValue(Template_CBox)); //sets the property value from the source control (template) in the destination control (yearList_CBox)
            }

            String[] LblPropertiesToClone = new String[] { "Font" };//properties to clone from the source (template)
            PropertyInfo[] LblcontrolProperties = Template_Lbl.GetType().GetProperties();
            //adjusting label style depending on the template label "Template_Lbl"
            foreach (String Property in LblPropertiesToClone)
            {
                PropertyInfo ObjPropertyInfo = LblcontrolProperties.First(a => a.Name == Property);//get the property value from the source control (template)
                ObjPropertyInfo.SetValue(YearList_Lbl, ObjPropertyInfo.GetValue(Template_Lbl));//sets the property value from the source control (template) in the destination control (yearList_Lbl)
            }

           MoveToNextYear_Btn.BackColor = System.Drawing.Color.White;
           MoveToNextYear_Btn.BorderColor = System.Drawing.Color.Silver;
           MoveToNextYear_Btn.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
           MoveToNextYear_Btn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
           MoveToNextYear_Btn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
           MoveToNextYear_Btn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
           MoveToNextYear_Btn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
           MoveToNextYear_Btn.Dock = System.Windows.Forms.DockStyle.Right;
           MoveToNextYear_Btn.FillColor = System.Drawing.Color.White;
           MoveToNextYear_Btn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           MoveToNextYear_Btn.ForeColor = System.Drawing.Color.Black;
           MoveToNextYear_Btn.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
           MoveToNextYear_Btn.Margin = new System.Windows.Forms.Padding(0);
           MoveToNextYear_Btn.Size = new System.Drawing.Size(196, 37);
           MoveToNextYear_Btn.TabIndex = 4;
           MoveToNextYear_Btn.Text = "Move to next year";
           MoveToNextYear_Btn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
           MoveToNextYear_Btn.Click += new System.EventHandler(this.MoveToNextYear_Btn_Click);
             foreach(Control item in Menu_Pnl.Controls)
            {
                Guna2Button Button = (Guna2Button)item;
                Button.Width = (Menu_Pnl.Width / 5);
            }


            //changing style of the new controls
            //location of the new Label is at 75 offset on y axis direction from the first Label
            YearList_Lbl.Location = new Point(Template_Lbl.Location.X, Template_Lbl.Location.Y + 75);
            YearList_Lbl.Text = "year";//adjusting label text 
            //location of the new comboobox is at 75 offset on y axis direction from the first comboobox
            YearList_CBox.Location = new Point(Template_CBox.Location.X, Template_CBox.Location.Y + 75);
            //adjusting the template comboobox style and text
            //note that template comboobox and label holds the standard design to use when creating new items in the panel
            Template_CBox.Name = "StateList_CBox";//changing comboobox name to "StateList_CBox"
            Template_Lbl.Name = "StateList_Lbl";//changing Label name to "StateList_Lbl"
            Template_Lbl.Text = "State";//changing Label Text to "State"
            Title_Lbl.Text = "Student";
        }

        //METHODS

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            //creating a new comboobox "yearslist_CBox"
            YearList_CBox = new Guna2ComboBox();
            //creating a new Label "yearslist_Lbl"
            YearList_Lbl = new Guna2HtmlLabel();
            //creating a new Label "yearslist_Lbl"
            MoveToNextYear_Btn = new Guna2Button();

        }


        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected override void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable RequestList = new DataTable(); //creating an empty datatable
            //creating empty columns in RequestList datatable
            RequestList.Columns.Add().ColumnName = "ID";//adding the first column with header text = "ID"
            RequestList.Columns.Add().ColumnName = "Name"; //adding the second column with header text = "Name"
            RequestList.Columns.Add().ColumnName = "Email"; //adding the thhird column with header text = "Email"
            RequestList.Columns.Add().ColumnName = "Year";//adding the fourth column with header text = "Year"
            Data_Dt.DataSource = RequestList; //linking datagridview data with the created datatable (RequestList)
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
            YearList_CBox.BindingContext = this.BindingContext;
            YearList_CBox.SelectedIndex = 0; //initially selecting the first element which is "All"
            //initializing student state comboobox with (current, Graduated)
            Template_CBox.Items.Add("Current"); //adding item at row index = 0 (first item)
            Template_CBox.Items.Add("Graduated");//adding item at row index = 1 (second item)
            Template_CBox.BindingContext = this.BindingContext;
            Template_CBox.SelectedIndex = 0; //initially selecting the first element which is "Current"
            //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
            this.Template_CBox.SelectedIndexChanged += new System.EventHandler(this.StateList_CBox_SelectedIndexChanged);
        }


        //changes to graduate student view
        //mainly used when the user filters graudated students
        //hides year comboobox and label in view and update panels as graduate student have no year
        //shows uinversity textbox and label in view and update panels
        private void GraduateStudentView()
        {
                //changing datagridview columns names because they are named in a dfiffrent names in database
                Data_Dt.Columns[1].Name = "ID"; //changes column name because in database it is named std_id
                Data_Dt.Columns[2].Name = "Name"; //changes column name text because in database it is named std_name
                Data_Dt.Columns[3].Name = "Email"; //changes column name text because in database it is named std_email
                Data_Dt.Columns[4].Name = "University"; //changes name header text because in database it is named std_year
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
                //changing datagridview columns names because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].Name = "ID"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].Name = "Name"; //changes column name text because in database it is named std_name
            Data_Dt.Columns[3].Name = "Email"; //changes column name text because in database it is named std_email
            Data_Dt.Columns[4].Name = "Year"; //changes name header text because in database it is named std_year
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
            DataTable yearsList = new DataTable(); //gets years in datatable column type int 
            yearsList.Columns.Add("std_Year");
            yearsList.Rows.Add("All"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("1"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("2"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("3"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("4"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("5"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("6"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("7"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("8"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("9"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("10"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("11"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("12"); //converting each row value to string and adding on the string list
            return yearsList; //returns the string list (All,1,2,3,4...etc)
        }
 
        ////////////////////////EVENTS///////////////////////////////
 
        //filter panel state list comboobox index changed
        //i.e selected a diffrent item from items list
        protected virtual void StateList_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Template_CBox.Text.ToString() == "Graduated")
            {
                YearList_CBox.Enabled = false; //disable years list comboobox data as graduated student does not have a year
            }
            else
            {
                YearList_CBox.Enabled = true; //enable years list comboobox data as graduated student does not have a year
            }
        } //end function

        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected override void Filter_Btn_Click(object sender, EventArgs e)
        {
            DataTable RequestList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            if (Template_CBox.Text.ToString() == "Current" && YearList_CBox.SelectedValue.ToString() == "All")
            {
                RequestList = controllerObj.getAllStudents(); //sends a query to retrieve all students (ID, Name, Email, Year)
                if(RequestList == null)
                {
                    RJMessageBox.Show("There are no current students in the current database.",
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                CurrentStudentView(); //changes to current student view
            }
            else if (Template_CBox.Text.ToString() == "Graduated") //check if selected state is = "Graduated
            {
                RequestList = controllerObj.getAllGraduatedStudents();
                if (RequestList == null)
                {
                    RJMessageBox.Show("There are no graduate students in the current database.",
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                GraduateStudentView();
            }
            else //check if selected state is = "current" and selected year is = 1,2,3...etc (not all)
            {
                try
                {
                    RequestList = controllerObj.getStudentsOfYear(int.Parse(YearList_CBox.Text));
                    if (RequestList == null)
                    {
                        RJMessageBox.Show("There are no current students in this year.",
                       "Error",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                    CurrentStudentView();
                }
                catch
                {
                   RJMessageBox.Show("there are no year selected.",
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }

            //checks if columns count > 1 i.e the first filter click
            //initially empty columns added when the student page is opened first time (constructor)        
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
                    string stdID = row.Cells[1].Value.ToString();//gets student ID from selected row
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
                RJMessageBox.Show("deletion of selected students done Successfully",
               "Successfully deleted",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
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


        //delete student button click event
        //deletes selected students
        protected void MoveToNextYear_Btn_Click(object sender, EventArgs e)
        {

            //inform the user that there are no rows selected
            RJMessageBox.Show("This button updates students year from current year to next year, moves current students who where in grade 12 to graduate students...etc.",
              "Note",
              MessageBoxButtons.OK, MessageBoxIcon.Information);

            //if there is at least one row selected
            //view warning message to ask for confrimation
            var result = RJMessageBox.Show("are you sure you want to update student information?, note that this operation cannot not be undone.",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                //loop on all selected rows and send a query to delete this student
                int year = 12;
                DataTable students;
                try
                {
                    students = controllerObj.getStudentsinYear(year);
                    for (int i = 0; i < students.Rows.Count; i++)
                    {
                        //university is optional , you may not enter it in function call
                        controllerObj.GraduateCurrentStudent(students.Rows[i][0].ToString());
                    }
                }
                catch
                {
                    RJMessageBox.Show("There was no students in year 12 to move to graduate students.",
                                         "Information",
                                         MessageBoxButtons.OK);
                }


                year = 11;
                for (; year >= 1; year--)
                {
                    try
                    {
                        students = controllerObj.getStudentsinYear(year);
                        for (int i = 0; i < students.Rows.Count; i++)
                        {
                            //student id and new year are passed
                            //this moves student to next year 
                            //and adds the default enrollment in the new courses
                            if (controllerObj.MoveStudentYear(students.Rows[i][0].ToString(), year + 1) == 0)
                            {
                                //error handling if needed (optional)
                                RJMessageBox.Show("Something went wrong, please try again.",
                                "Failed",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                                return;

                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
            
                RJMessageBox.Show("Successfully update students information.",
                                        "Failed",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon. Information);
                refreshDatagridView();
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
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex; //getting the selected row index
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex];//getting the selcted row from the row index
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value);//getting data from the selected row (ID) column because its the needed cell value to ened queries
                //creating new object of update student information
                viewController.ViewUpdateStudent(stdID.ToString());//viewing student information on new tab
            }
            return; //return
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
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex]; //getting the selcted row from the row index
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value); //getting data from the selected row (ID) column because its the needed cell value to ened queries
               //creating new object of view student information
               viewController.ViewViewStudent(stdID.ToString());//viewing student information on new tab
            }
            return; //return
        }


        //Add student button click event
        //Add selected student information
        protected override void Add_Btn_Click(object sender, EventArgs e)
        {
            //creating new object of Add student information
            viewController.ViewAddStudent();//viewing Add student information on new tab
        }

    }
}
