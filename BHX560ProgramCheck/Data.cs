using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace BHX560ProgramCheck
{
    class Data
    {
        public DataTable GetPartData()
        {
            DataTable dtPartData = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(Connection.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("SELECT TblJobDPCSV.JobNumber, JobStatus, IssueDate, BarcodeID " +
                                        "FROM TblJobDPCSV WITH(NOLOCK) " +
                                        "INNER JOIN TblClaytonsJobData WITH(NOLOCK) ON TblJobDPCSV.JobNumber = TblClaytonsJobData.JobNumber " +
                                        "WHERE JobStatus IN ('IP', 'D') AND DoorAndPanelHingeDone = 0 AND Point2Point = 'UNIX' " +
                                        "AND UserName = 'Automation'" +
                                        "ORDER BY BarcodeID ASC", con);
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dtPartData);
                }
                if (dtPartData.Rows.Count <= 0)
                    return null;
                else
                    return dtPartData;

            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return null;
            }

        }

    }
}
