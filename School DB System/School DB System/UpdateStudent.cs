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
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //UPDATE STUDENT USERCONTROL
    public partial class UpdateStudent : StudentAUD //inherits from the base usercontrol which contains the main design and functions (AUDSTUDENTPARENT)
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public UpdateStudent(ViewController viewController, Controller controllerObj, string StdID): base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(StdID); //filling textboxes with the selected student data
            //it send query to retrive selected student data
            //and fills textboxes with selected student information
        }

        //overriding onPaint function to change derived class (Update student) design
        protected override void OnPaint(PaintEventArgs pe)
        {

            Tittle_Lbl.Text = "Update Student"; //changes control title text to update student
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            StdSub_Pnl.Visible = true;
            TeachSub_Pnl.Visible = false;
            StdSub_Pnl.BringToFront();
            this.Controls.Remove(TeachSub_Pnl);
            StdName_Txt.Select();//initially selecting student name textbox
            StdPayedTuition_CBox.Visible = false; //hiding payed tuition check box in add student panel
        }
        //METHODS

        protected override void FillData(string stdID)
        {
            DataTable studentInformation;//creating datatable object to retrive students information
            //to fill textboxes with studentinformation (View student information or update student information)
            int isGradStd = controllerObj.IsGraduatedStudent(stdID);
            //query to check if this student is graduated or current student
            if (isGradStd == 0) //if isGradStd == 0 (selected student is Current student not graduated student)
            {
                //dealing only diffrent with the last column
                studentInformation = controllerObj.getCurrentStudentData(stdID);//gets current student data
                //student name, ID, SSN...etc
                StdYear_CBox.Items.Add(studentInformation.Rows[0][15].ToString());//
                StdPayedTuition_CBox.Checked = bool.Parse(studentInformation.Rows[0][16].ToString());
                StdYear_CBox.SelectedIndex = 0;
            }
            else //else if isGradStd == 1 (selected student is Graduated student not Current student)
            {
                //dealing only diffrent with the last column
                studentInformation = controllerObj.getGradStudentData(stdID);//gets graduate student data
                //student name, ID, SSN...etc
                StdUni_Txt.Text = studentInformation.Rows[0][15].ToString();
                //Graduate student view
                //depending on the active page type
                //in view and update it hides student year and textbox and shows graduated student university lbl and textbox
                //the default is current student view
                //by default properties student year label and comboobox are visible so hide them
                //and unviersity label and textbox are not visible so show them
                graduatedStudentView();
            }
            //note that getGradStudentData and getCurrentStudentData retrives student information in datatable that differs only in the last column
            //last column of getCurrentStudentData is studentYear as current student doesn't have university yet
            //last column of getGradStudentData is university as graduate student doesn't have a year (graduated) 
            //filling the common data between both
            StdID_Txt.Text = studentInformation.Rows[0][0].ToString();//filling student ID textbox with the selectd student ID
            StdName_Txt.Text = studentInformation.Rows[0][1].ToString();//filling student name textbox with the selectd student name
            StdPNum_Txt.Text = studentInformation.Rows[0][2].ToString();//filling student phone number textbox with the selectd student phone number
            StdSSN_Txt.Text = studentInformation.Rows[0][3].ToString();//filling student SSN textbox with the selectd student SSN
            StdEmail_Txt.Text = studentInformation.Rows[0][4].ToString();//filling student email textbox with the selectd student email
            StdParPNum_Txt.Text = studentInformation.Rows[0][5].ToString();//filling parent phone number textbox with the selectd student parent phone number
            StdDob_Dtp.Value = Convert.ToDateTime(studentInformation.Rows[0][6]);//filling student date of birth textbox with the selectd student date of birth
            StdNation_CBox.Items.Add(studentInformation.Rows[0][7].ToString());//filling student nationality Comboobox with the selectd student nationality
            StdNation_CBox.SelectedIndex = 0;//intitially selecting first item which is the item added (selected student nationality)
            StdAdress_Txt.Text = studentInformation.Rows[0][8].ToString();//filling student ID textbox with the selectd student ID
            Std2ndLang_CBox.Items.Add(studentInformation.Rows[0][9].ToString());//filling student second language textbox with the selectd student second language
            Std2ndLang_CBox.SelectedIndex = 0;//intitially selecting first item which is the item added (selected student second language)
            StdParSSN_Txt.Text = studentInformation.Rows[0][10].ToString();//filling parent SSN textbox with the selectd student parent SSN
            StdParName_Txt.Text = studentInformation.Rows[0][11].ToString();//filling parent name textbox with the selectd student parent name
            StdParAdress_Txt.Text = studentInformation.Rows[0][12].ToString();//filling parent address textbox with the selectd student parent address
            StdParPNum_Txt.Text = studentInformation.Rows[0][13].ToString();//filling parent phone number textbox with the selectd student parent phone number
            StdParEmail_Txt.Text = studentInformation.Rows[0][14].ToString();//filling parent email textbox with the selectd student parent email
            return; //return
        }

        //EVENTS

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

                for (int i = 0; i<2; i++)
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
}
