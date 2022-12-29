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

namespace School_DB_System
{
    public partial class AddDepartment : AUVDepartment
    {  //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        public AddDepartment(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent();
            DepHead_CBox.ValueMember = "staff_ID";
            DepHead_CBox.DisplayMember = "staff_Name";
            DepHead_CBox.DataSource = controllerObj.getTeachersNotHeads();
            DepID_Txt.Text = (int.Parse(controllerObj.getDepartmentsCount().ToString()) + 1).ToString();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
        }
        //overriding onPaint function to change derived class (Add Department) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "Add Department";
            foreach (Control item in Main_Pnl.Controls)
            {
                if (item is Guna2GradientPanel) //if the item is textbox
                {
                    Guna2GradientPanel Panel = (Guna2GradientPanel)item; //cast item to textbox to
                    if (Panel.Name != "DepSub_Pnl" || Panel.Name == "TitleBar_Pnl")
                    {
                        Panel.Hide();
                        this.Controls.Remove(Panel);
                    }
                }
            }
        }

        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres
                int queryRes = controllerObj.AddDepartment(DepID_Txt.Text.ToString(), DepName_Txt.Text.ToString(), DepHead_CBox.SelectedValue.ToString());

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new Department failed, revise Department information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Insertion a new Department Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    //reset the panel to be ready for the next insertion
                    viewController.CloseSubTab();
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete Department
                    //resets all textboxes text, clear error message...etc
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
