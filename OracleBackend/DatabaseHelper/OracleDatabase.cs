using Microsoft.AspNetCore.Hosting.Server;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace OracleBackend.DatabaseHelper
{
    public class OracleDatabase
    {
        static string strConexion = "user id=CWEB;password=Oracle123;data source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)" +
                          "(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)))";

        public static void InsertPerson(string firstName, string lastName)
        {
            List<OracleParameter> param = new List<OracleParameter>() {
                new OracleParameter("@first_name", firstName),
                new OracleParameter("@last_name", lastName)
            };

            ExecStoreProcedure("CWEB.PckgPersons.InsertPerson", param);
        }

        public static void DeletePerson(int personid)
        {
            List<OracleParameter> param = new List<OracleParameter>() {
                new OracleParameter("@firstName", personid)
            };

            ExecStoreProcedure("CWEB.PckgPersons.DeletePerson", param);
        }

        public static void UpdatePerson(string firstName, string lastName, int personid)
        {
            List<OracleParameter> param = new List<OracleParameter>() {
                new OracleParameter("@firstName", firstName),
                new OracleParameter("@lastName", lastName),
                new OracleParameter("@personid", personid)
            };

            ExecStoreProcedure("CWEB.PckgPersons.UpdatePerson", param);
        }

        public static DataTable GetPersons()
        {
            List<OracleParameter> param = new List<OracleParameter>() {
                new OracleParameter("@personsCursor", OracleDbType.RefCursor, ParameterDirection.InputOutput)
            };

            return ExecuteStoreProcedure("CWEB.PckgPersons.GetPersons", param);
        }


        //Para select 
        public static DataTable ExecuteStoreProcedure(string procedure, List<OracleParameter> param)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(strConexion))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (OracleParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ExecStoreProcedure(string procedure, List<OracleParameter> param)
        {
            try
            {
                using (OracleConnection conn = new OracleConnection(strConexion))
                {
                    conn.Open();
                    OracleCommand cmd = new OracleCommand();
                    cmd.CommandText = procedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;

                    if (param != null)
                    {
                        foreach (OracleParameter item in param)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
