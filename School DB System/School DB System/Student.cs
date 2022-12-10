using Guna.UI2.AnimatorNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Windows.Input;
using Guna.UI2.WinForms;

namespace School_DB_System
{
    public partial class Student : UserControl
    {
        ViewController viewController;
        bool windowOpened;
        DataTable yearsList;


        Controller controllerObj;
        public Student(ViewController viewController, Controller controllerObj)
        {

            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            ViewProf_Pnl.Hide();
            AddMain_Pnl.Hide();
            Update_Pnl.Hide();
            windowOpened = false;
            DataTable tempYearsList = controllerObj.getYears();
            int YearsC = tempYearsList.Rows.Count;
            yearsList = new DataTable();
            yearsList.Columns.Add("std_Year", typeof(string));
            yearsList.Rows.Add("All");
            for (int i = 0; i < YearsC; i++)
            {
                Object cellValue = (tempYearsList.Rows[i][0]).ToString();
                yearsList.Rows.Add(cellValue.ToString());
            }
            YearList_CBox.DisplayMember = "std_Year";
            YearList_CBox.ValueMember = "std_Year";
            YearList_CBox.DataSource = yearsList;
            StateList_CBox.Items.Add("Current");
            StateList_CBox.Items.Add("Graduated");
            StateList_CBox.SelectedIndex = 0;

            DataTable StudentsList = controllerObj.getAllStudents();
            StudentsList.Columns[0].ColumnName = "ID";
            StudentsList.Columns[1].ColumnName = "Name";
            StudentsList.Columns[2].ColumnName = "Email";
            StudentsList.Columns[3].ColumnName = "Year";
            Stud_DT.DataSource = StudentsList;
            Stud_DT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stud_DT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stud_DT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stud_DT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Stud_DT.Columns[1].ReadOnly = true;
            Stud_DT.Columns[2].ReadOnly = true;
            Stud_DT.Columns[3].ReadOnly = true;
            Stud_DT.Columns[4].ReadOnly = true;
            Stud_DT.ClearSelection();
            Stud_DT.Refresh();

            Add_SNationality_CBox.Items.Add("Egyptian");
            Add_SNationality_CBox.Items.Add("English");
            Add_SNationality_CBox.Items.Add("French");
            Add_SNationality_CBox.Items.Add("German");
            Add_SNationality_CBox.Items.Add("Iraqi");
            Add_SNationality_CBox.Items.Add("Italian");
            Add_SNationality_CBox.Items.Add("Iranian");
            Add_SNationality_CBox.Items.Add("Indonesian");
            Add_SNationality_CBox.Items.Add("Kuwaiti");
            Add_SNationality_CBox.Items.Add("Moroccan");
            Add_SNationality_CBox.Items.Add("Omani");
            Add_SNationality_CBox.Items.Add("Portuguese");
            Add_SNationality_CBox.SelectedIndex = 0;
            Add_SYear_CBox.DisplayMember = "std_Year";
            Add_SYear_CBox.ValueMember = "std_Year";
            Add_SYear_CBox.DataSource = tempYearsList;
            Add_SYear_CBox.SelectedIndex = 0;
            Add_Ssecond_CBox.Items.Add("Frensh");
            Add_Ssecond_CBox.Items.Add("German");
            Add_Ssecond_CBox.SelectedIndex = 0;
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            viewController.viewMainPage();
        }

        private void View_Back_Btn_Click(object sender, EventArgs e)
        {
            ViewProf_Pnl.Hide();
            windowOpened = false;
        }

        private void Update_Back_Btn_Click(object sender, EventArgs e)
        {
            Update_Pnl.Hide();
            windowOpened = false;
        }

        private void Add_Back_Btn_Click(object sender, EventArgs e)
        {
            AddMain_Pnl.Hide();
            windowOpened = false;
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            AddMain_Pnl.Show();
            Add_SName_Txt.Select();
            AddMain_Pnl.BringToFront();
            windowOpened = true;
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Stud_DT.SelectedRows.Count.ToString());
        }

        private void Update_Btn_Click(object sender, EventArgs e)
        {
            Update_Pnl.Show();
            windowOpened = true;
        }

        private void ViewProf_Btn_Click(object sender, EventArgs e)
        {
            ViewProf_Pnl.Show();
            windowOpened = true;
        }


