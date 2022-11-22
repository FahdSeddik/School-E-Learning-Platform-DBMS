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
    }
}
