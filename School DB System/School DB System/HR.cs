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
    public partial class HR : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        string Email;
        string ID;
        string username;
        public HR(ViewController viewController, Controller controllerobj, string ID)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerobj;
            this.ID = ID;
            DataTable EmailDt = controllerObj.getEmailFromID(ID);
            Email = EmailDt.Rows[0][0].ToString();
            DataTable usernameDt = controllerObj.getUsernameFromID(ID);
            username = usernameDt.Rows[0][0].ToString();
        }

        private void Teach_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewTeacher();
        }

        private void Staff_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewStaff();
        }

        private void Reqs_IBtn_Click(object sender, EventArgs e)
        {
            viewController.ViewRequest(username);
        }
    }
}
