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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            + "values('" + sid + "','" + sname + "','" + sssn + "','" + semail + "','" + smob + "','" + dob + "','" + nationatity + "','" + saddress + "','" + pssn + "','" + sid+ "','0000','" + seclan + "');"
            + "insert into Current_Student(std_ID, std_Year) values('" + sid + "'," + syear + ");";
            return dbMan.ExecuteNonQuery(query);
        }

        public int Insert_DEFAULT_ENROLLMENT(string sub_ID, string std_ID)
        {
            string query = "Insert into Enrollment Values('" + std_ID + "','" + sub_ID + "','U',0)";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getSubjectsInYear(int year)
        {
            string query = "SELECT sub_ID ,sub_Dep_Name from Subject Where sub_year = " + year;
            return dbMan.ExecuteReader(query);
        }

        public string getSecondNot(string std_ID)
        {
            string query = "SELECT second_language from Student where std_ID=" + std_ID;
            string lang = (string)dbMan.ExecuteScalar(query);
            if (lang == "German") return "French";
            return "German";
        }
        public DataTable getStudentsinYear(int year)
        {
            string query = "SELECT std_ID From Current_Student Where std_Year=" + year +";";
            return dbMan.ExecuteReader(query);
        }

        public int DeleteCurrent(string std_ID)
        {
            string query = "Delete From Current_Student Where std_ID=" + std_ID;
            return dbMan.ExecuteNonQuery(query);
        }
        public int AddGraduate(string std_ID, string uni = "")
        {
            string query;
            if (uni == "")
            {
                query = "INSERT INTO Grad_Student VALUES('" + std_ID + "', NULL )";
            }
            else
            {
                query = "INSERT INTO Grad_Student VALUES('" + std_ID + "','" + uni + "')";
            }
            return dbMan.ExecuteNonQuery(query);
        }
        public bool GraduateCurrentStudent(string std_ID, string uni = "")
        {
            return (DeleteCurrent(std_ID) !=0) && (AddGraduate(std_ID, uni) != 0);
        }

        public int UpdateYear(string std_ID, int year)
        {
            if (year >= 13) return 0;
            string query = "Update Current_Student set std_Year=" + year + " Where std_ID=" + std_ID;
            return dbMan.ExecuteNonQuery(query);
        }

        public int MoveStudentYear(string std_ID, int year)
        {
            DataTable subjects = getSubjectsInYear(year);
            //next year
            if (UpdateYear(std_ID, year) ==0) return 0;
            //student updated in current student
            for (int i = 0; i < subjects.Rows.Count; i++)
            {
                //skip german if takes french and vice versa
                if (subjects.Rows[i][1].ToString() == getSecondNot(std_ID)) continue;
                //enroll subject
                if (Insert_DEFAULT_ENROLLMENT(subjects.Rows[i][0].ToString(), std_ID) == 0) return 0;
            }
            return 1;
        }
            

            public int UpdateCurrentStudent(string pssn, string pname, string paddress, string pmob, string pemail, string sid, string sname, string sssn, string semail, string smob, string dob, string nationatity, string saddress, string seclan, int syear, bool payedtuition)
        {
            string query = "update Student set std_Name = '" + sname + "', std_SSN = '" + sssn + "', std_Email = '" + semail + "', std_Mobile = '" + smob + "', std_DoB = '" + dob + "', std_Nationality = '" + nationatity + "', std_Address = '" + saddress + "', std_ParentSSN = '" + pssn + "', second_language = '" + seclan + "' where std_ID = '" + sid + "';"
             + "update Current_Student set std_Year = " + syear + ", pay_tuition = '" + payedtuition + "' where std_ID = '" + sid + "';"
             + "update Parent set p_SSN = '" + pssn + "', p_Name = '" + pname + "', p_Address = '" + paddress + "', p_Mobile = '" + pmob + "', p_Email = '" + pemail + "' where p_SSN in ((select std_ParentSSN from Student where std_ID = '" + sid + "' ));";
            return dbMan.ExecuteNonQuery(query);
        }

        //public DataTable getDepartmentslist()
       // {
          //  string query = "select dep_Name,dep_ID from Department;";
           // return dbMan.ExecuteReader(query);
      //  }


      //  public DataTable getteachersOfDepartment(string depID)
       // {
        //    string query = "select t.staff_ID,s.staff_Name,s.staff_Email,s.staff_Mobile from Staff as s,Teacher as t where s.staff_LevelAuth=5 and s.staff_ID=t.staff_ID and t.tDep_ID= '" + depID + "';";
        //    return dbMan.ExecuteReader(query);
      //  }


        public int deleteTeacher(string teachID)
        {
            string query = "delete Teacher where staff_ID='" + teachID + "';"
                + "delete Staff where staff_ID='" + teachID + "';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getAllTeachers()
        {
            string query = "select s.staff_Name,t.staff_ID from Teacher as t,Staff as s where s.staff_ID=t.staff_ID ;";
            return dbMan.ExecuteReader(query);
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

     //   public DataTable getTeacherData(string TeachersID)
      // {
        //   string query = "select s.staff_Name,s.staff_ID,s.staff_Email,s.staff_SSN,s.staff_Address,s.staff_Mobile,s.staff_Salary,s.Full_Time,d.dep_Name from Staff as s,Teacher as t,Department as d where t.staff_ID=s.staff_ID and t.tDep_ID=d.dep_ID and t.staff_ID = " + TeachersID + ";";
         //  return dbMan.ExecuteReader(query);
        //}


     //   public DataTable getStaffPostionslist()
      //  {
          //  string query = "select distinct staff_Position,staff_LevelAuth from Staff;";
           // return dbMan.ExecuteReader(query);
       // }

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


        // public int deleteStaff(string staffID)
        // {
        //    string query = "delete Staff where staff_ID='" + staffID + "';";
        //   return dbMan.ExecuteNonQuery(query);
        // }

          public DataTable getStaffData(string staffID)
          {
              string StoredProcedureName = StoredProcedures.getStaffData;
              Dictionary<string, object> Parameters = new Dictionary<string, object>();
              Parameters.Add("@staffID",staffID); 
              return dbMan.ExecuteReader(StoredProcedureName, Parameters);
         }

      // public DataTable getInboxOf(string SSN)
     //  {
       //     string StoredProcedureName = StoredProcedures.getInboxOf;
        //   Dictionary<string, object> Parameters = new Dictionary<string, object>();
        //   Parameters.Add("@staff_SSN", SSN);
         //   return dbMan.ExecuteReader(StoredProcedureName, Parameters);
    //  }



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

       // public DataTable getStaffData(string staffID)
       // {
        //    string query = "select staff_Name,staff_ID,staff_Email,staff_SSN,staff_Address,staff_Mobile,staff_Salary,Full_Time,staff_Position from Staff where staff_ID = " + staffID + " ;";
        //    return dbMan.ExecuteReader(query);
       // }


        public DataTable getAllsubjectsOfDep(string depID)
        {
            string query = "Select s.sub_ID,sub_Name,day,Start_time,End_time,r_Building_Num,r_Floor,r_Num From Subject_Time_Loc as stl,Subject as s,Department as d Where dep_ID='"+depID+"' and dep_Name=sub_Dep_Name and stl.sub_ID = s.sub_ID Order by sub_Name";
            return dbMan.ExecuteReader(query);
        }


        public DataTable getSubjectsOfDepAndYear(string depID, int year)
        {
            string query = "Select s.sub_ID,sub_Name,day,Start_time,End_time,r_Building_Num,r_Floor,r_Num From Subject_Time_Loc as stl,Subject as s,Department as d Where dep_ID='" + depID + "' and dep_Name=sub_Dep_Name and stl.sub_ID = s.sub_ID and sub_Year = "+year+" Order by sub_Name";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getSubjectsOfYear(int year)
        {
            string query = "select sub_ID,sub_Name from subject where sub_year = "+year+";";
            return dbMan.ExecuteReader(query);
        }

        public int getGradeCount(string subID, string grade)
        {
            string query = "select count(grade) from enrollment where sub_ID = '"+subID+"' and grade = '"+grade+"' ;";
            return (int)dbMan.ExecuteScalar(query);
        }
     
        public int getPassCount(string subID)
        {
            string query = "select count(grade) from enrollment where sub_ID = '"+subID+"' and not grade  = 'F';";
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
        public int DeleteReq(string reqID)
        {
            string query = "delete from Request where Request_ID = '"+reqID+"';";
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
          string query = "select Request_ID,date,staff_Email,title,request from Request as r,Staff as s where s.staff_SSN = r.sender and r.receiver='" + SSN + "';";
           return dbMan.ExecuteReader(query);
        }
        public DataTable getPendingInboxOf(string SSN)
        {
            string query = "select Request_ID,date,staff_Email,title,request from Request as r,Staff as s where s.staff_SSN=r.sender and r.receiver='" + SSN + "' and state = -1;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getSentOf(string SSN)
        {
            string query = "select Request_ID,date,staff_Email,title,request from Request as r,Staff as s where s.staff_SSN=r.receiver and r.sender='" + SSN + "';";
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
            string query = "select s.sub_Name,st.sub_ID,s.sub_Year,st.r_Num,st.day,st.Start_Time,st.End_Time,d.dep_Name,d.dep_ID,sf.staff_Name,t.staff_ID,st.r_Building_Num,st.r_Floor " +
                "from Subject_Time_Loc as st,Subject as s,Department as d,Teacher as t,Staff as sf " +
                "where sf.staff_ID=t.staff_ID and t.tDep_ID=d.dep_ID and st.t_ID=t.staff_ID and s.sub_ID=st.sub_ID and st.sub_ID='" + subjID + "' and st.r_Num=" + roomID + " and st.day='" + Day + "' and st.Start_Time='" + Time + "';;";
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
       
      //  public int deleteStudentfromBus(string stdID)
       //{
         //   string query = "update Current_Student set bus_Num=null where std_ID='"+ stdID + "';";
         //   return dbMan.ExecuteNonQuery(query);
      //  }
        public int AddStudentToBus(string stdID,int busNum)
        {
            string query = "update Current_Student set bus_Num="+busNum+" where std_ID='"+stdID+"';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int getRoomsCount()
        {
            string query = "select count(r_Num) from Room;";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int UpdateBus(int busNum,int busCap,string busDriverID, string route)
        {
            string query = "update Bus set bus_Driver_ID='"+busDriverID+"',bus_Capacity="+busCap+",bus_Route='"+route+"'where bus_Num="+busNum+";";
            return dbMan.ExecuteNonQuery(query);
        }
        public int getBusesCount()
        {
            string query = "select COUNT(bus_Num) from Bus;";
            return (int)dbMan.ExecuteScalar(query);
        }
        // public int AddBus(int busNum, int busCap, string busDriverID, string route)
        // {
        //   string query = "insert into Bus (bus_Num,bus_Driver_ID,bus_Capacity,bus_Route) values ("+busNum+",'"+busDriverID+"',"+busCap+",'"+route+"');";
        //  return dbMan.ExecuteNonQuery(query);
        // }



        public DataTable getEmailFromSSN(string SSN)
        {
            string StoredProcedureName = StoredProcedures.getEmailFromSSN;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@staff_SSN", SSN);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public DataTable getAllDrivers()
        {
            string query = "select staff_Name,staff_ID from Staff where staff_LevelAuth=4;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getBusData(int BusNum)
        {
            string query = "select b.bus_Num,b.bus_Capacity,s.staff_Name,b.bus_Route,b.bus_Driver_ID from Bus as b,Staff as s where s.staff_ID=b.bus_Driver_ID and bus_Num=" + BusNum+";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getBuildingList()
        {
            string query = "select distinct r_Building_Num from Subject_Time_Loc;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getFloorsList()
        {
            string query = "select distinct r_Floor from Subject_Time_Loc;";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getBusesOfRoute(string route)
        {
            string query = "select b.bus_Num, s.staff_Name, b.bus_Capacity,b.bus_Route from Bus as b,Staff as s where s.staff_ID=b.bus_Driver_ID and b.bus_Route='" + route+"';";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getStudentsInBus(int BusNum)
        {
            string query = "select Student.std_ID,std_Name,std_Email,std_Year from Student,Current_Student where Current_Student.std_ID = Student.std_ID and bus_Num = " + BusNum + ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getStudentsNotInBus(int BusNum)
        {
            string query = "SELECT Student.std_ID,Student.std_Name,Student.std_Email,std_Year\r\nFROM Student,Current_Student\r\nWhere Student.std_ID = Current_Student.std_ID\r\nExcept\r\n(SELECT Student.std_ID,Student.std_Name,Student.std_Email,std_Year\r\nFROM Current_Student,Student\r\nWhere bus_Num="+BusNum+" and Student.std_ID=Current_Student.std_ID)";
            return dbMan.ExecuteReader(query);
        }

        public DataTable getAllBuses()
        {
            string query = "select b.bus_Num, s.staff_Name, b.bus_Capacity,b.bus_Route from Bus as b,Staff as s where s.staff_ID=b.bus_Driver_ID;";
            return dbMan.ExecuteReader(query);
        }

        public int deleteBus(int busNum)
        {
            string query = "delete from Bus where bus_Num="+busNum+";";
            return dbMan.ExecuteNonQuery(query);
        }

        public int deleteSubject(string teacherID,string subjID,string subDepName,int roomBuildingNum, int roomFloor,int roomNum,string startTime, string endTime, string day,int subjYear ,string subjName)
        {
            string query = "delete Teach where t_ID='"+ teacherID + "' and sub_ID='"+ subjID + "' and sub_Dep_Name='"+ subDepName + "';"+
            "delete Subject_Time_Loc where t_ID = '"+ teacherID + "' and r_Building_Num = "+ roomBuildingNum + " and r_Floor = "+roomFloor+" and r_Num = "+roomNum+ " and sub_ID = '" + subjID + "' and sub_Dep_Name = '"+ subDepName + "' and Start_Time = '"+startTime+"' and End_Time = '"+endTime+"' and day = '"+day+"';"
         +  " delete Subject where sub_ID = '"+ subjID + "' and sub_Dep_Name = '"+ subDepName + "' and sub_Name = '"+ subjName + "' and sub_Year = "+subjYear+"; ";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable viewAllTeachers(int BusNum)
        {
            string query = ";";
            return dbMan.ExecuteReader(query);
        }

        public DataTable viewBusInfo(int BusNum)
        {
            string query = "select s.staff_Name,b.bus_Driver_ID,b.bus_Num,b.bus_Capacity,b.bus_Route from Bus as b,Staff as s where s.staff_ID=b.bus_Driver_ID and b.bus_Num="+BusNum+";";
            return dbMan.ExecuteReader(query);
        }

        //w2fna 3nd 14 msh m3mola
        public DataTable getBusRoutes()
        {
            string query = "select distinct bus_Route from Bus;";
            return dbMan.ExecuteReader(query);
        }

        public int Respond(string SenderSSN, string reciverSSN, string ReqTitle, string ReqMessage, int status, string request_ID)
        {
            string Date = "GETDATE()";
            string query = "insert into Request(sender,receiver,title,request,state,Date) values ('" + SenderSSN + "','" + reciverSSN + "','" + ReqTitle + "','" + ReqMessage + "'," + status + "," + Date + ");" +
                "Update Request set state = " + status + " where  request_ID = " + request_ID ;
            return dbMan.ExecuteNonQuery(query);
        }

       // public DataTable getEmailFromSSN(string SSN)
       // {
        //    string query = "select staff_Email from Staff where staff_SSN ='" + SSN+"';";
         //   return dbMan.ExecuteReader(query);
       // }
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

        public int checkTimeAndLocation(int rNum, string startT,string endT , string Day )
        {
            string query = "select count(day) from Subject_Time_Loc where r_Num="+rNum+" and Start_Time='"+startT+"' and End_Time='"+endT+"' and day='"+Day+"';";
            return (int)dbMan.ExecuteScalar(query);
        }

        public int getSubjectsCount()
        {
            string query = "select count(sub_ID) from Subject;";
            return (int)dbMan.ExecuteScalar(query);
        }
        public int getDepartmentsCount()
        {
            string query = "select COUNT(dep_ID) from Department;";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable getTeachersNotHeads()
        {
            string query = "select s.staff_Name,t.staff_ID from Department as d,Teacher as t,Staff as s where s.staff_ID=t.staff_ID and t.tDep_ID=d.dep_ID and not exists (select d.dep_Head_ID from Department where d.dep_Head_ID=s.staff_ID);";
            return dbMan.ExecuteReader(query);
        }

       // public int AddDepartment(string depID,string depName,string headID)
       // {
       //     string query = "insert into Department (dep_ID,dep_Name,dep_Head_ID) values ('"+depID+"','"+depName+"','"+headID+"');";
        //    return dbMan.ExecuteNonQuery(query);
       // }

        public int UpdateDepartment(string depID, string depName, string headID)
        {
            string query = "update Department set dep_Name='"+depName+"',dep_Head_ID='"+ headID + "' where dep_ID='"+depID+"';";
            return dbMan.ExecuteNonQuery(query);
        }
        public int deleteDepartment(string depID)
        {
            string query = "delete Department where dep_ID='"+depID+"';";
            return dbMan.ExecuteNonQuery(query);
        }

        public DataTable getDepartmentsData()
        {
            string query = "select d.dep_ID,d.dep_Name,s.staff_Name,s.staff_ID from Department as d,Staff as s where d.dep_Head_ID=s.staff_ID;";
            return dbMan.ExecuteReader(query);
        }
        public DataTable getDepartmentData(string depID)
        {
            string query = "select d.dep_ID,d.dep_Name,s.staff_Name,s.staff_ID from Department as d,Staff as s where d.dep_Head_ID=s.staff_ID and d.dep_ID ='"+depID+"';";
            return dbMan.ExecuteReader(query);
        }
        public int AddRoom(int BuildingNum, int RFloor,int RNum,int RCap,bool HasProjector)
        {
            string query = "insert into Room(r_Building_Num,r_Floor,r_Num,r_Capacity,r_Projector) values ("+ BuildingNum + ","+ RFloor + ","+ RNum + ","+ RCap + ",'"+ HasProjector + "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int AddSubject(string subID,string subDepName,string subName,int subYear,string teacherID, int roomBuildingNum,int roomFloor, int roomNum,string startTime,string endTime,string day)
        {
            string query = "insert into Subject(sub_ID,sub_Dep_Name,sub_Name,sub_Year) " +
                "values ('"+subID+"','"+subDepName+ "','"+ subName + "',"+subYear+");" +
                " insert into Subject_Time_Loc(t_ID,r_Building_Num,r_Floor,r_Num,sub_ID,sub_Dep_Name,Start_Time,End_Time,day) values ('"+ teacherID + "',"+roomBuildingNum+","+ roomFloor + ","+roomNum+",'" + subID + "','" + subDepName+ "','"+startTime+"','"+endTime+"','"+day+"');" +
                "insert into Teach(t_ID,sub_ID,sub_Dep_Name) values ('"+ teacherID + "','" + subID + "','" + subDepName+ "');";
            return dbMan.ExecuteNonQuery(query);
        }

        public int UpdateSubject(string subID, string subName, string subDepName, int subYear, string teacherID, int oldRoomBuildingNum, int roomBuildingNum, int oldRoomFloor, int roomFloor, int oldRoomNum, int roomNum, string oldStartTime, string startTime, string oldEndTime, string endTime, string oldDay, string day)
        {
            string query = "update Subject set sub_Name='"+subName+"' where sub_ID='"+subID+"' and sub_Year="+subYear+";" +
                "update Subject_Time_Loc set t_ID='"+teacherID+"',Start_Time='"+startTime+"',End_Time='"+endTime+"',day='"+day+"',r_Building_Num="+roomBuildingNum+",r_Floor="+roomFloor+",r_Num="+roomNum+" where r_Num="+oldRoomNum+" and sub_ID='"+subID+"' and sub_Dep_Name='"+ subDepName + "' and Start_Time='"+oldStartTime+"' and End_Time='"+oldEndTime+"' and day='"+oldDay+"';" +
                "update Teach set t_ID='"+teacherID+"' where sub_ID='"+subID+"';";
            return dbMan.ExecuteNonQuery(query);
        }

        public int checkSubjectTeacher(string teacherID,string startTime,string endTime,string Day)
        {
            string query = "select count(t_ID) from Subject_Time_Loc where t_ID='"+ teacherID + "' and Start_Time='"+ startTime + "' and End_Time='"+ endTime + "' and day='"+ Day + "';";
            return (int)dbMan.ExecuteScalar(query);
        }

        public DataTable getDepartmentslist()
        {
            string StoredProcedureName = StoredProcedures.getDepartmentslist;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

        public int AddDepartment(string depID, string depName, string headID)
        {
            string StoredProcedureName = StoredProcedures.AddDepartment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@dep_ID", depID);
            Parameters.Add("@dep_Name", depName);
            Parameters.Add("@dep_Head_ID", headID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable getTeacherData(string TeachersID)
        {
            string StoredProcedureName = StoredProcedures.getTeacherData;
          Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@staff_ID", TeachersID);
          return dbMan.ExecuteReader(StoredProcedureName, Parameters);
       }

        public DataTable getStaffPostionslist()
        {
            string StoredProcedureName = StoredProcedures.getStaffPostionslist;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

        public int deleteStaff(string staffID)
        {
            string StoredProcedureName = StoredProcedures.deleteStaff;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@staffID", staffID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }
        public int deleteStudentfromBus(string stdID)
        {
            string StoredProcedureName = StoredProcedures.deleteStudentfromBus;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@std_ID", stdID);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public int AddBus(int busNum, int busCap, string busDriverID, string route)
        {
            string StoredProcedureName = StoredProcedures.AddBus;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@bus_Num", busNum);
            Parameters.Add("@bus_Driver_ID", busCap);
            Parameters.Add("@bus_Capacity", busDriverID);
            Parameters.Add("@bus_Route", route);
            return dbMan.ExecuteNonQuery(StoredProcedureName, Parameters);
        }

        public DataTable getteachersOfDepartment(string depID)
        {
            string StoredProcedureName = StoredProcedures.getteachersOfDepartment;
            Dictionary<string, object> Parameters = new Dictionary<string, object>();
            Parameters.Add("@dep_ID", depID);
            return dbMan.ExecuteReader(StoredProcedureName, Parameters);
        }

    }

}

