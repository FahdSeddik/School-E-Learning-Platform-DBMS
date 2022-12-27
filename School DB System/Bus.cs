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

namespace School_DB_System
{
    public partial class Bus : SSSTPageParent
    {
        //DATA MEMBERS
        protected ViewController viewController; //viewcontroller object
        protected Controller controllerObj; // controller object
        public Bus(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
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
        }
        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            //adjusting the template comboobox style and text
            //note that template comboobox and label holds the standard design to use when creating new items in the panel
            Template_CBox.Name = "Route_CBox";//changing comboobox name to "StateList_CBox"
            Template_Lbl.Name = "RouteList_Lbl";//changing Label name to "StateList_Lbl"
            Template_Lbl.Text = "Route";//changing Label Text to "State"
        }

        //METHODS

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            //creating a new comboobox "yearslist_CBox"
        
        }


        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected override void initializeDataGridView()
        {
            //initializing datagridview wirh empty columns (ID, Name, Email, Year)
            DataTable RequestList = new DataTable(); //creating an empty datatable
            //creating empty columns in RequestList datatable
            RequestList.Columns.Add().ColumnName = "Number";//adding the first column with header text = "ID"
            RequestList.Columns.Add().ColumnName = "Driver"; //adding the second column with header text = "Name"
            RequestList.Columns.Add().ColumnName = "Capacity"; //adding the thhird column with header text = "Email"
            RequestList.Columns.Add().ColumnName = "Route";//adding the fourth column with header text = "Year"
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
            DataTable routes = getAllBusesRoutes();
            //initializing student state comboobox with (current, Graduated)
            Template_CBox.ValueMember = "bus_Route";
            Template_CBox.DisplayMember = "bus_Route";
            Template_CBox.DataSource = routes;
            Template_CBox.SelectedIndex = 0; //initially selecting the first element which is "Current"
            //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
        }

        //changes to graduate student view
        //mainly used when the user filters graudated students
        //hides year comboobox and label in view and update panels as graduate student have no year
        //shows uinversity textbox and label in view and update panels
      
   

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

            DataTable busesList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            if (Template_CBox.Text.ToString() == "All")
            {
                busesList =controllerObj.getAllBuses(); //sends a query to retrieve all students (ID, Name, Email, Year)
                Data_Dt.DataSource = busesList; //linking student datagridview with students list datatable
            }
       
            else //check if selected state is = "current" and selected year is = 1,2,3...etc (not all)
            {
                busesList = controllerObj.getBusesOfRoute(Template_CBox.SelectedValue.ToString());
                Data_Dt.DataSource = busesList; //linking student datagridview with students list datatable

            }
            //changing datagridview columns names because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].Name = "BusNum"; //changes column name because in database it is named std_id
            Data_Dt.Columns[2].Name = "Driver"; //changes column name text because in database it is named std_name
            Data_Dt.Columns[3].Name = "Capacity"; //changes column name text because in database it is named std_email
            Data_Dt.Columns[4].Name = "Route"; //changes name header text because in database it is named std_year
            //changing datagridview columns headertext because they are named in a dfiffrent names in database
            Data_Dt.Columns[1].HeaderText = "Number"; //changes column header text because in database it is named std_id
            Data_Dt.Columns[2].HeaderText = "Driver"; //changes column header text because in database it is named std_name
            Data_Dt.Columns[3].HeaderText = "Capacity"; //changes column header text because in database it is named std_email
            Data_Dt.Columns[4].HeaderText = "Route"; //changes column header text because in database it is named std_year

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
        private DataTable getAllBusesRoutes()
        {
            DataTable tempbusesList = controllerObj.getBusRoutes(); //sends a query to retrieve all students (ID, Name, Email, Year)
            //creating a new years datatable but column type string because we need to add 'all' row in the top of years (can't add string and int in same column)
            int busesC = tempbusesList.Rows.Count; //getting yearslist count to loop on it
            DataTable busesList = new DataTable(); //creating a new list
            busesList.Columns.Add("bus_Route", typeof(string)); //creating a column of name 'std_year' and of type string
            busesList.Rows.Add("All"); //adding the first item in the list 'all' to allow choosing all years for filter
            for (int i = 0; i < busesC; i++) //looping in the integer list and converting each row value to string and adding on the string list
            {
                busesList.Rows.Add(tempbusesList.Rows[i][0].ToString()); //converting each row value to string and adding on the string list
            }
            return busesList; //returns the string list (All,1,2,3,4...etc)
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
                    int BusNum = int.Parse(row.Cells[1].Value.ToString());//gets student ID from selected row
                    int res = controllerObj.deleteBus(BusNum); //sends a query with the student id to delete
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
                refreshDatagridView(); //refresh datagrid view after insert or delete student
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
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex; //getting the selected row index
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex];//getting the selcted row from the row index
                int BusNum = int.Parse(selectedRow.Cells["BusNum"].Value.ToString());//getting data from the selected row (ID) column because its the needed cell value to ened queries
                //creating new object of update student information
                viewController.ViewUpdateBus(BusNum);//viewing student information on new tab
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
                int BusNum = int.Parse(selectedRow.Cells["BusNum"].Value.ToString()); //getting data from the selected row (ID) column because its the needed cell value to ened queries
                                                                                //creating new object of view student information
                viewController.ViewViewBus(BusNum);//viewing student information on new tab
            }
            return; //return
        }


        //Add student button click event
        //Add selected student information
        protected override void Add_Btn_Click(object sender, EventArgs e)
        {
            //creating new object of Add student information
            viewController.ViewAddBus();//viewing Add student information on new tab
        }
    }
}
