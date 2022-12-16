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

    //VIEW STUDENT USERCONTROL
    public partial class ViewStudent : AUDStudentParent
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public ViewStudent(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
        }

        //overriding onPaint function to change derived class (Update student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "View Student"; //changes control title text to update student
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            //loops on each textbox in the control
            foreach (Control item in Sub_Pnl.Controls) //loop on each item in the panel
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

            }
        }

    }
}
