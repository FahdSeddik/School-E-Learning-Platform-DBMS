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

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format(abbreviation -> word)
    //(Subj -> subject) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //subject USERCONTROL
    public partial class Subject : SecondaryTabBase //inherits from the base usercontrol which contains the main design and functions (SSSTPageParent)
    {
        //DATA MEMBERS
        protected ViewController viewController; //viewcontroller object
        protected Controller controllerObj; // controller object
        Guna2ComboBox YearList_CBox;
        Guna2HtmlLabel YearList_Lbl;
        public Subject(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            PrepareControls();//adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
            //initially hide subpage panel which contains Add subject usercontrol or update subject usercontrol or view subject information usercontrol
            initializeFilter(); //initialize filter panel components (ComboBoxes)
                                //(subject states : Current, Graduated, Years : 1,2,3,...etc)
            initializeDataGridView();//initialize Datagridview data (columns and rows)
                                     //(adding column names, adjusting datagridview style...etc)
        }
        //overriding onPaint function to change derived class (Add subject) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Filter_Pnl.Controls.Add(YearList_Lbl);//adding the Label to the filter panel
            Filter_Pnl.Controls.Add(YearList_CBox);//adding the comboobox to the filter panel

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

            //changing style of the new controls
            //location of the new Label is at 75 offset on y axis direction from the first Label
            YearList_Lbl.Location = new Point(Template_Lbl.Location.X, Template_Lbl.Location.Y + 75);
            YearList_Lbl.Text = "year";//adjusting label text 
            //location of the new comboobox is at 75 offset on y axis direction from the first comboobox
            YearList_CBox.Location = new Point(Template_CBox.Location.X, Template_CBox.Location.Y + 75);
            //adjusting the template comboobox style and text
            //note that template comboobox and label holds the standard design to use when creating new items in the panel
            Template_CBox.Name = "SubjDep_CBox";//changing comboobox name to "StateList_CBox"
            Template_Lbl.Name = "SubjDep_Lbl";//changing Label name to "StateList_Lbl"
            Template_Lbl.Text = "Department";//changing Label Text to "State"
        }

        //METHODS

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            //creating a new comboobox "yearslist_CBox"
            YearList_CBox = new Guna2ComboBox();
            //creating a new Label "yearslist_Lbl"
            YearList_Lbl = new Guna2HtmlLabel();
        }


        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected override void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable subjectsList = new DataTable(); //creating an empty datatable
            //creating empty columns in subjectsList datatable
            subjectsList.Columns.Add().ColumnName = "ID";//adding the first column with header text = "ID"
            subjectsList.Columns.Add().ColumnName = "Name"; //adding the second column with header text = "Name"
            subjectsList.Columns.Add().ColumnName = "Day"; //adding the thhird column with header text = "Email"
            subjectsList.Columns.Add().ColumnName = "StartTime"; //adding the thhird column with header text = "Email"
            subjectsList.Columns.Add().ColumnName = "EndTime"; //adding the thhird column with header text = "Email"
            subjectsList.Columns.Add().ColumnName = "RoomNum";//adding the fourth column with header text = "Year"
            Data_Dt.DataSource = subjectsList; //linking datagridview data with the created datatable (subjectsList)
            //adjusting subjects datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            Data_Dt.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            Data_Dt.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting subjects datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[5].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[6].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
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
            YearList_CBox.DisplayMember = "Subj_Year"; //displaying Subj_Year column from datatable "Yearslist"
            YearList_CBox.ValueMember = "Subj_Year"; //linking value to Subj_year column from datatable "YearsList"
            YearList_CBox.BindingContext = this.BindingContext;
            YearList_CBox.DataSource = yearslist; //linking yearslist comboobox and yearlist datatable
            YearList_CBox.SelectedIndex = 0; //initially selecting the first element which is "All"

            //initializing years comboobox with years (All, 1, 2, 3...etc) 
            DataTable Departmentslist = controllerObj.getDepartmentslist();//retrving years datatable (All, 1, 2, 3...etc)
            Template_CBox.DisplayMember = "dep_Name"; //displaying Subj_Year column from datatable "Yearslist"
            Template_CBox.ValueMember = "dep_ID"; //linking value to Subj_year column from datatable "YearsList"
            Template_CBox.BindingContext = this.BindingContext;
            Template_CBox.DataSource = Departmentslist; //linking yearslist comboobox and yearlist datatable
            Template_CBox.SelectedIndex = 0; //initially selecting the first element which is "All"
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
            yearsList.Columns.Add("Subj_Year", typeof(string)); //creating a column of name 'Subj_year' and of type string
            yearsList.Rows.Add("All"); //adding the first item in the list 'all' to allow choosing all years for filter
            for (int i = 0; i < YearsC; i++) //looping in the integer list and converting each row value to string and adding on the string list
            {
                yearsList.Rows.Add(tempYearsList.Rows[i][0].ToString()); //converting each row value to string and adding on the string list
            }
            return yearsList; //returns the string list (All,1,2,3,4...etc)
        }

        ////////////////////////EVENTS///////////////////////////////

    

        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected override void Filter_Btn_Click(object sender, EventArgs e)
        {
            //checks if columns count > 1 i.e the first filter click
            //initially empty columns added when the subject page is opened first time (constructor)
            if (Data_Dt.Columns.Count > 1)
            {
                //remove columns from datagridview
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
                Data_Dt.Columns.RemoveAt(1);
            }

            DataTable subjectsList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            if (YearList_CBox.Text.ToString() == "All")
            {
                subjectsList = controllerObj.getAllsubjectsOfDep(Template_CBox.SelectedValue.ToString()); //sends a query to retrieve all subjects (ID, Name, Email, Year)
                Data_Dt.DataSource = subjectsList; //linking subject datagridview with subjects list datatable
            }
            else//check if selected state is = "Graduated
            {
                subjectsList = controllerObj.getSubjectsOfDepAndYear(Template_CBox.SelectedValue.ToString(),int.Parse(YearList_CBox.SelectedValue.ToString()));
                Data_Dt.DataSource = subjectsList; //linking subject datagridview with subjects list datatable
            }
            //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "ID"; //changes column header text because in database it is named Subj_id
            Data_Dt.Columns[2].HeaderText = "Name"; //changes column header text because in database it is named Subj_name
            Data_Dt.Columns[3].HeaderText = "Day"; //changes column header text because in database it is named Subj_email
            Data_Dt.Columns[4].HeaderText = "Start Time"; //changes column header text because in database it is named Subj_year
                                                        //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            Data_Dt.Columns[5].HeaderText = "End Time"; //changes column header text because in database it is named Subj_year
                                                        //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            Data_Dt.Columns[6].HeaderText = "Room Number"; //changes column header text because in database it is named Subj_year
                                                           //initializing datagridview wirh empty columns (ID, Name, Email, Year)
                                                           //creating empty columns in subjectsList datatable

            Data_Dt.Columns[1].Name= "ID";//adding the first column with header text = "ID"
            Data_Dt.Columns[2].Name = "Name"; //adding the second column with header text = "Name"
            Data_Dt.Columns[3].Name = "Day"; //adding the thhird column with header text = "Email"
            Data_Dt.Columns[4].Name = "StartTime"; //adding the thhird column with header text = "Email"
            Data_Dt.Columns[5].Name = "EndTime"; //adding the thhird column with header text = "Email"
            Data_Dt.Columns[6].Name = "RoomNum";//adding the fourth column with header text = "Year"

            //adjusting subjects datagridview columns style
            Data_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting first column style (auto size mode depending on the length of content)
            Data_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting second column style (auto size mode depending on the length of content)
            Data_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting third column style (auto size mode depending on the length of content)
            Data_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            Data_Dt.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            Data_Dt.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //adjusting fourth column style (auto size mode depending on the length of content)
            //adjusting subjects datagridview columns properties
            Data_Dt.Columns[1].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[2].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[3].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[4].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[5].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            Data_Dt.Columns[6].ReadOnly = true; //adjusting first column properties (prevent user from editing column)
            //refreshing datagridview
            Data_Dt.ClearSelection(); //selecting 0 rows (clearing selection) 
            Data_Dt.Refresh(); //refresh datagridview
            return;
        }

        //delete subject button click event
        //deletes selected subjects
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
                //loop on all selected rows and send a query to delete this subject
                foreach (DataGridViewRow row in Data_Dt.SelectedRows)//looping on each selected row
                {
                    string subjID = row.Cells[1].Value.ToString();//gets subject ID from selected row
                    int roomNum = int.Parse(row.Cells[6].Value.ToString());
                    string Day = row.Cells[3].Value.ToString();
                    string Time = row.Cells[4].Value.ToString();

                    DataTable RoomData = controllerObj.getRoomData(roomNum);
                    int roomBuildingNum = int.Parse(RoomData.Rows[0][0].ToString());
                    int roomFloor = int.Parse(RoomData.Rows[0][1].ToString());

                    DataTable SubjInformation = controllerObj.getSubjectData(subjID, roomNum, Day, Time);


                    string subjName = SubjInformation.Rows[0][0].ToString();//filling Subj name textbox with the selectd Subj name
        
                    int subjYear = int.Parse(SubjInformation.Rows[0][2].ToString());



                    string startTime = SubjInformation.Rows[0][5].ToString();
                    string endTime = SubjInformation.Rows[0][6].ToString();

                    string subjDepName = SubjInformation.Rows[0][7].ToString(); 

                    string teacherID = SubjInformation.Rows[0][10].ToString();
                  
                    int res = controllerObj.deleteSubject(teacherID,subjID,subjDepName,roomBuildingNum,roomFloor,roomNum,startTime,endTime,Day,subjYear,subjName); //sends a query with the subject id to delete
                   if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected subject failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                RJMessageBox.Show("deletion of selected subjects done Successfully",
               "Successfully deleted",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                refreshDatagridView(); //refresh datagrid view after insert or delete subject
                return;
            }
            else
            {
                return; //return (do nothing)
            }
        }

        //update subject button click event
        //updated selected subject information
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
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex]; //getting the selcted row from the row index
                string subjID = Convert.ToString(selectedRow.Cells["ID"].Value); //getting data from the selected row (ID) column because its the needed cell value to ened queries
                int roomID = int.Parse(selectedRow.Cells["RoomNum"].Value.ToString());
                string Day = Convert.ToString(selectedRow.Cells["Day"].Value);
                string Time = Convert.ToString(selectedRow.Cells["StartTime"].Value);//creating new object of view subject information
                viewController.ViewUpdateSubject(subjID, roomID, Day, Time);//viewing subject information on new tab
            }
            return; //return
        }

        //view subject button click event
        //views selected subject information
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
                string subjID = Convert.ToString(selectedRow.Cells["ID"].Value); //getting data from the selected row (ID) column because its the needed cell value to ened queries
                int roomID = int.Parse(selectedRow.Cells["RoomNum"].Value.ToString());
                string Day = Convert.ToString(selectedRow.Cells["Day"].Value);
                string Time = Convert.ToString(selectedRow.Cells["StartTime"].Value);//creating new object of view subject information
                viewController.ViewViewSubject(subjID,roomID,Day,Time);//viewing subject information on new tab
            }
            return; //return
        }


        //Add subject button click event
        //Add selected subject information
        protected override void Add_Btn_Click(object sender, EventArgs e)
        {
            //creating new object of Add subject information
          viewController.ViewAddSubject();//viewing Add subject information on new tab
        }
    }
}
