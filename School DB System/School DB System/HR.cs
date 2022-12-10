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
        public HR(ViewController viewController)
        {
            InitializeComponent();
            this.viewController = viewController;
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
            viewController.viewMail();
        }
    }
}
