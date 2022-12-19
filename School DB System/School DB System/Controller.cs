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
        public DataTable getAllGraduatedStudents()
        {
            string query = "select Student.std_ID,std_Name,std_Email,gstd_University from Student,Grad_Student where Grad_Student.std_ID = Student.std_ID;";
            return dbMan.ExecuteReader(query);
        }
        public int getStudentsCount()
        {
            string query = "select count(std_ID) from Student";
            return (int)dbMan.ExecuteScalar(query);
        }
        public DataTable getStudentsOfYear(int year)
        {
            string query = "select Student.std_ID,std_Name,std_Email,std_Year from Student,Current_Student where Current_Student.std_ID = Student.std_ID and std_Year = "+year+";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getCurrentStudentData(string stdID)
        {
            string query = "select s.std_ID,std_Name,std_Mobile,std_SSN,std_Email,P_Mobile,std_DoB,std_Nationality,std_Address,second_language,p_SSN,p_Name,p_Address,p_Mobile,p_Email,std_Year,cs.pay_tuition from Student as s,Parent as p,Current_Student as cs where s.std_ID= '" + stdID+"' and s.std_ParentSSN=p.p_SSN and cs.std_ID = s.std_ID;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getGradStudentData(string stdID)
        {
            string query = "select s.std_ID,std_Name,std_Mobile,std_SSN,std_Email,P_Mobile,std_DoB,std_Nationality,std_Address,second_language,p_SSN,p_Name,p_Address,p_Mobile,p_Email,gstd_University from Student as s,Parent as p,Grad_Student as g where s.std_ID= '"+ stdID+"' and s.std_ParentSSN=p.p_SSN and g.std_ID=s.std_ID;";
            return dbMan.ExecuteReader(query);
        }

        public int IsGraduatedStudent(string stdID)
        {
            string query = "select count(std_ID) from Grad_Student where std_ID = '"+stdID+"'";
            return (int)dbMan.ExecuteScalar(query);
        }
        
            public int getTeachersCount()
              {
            string query = "SELECT count(staff_ID) FROM Teacher;";
            return (int)dbMan.ExecuteScalar(query);
             }

        public int deleteStudent(string stdID)
        {
            string query = "delete Parent where p_SSN in ((select std_ParentSSN from Student where std_ID='"+stdID+"'));";
            return dbMan.ExecuteNonQuery(query);
        }
        public int AddStudent(string pssn,string pname,string paddress,string pmob,string pemail,string sid,string sname,string sssn,string semail,string smob,string dob,string nationatity,string saddress,string seclan,int syear)
        {
            string query = "insert into Parent(p_SSN, p_Name, p_Address, p_Mobile, p_Email) values("+pssn+",'"+pname+"','"+paddress+"',"+pmob+",'"+pemail+"');"
            + "insert into Student(std_ID, std_Name, std_SSN, std_Email, std_Mobile, std_DoB, std_Nationality, std_Address, std_ParentSSN, Username, Password, second_language)"
            + "values('"+sid+"','"+sname+"','"+sssn+"','"+semail+"','"+smob+"','"+dob+"','"+nationatity+"','"+saddress+"','"+pssn+"','"+sid.ToString()+"','"+sname+"','"+seclan+"');"
            +"insert into Current_Student(std_ID, std_Year) values('"+sid+"',"+syear+");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateCurrentStudent(string pssn, string pname, string paddress, string pmob, string pemail, string sid, string sname, string sssn, string semail, string smob, string dob, string nationatity, string saddress, string seclan, int syear, bool payedtuition)
        {
           string query = "update Student set std_Name = '"+sname+"', std_SSN = '"+sssn+"', std_Email = '"+semail+"', std_Mobile = '"+smob+"', std_DoB = '"+dob+"', std_Nationality = '"+nationatity+"', std_Address = '"+saddress+"', std_ParentSSN = '"+pssn+"', second_language = '"+seclan+"' where std_ID = '"+sid+"';"

            +"update Current_Student set std_Year = "+syear+ ", pay_tuition = '"+payedtuition+"' where std_ID = '" + sid+"';"

            +"update Parent set p_SSN = '"+pssn+"', p_Name = '"+pname+"', p_Address = '"+paddress+"', p_Mobile = '"+pmob+"', p_Email = '"+pemail+"' where p_SSN in ((select std_ParentSSN from Student where std_ID = '"+sid+"' ));";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getDepartmentslist()
        {
            string query = "select dep_Name,dep_ID from Department;";
            return dbMan.ExecuteReader(query);
        }

        
            public DataTable getteachersOfDepartment(string depID)
                 {
            string query = "select t.staff_ID,s.staff_Name,s.staff_Email,s.staff_Mobile from Staff as s,Teacher as t where s.staff_LevelAuth=5 and s.staff_ID=t.staff_ID and t.tDep_ID= '" + depID+"';";
            return dbMan.ExecuteReader(query);
             }

        
            public int deleteTeacher(string teachID)
        {
            string query = "delete Teacher where staff_ID='"+teachID+"';"
                + "delete Staff where staff_ID='"+teachID+"';";
           return dbMan.ExecuteNonQuery(query);
        }

        public int AddTeacher(string staffID, string staffName, string staffSSN, Int64 staffSalary, string staffAdress, string staffEmail, string staffMobileNumber, string staffDep, bool fullTime, string username, string password)
         {
                string query = "insert into Staff (staff_ID,staff_Name,staff_SSN,staff_Position,staff_LevelAuth,staff_Salary,staff_Address,staff_Email,staff_Mobile,Full_Time,Username,Password) " +
                "values ('"+staffID+"','"+staffName+"','"+staffSSN+ "','teacher',"+5+","+staffSalary+",'"+staffAdress+"','"+staffEmail+"','"+staffMobileNumber+"','"+fullTime+"','"+staffID+"','"+0000+"');"
                + "insert into Teacher(staff_ID,tDep_ID) values ('" + staffID+"','"+ staffDep + "');";
                return dbMan.ExecuteNonQuery(query);
         }

        public int UpdateTeacher(string staffID, string staffName, string staffSSN, Int64 staffSalary, string staffAdress, string staffEmail, string staffMobileNumber, string staffDep, bool fullTime, string username, string password)
        {
            string query = "update Staff " + 
            "set staff_Name = '"+staffName+"', staff_SSN = '"+staffSSN+ "', staff_Position = 'teacher', staff_LevelAuth = "+5+", staff_Salary = "+staffSalary+", staff_Address = '"+staffAdress+"', staff_Email = '"+staffEmail+"', staff_Mobile = '"+staffMobileNumber+"', Full_Time = '"+fullTime+"' where staff_ID = '"+staffID+"'; ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getTeacherData(string TeachersID)
        {
            string query = "select s.staff_Name,s.staff_ID,s.staff_Email,s.staff_SSN,s.staff_Address,s.staff_Mobile,s.staff_Salary,s.Full_Time,d.dep_Name from Staff as s,Teacher as t,Department as d where t.staff_ID=s.staff_ID and t.tDep_ID=d.dep_ID and t.staff_ID = " + TeachersID + ";";
            return dbMan.ExecuteReader(query);
        }

        



        public int UpdateGraduateStudent(string pssn, string pname, string paddress, string pmob, string pemail, string sid, string sname, string sssn, string semail, string smob, string dob, string nationatity, string saddress, string seclan, string university)
            {
            string query = "update Student set std_Name = '" + sname + "', std_SSN = '" + sssn + "', std_Email = '" + semail + "', std_Mobile = '" + smob + "', std_DoB = '" + dob + "', std_Nationality = '" + nationatity + "', std_Address = '" + saddress + "', std_ParentSSN = '" + pssn + "', second_language = '" + seclan + "' where std_ID = '" + sid + "';"

             + "update Grad_Student set gstd_University = '" + university + "' where std_ID = '" + sid + "';"

             + "update Parent set p_SSN = '" + pssn + "', p_Name = '" + pname + "', p_Address = '" + paddress + "', p_Mobile = '" + pmob + "', p_Email = '" + pemail + "' where p_SSN in ((select std_ParentSSN from Student where std_ID = '" + sid + "' ));";
            return dbMan.ExecuteNonQuery(query);
          }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }

    }

