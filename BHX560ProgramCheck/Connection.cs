using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Configuration;
using System.IO;

namespace BHX560ProgramCheck
{
    class Connection
    {
        public static String ConnectionString = "";//ConfigurationManager.AppSettings["connectionString"].ToString();
        public static String ServerName = "";
        public static String DatabaseName = "";
        public static String Username = "";
        public static String Password = "";
        public static Boolean isSettingDone = false;
        public static void CheckSettings()
        {
            try
            {
                ServerName = "DBMEL02";
                DatabaseName = "ClaytonsSQL";
                Username = "ManufUser";

                if (!Username.Trim().Equals(""))
                {
                    Password = "*(j8pE+N";
                    ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Persist Security Info=True;User ID=" + Username
                                        + ";Password=" + Password;
                }
                else
                    ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DatabaseName + ";Integrated Security=True";
                isSettingDone = true;

            }
            catch (Exception ex)
            {
                ConnectionString = ""; //ConfigurationManager.AppSettings["connectionString"].ToString();
                isSettingDone = false;
                Debug.Write(ex);
            }
        }

        public static String CheckConnection(String server, String db, String un, String pass)
        {
            String result = "";
            SqlConnection con1 = null;
            try
            {
                if (un.Trim().Equals(""))
                    con1 = new SqlConnection("Data Source=" + server + ";Initial Catalog=" + db + ";Integrated Security=True");
                else
                    con1 = new SqlConnection("Data Source=" + server + ";Initial Catalog=" + db + ";Persist Security Info=True;User ID=" + un + ";Password=" + pass);
                con1.Open();
                con1.Close();
                con1.Dispose();
                con1 = null;
                result = "1";

            }
            catch (Exception ex)
            {
                result = "Error : " + ex.Message.ToString();
            }
            return result;
        }
    }
}
