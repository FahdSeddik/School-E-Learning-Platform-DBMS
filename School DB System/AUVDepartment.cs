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
    public partial class AUVDepartment : BaseAUV
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public AUVDepartment(ViewController viewController, Controller controllerObj): base(viewController,controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
        }

        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            
        }

               protected override void FillData(string DepID)
              {
            DataTable DepInformation;//creating datatable object to retrive Deps information
            //to fill textboxes with Depinformation (View Dep information or update Dep information)
            DepInformation = controllerObj.getDepartmentData(DepID);
          //creating datatable object to retrive Teachers information
                                         //to fill textboxes with Teacherinformation (View Teacher information or update Teacher information)
                                         //query to check if this Dep is graduated or current Dep
                                         //note that getGradDepData and getCurrentDepData retrives Dep information in datatable that differs only in the last column
                                         //last column of getCurrentDepData is DepYear as current Dep doesn't have university yet
                                         //last column of getGradDepData is university as graduate Dep doesn't have a year (graduated) 
                                         //filling the common data between both

            DepID_Txt.Text = DepInformation.Rows[0][0].ToString();//filling Dep name textbox with the selectd Dep name
            DepName_Txt.Text = DepInformation.Rows[0][1].ToString();//filling Dep ID textbox with the selectd Dep ID
            DepHead_CBox.ValueMember = "staff_ID";
            DepHead_CBox.DisplayMember = "staff_Name";
            DepHead_CBox.DataSource = controllerObj.getAllTeachers();
            string TeacherName = DepInformation.Rows[0][2].ToString();
            DepHead_CBox.SelectedIndex = DepHead_CBox.FindString(TeacherName);

        }
    }
}
