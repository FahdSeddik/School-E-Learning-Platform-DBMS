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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //VIEW STUDENT USERCONTROL
    public partial class UpdateSubject : AUVSubject
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public UpdateSubject(ViewController viewController, Controller controllerObj, string subjID, int roomID, String Day, string Time) : base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(subjID, roomID, Day, Time); //filling textboxes with the selected student data
            //it send query to retrive selected student data
            //and fills textboxes with selected student information
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "Update Subject"; //changes control title text to update student
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            Submit_Btn.Visible = false; //hides submit button as view doesn't use it
            StdSub_Pnl.Visible = false;
            StaffSub_Pnl.Visible = false;

            SubjSub_Pnl.BringToFront();
            this.Controls.Remove(StaffSub_Pnl);
            this.Controls.Remove(StdSub_Pnl);
            SubjInfo_Pnl.Visible = false;
            SubjTeach_Pnl.Visible = false;
            SubjTimeAndLoc_Pnl.Dock = DockStyle.Top;


            }
        }

    //Submit button click event
    //submits the updated information
    //sends query to database to update student information
    protected override void Submit_Btn_Click(object sender, EventArgs e)
    {
        //checks if there a empty required data (empty textboxs)
        //loops on each textbox in the control
        foreach (Control item in StdSub_Pnl.Controls) //loop on each item in the panel
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

            for (int i = 0; i < 2; i++)
            {
                if (StdUni_Txt.Visible == true) //means this is a graduate student view (selected student is graduate)
                {
                    queryRes = controllerObj.UpdateGraduateStudent(StdParSSN_Txt.Text.ToString(), StdParName_Txt.Text.ToString(), StdParAdress_Txt.Text.ToString(), StdParPNum_Txt.Text.ToString(),
                    StdParEmail_Txt.Text.ToString(), StdID_Txt.Text.ToString(), StdName_Txt.Text.ToString(), StdSSN_Txt.Text.ToString(), StdEmail_Txt.Text.ToString(),
                    StdPNum_Txt.Text.ToString(), StdDob_Dtp.Value.ToString(), StdNation_CBox.Text.ToString(), StdAdress_Txt.Text.ToString(), Std2ndLang_CBox.Text.ToString(), StdUni_Txt.Text.ToString());
                }
                else
                {
                    queryRes = controllerObj.UpdateCurrentStudent(StdParSSN_Txt.Text.ToString(), StdParName_Txt.Text.ToString(), StdParAdress_Txt.Text.ToString(), StdParPNum_Txt.Text.ToString(),
                    StdParEmail_Txt.Text.ToString(), StdID_Txt.Text.ToString(), StdName_Txt.Text.ToString(), StdSSN_Txt.Text.ToString(), StdEmail_Txt.Text.ToString(),
                    StdPNum_Txt.Text.ToString(), StdDob_Dtp.Value.ToString(), StdNation_CBox.Text.ToString(), StdAdress_Txt.Text.ToString(), Std2ndLang_CBox.Text.ToString(), int.Parse(StdYear_CBox.Text.ToString()), bool.Parse(StdPayedTuition_CBox.Checked.ToString()));
                }
            }

            if (queryRes == 0) //if queryres = 0 i.e query executing failed
            {
                //inform the user that the insertion failed
                RJMessageBox.Show("Student Information couldn't be updated, revise student information and try again.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return; //return
            }
            else
            {
                //inform the user that the insertion succeded
                RJMessageBox.Show("Student information updated successfully",
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
