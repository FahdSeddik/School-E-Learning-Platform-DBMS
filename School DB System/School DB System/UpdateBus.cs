﻿using System;
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
    public partial class UpdateBus : AUVBus
    {//DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public UpdateBus(ViewController viewController, Controller controllerObj,int BusNum) : base(viewController, controllerObj)
        {
            InitializeComponent();
            FillData(BusNum);
            this.viewController = viewController;
            this.controllerObj = controllerObj;
        }
        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Title_Txt.Text = "Update Bus";
        }

        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres
                int queryRes = controllerObj.UpdateBus(int.Parse(BNum_Txt.Text.ToString()), int.Parse(BCap_Nud.Value.ToString()), BDriver_CBox.SelectedValue.ToString(), Add_Route_Txt.Text.ToString());

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new student failed, revise student information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Insertion a new student Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    //reset the panel to be ready for the next insertion
                    viewController.CloseSubTab();
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete student
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