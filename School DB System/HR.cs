using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace School_DB_System
{
    public partial class HR : UserControl
    {
        ViewController viewController;
        Controller controllerObj;

        string Username;
        public HR(ViewController viewController, Controller controllerobj, string username)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerobj;
           
            Username = username;

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
            viewController.ViewRequest(Username);
        }
    }
}
