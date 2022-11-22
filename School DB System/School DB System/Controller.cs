using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void TerminateConnection()
        {
            dbMan.CloseConnection();
        }

    }
}
