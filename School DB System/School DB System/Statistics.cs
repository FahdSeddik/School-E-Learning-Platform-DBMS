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
    public partial class Statistics : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        public Statistics(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            Stat_Table.Rows.Add("Minimum", "0");
            Stat_Table.Rows.Add("Maximum", "0");
            Stat_Table.Rows.Add("Range", "0");
            Stat_Table.Rows.Add("Average", "0");
            Stat_Table.Rows.Add("Median", "0");
            Stat_Table.Rows.Add("Standard Deviation", "0");
            Stat_Table.Rows.Add("Variance", "0");
            this.controllerObj = controllerObj;
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.Logout();
        }
    }
}
