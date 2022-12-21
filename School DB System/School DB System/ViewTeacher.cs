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

    //VIEW Teacher USERCONTROL
    public partial class ViewTeacher : ViewStaff
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public ViewTeacher(ViewController viewController, Controller controllerObj, string TeachID) : base(viewController, controllerObj, TeachID) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(TeachID); //filling textboxes with the selected Teacher data
            //it send query to retrive selected Teacher data
            //and fills textboxes with selected Teacher information
        }

        //overriding onPaint function to change derived class (Update Teacher) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "View Teacher"; //changes control title text to update Teacher
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            Submit_Btn.Visible = false; //hides submit button as view doesn't use it
            //loops on each textbox in the control
            foreach (Control item in StaffSub_Pnl.Controls) //loop on each item in the panel
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
            StaffFullTime_CHBox.Enabled = false; //disable editing payed tuition comboobox in view Teacher page
            StaffPos_CBox.Visible = false;
            StaffPosReq_Lbl.Visible = false;
            StaffPos_Lbl.Visible = false;
            StaffDepReq_Lbl.Location = StaffPos_Lbl.Location;
            StaffDep_CBox.Location = StaffPos_CBox.Location;
            StaffDep_Lbl.Location = StaffPos_Lbl.Location;
            hideErrorMessage();
        }

    }
}
