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
    public partial class ViewBus : AUVBus
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public ViewBus(ViewController viewController, Controller controllerObj, int BusNum) : base(viewController, controllerObj)
        {
            InitializeComponent();
            FillData(BusNum);
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            EditControls();
        }
        //overriding onPaint function to change derived class (Add student) design
       protected override void EditControls()
        {
            Title_Txt.Text = "View Bus";
            foreach(Control item in BSub_Pnl.Controls)
            {
                if (item is Guna2Button)
                {
                    break;
                }
                    item.Enabled = false;
     
            }
            Submit_Btn.Visible = false;
        }

       
    }
}
