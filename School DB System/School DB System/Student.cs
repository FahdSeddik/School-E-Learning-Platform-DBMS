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
        DataTable yearsList;
        int stdsCount;
        bool isGrad;


        Controller controllerObj;
        public Student(ViewController viewController, Controller controllerObj)
        {

            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            isGrad = false;
            View_Pnl.Hide();
            AddMain_Pnl.Hide();
            Update_Pnl.Hide();
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

            DataTable StudentsList = new DataTable();
            StudentsList.Columns.Add().ColumnName = "ID";
            StudentsList.Columns.Add().ColumnName = "Name";
            StudentsList.Columns.Add().ColumnName = "Email";
            StudentsList.Columns.Add().ColumnName = "Year";
            Std_Dt.DataSource = StudentsList;
            Std_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[1].ReadOnly = true;
            Std_Dt.Columns[2].ReadOnly = true;
            Std_Dt.Columns[3].ReadOnly = true;
            Std_Dt.Columns[4].ReadOnly = true;
            Std_Dt.ClearSelection();
            Std_Dt.Refresh();

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
            Add_SsecondLang_CBox.Items.Add("Frensh");
            Add_SsecondLang_CBox.Items.Add("German");
            Add_SsecondLang_CBox.SelectedIndex = 0;
        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to Leave homePage?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                viewController.viewMainPage();
            }
            else
            {
                return;
            }
            
        }

        private void View_Back_Btn_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to close this window?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                View_Pnl.Hide();
            }
            else
            {
                return;
            }
            
        }

        private void Update_Back_Btn_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to close this window?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Update_Pnl.Hide();
            }
            else
            {
                return;
            }
            
        }

        private void Add_Back_Btn_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to close this window?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                AddMain_Pnl.Hide();
                resetAddPanel();
            }
            else
            {
                return;
            }
           
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
                AddMain_Pnl.Show();
                Add_SName_Txt.Select();
                AddMain_Pnl.BringToFront();
                return;
        }

        private void Delete_Btn_Click(object sender, EventArgs e)
        {
            if(Std_Dt.SelectedRows.Count < 1)
            {
                RJMessageBox.Show("There are no rows selected, please select at lease one row and try again.",
                 "Invalid Operation",
                 MessageBoxButtons.OK);
                return;
            }
            
                var result = RJMessageBox.Show("are you sure you want to delete selected rows?, note that this operation cannot not be undone.",
              "Warning",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {

                foreach(DataGridViewRow row in Std_Dt.SelectedRows)
                {
                    int stdid = int.Parse(row.Cells[1].Value.ToString());
                    int res = controllerObj.deleteStudent(stdid);
                    if (res == 0)
                    {
                        RJMessageBox.Show("deletion of selected student failed, please try again.",
                       "Error",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                        return;
                    }
                }
                    Filter_Btn.PerformClick();
                    RJMessageBox.Show("deletion of selected students done Successfully",
                   "Successfully deleted",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                    return;
                }
    
        }

        private void Update_Btn_Click(object sender, EventArgs e)
        {

                    if (Std_Dt.SelectedRows.Count > 1)
                    {
                        RJMessageBox.Show("Can't update more than one row, please select only one row and try again.",
                         "Invalid Operation",
                         MessageBoxButtons.OK);
                        return;
                    }
                    if (Std_Dt.SelectedRows.Count <= 0)
                    {
                        RJMessageBox.Show("There are no rows selected, please select only one row and try again.",
                         "Invalid Operation",
                         MessageBoxButtons.OK);
                        return;
                    }
            if (!isGrad)
            {
                Update_SecondLang_CBox.Items.Clear();
                Update_SNationality_CBox.Items.Clear();
                Update_SYear_CBox.Items.Clear();
                Update_SYear_CBox.Show();
                Update_SYear_Lbl.Show();
                Update_SUniversity_Txt.Hide();
                Update_SUniversity_Lbl.Hide();
                int selectedrowindex = Std_Dt.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = Std_Dt.Rows[selectedrowindex];
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value);
                DataTable studentInformation = controllerObj.getStudentData(long.Parse(stdID));
                Update_SID_Txt.Text = (studentInformation.Rows[0][0]).ToString();
                Update_SName_Txt.Text = studentInformation.Rows[0][1].ToString();
                Update_SYear_CBox.Items.Add(studentInformation.Rows[0][2].ToString());
                Update_SYear_CBox.SelectedIndex = 0;
                Update_SPNumber_Txt.Text = studentInformation.Rows[0][3].ToString();
                Update_SSSN_Txt.Text = studentInformation.Rows[0][4].ToString();
                Update_SEmail_Txt.Text = studentInformation.Rows[0][5].ToString();
                Update_PPNumber_Txt.Text = studentInformation.Rows[0][6].ToString();
                Update_SDob_Dtp.Value = Convert.ToDateTime(studentInformation.Rows[0][7]);
                Update_SNationality_CBox.Items.Add(studentInformation.Rows[0][8].ToString());
                Update_SNationality_CBox.SelectedIndex = 0;
                Update_SAdress_Txt.Text = studentInformation.Rows[0][9].ToString();
                Update_SecondLang_CBox.Items.Add(studentInformation.Rows[0][10].ToString());
                Update_SecondLang_CBox.SelectedIndex = 0;
                Update_PSSN_Txt.Text = studentInformation.Rows[0][11].ToString();
                Update_PName_Txt.Text = studentInformation.Rows[0][12].ToString();
                Update_PAdress_Txt.Text = studentInformation.Rows[0][13].ToString();
                Update_PPNumber_Txt.Text = studentInformation.Rows[0][14].ToString();
                Update_PEmail_Txt.Text = studentInformation.Rows[0][15].ToString();
            }
            else
            {
                Update_SecondLang_CBox.Items.Clear();
                Update_SNationality_CBox.Items.Clear();
                Update_SYear_CBox.Hide();
                Update_SYear_Lbl.Hide();
                Update_SUniversity_Txt.Show();
                Update_SUniversity_Lbl.Show();
                int selectedrowindex = Std_Dt.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = Std_Dt.Rows[selectedrowindex];
                string stdID = Convert.ToString(selectedRow.Cells["ID"].Value);
                DataTable studentInformation = controllerObj.getGradStudentData(long.Parse(stdID));
                Update_SID_Txt.Text = (studentInformation.Rows[0][0]).ToString();
                Update_SName_Txt.Text = studentInformation.Rows[0][1].ToString();
                Update_SPNumber_Txt.Text = studentInformation.Rows[0][2].ToString();
                Update_SSSN_Txt.Text = studentInformation.Rows[0][3].ToString();
                Update_SEmail_Txt.Text = studentInformation.Rows[0][4].ToString();
                Update_PPNumber_Txt.Text = studentInformation.Rows[0][5].ToString();
                Update_SDob_Dtp.Value = Convert.ToDateTime(studentInformation.Rows[0][6]);
                Update_SNationality_CBox.Items.Add(studentInformation.Rows[0][7].ToString());
                Update_SNationality_CBox.SelectedIndex = 0;
                Update_SAdress_Txt.Text = studentInformation.Rows[0][8].ToString();
                Update_SecondLang_CBox.Items.Add(studentInformation.Rows[0][9].ToString());
                Update_SecondLang_CBox.SelectedIndex = 0;
                Update_PSSN_Txt.Text = studentInformation.Rows[0][10].ToString();
                Update_PName_Txt.Text = studentInformation.Rows[0][11].ToString();
                Update_PAdress_Txt.Text = studentInformation.Rows[0][12].ToString();
                Update_PPNumber_Txt.Text = studentInformation.Rows[0][13].ToString();
                Update_PEmail_Txt.Text = studentInformation.Rows[0][14].ToString();
                Update_SUniversity_Txt.Text = studentInformation.Rows[0][15].ToString();
            }
            Update_Pnl.BringToFront();
            Update_Pnl.Show();
            return;
   
            
            
        }

        private void ViewProf_Btn_Click(object sender, EventArgs e)
        {
            
               
                if (Std_Dt.SelectedRows.Count > 1)
                {
                    RJMessageBox.Show("Can't update more than one row, please select only one row and try again.",
                     "Invalid Operation",
                     MessageBoxButtons.OK);
                    return;
                }
                if (Std_Dt.SelectedRows.Count <= 0)
                {
                    RJMessageBox.Show("There are no rows selected, please select only one row and try again.",
                     "Invalid Operation",
                     MessageBoxButtons.OK);
                    return;
                }
                {
                if(!isGrad)
                {
                    View_SecondLang_CBox.Items.Clear();
                    View_SNationality_CBox.Items.Clear();
                    View_SYear_CBox.Items.Clear();
                    View_SYear_CBox.Show();
                    VIew_SYear_Lbl.Show();
                    View_SUniversity_Txt.Hide();
                    View_SUniversity_Lbl.Hide();
                    int selectedrowindex = Std_Dt.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = Std_Dt.Rows[selectedrowindex];
                    string stdID = Convert.ToString(selectedRow.Cells["ID"].Value);
                    DataTable studentInformation = controllerObj.getStudentData(long.Parse(stdID));
                    View_SID_Txt.Text = (studentInformation.Rows[0][0]).ToString();
                    View_SName_Txt.Text = studentInformation.Rows[0][1].ToString();
                    View_SYear_CBox.Items.Add(studentInformation.Rows[0][2].ToString());
                    View_SYear_CBox.SelectedIndex = 0;
                    View_SPNumber_Txt.Text = studentInformation.Rows[0][3].ToString();
                    View_SSSN_Txt.Text = studentInformation.Rows[0][4].ToString();
                    View_SEmail_Txt.Text = studentInformation.Rows[0][5].ToString();
                    View_PPNumber_Txt.Text = studentInformation.Rows[0][6].ToString();
                    View_SDob_Dtp.Value = Convert.ToDateTime(studentInformation.Rows[0][7]);
                    View_SNationality_CBox.Items.Add(studentInformation.Rows[0][8].ToString());
                    View_SNationality_CBox.SelectedIndex = 0;
                    View_SAdress_Txt.Text = studentInformation.Rows[0][9].ToString();
                    View_SecondLang_CBox.Items.Add(studentInformation.Rows[0][10].ToString());
                    View_SecondLang_CBox.SelectedIndex = 0;
                    View_PSSN_Txt.Text = studentInformation.Rows[0][11].ToString();
                    View_PName_Txt.Text = studentInformation.Rows[0][12].ToString();
                    View_PAdress_Txt.Text = studentInformation.Rows[0][13].ToString();
                    View_PPNumber_Txt.Text = studentInformation.Rows[0][14].ToString();
                    View_PEmail_Txt.Text = studentInformation.Rows[0][15].ToString();
                }
                else
                {
                    View_SecondLang_CBox.Items.Clear();
                    View_SNationality_CBox.Items.Clear();
                    View_SYear_CBox.Hide();
                    VIew_SYear_Lbl.Hide();
                    View_SUniversity_Txt.Show();
                    View_SUniversity_Lbl.Show();
                    int selectedrowindex = Std_Dt.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = Std_Dt.Rows[selectedrowindex];
                    string stdID = Convert.ToString(selectedRow.Cells["ID"].Value);
                    DataTable studentInformation = controllerObj.getGradStudentData(long.Parse(stdID));
                    View_SID_Txt.Text = (studentInformation.Rows[0][0]).ToString();
                    View_SName_Txt.Text = studentInformation.Rows[0][1].ToString();
                    View_SPNumber_Txt.Text = studentInformation.Rows[0][2].ToString();
                    View_SSSN_Txt.Text = studentInformation.Rows[0][3].ToString();
                    View_SEmail_Txt.Text = studentInformation.Rows[0][4].ToString();
                    View_PPNumber_Txt.Text = studentInformation.Rows[0][5].ToString();
                    View_SDob_Dtp.Value = Convert.ToDateTime(studentInformation.Rows[0][6]);
                    View_SNationality_CBox.Items.Add(studentInformation.Rows[0][7].ToString());
                    View_SNationality_CBox.SelectedIndex = 0;
                    View_SAdress_Txt.Text = studentInformation.Rows[0][8].ToString();
                    View_SecondLang_CBox.Items.Add(studentInformation.Rows[0][9].ToString());
                    View_SecondLang_CBox.SelectedIndex = 0;
                    View_PSSN_Txt.Text = studentInformation.Rows[0][10].ToString();
                    View_PName_Txt.Text = studentInformation.Rows[0][11].ToString();
                    View_PAdress_Txt.Text = studentInformation.Rows[0][12].ToString();
                    View_PPNumber_Txt.Text = studentInformation.Rows[0][13].ToString();
                    View_PEmail_Txt.Text = studentInformation.Rows[0][14].ToString();
                    View_SUniversity_Txt.Text=studentInformation.Rows[0][15].ToString();
                }
               
                View_Pnl.Show();
                Add_SName_Txt.Select();
                View_Pnl.BringToFront();
                }
               
            
        }


        private void Stud_DT_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == Select_Col.Index && e.RowIndex != -1)
            {
                Std_Dt.EndEdit();
           }
            if (e.ColumnIndex != Select_Col.Index && e.RowIndex != -1)
            {
                Std_Dt.EndEdit();
           }
        }


        private void Stud_DT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == Select_Col.Index && e.RowIndex != -1)
            {
                if(Convert.ToInt32(Std_Dt[e.ColumnIndex, e.RowIndex].Value) == 0)
                {
                    Std_Dt[e.ColumnIndex, e.RowIndex].Value = 1;
                    Std_Dt[e.ColumnIndex, e.RowIndex].Selected = true;
                    
                }
                else
                {
                    Std_Dt[e.ColumnIndex, e.RowIndex].Value = 0;
                    Std_Dt[e.ColumnIndex, e.RowIndex].Selected = false;
                 }
               
            }
            if (e.ColumnIndex != Select_Col.Index && e.RowIndex != -1)
            {
                if(Convert.ToInt32(Std_Dt[Select_Col.Index, e.RowIndex].Value) == 0)
                {
                    RJMessageBox.Show("To select or unselect a row use row checkbox.",
                          "Invalid Operation",
                          MessageBoxButtons.OK);
                    Std_Dt[e.ColumnIndex, e.RowIndex].Selected = false;

                }
                else
                {
                    RJMessageBox.Show("To select or unselect row use row checkbox.",
                         "Invalid Operation",
                         MessageBoxButtons.OK);

                    Std_Dt[e.ColumnIndex, e.RowIndex].Selected = true;
                }
            }
        }

        private void SelectAll_CHBox_CheckStateChanged(object sender, EventArgs e)
        {
            if(SelectAll_CHBox.Checked == true)
            {
                Std_Dt.SelectAll();
                for (int i = 0; i < Std_Dt.SelectedRows.Count; i++)
                {
                    Std_Dt[0, i].Value = 1;
                }
            }
            else
            {
                for (int i = 0; i < Std_Dt.SelectedRows.Count; i++)
                {
                    Std_Dt[0, i].Value = 0;
                }
                Std_Dt.ClearSelection();
              
            }

        }


        private void Add_Submit_Btn_Click(object sender, EventArgs e)
        {

            foreach (Control item in AddSub_Pnl.Controls)
            {
                if (item is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)item;
                    textBox.Focus();
                    if (textBox.BorderColor == Color.Red)
                    {
                        
                        RJMessageBox.Show("Please insert all the required Values.",
                             "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                        return;
                    }
                }
            }

           

            try
            {
                int res = controllerObj.AddStudent(long.Parse(Add_PSSN_Txt.Text.ToString()), Add_PName_Txt.Text.ToString(), Add_PAdress_Txt.Text.ToString(), long.Parse(Add_PPNumber_Txt.Text.ToString()), Add_PEmail_Txt.Text.ToString(), long.Parse(Add_SID_Txt.Text.ToString()), Add_SName_Txt.Text.ToString(), long.Parse(Add_SSSN_Txt.Text.ToString()), Add_SEmail_Txt.Text.ToString(), long.Parse(Add_SPNumber_Txt.Text.ToString()), Add_SDob_Dtp.Value.ToString(), Add_SNationality_CBox.Text.ToString(), Add_SAdress_Txt.Text.ToString(), Add_SsecondLang_CBox.Text.ToString(), int.Parse(Add_SYear_CBox.Text.ToString()));
                if (res == 0)
                {
                    RJMessageBox.Show("Insertion of new student failed, revise student information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Filter_Btn.PerformClick();
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
                RJMessageBox.Show("Invalid data, please correct entered data and try again.",
              "Error",
              MessageBoxButtons.OK,
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
            if(Std_Dt.Columns.Count > 1)
            {
                Std_Dt.Columns.RemoveAt(1);
                Std_Dt.Columns.RemoveAt(1);
                Std_Dt.Columns.RemoveAt(1);
                Std_Dt.Columns.RemoveAt(1);
            }
            DataTable StudentsList = null;

            if (StateList_CBox.Text.ToString() == "Current" && YearList_CBox.SelectedValue.ToString() == "All")
            {
                StudentsList = controllerObj.getAllStudents();
                StudentsList.Columns[0].ColumnName = "ID";
                StudentsList.Columns[1].ColumnName = "Name";
                StudentsList.Columns[2].ColumnName = "Email";
                StudentsList.Columns[3].ColumnName = "Year";
                isGrad = false;
            }
            else if (StateList_CBox.Text.ToString() == "Graduated")
            {
               StudentsList = controllerObj.getAllGraduatedStudents();
                StudentsList.Columns[0].ColumnName = "ID";
                StudentsList.Columns[1].ColumnName = "Name";
                StudentsList.Columns[2].ColumnName = "Email";
                StudentsList.Columns[3].ColumnName = "University";
                isGrad = true;
            }
            else
            {
                StudentsList = controllerObj.getStudentsOfYear(int.Parse(YearList_CBox.Text));
                StudentsList.Columns[0].ColumnName = "ID";
                StudentsList.Columns[1].ColumnName = "Name";
                StudentsList.Columns[2].ColumnName = "Email";
                StudentsList.Columns[3].ColumnName = "University";
                isGrad = false;
            }
            Std_Dt.DataSource = StudentsList;
            Std_Dt.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Std_Dt.Columns[1].ReadOnly = true;
            Std_Dt.Columns[2].ReadOnly = true;
            Std_Dt.Columns[3].ReadOnly = true;
            Std_Dt.Columns[4].ReadOnly = true;
            Std_Dt.ClearSelection();
            Std_Dt.Refresh();
            return;

        }

        private void resetAddPanel()
        {
            foreach (Control item in AddSub_Pnl.Controls)
            {
                if (item is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)item;
                    textBox.ResetText();
                    textBox.BorderColor = Color.Gray;
                }
                if (item is Guna2ComboBox)
                {
                    Guna2ComboBox comboBox = (Guna2ComboBox)item;
                    comboBox.SelectedIndex = 0;
                }
            }
            Add_SName_Txt.Select();
            Add_ErrorMessage_Lbl.Hide();
        }

        private void Stud_DT_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Std_Dt.CancelEdit();
        }

    


        private void updateStudentID()
        {
            if(Add_SSSN_Txt.BorderColor == Color.Gray)
            {
                stdsCount = controllerObj.getStudentsCount();
                stdsCount++;
                string formattedStdCount = string.Format("{0:00000}", stdsCount);
                char[] CArr = Add_SSSN_Txt.Text.ToCharArray();
                int CYear = int.Parse(Add_SYear_CBox.Text);
                char[] gradYear = ((DateTime.Now.Year) + (12 - CYear)).ToString().ToCharArray();
                Add_SID_Txt.Text = gradYear[2].ToString() + gradYear[3].ToString() + CArr[0].ToString() + CArr[1].ToString() + formattedStdCount.ToString();
                return;
            }
            else
            {
                Add_SID_Txt.Text = "";
                return;
            }
            
        }

    
        private void Add_PName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Add_PName_Txt.Text.Any(char.IsDigit))
            {
                Add_ErrorMessage_Lbl.Text = "invalid name, names can't contain numbers, please inert a valid name";
                Add_ErrorMessage_Lbl.Show();
                Add_PName_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Add_ErrorMessage_Lbl.Hide();
                Add_PName_Txt.BorderColor = Color.Gray;
                return;
            }
        }


        private void Add_SName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Add_SName_Txt.Text.ToString() == "")
            {
                Add_ErrorMessage_Lbl.Text = "invalid name, please inert a valid name";
                Add_ErrorMessage_Lbl.Show();
                Add_SName_Txt.BorderColor = Color.Red;
                return;
            }
            if (Add_SName_Txt.Text.Any(char.IsDigit))
            {
                Add_ErrorMessage_Lbl.Text = "invalid name, names can't contain numbers, please inert a valid name";
                Add_ErrorMessage_Lbl.Show();
                Add_SName_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Add_ErrorMessage_Lbl.Hide();
                Add_SName_Txt.BorderColor = Color.Gray;
                return;
            }
        }

        private void Add_SSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Add_SSSN_Txt.Text.ToString() == "" || Add_SSSN_Txt.TextLength < 14 || Add_SSSN_Txt.TextLength > 20)
            {
                Add_ErrorMessage_Lbl.Text = "invalid SSN, please inert a valid 14 - 20 number SSN";
                Add_ErrorMessage_Lbl.Show();
                Add_SSSN_Txt.BorderColor = Color.Red;
                updateStudentID();
                return;
            }
            if (Add_SSSN_Txt.Text.Any(char.IsLetter))
            {
                Add_ErrorMessage_Lbl.Text = "invalid SSN, SSN can't contain characters, please inert a valid 14 - 20 number SSN";
                Add_ErrorMessage_Lbl.Show();
                Add_SSSN_Txt.BorderColor = Color.Red;
                updateStudentID();
                return;
            }
            {
                Add_ErrorMessage_Lbl.Hide();
                Add_SSSN_Txt.BorderColor = Color.Gray;
                updateStudentID();
                return;
            }
        }

        private void Add_SPNumber_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Add_SPNumber_Txt.Text.ToString() == "" || Add_SPNumber_Txt.TextLength != 11)
            {
                Add_ErrorMessage_Lbl.Text = "invalid phone number, please inert a valid 11 digit number";
                Add_ErrorMessage_Lbl.Show();
                Add_SPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            if (Add_SPNumber_Txt.Text.Any(char.IsLetter))
            {
                Add_ErrorMessage_Lbl.Text = "invalid phone number, phone numbers can't contain characters, please inert a valid 11 digit number";
                Add_ErrorMessage_Lbl.Show();
                Add_SPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Add_ErrorMessage_Lbl.Hide();
                Add_SPNumber_Txt.BorderColor = Color.Gray;
                return;
            }
        }

        private void Add_PPNumber_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Add_PPNumber_Txt.Text.ToString() == "" || Add_PPNumber_Txt.TextLength != 11)
            {
                Add_ErrorMessage_Lbl.Text = "invalid phone number, please inert 11 digit number";
                Add_ErrorMessage_Lbl.Show();
                Add_PPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            if (Add_PPNumber_Txt.Text.Any(char.IsLetter))
            {
                Add_ErrorMessage_Lbl.Text = "invalid phone number, phone numbers can't contain characters, please inert a valid 11 digit number";
                Add_ErrorMessage_Lbl.Show();
                Add_PPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Add_ErrorMessage_Lbl.Hide();
                Add_PPNumber_Txt.BorderColor = Color.Gray;
                return;
            }
        }

        private void Add_PSSN_txt_TextChanged(object sender, EventArgs e)
        {
            if (Add_PSSN_Txt.Text.ToString() == "" || Add_PSSN_Txt.TextLength < 14 || Add_PSSN_Txt.TextLength > 20)
            {
                Add_ErrorMessage_Lbl.Text = "invalid SSN, please inert a valid 14 - 20 number SSN";
                Add_ErrorMessage_Lbl.Show();
                Add_PSSN_Txt.BorderColor = Color.Red;

                return;
            }
            if (Add_PSSN_Txt.Text.Any(char.IsLetter))
            {
                Add_ErrorMessage_Lbl.Text = "invalid SSN, SSN can't contain characters, please inert a valid 14 - 20 number SSN";
                Add_ErrorMessage_Lbl.Show();
                Add_PSSN_Txt.BorderColor = Color.Red;

                return;
            }

            {
                Add_ErrorMessage_Lbl.Hide();
                Add_PSSN_Txt.BorderColor = Color.Gray;

                return;
            }
        }

        private void Add_SYear_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStudentID();
        }

        private void Update_SSubmit_Btn_Click(object sender, EventArgs e)
        {
            foreach (Control item in Update_Sub_Pnl.Controls)
            {
                if (item is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)item;
                    textBox.Focus();
                    if (textBox.BorderColor == Color.Red)
                    {

                        RJMessageBox.Show("Please insert all the required Values.",
                             "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                        return;
                    }
                }
            }



            try
            {
                int res = controllerObj.UpdateCurrentStudent(long.Parse(Update_PSSN_Txt.Text.ToString()), Update_PName_Txt.Text.ToString(), Update_PAdress_Txt.Text.ToString(), long.Parse(Update_PPNumber_Txt.Text.ToString()), Update_PEmail_Txt.Text.ToString(), long.Parse(Update_SID_Txt.Text.ToString()), Update_SName_Txt.Text.ToString(), long.Parse(Update_SSSN_Txt.Text.ToString()), Update_SEmail_Txt.Text.ToString(), long.Parse(Update_SPNumber_Txt.Text.ToString()), Update_SDob_Dtp.Value.ToString(), Update_SNationality_CBox.Text.ToString(), Update_SAdress_Txt.Text.ToString(), Update_SecondLang_CBox.Text.ToString(), int.Parse(Update_SYear_CBox.Text.ToString()));
                if (res == 0)
                {
                    RJMessageBox.Show("Student Information couldn't be updated, revise student information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Filter_Btn.PerformClick();
                    RJMessageBox.Show("Student information updated successfully",
                   "Successfully Updated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    resetAddPanel();
                    return;
                }
            }
            catch (Exception error)
            {
                RJMessageBox.Show("Invalid data, please correct entered data and try again.",
              "Error",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return;
            }
        }

        private void Update_SName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Update_SName_Txt.Text.ToString() == "")
            {
                Update_ErrorMessage_Lbl.Text = "invalid name, please inert a valid name";
                Update_ErrorMessage_Lbl.Show();
                Update_SName_Txt.BorderColor = Color.Red;
                return;
            }
            if (Update_SName_Txt.Text.Any(char.IsDigit))
            {
                Update_ErrorMessage_Lbl.Text = "invalid name, names can't contain numbers, please inert a valid name";
                Update_ErrorMessage_Lbl.Show();
                Update_SName_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Update_ErrorMessage_Lbl.Hide();
                Update_SName_Txt.BorderColor = Color.Gray;
                return;
            }
        }

        private void Update_SSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Update_SSSN_Txt.Text.ToString() == "" || Update_SSSN_Txt.TextLength < 14 || Update_SSSN_Txt.TextLength > 20)
            {
                Update_ErrorMessage_Lbl.Text = "invalid SSN, please inert a valid 14 - 20 number SSN";
                Update_ErrorMessage_Lbl.Show();
                Update_SSSN_Txt.BorderColor = Color.Red;
 
                return;
            }
            if (Add_SSSN_Txt.Text.Any(char.IsLetter))
            {
                Update_ErrorMessage_Lbl.Text = "invalid SSN, SSN can't contain characters, please inert a valid 14 - 20 number SSN";
                Update_ErrorMessage_Lbl.Show();
                Update_SSSN_Txt.BorderColor = Color.Red;
           
                return;
            }
            {
                Update_ErrorMessage_Lbl.Hide();
                Update_SSSN_Txt.BorderColor = Color.Gray;
            
                return;
            }
        }

        private void Update_SPNumber_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Update_SPNumber_Txt.Text.ToString() == "" || Update_SPNumber_Txt.TextLength != 11)
            {
                Update_ErrorMessage_Lbl.Text = "invalid phone number, please inert a valid 11 digit number";
                Update_ErrorMessage_Lbl.Show();
                Update_SPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            if (Update_SPNumber_Txt.Text.Any(char.IsLetter))
            {
                Update_ErrorMessage_Lbl.Text = "invalid phone number, phone numbers can't contain characters, please inert a valid 11 digit number";
                Update_ErrorMessage_Lbl.Show();
                Update_SPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Update_ErrorMessage_Lbl.Hide();
                Update_SPNumber_Txt.BorderColor = Color.Gray;
                return;
            }
        }

        private void Update_PPNumber_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Update_PPNumber_Txt.Text.ToString() == "" || Update_PPNumber_Txt.TextLength != 11)
            {
                Update_ErrorMessage_Lbl.Text = "invalid phone number, please inert 11 digit number";
                Update_ErrorMessage_Lbl.Show();
                Update_PPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            if (Add_PPNumber_Txt.Text.Any(char.IsLetter))
            {
                Update_ErrorMessage_Lbl.Text = "invalid phone number, phone numbers can't contain characters, please inert a valid 11 digit number";
                Update_ErrorMessage_Lbl.Show();
                Update_PPNumber_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Update_ErrorMessage_Lbl.Hide();
                Update_PPNumber_Txt.BorderColor = Color.Gray;
                return;
            }
        }

        private void Update_PSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Update_PSSN_Txt.Text.ToString() == "" || Update_PSSN_Txt.TextLength < 14 || Update_PSSN_Txt.TextLength > 20)
            {
                Update_ErrorMessage_Lbl.Text = "invalid SSN, please inert a valid 14 - 20 number SSN";
                Update_ErrorMessage_Lbl.Show();
                Update_PSSN_Txt.BorderColor = Color.Red;

                return;
            }
            if (Update_PSSN_Txt.Text.Any(char.IsLetter))
            {
                Update_ErrorMessage_Lbl.Text = "invalid SSN, SSN can't contain characters, please inert a valid 14 - 20 number SSN";
                Update_ErrorMessage_Lbl.Show();
                Update_PSSN_Txt.BorderColor = Color.Red;

                return;
            }

            {
                Update_ErrorMessage_Lbl.Hide();
                Update_PSSN_Txt.BorderColor = Color.Gray;

                return;
            }
        }

        private void Update_PName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (Update_PName_Txt.Text.Any(char.IsDigit))
            {
                Update_ErrorMessage_Lbl.Text = "invalid name, names can't contain numbers, please inert a valid name";
                Update_ErrorMessage_Lbl.Show();
                Update_PName_Txt.BorderColor = Color.Red;
                return;
            }
            {
                Update_ErrorMessage_Lbl.Hide();
                Update_PName_Txt.BorderColor = Color.Gray;
                return;
            }
        }
    }
}
