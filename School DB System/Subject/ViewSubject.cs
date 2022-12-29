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
    public partial class ViewSubject : AUVSubject
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public ViewSubject(ViewController viewController, Controller controllerObj, string subjID, int roomID, String Day, string Time) : base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(subjID,roomID,Day,Time); //filling textboxes with the selected student data
            //it send query to retrive selected student data
            //and fills textboxes with selected student information
            EditControls();
        }
       protected override void EditControls()
        {
            Tittle_Lbl.Text = "View Subject"; //changes control title text to update student
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            Submit_Btn.Visible = false; //hides submit button as view doesn't use it
            StdSub_Pnl.Visible = false;
            StaffSub_Pnl.Visible = false;
            ////SubjTAndLocNext_Btn.Visible = false;
            //SubjTeachNext_Btn.Visible = false;
            //SubjTeachNext_Btn.Visible=false;
            SubjSub_Pnl.BringToFront();
            this.Controls.Remove(StaffSub_Pnl);
            this.Controls.Remove(StdSub_Pnl);
            //loops on each textbox in the control
            foreach (Control item in SubjSub_Pnl.Controls) //loop on each item in the panel
            {
                if(item is Guna2GradientPanel)
                {
                    Guna2GradientPanel Panel = (Guna2GradientPanel)item;
                    foreach (Control item2 in Panel.Controls)
                    {
                        if (item2 is Guna2TextBox) //if the item is textbox
                        {
                            Guna2TextBox textBox = (Guna2TextBox)item2; //cast item to textbox to use textbox functionalities
                            textBox.Enabled = false; //make all textboxes unenabled (read only)
                        }
                        else if (item2 is Guna2HtmlLabel) //if the item is label
                        {
                            Guna2HtmlLabel Label = (Guna2HtmlLabel)item2; //cast item to textbox to use textbox functionalities
                            if (Label.ForeColor == Color.DarkRed) //checks if label color is red (Required label red star) which is next to the required fields
                            {
                                Label.Visible = false; //hides label (hides all required star label)
                            }
                        }
                        else if (item2 is Guna2ComboBox)
                        {
                            Guna2ComboBox comboobox = (Guna2ComboBox)item2; //cast item to comboBox to use comboBox functionalities
                            comboobox.Enabled = false; //make all combooboxes unenabled (read only)
                        }
                        else if(item2 is Guna2Button)
                        {
                            Guna2Button button = (Guna2Button)item2;
                                button.Visible = false;
                        }
                    }

                }
                
            }
        }

    }
}
