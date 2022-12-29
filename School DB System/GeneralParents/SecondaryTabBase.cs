using Guna.UI2.AnimatorNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Input;
using Guna.UI2.WinForms;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //STUDENT, STAFF, SUBJECT, TEACHER USERCONTROL BASE USERCONTROL
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)
    //(Dt - > datagridview)

    //STUDENT USERCONTROL
    public partial class SecondaryTabBase : UserControl
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //Student usercontrol non default constructor
        public SecondaryTabBase(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
        }

        //METHODS

        protected virtual void EditControls()
        {

        }


        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected virtual void initializeDataGridView()
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
       async protected virtual void showNotes()
        {
            await Task.Delay(1000);
            RJMessageBox.Show("Selection\r\n\r\nIf you have many rows to select you can,\r\n1.click and hold your left mouse button. Next, drag the mouse until the last row is highlighted.\r\n2.hold CTRL while selecting rows to select more than one row which maybe useful if the user wants to select more than one consecutive row.\r\n\r\nSorting\r\n\r\nTo sort data according to a specific property click on the table header you want to sort with respect to\r\nTo switch between ascending and descnding order click again on the table header",
             "Notes", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        async protected void showDelayedError(string errorMsg)
        {
            await Task.Delay(1000);
            RJMessageBox.Show(errorMsg,
                   "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        //initialize filter panel components (ComboBoxes)
        //linking combooboxes with data
        protected virtual void initializeFilter()
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected virtual void PrepareControls()
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //clicks filter button to refresh the datagridview
        //refreshes database
        public void refreshDatagridView()
        {
            Filter_Btn.PerformClick();//clicks filter button to refresh the datagridview
        }

        //Page back button
        //closes page and return to home page
        protected virtual void MainBack_Btn_Click(object sender, EventArgs e)
        {
            //asking for confirmation
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to Leave homePage?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                viewController.CloseMainTab(); //closes page and return to home page
            }
            else //if didn't confirm "No"
            {
                return; //stay at student page
            }

        }


        //EVENTS

        //Add button click event
        //the button functionality depends on the page student or staff or teacher or subject 
        protected virtual void Add_Btn_Click(object sender, EventArgs e)
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //delete button click event
        //the button functionality depends on the page student or staff or teacher or subject 
        protected virtual void Delete_Btn_Click(object sender, EventArgs e)
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //Update button click event
        //the button functionality depends on the page student or staff or teacher or subject 
        protected virtual void Update_Btn_Click(object sender, EventArgs e)
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //View button click event
        //the button functionality depends on the page student or staff or teacher or subject 
        protected virtual void ViewProf_Btn_Click(object sender, EventArgs e)
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

      
       

        //filter button click event
        //filters the datagridview with the selected combooboxes i.e choosen year and state
        protected virtual void Filter_Btn_Click(object sender, EventArgs e)
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
        }

        //title bar on click event
        private void TtitleBar_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            viewController.ApplicationMouseDown(sender, e);

        }

        //title bar mouse move event
        private void TtitleBar_Pnl_MouseMove(object sender, MouseEventArgs e)
        {
            viewController.ApplicationMouseMove(sender, e);
        }

        //title bar mouse up event
        private void TtitleBar_Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            viewController.ApplicationMouseUp(sender, e);
        }

        //select all checkbox check state changed event
        //selects or deselects all rows
        private void selectALL_Btn_Click(object sender, EventArgs e)
        {
            //if select all checkbox checked state = true (select all checkbox is checked)
            //note that checkbox state and row selectedstate need to be done explisitly beacuse they are not linked by default
            //loop on all selected rows and check checkbox state
            if (Data_Dt.SelectedRows.Count == Data_Dt.Rows.Count && SelectAll_Btn.Text == "Deselect All")
            {
                SelectAll_Btn.Text = "Select All";
                SelectAll_Btn.FillColor = Color.DarkGray;
                Data_Dt.ClearSelection();//deselect all rows

            }
            //elseif select all checkbox checked state = false (select all checkbox is unchecked)
            //note that checkbox state and row selectedstate need to be done explisitly beacuse they are not linked by default
            //loop on all selected rows and uncheck checkbox state
            else if(Data_Dt.SelectedRows.Count != Data_Dt.Rows.Count && SelectAll_Btn.Text == "Select All")
            {
                SelectAll_Btn.Text = "Deselect All";
                SelectAll_Btn.FillColor = Color.Gray;
                Data_Dt.SelectAll(); //select all rows on datargidview
            }
            else if (Data_Dt.SelectedRows.Count != Data_Dt.Rows.Count && SelectAll_Btn.Text == "Deselect All")
            {
                SelectAll_Btn.Text = "Select All";
                SelectAll_Btn.FillColor = Color.DarkGray;
                Data_Dt.ClearSelection();//deselect all rows
            }
            else
            {
                SelectAll_Btn.Text = "Select All";
                SelectAll_Btn.FillColor = Color.DarkGray;
                Data_Dt.ClearSelection();//deselect all rows
            }
        }

        protected virtual void SSSTPageParent_Load(object sender, EventArgs e)
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
            showNotes();
        }
    }
}
