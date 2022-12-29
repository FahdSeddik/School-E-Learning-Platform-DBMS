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
        protected virtual void EditControls()
        {

        }

        protected virtual void FillData(int BusID)
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
            BDriver_CBox.DataSource = controllerObj.getAllDrivers();
            BDriver_CBox.SelectedIndex = BDriver_CBox.FindString(BusInformation.Rows[0][2].ToString());

            // Add_Route_CBox.ValueMember = "bus_Route";
            //Add_Route_CBox.DisplayMember = "bus_Route";
            // Add_Route_CBox.DataSource = controllerObj.getBusRoutes();
            // Add_Route_CBox.SelectedIndex = Add_Route_CBox.FindString(BusInformation.Rows[0][3].ToString());
            Add_Route_Txt.Text = BusInformation.Rows[0][3].ToString();
        }
    

        protected void BStudList_Txt_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("This will open students list in the selected bus on a new tab.",
           "information",
           MessageBoxButtons.OK);

                viewController.viewBusStudentsList(int.Parse(BNum_Txt.Text.ToString()));
        }

        protected virtual void Submit_Btn_Click(object sender, EventArgs e)
        {
           
        }

        private void BBack_Btn_Click(object sender, EventArgs e)
        {
            //asking for confirmation
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to Leave homePage?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                viewController.CloseSubTab(); //closes page and return to home page
            }
            else //if didn't confirm "No"
            {
                return; //stay at student page
            }
        }
    }
}
