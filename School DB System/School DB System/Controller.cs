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
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;

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

        public int Login(string username, string password)
        {
            string query = "select staff_LevelAuth from staff where Username = '" + username + "' and Password = '" + password + "';";
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
        public int getStudentsCountOfYear(int year)
        {
            string query = "select count(std_ID) from Current_Student where std_Year=" + year + ";";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable getStudentsOfYear(int year)
        {
            string query = "select Student.std_ID,std_Name,std_Email,std_Year from Student,Current_Student where Current_Student.std_ID = Student.std_ID and std_Year = " + year + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getCurrentStudentData(string stdID)
        {
            string query = "select s.std_ID,std_Name,std_Mobile,std_SSN,std_Email,P_Mobile,std_DoB,std_Nationality,std_Address,second_language,p_SSN,p_Name,p_Address,p_Mobile,p_Email,std_Year,cs.pay_tuition from Student as s,Parent as p,Current_Student as cs where s.std_ID= '" + stdID + "' and s.std_ParentSSN=p.p_SSN and cs.std_ID = s.std_ID;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getGradStudentData(string stdID)
        {
            string query = "select s.std_ID,std_Name,std_Mobile,std_SSN,std_Email,P_Mobile,std_DoB,std_Nationality,std_Address,second_language,p_SSN,p_Name,p_Address,p_Mobile,p_Email,gstd_University from Student as s,Parent as p,Grad_Student as g where s.std_ID= '" + stdID + "' and s.std_ParentSSN=p.p_SSN and g.std_ID=s.std_ID;";
            return dbMan.ExecuteReader(query);
        }

        public int IsGraduatedStudent(string stdID)
        {
            string query = "select count(std_ID) from Grad_Student where std_ID = '" + stdID + "'";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int getTeachersCount()
        {
            string query = "SELECT count(staff_ID) FROM Teacher;";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getStaffCount()
        {
            string query = "SELECT count(staff_ID) FROM Staff;";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int deleteStudent(string stdID)
        {
            string query = "delete Parent where p_SSN in ((select std_ParentSSN from Student where std_ID='" + stdID + "'));";
            return dbMan.ExecuteNonQuery(query);
        }
        public int AddStudent(string pssn, string pname, string paddress, string pmob, string pemail, string sid, string sname, string sssn, string semail, string smob, string dob, string nationatity, string saddress, string seclan, int syear)
        {
            string query = "insert into Parent(p_SSN, p_Name, p_Address, p_Mobile, p_Email) values(" + pssn + ",'" + pname + "','" + paddress + "'," + pmob + ",'" + pemail + "');"
            + "insert into Student(std_ID, std_Name, std_SSN, std_Email, std_Mobile, std_DoB, std_Nationality, std_Address, std_ParentSSN, Username, Password, second_language)"
            + "values('" + sid + "','" + sname + "','" + sssn + "','" + semail + "','" + smob + "','" + dob + "','" + nationatity + "','" + saddress + "','" + pssn + "','" + sid.ToString() + "','" + sname + "','" + seclan + "');"
            + "insert into Current_Student(std_ID, std_Year) values('" + sid + "'," + syear + ");";
            return dbMan.ExecuteNonQuery(query);
        }
        public int UpdateCurrentStudent(string pssn, string pname, string paddress, string pmob, string pemail, string sid, string sname, string sssn, string semail, string smob, string dob, string nationatity, string saddress, string seclan, int syear, bool payedtuition)
        {
            string query = "update Student set std_Name = '" + sname + "', std_SSN = '" + sssn + "', std_Email = '" + semail + "', std_Mobile = '" + smob + "', std_DoB = '" + dob + "', std_Nationality = '" + nationatity + "', std_Address = '" + saddress + "', std_ParentSSN = '" + pssn + "', second_language = '" + seclan + "' where std_ID = '" + sid + "';"

             + "update Current_Student set std_Year = " + syear + ", pay_tuition = '" + payedtuition + "' where std_ID = '" + sid + "';"

             + "update Parent set p_SSN = '" + pssn + "', p_Name = '" + pname + "', p_Address = '" + paddress + "', p_Mobile = '" + pmob + "', p_Email = '" + pemail + "' where p_SSN in ((select std_ParentSSN from Student where std_ID = '" + sid + "' ));";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getDepartmentslist()
        {
            string query = "select dep_Name,dep_ID from Department;";
            return dbMan.ExecuteReader(query);
        }


        public DataTable getteachersOfDepartment(string depID)
        {
            string query = "select t.staff_ID,s.staff_Name,s.staff_Email,s.staff_Mobile from Staff as s,Teacher as t where s.staff_LevelAuth=5 and s.staff_ID=t.staff_ID and t.tDep_ID= '" + depID + "';";
            return dbMan.ExecuteReader(query);
        }


        public int deleteTeacher(string teachID)
        {
            string query = "delete Teacher where staff_ID='" + teachID + "';"
                + "delete Staff where staff_ID='" + teachID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int AddTeacher(string staffID, string staffName, string staffSSN, Int64 staffSalary, string staffAdress, string staffEmail, string staffMobileNumber, string staffDep, bool fullTime, string username, string password)
        {
            string query = "insert into Staff (staff_ID,staff_Name,staff_SSN,staff_Position,staff_LevelAuth,staff_Salary,staff_Address,staff_Email,staff_Mobile,Full_Time,Username,Password) " +
            "values ('" + staffID + "','" + staffName + "','" + staffSSN + "','teacher'," + 5 + "," + staffSalary + ",'" + staffAdress + "','" + staffEmail + "','" + staffMobileNumber + "','" + fullTime + "','" + staffID + "','" + 0000 + "');"
            + "insert into Teacher(staff_ID,tDep_ID) values ('" + staffID + "','" + staffDep + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateTeacher(string staffID, string staffName, string staffSSN, Int64 staffSalary, string staffAdress, string staffEmail, string staffMobileNumber, int staffDepID, bool fullTime, string username, string password)
        {
            string query = "update Staff " +
            "set staff_Name = '" + staffName + "', staff_SSN = '" + staffSSN + "', staff_Position = 'teacher', staff_LevelAuth = " + 5 + ", staff_Salary = " + staffSalary + ", staff_Address = '" + staffAdress + "', staff_Email = '" + staffEmail + "', staff_Mobile = '" + staffMobileNumber + "', Full_Time = '" + fullTime + "' where staff_ID = '" + staffID + "';" +
            "update Teacher set tDep_ID=" + staffDepID + " where staff_ID='" + staffID + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getTeacherData(string TeachersID)
        {
            string query = "select s.staff_Name,s.staff_ID,s.staff_Email,s.staff_SSN,s.staff_Address,s.staff_Mobile,s.staff_Salary,s.Full_Time,d.dep_Name from Staff as s,Teacher as t,Department as d where t.staff_ID=s.staff_ID and t.tDep_ID=d.dep_ID and t.staff_ID = " + TeachersID + ";";
            return dbMan.ExecuteReader(query);
        }


        public DataTable getStaffPostionslist()
        {
            string query = "select distinct staff_Position,staff_LevelAuth from Staff;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getStaffPostionsFromID(string staffID)
        {
            string query = "select staff_Position from Staff where staff_ID = '" + staffID + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getStaffOfPosition(string staffPosition)
        {
            string query = "select staff_ID, staff_Name, staff_Email, staff_Mobile from Staff where staff_Position = '" + staffPosition + "';";
            return dbMan.ExecuteReader(query);
        }


        public int deleteStaff(string staffID)
        {
            string query = "delete Staff where staff_ID='" + staffID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int AddStaff(string staffID, string staffName, string staffSSN, Int64 staffSalary, string staffAdress, string staffEmail, string staffMobileNumber, string staffDep, bool fullTime, string username, string password, string staffPosition, int staffLvlOfAuth)
        {
            string query = "insert into Staff (staff_ID,staff_Name,staff_SSN,staff_Position,staff_LevelAuth,staff_Salary,staff_Address,staff_Email,staff_Mobile,Full_Time,Username,Password) " +
            "values ('" + staffID + "','" + staffName + "','" + staffSSN + "','" + staffPosition + "'," + staffLvlOfAuth + "," + staffSalary + ",'" + staffAdress + "','" + staffEmail + "','" + staffMobileNumber + "','" + fullTime + "','" + staffID + "','" + 0000 + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateStaff(string staffID, string staffName, string staffSSN, Int64 staffSalary, string staffAdress, string staffEmail, string staffMobileNumber, bool fullTime, string username, string password, string staffPosition, int staffLvlOfAuth)
        {
            string query = "update Staff " +
            "set staff_Name = '" + staffName + "', staff_SSN = '" + staffSSN + "', staff_Position = '" + staffPosition + "', staff_LevelAuth = " + staffLvlOfAuth + ", staff_Salary = " + staffSalary + ", staff_Address = '" + staffAdress + "', staff_Email = '" + staffEmail + "', staff_Mobile = '" + staffMobileNumber + "', Full_Time = '" + fullTime + "' where staff_ID = '" + staffID + "'; ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getStaffData(string staffID)
        {
            string query = "select staff_Name,staff_ID,staff_Email,staff_SSN,staff_Address,staff_Mobile,staff_Salary,Full_Time,staff_Position from Staff where staff_ID = " + staffID + " ;";
            return dbMan.ExecuteReader(query);
        }


        public DataTable getAllsubjectsOfDep(string depID)
        {
            string query = "select s.sub_Num,s.sub_Name,t.day,t.Start_Time,t.End_Time,t.r_Num from Subject as s,Subject_Time_Loc as t,Room as r,Staff as sf,Department as d where s.sub_Num=t.sub_Num and s.sub_Dep_Name=t.sub_Dep_Name and r.r_Building_Num=t.r_Building_Num and r.r_Floor=t.r_Floor and r.r_Num=t.r_Num and t.t_ID=sf.staff_ID and d.dep_Name=t.sub_Dep_Name and d.dep_ID=" + depID + ";";
            return dbMan.ExecuteReader(query);
        }


        public DataTable getSubjectsOfDepAndYear(string depID, int year)
        {
            string query = "select s.sub_Num,s.sub_Name,t.day,t.Start_Time,t.End_Time,t.r_Num from Subject as s,Subject_Time_Loc as t,Room as r,Staff as sf,Department as d where s.sub_Num=t.sub_Num and s.sub_Dep_Name=t.sub_Dep_Name and r.r_Building_Num=t.r_Building_Num and r.r_Floor=t.r_Floor and r.r_Num=t.r_Num and t.t_ID=sf.staff_ID and d.dep_Name=t.sub_Dep_Name and d.dep_ID=" + depID + " and s.sub_Year=" + year + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getSubjectsOfYear(int year)
        {
            string query = "select s.sub_Num,s.sub_Name from Subject as s,Subject_Time_Loc as t,Room as r,Staff as sf,Department as d where s.sub_Num=t.sub_Num and s.sub_Dep_Name=t.sub_Dep_Name and r.r_Building_Num=t.r_Building_Num and r.r_Floor=t.r_Floor and r.r_Num=t.r_Num and t.t_ID=sf.staff_ID and d.dep_Name=t.sub_Dep_Name and s.sub_Year=" + year + ";";
            return dbMan.ExecuteReader(query);
        }

        public int getAGradeCount(int year, int subjNum)
        {
            string query = "select COUNT(e.std_ID) from Enrollment as e,Current_Student as s where s.std_Year=" + year + " and s.std_ID=e.std_ID and e.sub_Num=" + subjNum + " and e.Grade='A';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getBGradeCount(int year, int subjNum)
        {
            string query = "select COUNT(e.std_ID) from Enrollment as e,Current_Student as s where s.std_Year=" + year + " and s.std_ID=e.std_ID and e.sub_Num=" + subjNum + " and e.Grade='B';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getCGradeCount(int year, int subjNum)
        {
            string query = "select COUNT(e.std_ID) from Enrollment as e,Current_Student as s where s.std_Year=" + year + " and s.std_ID=e.std_ID and e.sub_Num=" + subjNum + " and e.Grade='C';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getDGradeCount(int year, int subjNum)
        {
            string query = "select COUNT(e.std_ID) from Enrollment as e,Current_Student as s where s.std_Year=" + year + " and s.std_ID=e.std_ID and e.sub_Num=" + subjNum + " and e.Grade='D';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getFGradeCount(int year, int subjNum)
        {
            string query = "select COUNT(e.std_ID) from Enrollment as e,Current_Student as s where s.std_Year=" + year + " and s.std_ID=e.std_ID and e.sub_Num=" + subjNum + " and e.Grade='F';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getPassCount(int year, int subjNum)
        {
            string query = "select COUNT(e.std_ID) from Enrollment as e,Current_Student as s where s.std_Year=" + year + " and s.std_ID=e.std_ID and e.sub_Num = " + subjNum + " and not e.Grade='F';";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int getTeacherCount(string depID)
        {
            string query = "SELECT count(staff_ID) FROM Teacher WHERE tDep_ID='" + depID + "';";
            return (int)dbMan.ExecuteScalar(query);
        }
        public object getAvgTeacherSalary(string depID)
        {
            string query = "SELECT AVG(staff_Salary) FROM Staff as s,Teacher as t WHERE s.staff_ID=t.staff_ID and s.staff_LevelAuth=5 and t.tDep_ID='" + depID + "';";
            return dbMan.ExecuteScalar(query);
        }

        public object getMinTeacherSalary(string depID)
        {
            string query = "SELECT min(staff_Salary) FROM Staff as s,Teacher as t WHERE s.staff_ID=t.staff_ID and s.staff_LevelAuth=5 and t.tDep_ID='" + depID + "';";
            return dbMan.ExecuteScalar(query);
        }
        public object getMaxTeacherSalary(string depID)
        {
            string query = "SELECT max(staff_Salary) FROM Staff as s,Teacher as t WHERE s.staff_ID=t.staff_ID and s.staff_LevelAuth=5 and t.tDep_ID='" + depID + "';";
            return dbMan.ExecuteScalar(query);
        }
        public object getSTDEVTeacherSalary(string depID)
        {
            string query = "SELECT STDEV(staff_Salary) FROM Staff as s,Teacher as t WHERE s.staff_ID=t.staff_ID and s.staff_LevelAuth=5 and t.tDep_ID='" + depID + "';";
            return dbMan.ExecuteScalar(query);
        }
        public object getStaffAVGSalary()
        {
            string query = "SELECT AVG(staff_Salary) FROM Staff;";
            return dbMan.ExecuteScalar(query);
        }
        public object getStaffMinSalary()
        {
            string query = "SELECT min(staff_Salary) FROM Staff;";
            return dbMan.ExecuteScalar(query);
        }
        public object getStaffMaxSalary()
        {
            string query = "SELECT max(staff_Salary) FROM Staff;";
            return dbMan.ExecuteScalar(query);
        }
        public object getStaffStDevSalary()
        {
            string query = "SELECT stdev(staff_Salary) FROM Staff;";
            return dbMan.ExecuteScalar(query);
        }



        public int UpdateGraduateStudent(string pssn, string pname, string paddress, string pmob, string pemail, string sid, string sname, string sssn, string semail, string smob, string dob, string nationatity, string saddress, string seclan, string university)
        {
            string query = "update Student set std_Name = '" + sname + "', std_SSN = '" + sssn + "', std_Email = '" + semail + "', std_Mobile = '" + smob + "', std_DoB = '" + dob + "', std_Nationality = '" + nationatity + "', std_Address = '" + saddress + "', std_ParentSSN = '" + pssn + "', second_language = '" + seclan + "' where std_ID = '" + sid + "';"

             + "update Grad_Student set gstd_University = '" + university + "' where std_ID = '" + sid + "';"

             + "update Parent set p_SSN = '" + pssn + "', p_Name = '" + pname + "', p_Address = '" + paddress + "', p_Mobile = '" + pmob + "', p_Email = '" + pemail + "' where p_SSN in ((select std_ParentSSN from Student where std_ID = '" + sid + "' ));";
            return dbMan.ExecuteNonQuery(query);
        }
        public int DeleteReq(string sender, string reciver, string title, string message, DateTime date)
        {
            string query = "delete from Request where sender = '" + sender + "' and receiver = '" + reciver + "' and title='" + title + "' and request='" + message + "' and date='" + date + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getEmailOf(string username)
        {
            string query = "select staff_Email from Staff where Username='" + username + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getIDFromUsername(string username)
        {
            string query = "select staff_ID from Staff where Username='" + username + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getSSNFromUsername(string username)
        {
            string query = "select staff_SSN from Staff where Username='" + username + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getInboxOf(string SSN)
        {
            string query = "select date,staff_Email,title,request from Request as r,Staff as s where s.staff_SSN = r.sender and r.receiver='" + SSN + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getPendingInboxOf(string SSN)
        {
            string query = "select date,staff_Email,title,request from Request as r,Staff as s where s.staff_SSN=r.sender and r.receiver='" + SSN + "' and state = -1;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSentOf(string SSN)
        {
            string query = "select date,staff_Email,title,request from Request as r,Staff as s where s.staff_SSN=r.receiver and r.sender='" + SSN + "';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getSSNFromEmail(string email)
        {
            string query = "select staff_SSN from Staff where staff_Email='" + email + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getStdIDFromEmail(string email)
        {
            string query = "select staff_ID from Staff where staff_Email='" + email + "';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSubjectData(string subjID, int roomID, String Day, string Time)
        {
            string query = "select s.sub_Name,st.sub_Num,s.sub_Year,st.r_Num,st.day,st.Start_Time,st.End_Time,d.dep_Name,d.dep_ID,sf.staff_Name,t.staff_ID " +
                "from Subject_Time_Loc as st,Subject as s,Department as d,Teacher as t,Staff as sf " +
                "where sf.staff_ID=t.staff_ID and t.tDep_ID=d.dep_ID and st.t_ID=t.staff_ID and s.sub_Num=st.sub_Num and st.sub_Num=" + subjID + " and st.r_Num=" + roomID + " and st.day='" + Day + "' and st.Start_Time='" + Time + "';;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getRoomData(int roomNum)
        {
            string query = "select * from Room where r_Num=" + roomNum + ";";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getRooms()
        {
            string query = "select r_Num from Room;";
            return dbMan.ExecuteReader(query);
        }
       

        public int Respond(string SenderSSN, string reciverSSN, string ReqTitle, string ReqMessage, int status,string oldTitle,String oldReqMessage)
        {
            string query = "insert into Request(sender,receiver,title,request,state) values ('"+SenderSSN+"','"+reciverSSN+"','"+ReqTitle+"','"+ReqMessage+"',"+status+");"+
                "update Request set state = "+status+" where sender='"+reciverSSN+"' and receiver='"+SenderSSN+"' and title='"+ oldTitle + "' and request='"+ oldReqMessage + "';";
            return dbMan.ExecuteNonQuery(query);
        }
        public DataTable getEmailFromSSN(string SSN)
        {
            string query = "select staff_Email from Staff where staff_SSN='" + SSN+"';";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getStdEmailFromID(string ID)
        {
            string query = "select std_Email from Student where std_ID= '" + ID + "';";
            return dbMan.ExecuteReader(query);
        }
        
        public DataTable getUsernameFromID(string ID)
        {
            
            string query = "select Username from Staff where staff_ID = '"+ID+"';";
            return dbMan.ExecuteReader(query);
        }

        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }

    }

