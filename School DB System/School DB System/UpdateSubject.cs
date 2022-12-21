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
}
