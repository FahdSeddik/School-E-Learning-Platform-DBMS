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
    public partial class AddRoom : UserControl
    {
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public AddRoom(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent();
            RoomNum_Txt.Text = (int.Parse(controllerObj.getRoomsCount().ToString()) + 1).ToString();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
        }

        private void RoomSubmit_Btn_Click(object sender, EventArgs e)
        {
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres
                int queryRes = controllerObj.AddRoom(int.Parse(BuildNum_Nud.Value.ToString()), int.Parse(RoomFloor_Nud.Value.ToString()), int.Parse(RoomNum_Txt.Text.ToString()), int.Parse(RoomCap_Nud.Value.ToString()), RoomProjector_CHBox.Checked);

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
                    viewController.CloseTempTab();
                    viewController.CloseSubTab();
                    viewController.ViewAddSubject();
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

        private void RoomBack_Btn_Click(object sender, EventArgs e)
        {
            //if there is at least one row selected
            //view warning message to ask for confrimation
            var result = RJMessageBox.Show("are you sure you want to delete selected rows?, note that this operation cannot not be undone.",
            "Warning",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                //loop on all selected rows and send a query to delete this subject
                viewController.CloseTempTab();
                return;
            }
            else
            {
                return; //return (do nothing)
            }
        }
    
    }
}
