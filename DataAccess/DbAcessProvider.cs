using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbAcessProvider
    {
        private readonly string _strcnn = "";
        private readonly string _strcnnHome = "";

        public DbAcessProvider()
        {
            _strcnn = ConfigurationManager.ConnectionStrings["ConnectionTest"].ConnectionString;
            _strcnnHome = ConfigurationManager.ConnectionStrings["ConnectionHome"].ConnectionString;
        }

        public DataTable ExecuteCommandHome(string strCommand)
        {
            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = _strcnnHome;
                    connection.Open();
                    using (SqlCommand sqlCmd = connection.CreateCommand())
                    {
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = strCommand;

                        using (var sda = new SqlDataAdapter(sqlCmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExecuteCommand(string strCommand)
        {
            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = _strcnn;
                    connection.Open();
                    using (SqlCommand sqlCmd = connection.CreateCommand())
                    {
                        sqlCmd.CommandType = CommandType.Text;
                        sqlCmd.CommandText = strCommand;

                        using (var sda = new SqlDataAdapter(sqlCmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExcuteStore(string storeName, SqlParameter[] param)
        {
            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = _strcnn;
                    connection.Open();
                    using (SqlCommand sqlCmd = connection.CreateCommand())
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = storeName;
                        sqlCmd.Parameters.AddRange(param);

                        using (var sda = new SqlDataAdapter(sqlCmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ExcuteStore(string storeName, SqlParameter[] param, ref int total)
        {
            try
            {
                using (var connection = new SqlConnection())
                {
                    connection.ConnectionString = _strcnn;
                    connection.Open();
                    using (SqlCommand sqlCmd = connection.CreateCommand())
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlCmd.CommandText = storeName;
                        sqlCmd.Parameters.AddRange(param);

                        using (var sda = new SqlDataAdapter(sqlCmd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            total = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
                            return ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool ConnectionTest(string strCon)
        {
            SqlConnection Conn;
            Conn = new SqlConnection(strCon);
            try
            {
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }
    }
}
