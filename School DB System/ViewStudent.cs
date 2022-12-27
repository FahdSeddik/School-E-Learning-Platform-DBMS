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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //VIEW STUDENT USERCONTROL
    internal partial class ViewStudent : StudentAUD
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public ViewStudent(ViewController viewController, Controller controllerObj, string StdID) : base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(StdID); //filling textboxes with the selected student data
            //it send query to retrive selected student data
            //and fills textboxes with selected student information
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

        //overriding onPaint function to change derived class (Update student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "View Student"; //changes control title text to update student
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            Submit_Btn.Visible = false; //hides submit button as view doesn't use it
            StdSub_Pnl.Visible = true;
            StaffSub_Pnl.Visible = false;
            StdSub_Pnl.BringToFront();
            this.Controls.Remove(StaffSub_Pnl);
            //loops on each textbox in the control
            foreach (Control item in StdSub_Pnl.Controls) //loop on each item in the panel
            {
                if (item is Guna2TextBox) //if the item is textbox
                {
                    Guna2TextBox textBox = (Guna2TextBox)item; //cast item to textbox to use textbox functionalities
                    textBox.Enabled = false; //make all textboxes unenabled (read only)
                }
                else if (item is Guna2HtmlLabel) //if the item is label
                {
                    Guna2HtmlLabel Label = (Guna2HtmlLabel)item; //cast item to textbox to use textbox functionalities
                    if (Label.ForeColor == Color.DarkRed) //checks if label color is red (Required label red star) which is next to the required fields
                    {
                        Label.Visible = false; //hides label (hides all required star label)
                    }
                }
                else if (item is Guna2ComboBox)
                {
                    Guna2ComboBox comboobox = (Guna2ComboBox)item; //cast item to comboBox to use comboBox functionalities
                    comboobox.Enabled = false; //make all combooboxes unenabled (read only)
                }
            }
            StdDob_Dtp.Enabled = false; //make std date of birth datetime picker unenabled (read only)
            StdPayedTuition_CBox.Enabled = false; //disable editing payed tuition comboobox in view student page
        }


    }
}
