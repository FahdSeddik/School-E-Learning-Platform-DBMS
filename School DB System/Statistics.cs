using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace School_DB_System
{
    public partial class Statistics : UserControl
    {
        ViewController viewController;
        Controller controllerObj;
        DataTable StdGrades;
        DataTable StdGrades2;
        public Statistics(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent();
            this.viewController = viewController;
            this.controllerObj = controllerObj;
            NumOfStdsVal_Lbl.Text = (controllerObj.getStudentsCount()).ToString();
           

            YearList_CBox.DisplayMember = "std_Year"; //displaying std_Year column from datatable "Yearslist"
            YearList_CBox.ValueMember = "std_Year"; //linking value to std_year column from datatable "YearsList"
            YearList_CBox.DataSource = controllerObj.getYears();

            SubjList_CBox.DisplayMember = "sub_Name"; //displaying std_Year column from datatable "Yearslist"
            SubjList_CBox.ValueMember = "sub_ID"; //linking value to std_year column from datatable "YearsList"
            SubjList_CBox.DataSource = controllerObj.getSubjectsOfYear(int.Parse(YearList_CBox.SelectedValue.ToString()));

            TeachDep_CBox.DisplayMember = "dep_Name"; //displaying std_Year column from datatable "Yearslist"
            TeachDep_CBox.ValueMember = "dep_ID"; //linking value to std_year column from datatable "YearsList"
            TeachDep_CBox.DataSource = controllerObj.getDepartmentslist();
            ///////////////////////////
            StdGrades = new DataTable();
            StdGrades.Columns.Add("X");
            StdGrades.Columns.Add("Y");
            StudGrades_Chart.Series.Add("Students");
            StudGrades_Chart.Series["Students"].XValueMember = "X";
            StudGrades_Chart.Series["Students"].YValueMembers = "Y";
            StudGrades_Chart.DataSource = StdGrades;
            /////////////////////////////////////////
            StdGrades2 = new DataTable();
            StdGrades2.Columns.Add("S");
            StdGrades2.Columns.Add("F");
            StudPass_Chart.Series.Add("PassOrFail").ChartType = SeriesChartType.Pie;

            StudPass_Chart.Series["PassOrFail"].XValueMember = "S";
            StudPass_Chart.Series["PassOrFail"].YValueMembers = "F";
           
            StudPass_Chart.DataSource = StdGrades2;
            //////////////////////////////////////////////
            DataTable StaffSalaries = new DataTable();
            StaffSalaries.Columns.Add("Name");
            StaffSalaries.Columns.Add("Value");
            double Avg, Min, Max, Stdev;
            Int64 Count;
            Avg = double.Parse(controllerObj.getStaffAVGSalary().ToString());
            Count = Int64.Parse(controllerObj.getStaffCount().ToString());
            Min = double.Parse(controllerObj.getStaffMinSalary().ToString());
            Max = double.Parse(controllerObj.getStaffMaxSalary().ToString());
            Stdev = double.Parse(controllerObj.getStaffStDevSalary().ToString());
            StaffSalaries.Rows.Add("Average", Avg.ToString());
            StaffSalaries.Rows.Add("Min", Min.ToString());
            StaffSalaries.Rows.Add("Max", Max.ToString());
            StaffSalaries.Rows.Add("Standar Deviation", Stdev.ToString());
            StaffStat_Dgv.DataSource = StaffSalaries;
            NumOfStaffVal_Lbl.Text = Count.ToString();
            hideEmptyChartMsg();
            ///////////////

        }

        private void MainBack_Btn_Click(object sender, EventArgs e)
        {
            //asking for confirmation
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to Leave homePage?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                viewController.CloseMainTab(); //closes page and return to home page
            }
            else //if didn't confirm "No"
            {
                return; //stay at student page
            }
        }

        private void View_Btn_Click(object sender, EventArgs e)
        {
            int ACount, BCount, CCount, DCount, FCount,SuccedCount;
            int year = int.Parse(YearList_CBox.SelectedValue.ToString());
            string sub_ID = SubjList_CBox.SelectedValue.ToString();
            ACount = controllerObj.getGradeCount(sub_ID,"A");
            BCount = controllerObj.getGradeCount(sub_ID,"B");
            CCount = controllerObj.getGradeCount(sub_ID, "C");
            DCount = controllerObj.getGradeCount(sub_ID, "D");
            FCount = controllerObj.getGradeCount(sub_ID, "F");
            SuccedCount = controllerObj.getPassCount(sub_ID);
            if(ACount == 0 && BCount == 0 && CCount == 0 && DCount == 0 && FCount ==0)
            {
                StudGrades_Chart.Series["Students"].Enabled = false;
                StudPass_Chart.Series["PassOrFail"].Enabled = false;
                showEmptyChartMsg();
                return;
            }
            StudGrades_Chart.Series["Students"].Enabled = true;
            StudPass_Chart.Series["PassOrFail"].Enabled = true;
            hideEmptyChartMsg();
            StdGrades.Rows.Clear();
            StdGrades2.Rows.Clear();
            StdGrades.Rows.Add("A", ACount.ToString());
            StdGrades.Rows.Add("B", BCount.ToString());
            StdGrades.Rows.Add("C", CCount.ToString());
            StdGrades.Rows.Add("D", DCount.ToString());
            StdGrades.Rows.Add("F", FCount.ToString());
            StdGrades2.Rows.Add("pass", SuccedCount.ToString());
            StdGrades2.Rows.Add("Fail", FCount.ToString());
            StudPass_Chart.PaletteCustomColors = new Color[] { Color.BlanchedAlmond, Color.Yellow };
            NumOfStudsOfYearValue_Lbl.Text = (controllerObj.getStudentsCountOfYear(year)).ToString();
            StudGrades_Chart.DataBind();
            StudPass_Chart.DataBind();
            
        }

        private void showEmptyChartMsg()
        {
            EmptyChartErrorMsg_Lbl.Show();
            EmptyPieChartErrorMsg_Lbl.Show();
        }

        private void hideEmptyChartMsg()
        {
            EmptyChartErrorMsg_Lbl.Hide();
            EmptyPieChartErrorMsg_Lbl.Hide();
        }

        private void TeachView_Btn_Click(object sender, EventArgs e)
        {
            DataTable TeacherSalaries = new DataTable();
            TeacherSalaries.Columns.Add("Name");
            TeacherSalaries.Columns.Add("Value");
            string depID = TeachDep_CBox.SelectedValue.ToString();
            ////////////////////////////
            double Avg, Count, Min, Max, Stdev;
            Avg = double.Parse(controllerObj.getAvgTeacherSalary(depID).ToString());
            Count = double.Parse(controllerObj.getTeacherCount(depID).ToString());
            Min = double.Parse(controllerObj.getMinTeacherSalary(depID).ToString());
            Max = double.Parse(controllerObj.getMaxTeacherSalary(depID).ToString());
            Stdev = double.Parse(controllerObj.getSTDEVTeacherSalary(depID).ToString());
            /////////////////////////
            TeacherSalaries.Rows.Add("Average", Avg.ToString());
            TeacherSalaries.Rows.Add("Min", Min.ToString());
            TeacherSalaries.Rows.Add("Max", Max.ToString());
            TeacherSalaries.Rows.Add("Standar Deviation", Stdev.ToString());
            ////////////////////////
            TeachStat_Dgv.DataSource = TeacherSalaries;
            TeachStat_Dgv.Refresh();
            NumOfTeachVal_Lbl.Text = Count.ToString();
        }

        private void YearList_CBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
                SubjList_CBox.DisplayMember = "sub_Name"; //displaying std_Year column from datatable "Yearslist"
                SubjList_CBox.ValueMember = "sub_ID"; //linking value to std_year column from datatable "YearsList"
                DataTable SubjList = controllerObj.getSubjectsOfYear(int.Parse(YearList_CBox.SelectedValue.ToString()));
                SubjList_CBox.DataSource = SubjList;
                SubjList_CBox.Refresh();
                SubjList_CBox.SelectedIndex = 0;
          
        }
    }
}
