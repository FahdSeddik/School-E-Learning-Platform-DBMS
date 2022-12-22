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
    public partial class AUVBus : UserControl //inherits from usercontrol
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public AUVBus(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use

        }
    
        protected virtual void FillData(string BusID)
        {
            DataTable BusInformation;//creating datatable object to retrive Staffs information
            //to fill textboxes with Staffinformation (View Staff information or update Staff information)
            BusInformation = controllerObj.getBusData(BusID);
  
            //query to check if this Staff is graduated or current Staff
            //note that getGradStaffData and getCurrentStaffData retrives Staff information in datatable that differs only in the last column
            //last column of getCurrentStaffData is StaffYear as current Staff doesn't have university yet
            //last column of getGradStaffData is university as graduate Staff doesn't have a year (graduated) 
            //filling the common data between both

            BNum_Txt.Text = BusInformation.Rows[0][0].ToString();
            BCap_Nud.Value = int.Parse(BusInformation.Rows[0][1].ToString());
            BDriver_CBox.ValueMember = "staff_ID";
            BDriver_CBox.DisplayMember = "staff_Name";
            BDriver_CBox.DataSource = controllerObj.getDrivers();
            BDriver_CBox.SelectedIndex = BDriver_CBox.FindString(BusInformation.Rows[0][2].ToString());
            Add_Route_Txt.Text = BusInformation.Rows[0][3].ToString();
        }

        protected void BStudList_Txt_Click(object sender, EventArgs e)
        {
            viewController.viewBusStudentsList(BNum_Txt.ToString());
        }

        protected virtual void Submit_Btn_Click(object sender, EventArgs e)
        {
           
        }
    }
}
