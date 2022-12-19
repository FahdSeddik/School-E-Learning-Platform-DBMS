using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //ADD, UPDATE, DELETE STUDENT USERCONTROL BASE USERCONTROL
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //AUDSTUDENTPARENT USERCONTROL (BASE USERCONTROL FOR ADD STUDENT, UPDATE STUDENT, VIEW STUDENT)
    public partial class BaseAUD : UserControl //inherits from usercontrol
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        protected BaseAUD(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
        }

        //METHODS

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected virtual void PrepareControls()
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //show Error Message method lbl with a suitable message informing the user with the problem
        protected void showErrorMessage(string ErrorMessage)
        {
            ErrorMessage_Lbl.Text = ErrorMessage; //display error message in the label location
            ErrorMessage_Lbl.Show(); //show error message label
        }

        //hide Error Message lbl method
        protected void hideErrorMessage()
        {
            ErrorMessage_Lbl.Hide(); //hide error message label
        }


        //Fill textboxes with a student data (the selected student data)
        //used with update and view to fill textboxes with the selected student data
        protected virtual void FillData(string stdID)
        {
            //do nothing in the base class as it depends on page type update or add
        }

        //Get countires list to use in nationality comboobox
        // (Egyptian, American...etc)
        protected static List<string> GetNationalityList()
        {
            List<string> NationalityList = new List<string> { "Egyptian", "german", "French" };
            return NationalityList;
        }

        //EVENTS

        //Submit button click event
        //Add, Update Submit button
        protected virtual void Submit_Btn_Click(object sender, EventArgs e)
        {
            //do nothing in the base class as it depends on page type update or add
        }

        //Add, Update, View back button
        //closes the current opened page (Add, Updated, View)
        protected void Back_btn_Click(object sender, EventArgs e)
        {
            //asking for confirmation
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to close this window?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                viewController.CloseSubTab();
            }
            else //if didn't confirm "No"
            {
                return; //keeps the current page opened
            }
        }

    }
}
