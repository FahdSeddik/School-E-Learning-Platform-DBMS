using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace School_DB_System
{
    public class Controller
    {
        DBManager dbMan;
        public Controller()
        {
            dbMan = new DBManager();
        }
        //TODO: functions in the requirement

        public int Login(string username,string password)
        {
            string query = "select staff_LevelAuth from staff where Username = '"+username+"' and Password = '"+password+"';";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable getYears()
        {
            string query = "select distinct std_Year from Current_Student;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getAllStudents()
        {
            string query = "select Student.std_ID,std_Name,std_Email,std_Year from Student,Current_Student where Current_Student.std_ID = Student.std_ID;";
            return dbMan.ExecuteReader(query);
        }

        public int AddStudent(int pssn,string pname,string paddress,int pmob,string pemail,int sid,string sname,int sssn,string semail,int smob,string dob,string nationatity,string saddress,string seclan,int syear)
        {
            string query = "insert into Parent(p_SSN, p_Name, p_Address, p_Mobile, p_Email) values("+pssn+",'"+pname+"','"+paddress+"',"+pmob+",'"+pemail+"');"
            + "insert into Student(std_ID, std_Name, std_SSN, std_Email, std_Mobile, std_DoB, std_Nationality, std_Address, std_ParentSSN, Username, Password, second_language)"
            + "values("+sid+",'"+sname+"',"+sssn+",'"+semail+"',"+smob+",'"+dob+"','"+nationatity+"','"+saddress+"',"+pssn+",'"+sid.ToString()+"','"+sname+"','"+seclan+"');"
            +"insert into Current_Student(std_ID, std_Year) values("+sid+","+syear+");";
            return dbMan.ExecuteNonQuery(query);
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }

    }

