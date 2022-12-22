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
    {//DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public ViewBus(ViewController viewController, Controller controllerObj, string BusNum) : base(viewController, controllerObj)
        {
            InitializeComponent();
            FillData(BusNum);
        }
        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Title_Txt.Text = "View Bus";
        }

       
    }
}
