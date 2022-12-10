using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace School_DB_System
{
    public class DBManager
    {
        static string DB_Connection_String = @"Data Source=DESKTOP-QQJO3GL\SQLEXPRESS;Initial Catalog=SchoolDBMS;Integrated Security=True";

        SqlConnection myConnection;

        public DBManager()
        {
            myConnection = new SqlConnection(DB_Connection_String);
            try
            {
                myConnection.Open(); //Open a connection with the DB

            }
            catch (Exception e)
            {
                // this message should not appear to user in the final application
                MessageBox.Show("An error occurred while connecting to the database!");
            }
        }

        public int ExecuteNonQuery(string query)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                return myCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // this message should not appear to user in the final application
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public DataTable ExecuteReader(string query)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                SqlDataReader reader = myCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    reader.Close();
                    return dt;
                }
                else
                {
                    reader.Close();
                    return null;
                }
            }
            catch (Exception ex)
            {
                // this message should not appear to user in the final application
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public object ExecuteScalar(string query)
        {
            try
            {
                SqlCommand myCommand = new SqlCommand(query, myConnection);
                return myCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                // this message should not appear to user in the final application
                MessageBox.Show(ex.Message);
                return 0;
            }
        }

        public void CloseConnection()
        {
            try
            {
                myConnection.Close();
            }
            catch (Exception e)
            {
                // this message should not appear to user in the final application
                MessageBox.Show(e.Message);
            }
        }


    }
}
;
