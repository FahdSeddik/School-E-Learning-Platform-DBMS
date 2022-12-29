using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_DB_System
{
    public partial class StudentsList : Student
    {
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        int BusNum;//non default construct

        public StudentsList(ViewController viewController, Controller controllerObj, int busNum) : base(viewController, controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            Template_CBox.Items.Clear();
            Template_CBox.Items.Add("in bus");
            Template_CBox.Items.Add("not in bus");
            Template_CBox.SelectedIndex = 0;
            this.Controls.Remove(Update_Btn);
            this.BusNum = busNum;
            Update_Btn.Visible = false;
            MoveToNextYear_Btn.Visible = false;
            initializeDataGridView();

        }

        //filter panel state list comboobox index changed
        //i.e selected a diffrent item from items list
        protected override void StateList_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Template_CBox.Text.ToString() == "in bus")
            {
               
            }
            else
            {
               
            }
        } //end function
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
                    int res = controllerObj.deleteStudentfromBus(stdID); //sends a query with the student id to delete
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

        protected override void MainBack_Btn_Click(object sender, EventArgs e)
        {
            //asking for confirmation
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to Leave homePage?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                viewController.CloseSubTab(); //closes page and return to home page
            }
            else //if didn't confirm "No"
            {
                return; //stay at student page
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
            try //handles any unexpected error while converting any string to string or query fail
            {
                int selectedrowindex = Data_Dt.SelectedCells[0].RowIndex; //getting the selected row index
                DataGridViewRow selectedRow = Data_Dt.Rows[selectedrowindex]; //getting the selcted row from the row index
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value); //getting data from the selec
                //send a query and gets the result of the query in queryres
                int queryRes = controllerObj.AddStudentToBus(stdID, BusNum);

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new student failed, revise student information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Insertion a new student Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    //reset the panel to be ready for the next insertion
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete student
                    //resets all textboxes text, clear error message...etc
                    return; //return
                }
            }
            catch (Exception error) //if any unexpected error while converting any string to string or query fail
            {
                //inform the user that the data is invalid
                RJMessageBox.Show("Invalid data, please correct entered data and try again.",
              "Error",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return; //return
            }
        }

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

            DataTable RequestList = null; //create an empty datatable

            //check if selected state is = "current" and selected year is = "All"
            if (Template_CBox.Text.ToString() == "in bus")
            {
                RequestList = controllerObj.getStudentsInBus(BusNum); //sends a query to retrieve all students (ID, Name, Email, Year)
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                Delete_Btn.Enabled = true; //disable years list comboobox data as graduated student does not have a year
                Add_Btn.Enabled = false;

            }
            else //check if selected state is = "current" and selected year is = 1,2,3...etc (not all)
            {
                RequestList = controllerObj.getStudentsNotInBus(BusNum); //sends a query to retrieve all students (ID, Name, Email, Year)
                Data_Dt.DataSource = RequestList; //linking student datagridview with students list datatable
                Delete_Btn.Enabled = false; //enable years list comboobox data as graduated student does not have a year
                Add_Btn.Enabled = true;
            }
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
    }
}

