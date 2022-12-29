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
    public partial class ViewDepartment : AUVDepartment
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public ViewDepartment(ViewController viewController, Controller controllerObj, string DepID) : base(viewController, controllerObj)
        {
            InitializeComponent();
            FillData(DepID);
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            EditControls();
        }
        //overriding onPaint function to change derived class (Add student) design

       protected override void EditControls()
        {
            Tittle_Lbl.Text = "View Department";
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
                else if(item is Guna2Button)
                {
                    item.Visible = false;
                }
            }
            foreach (Control item in DepSub_Pnl.Controls)
            {
                item.Enabled = false;
            }
        }

    }
}