        private void Stud_DT_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == Select_Col.Index && e.RowIndex != -1)
            {
                Stud_DT.EndEdit();
            }
        }

        private void Stud_DT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Select_Col.Index && e.RowIndex != -1)
            {
                Stud_DT.EndEdit();
            }
        }

        private void Stud_DT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Select_Col.Index && e.RowIndex != -1)
            {
                if(Convert.ToInt32(Stud_DT[e.ColumnIndex, e.RowIndex].Value) == 0)
                {
                    Stud_DT[e.ColumnIndex, e.RowIndex].Value = 1;
                    Stud_DT[e.ColumnIndex, e.RowIndex].Selected = true;
                    
                }
                else
                {
                    Stud_DT[e.ColumnIndex, e.RowIndex].Value = 0;
                    Stud_DT[e.ColumnIndex, e.RowIndex].Selected = false;
                 }
               
            }
            if (e.ColumnIndex != Select_Col.Index && e.RowIndex != -1)
            {
                if(Convert.ToInt32(Stud_DT[Select_Col.Index, e.RowIndex].Value) == 0)
                {
                    Stud_DT[e.ColumnIndex, e.RowIndex].Selected = false;
                }
                else
                {
                   
                    Stud_DT[e.ColumnIndex, e.RowIndex].Selected = true;
                }
            }
        }

        private void SelectAll_CHBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(SelectAll_CHBox.Checked == true)
            {
                Stud_DT.SelectAll();
                for (int i = 0; i < Stud_DT.SelectedRows.Count; i++)
                {
                    Stud_DT[0, i].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < Stud_DT.SelectedRows.Count; i++)
                {
                    Stud_DT[0, i].Value = 0;
                }
                Stud_DT.ClearSelection();
              
            }

        }

        private void Stud_DT_CellDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Stud_DT_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void Add_Submit_Btn_Click(object sender, EventArgs e)
        {
            if(Add_SName_Txt.Text == "") 
            {
                RJMessageBox.Show("Please insert all the required Values.",
                "Error",
                MessageBoxButtons.RetryCancel,
                MessageBoxIcon.Error);
                return;
            }
            if (Add_SID_Txt.Text == "")
            {
                RJMessageBox.Show("Please insert all the required Values.",
               "Error",
               MessageBoxButtons.RetryCancel,
               MessageBoxIcon.Error);
                return;
            }
            if (Add_SDob_Dtp.Text == "")
            {
                RJMessageBox.Show("Please insert all the required Values.",
               "Error",
               MessageBoxButtons.RetryCancel,
               MessageBoxIcon.Error);
                return;
            }
            if (Add_SSSN_Txt.Text == "")
            {
                RJMessageBox.Show("Please insert all the required Values.",
               "Error",
               MessageBoxButtons.RetryCancel,
               MessageBoxIcon.Error);
                return;
            }
            if (Add_PPNumber_Txt.Text == "")
            {
                RJMessageBox.Show("Please insert all the required Values.",
               "Error",
               MessageBoxButtons.RetryCancel,
               MessageBoxIcon.Error);
                return;
            }
            if (Add_PSSN_txt.Text == "")
            {
                RJMessageBox.Show("Please insert all the required Values.",
               "Error",
               MessageBoxButtons.RetryCancel,
               MessageBoxIcon.Error);
                return;
            }

            try
            {
                int res = controllerObj.AddStudent(int.Parse(Add_PSSN_txt.Text), Add_PName_Txt.Text.ToString(), Add_PAdress_Txt.Text.ToString(), int.Parse(Add_PPNumber_Txt.Text.ToString()), Add_PEmail_Txt.Text.ToString(), int.Parse(Add_SID_Txt.Text.ToString()), Add_SName_Txt.Text.ToString(), int.Parse(Add_SSSN_Txt.Text.ToString()), Add_SEmail_Txt.Text.ToString(), int.Parse(Add_SPNumber_Txt.Text.ToString()), Add_SDob_Dtp.Value.ToString(), Add_SNationality_CBox.Text.ToString(), Add_SAdress_Txt.Text.ToString(), Add_Ssecond_CBox.Text.ToString(), int.Parse(Add_SYear_CBox.Text.ToString()));
                if (res == 0)
                {
                    RJMessageBox.Show("Insertion of new student failed.",
                    "Error",
                    MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    RJMessageBox.Show("Insertion a new student Successfully",
                   "Successfully added",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                    resetAddPanel();
                    return;
                }
            }
            catch(Exception error)
            {
                RJMessageBox.Show("Invalid data, please note that SSN,ID,Phone Number are number not strings, correct entered data and try again.",
              "Error",
              MessageBoxButtons.RetryCancel,
              MessageBoxIcon.Error);
                return;
            }
            
        }

        private void StateList_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(StateList_CBox.Text.ToString() == "Graduated")
            {
                YearList_CBox.DataSource = null;
                YearList_CBox.Enabled = false;
            }
            else
            {
                YearList_CBox.Enabled = true;
                YearList_CBox.DisplayMember = "std_Year";
                YearList_CBox.ValueMember = "std_Year";
                YearList_CBox.DataSource = yearsList;
            }
        }

        private void Filter_Btn_Click(object sender, EventArgs e)
        {
            Stud_DT.ClearSelection();
        }

        private void resetAddPanel()
        {
            foreach (Control item in AddSub_Pnl.Controls)
            {
                if (item is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)item;
                    textBox.ResetText();
                }
                if (item is Guna2ComboBox)
                {
                    Guna2ComboBox comboBox = (Guna2ComboBox)item;
                    comboBox.SelectedIndex = 0;
                }
            }
            Add_SName_Txt.Select();
        }
    }
}
