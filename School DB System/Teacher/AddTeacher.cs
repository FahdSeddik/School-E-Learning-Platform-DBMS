using Guna.UI2.WinForms;
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
    //(Teach -> teacher) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //ADD teacher USERCONTROL
    public partial class AddTeacher : AddStaff //inherits from the base usercontrol which contains the main design and functions (AUDteacherPARENT)
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        public AddTeacher(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            //intiallizing years list comboobox with years (1, 2, 3, ...etc)
            StaffDep_CBox.DisplayMember = "dep_Name";
            StaffDep_CBox.ValueMember = "dep_ID";
            StaffDep_CBox.DataSource = controllerObj.getDepartmentslist();
            this.StaffDep_CBox.SelectedIndexChanged += new System.EventHandler(this.StaffDep_CBox_SelectedIndexChanged);
            EditControls();
        }

        //overriding onPaint function to change derived class (Add teacher) design
       protected override void EditControls()
        {
            Tittle_Lbl.Text = "Add Teacher";
            StaffSub_Pnl.Visible = true;
            StaffSub_Pnl.BringToFront();
            this.Controls.Remove(StdSub_Pnl);
            StaffPos_CBox.Visible = false;
            StaffPosReq_Lbl.Visible = false;
            StaffPos_Lbl.Visible = false;
            StaffDepReq_Lbl.Location = StaffPos_Lbl.Location;
            StaffDep_CBox.Location = StaffPos_CBox.Location;
            StaffDep_Lbl.Location = StaffPos_Lbl.Location;
        }

        //METHODS

        //updates teacher ID
        //teacher ID is generated automaticlly to ensure its uniqueness
        //teacher ID is in the format 7 digits{Graduation year tenth digit, graduation year unit digit, SSN first digit, SSN second digit, 5 digits for teachers count}
        //i.e if the teacher went to the school at year 5 and SSN = 11342124124123 and this the 21th teacher in the school and we are in 2022 and last year is 12
        //then ID will be  (291100021) (29) stands for 2029 (graduation year last 2 digits) and 11 stands for the first two letters in SSN and 00021 stands for the 21th teacher
        //teacher ID depends on SSN and year so this method is called when selected year changed or SSN text changed (only when adding teacher in the first time)
        //Note that in updating teacher information teacher id is not changed even if selected year and SSN changed
        protected override void updateStaffID()
        {
            if (StaffSSN_Txt.TextLength < 2)
            {
                StaffID_Txt.Text = ""; //empty teacher ID (reset)
                return; //return (do nothing)
            }
            if (StaffSSN_Txt.BorderColor == Color.Gray) //if SSN textbox bordercolor is gray means enetered Valid SSN generate teacher ID
            {
                int StaffCount = controllerObj.getStaffCount(); //retrieves teacher count
                StaffCount++; //increments teacher count by 1 i.e if teachers count is = 3 means the teacher that will be added is the 4th teacher no the 3th
                string formattedTeachCount = string.Format("{0:00000}", StaffCount); //formatting teachers count to 5 digits and padding with zeros if needed i teachers count is 300 it will be 00300 and if 45000 it will be 45000
                char[] SSNFirst2digits = StaffSSN_Txt.Text.ToCharArray(); //converting SSN to array of characters to access characters (first 2 digits)
                char[] DepID = (StaffDep_CBox.SelectedValue.ToString()).ToCharArray(); //converting graduation year textbox text to integer to use to calculate graduation year
                //note that this calculates depending on the real year in the world (datetime.now.year) so its updated with the real time year (only when adding a new teacher not in updating teacher information)
                //created teacher ID with the specfied format
                StaffID_Txt.Text = "2" + DepID[0].ToString() + SSNFirst2digits[0].ToString() + SSNFirst2digits[1].ToString() + formattedTeachCount.ToString();
                return; //return (do nothing)
            }
            else //if SSN textbox bordercolor is red means enetered invalid SSN so don't generate teacher ID and return
            {
                StaffID_Txt.Text = ""; //empty teacher ID (reset)
                return; //return (do nothing)
            }
        }

    

        //EVENTS
        //add teacher year comboobox selection changed event
        //if the selected year changed change teacher ID as it depeneds on the selected year
        //(first 2 digits of the ID are the last 2 digits of the graduation year that depends on the year the teacher enrolled in the school) 
  

        //Submit button click event
        //sends query to database to insert a new teacher
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            //checks if there a empty required data (empty textboxs)
            //loops on each textbox in the control
            foreach (Control item in StaffSub_Pnl.Controls) //loop on each item in the panel
            {
                if (item is Guna2TextBox) //if the item is textbox
                {
                    Guna2TextBox textBox = (Guna2TextBox)item; //cast item to textbox to use textbox functionalities
                    textBox.Focus(); //focus on each textbox 
                    //means select the textbox
                    //next loop it selects the next textbox which performs the previously selected textbox leave event
                    //each textbox is responsible for validating the data in it using text changed event or leave event
                    //when there is a non valid in any textbox the textbox bordercolor is changed to red
                    //so when this loop ends every required textbox data if not valid this textbox border color will be red
                    if (textBox.BorderColor == Color.Red) //checks if this textbox border color is red (invalid data in textbox)
                    {
                        //inform the user to insert all required values
                        RJMessageBox.Show("Please insert all the required Values.",
                             "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                        return;
                        //return (do nothing)
                    }
                }
            }
            //if the all the data entered by the user is valid
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres
                int queryRes = controllerObj.AddTeacher(StaffID_Txt.Text.ToString(), StaffName_Txt.Text.ToString(), StaffSSN_Txt.Text.ToString(), Int64.Parse(StaffSalary_Txt.Text), StaffAdress_Txt.Text.ToString(), StaffEmail_Txt.Text.ToString(), StaffPNum_Txt.Text.ToString(), StaffDep_CBox.SelectedValue.ToString(), StaffFullTime_CHBox.Checked, StaffID_Txt.Text.ToString(), "0000");

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new teacher failed, revise teacher information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Inserted a new teacher Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    resetAddPanel();//reset the panel to be ready for the next insertion
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete teacher
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

    }
}
