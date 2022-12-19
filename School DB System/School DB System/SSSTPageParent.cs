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
    public partial class SSSTPageParent : UserControl
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //Student usercontrol non default constructor
        public SSSTPageParent(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
        }

        //METHODS

        //initialize Datagridview data (columns and rows)
        //(adding column names, adjusting datagridview style...etc)
        protected virtual void initializeDataGridView()
        {
            //functinality depending on the child usercontrol (student, staff, subject, teacher)
            //so it is virtual function
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
        private void MainBack_Btn_Click(object sender, EventArgs e)
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

        //student datagridview cell click event
        private void Stud_DT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //checks if the selected column index is checkbox column and row index not out of range
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                //toggels the checkbox value
                if (Convert.ToInt32(Data_Dt[e.ColumnIndex, e.RowIndex].Value) == 0) //if the value of the cell is = 0  i.e row is selected and checkbox is unchecked
                {
                    Data_Dt[this.Select_Col.Index, e.RowIndex].Value = 1; //change select cell value to 1 i.e (check the checkbox)
                    Data_Dt[e.ColumnIndex, e.RowIndex].Selected = true; //change selected state of row to true i.e select the row
                    //note that checkbox state and row selectedstate need to be done explisitly beacuse they are not linked by default

                }
                else //if the value of the cell is = 1  i.e row is selected and checkbox is checked
                {
                    Data_Dt[this.Select_Col.Index, e.RowIndex].Value = 0; //change select cell value to 0 i.e (uncheck the checkbox)
                    Data_Dt[e.ColumnIndex, e.RowIndex].Selected = false; //change selected state of row to false i.e deselect the row
                    //note that checkbox state and row selectedstate need to be done explisitly beacuse they are not linked by default
                }
            }
        }

        //student datgridview cell double click event
        private void Stud_DT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Data_Dt.CancelEdit(); //end edit
        }

        //student datagridview cell mouse up event
        private void Stud_DT_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 || e.RowIndex != -1) //if not out of range index
            {
                Data_Dt.EndEdit(); //end edit
            }
        }

        //select all checkbox check state changed event
        //selects or deselects all rows
        private void SelectAll_CHBox_CheckStateChanged(object sender, EventArgs e)
        {
            //if select all checkbox checked state = true (select all checkbox is checked)
            //note that checkbox state and row selectedstate need to be done explisitly beacuse they are not linked by default
            //loop on all selected rows and check checkbox state
            if (SelectAll_CHBox.Checked == true)
            {
                Data_Dt.SelectAll(); //select all rows on datargidview
                for (int i = 0; i < Data_Dt.SelectedRows.Count; i++) //for each selected row check checkbox 
                {
                    Data_Dt[0, i].Value = 1; //change checkbox checked state in all rows to 1 i.e check all checkboxes
                }
            }
            //elseif select all checkbox checked state = false (select all checkbox is unchecked)
            //note that checkbox state and row selectedstate need to be done explisitly beacuse they are not linked by default
            //loop on all selected rows and uncheck checkbox state
            else
            {
                for (int i = 0; i < Data_Dt.SelectedRows.Count; i++) //for each selected row check checkbox 
                {
                    Data_Dt[0, i].Value = 0; //change checkbox checked state in all rows to 0 i.e uncheck all checkboxes
                }
                Data_Dt.ClearSelection(); //deselect all rows
            }
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
    }
}
