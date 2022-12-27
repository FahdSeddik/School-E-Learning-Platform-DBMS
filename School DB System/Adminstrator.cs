using Krypton.Toolkit;
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
    public partial class Adminstrator : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        string Username;
        public Adminstrator(ViewController viewController, Controller controllerobj, string username)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerobj;
            Username = username;
        }

        private void Stud_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewStudent();
        }

        private void Teach_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewTeacher();
        }

        private void Staff_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewStaff();
        }

        private void Trans_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewBus();
        }

        private void Reqs_IBtn_Click(object sender, EventArgs e)
        {
            viewController.ViewRequest(Username);
        }

        private void Stat_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewStatistics();
        }

        private void Subj_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewSubject();
        }

        private void Dep_IBtn_Click(object sender, EventArgs e)
        {
            viewController.viewDepartment();
        }
    }
}
