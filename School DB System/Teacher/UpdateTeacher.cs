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
    //The used abbreviations in the format (abbreviation -> word) 
    //(Teach -> Teacher) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //UPDATE Teacher USERCONTROL
    public partial class UpdateTeacher : UpdateStaff //inherits from the base usercontrol which contains the main design and functions (AUDTeacherPARENT)
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public UpdateTeacher(ViewController viewController, Controller controllerObj, string TeachID) : base(viewController, controllerObj, TeachID) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(TeachID); //filling textboxes with the selected Teacher data
            //it send query to retrive selected Teacher data
            //and fills textboxes with selected Teacher information
            EditControls();
        }

        //overriding onPaint function to change derived class (Update Teacher) design
       protected override void EditControls()
        {
            Tittle_Lbl.Text = "Update Teacher"; //changes control title text to update Teacher
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            StaffName_Txt.Select(); //intially selecting Teacher name textbox
            StaffPos_CBox.Visible = false;
            StaffPosReq_Lbl.Visible = false;
            StaffPos_Lbl.Visible = false;
            StaffDepReq_Lbl.Location = StaffPos_Lbl.Location;
            StaffDep_CBox.Location = StaffPos_CBox.Location;
            StaffDep_Lbl.Location = StaffPos_Lbl.Location;
        }
        //METHODS

        //EVENTS

        //Submit button click event
        //submits the updated information
        //sends query to database to update Teacher information
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
                int queryRes = 0;//intially = 0

                queryRes = controllerObj.UpdateTeacher(StaffID_Txt.Text.ToString(), StaffName_Txt.Text.ToString(), StaffSSN_Txt.Text.ToString(), Int64.Parse(StaffSalary_Txt.Text), StaffAdress_Txt.Text.ToString(), StaffEmail_Txt.Text.ToString(), StaffPNum_Txt.Text.ToString(), int.Parse(StaffDep_CBox.SelectedValue.ToString()), StaffFullTime_CHBox.Checked, StaffID_Txt.Text.ToString(), "0000");

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Teacher Information couldn't be updated, revise Teacher information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Teacher information updated successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
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
