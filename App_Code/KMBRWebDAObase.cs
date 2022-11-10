using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Configuration;

namespace ClassKMBRWeb
{
    public abstract class KMBRWebDAObase 
    {
        //private static string connectionString = "Data Source=ikmpc212;Initial Catalog=DB_KMBR;Persist Security Info=True;User ID=Sanketham; PWD=Sanketham; timeout=0 ";
        //private static string connectionString = "Data Source=ikmpc212;Initial Catalog=DB_KMBRWeb;Persist Security Info=True;User ID=KMBRWeb; PWD=KMBRWeb; timeout=0 ";
        //private static string connectionString = "Data Source=ikmpc212;Initial Catalog=DB_Finance;Persist Security Info=True;User ID=FAUser; PWD=FAUser";
        private static string connectionString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
        private static string[] ConnectionDBNameKMBR = connectionString.Split(';');
        private static string databaseNameKMBR = ConnectionDBNameKMBR[1].Substring(9);

        private static string connectionStringImagelog = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
        private static string[] ConnectionDBNameKMBRImagelog = connectionStringImagelog.Split(';');
        private static string databaseNameKMBRImagelog = ConnectionDBNameKMBRImagelog[1].Substring(9);


        public static string DatabaseNameKMBR
        {
            get
            {
                return databaseNameKMBR;
            }
            set
            {
                databaseNameKMBR = value;
            }
        }

        public static string DatabaseNameKMBRImagelog
        {
            get
            {
                return databaseNameKMBRImagelog;
            }
            set
            {
                databaseNameKMBRImagelog = value;
            }
        }
        
        public static string ConnectionString
        {
              
            get
            {
                return connectionString;
            }
            set
            {
                connectionString = value;
            }
              
        }

        //private static SqlConnection OpenConnection()
        //{
        //    SqlConnection con = new SqlConnection(connectionString);            
        //    con.Open();
        //    return con;
        //}

        //private static SqlCommand CreateCommand()
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = OpenConnection();
        //    return cmd;
        //}

        //protected int Save(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        //{
        //    int recAffected = 0;
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand sqlCmd = new SqlCommand();
        //    try
        //    {
        //        //sqlCmd = CreateCommand();
        //        con.Open();
        //        sqlCmd.Connection = con;
        //        sqlCmd.CommandText = sqlQuery;
        //        sqlCmd.CommandType = cmdtype;
        //        SqlCommandBuilder.DeriveParameters(sqlCmd);
        //        for (int i = 0; i < arrIN.Count; i++)
        //        {
        //            sqlCmd.Parameters[i + 1].Value = arrIN[i];
        //            string str = arrIN[i] + ",";
        //        }
        //        recAffected = sqlCmd.ExecuteNonQuery();
        //    }
               
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception occured @ save " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCmd.Dispose();
        //        con.Close();
        //    }
        //    return recAffected;
        //}

        //protected void Save(string sqlQuery, CommandType cmdtype, ArrayList arrIN, DataSet ds)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    try
        //    {
        //        //sqlCmd = CreateCommand();
        //        con.Open();
        //        sqlCmd.Connection = con;
        //        sqlCmd.CommandText = sqlQuery;
        //        sqlCmd.CommandType = cmdtype;
        //        SqlCommandBuilder.DeriveParameters(sqlCmd);
        //        for (int i = 0; i < arrIN.Count; i++)
        //        {
        //            sqlCmd.Parameters[i + 1].Value = arrIN[i];
        //        }
        //        da.SelectCommand = sqlCmd;
        //        da.Fill(ds, "Rec");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception occured @ save " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCmd.Dispose();
        //        con.Close();
        //    }
        //}

        //protected void Save(string sqlQuery, CommandType cmdtype, DataSet ds)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    try
        //    {
        //        //sqlCmd = CreateCommand();
        //        con.Open();
        //        sqlCmd.Connection = con;
        //        sqlCmd.CommandText = sqlQuery;
        //        sqlCmd.CommandType = cmdtype;
        //        da.SelectCommand = sqlCmd;
        //        da.Fill(ds, "Rec");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception occured @ save " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCmd.Dispose();
        //        con.Close();
        //    }
        //}

        //protected int Edit(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        //{
        //    int recAffected = 0;
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlCommand sqlCmd = new SqlCommand();
        //    try
        //    {
        //        //sqlCmd = CreateCommand();
        //        con.Open();
        //        sqlCmd.Connection = con;
        //        sqlCmd.CommandText = sqlQuery;
        //        sqlCmd.CommandType = cmdtype;

        //        SqlCommandBuilder.DeriveParameters(sqlCmd);
        //        for (int i = 0; i < arrIN.Count; i++)
        //        {
        //            sqlCmd.Parameters[i + 1].Value = arrIN[i];
        //        }
        //        recAffected = sqlCmd.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception occured @ edit " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCmd.Dispose();
        //        con.Close();
        //    }
        //    return recAffected;
        //}

        //protected DataSet Fetch(string sqlQuery, CommandType cmdtype, ArrayList arrIN)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    ArrayList arrList = new ArrayList();
        //    try
        //    {
        //        //sqlCmd = CreateCommand();
        //        con.Open();
        //        sqlCmd.Connection = con;
        //        sqlCmd.CommandText = sqlQuery;
        //        sqlCmd.CommandType = cmdtype;

        //        SqlCommandBuilder.DeriveParameters(sqlCmd);
        //        for (int i = 0; i < arrIN.Count; i++)
        //        {
        //            sqlCmd.Parameters[i + 1].Value = arrIN[i];
        //        }
        //        da.SelectCommand = sqlCmd;
        //        da.Fill(ds, "Rec");
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception occured @ fetch " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCmd.Dispose();
        //        con.Close();
        //    }
        //}

        //protected DataSet Fetch(string sqlQuery, CommandType cmdtype)
        //{
        //    SqlConnection con = new SqlConnection(connectionString);
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    DataSet ds = new DataSet();
        //    SqlCommand sqlCmd = new SqlCommand();
        //    ArrayList arrList = new ArrayList();
        //    try
        //    {
        //        //sqlCmd = CreateCommand();
        //        //SqlConnection.ClearPool(con);
        //        con.Open();
        //        sqlCmd.Connection = con;
        //        sqlCmd.CommandText = sqlQuery;
        //        sqlCmd.CommandType = cmdtype;

        //        da.SelectCommand = sqlCmd;
        //        da.Fill(ds, "Rec");
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Exception occured @ fetch " + ex.Message);
        //    }
        //    finally
        //    {
        //        sqlCmd.Dispose();
        //        con.Close();
        //        SqlConnection.ClearPool(con);
        //    }
        //}

        //public int insertQuery(string myQuery, string k, byte[] bytes)
        //{
        //    int row = 0;
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        con.Open();
        //        if (con.State == ConnectionState.Open)
        //        {
        //            SqlCommand sqlCmd = new SqlCommand(myQuery, con);
        //            sqlCmd.Parameters.AddWithValue(k, bytes);

        //            try
        //            {
        //                row = sqlCmd.ExecuteNonQuery();
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new Exception("Exception occured @ fetch " + ex.Message);
        //            }
        //            finally
        //            {
        //                sqlCmd.Dispose();
        //                con.Close();
        //                SqlConnection.ClearPool(con);
        //            }
        //        }
        //    }
        //    return row;
        //}

        //New methods added for create connection string 

        protected DataSet FetchNew(string sqlQuery, CommandType cmdtype, ArrayList arrIN, string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            ArrayList arrList = new ArrayList();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;

                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con.Close();
            }
        }

        protected DataSet FetchNew(string sqlQuery, CommandType cmdtype, string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand();
            ArrayList arrList = new ArrayList();
            try
            {
                //sqlCmd = CreateCommand();
                //SqlConnection.ClearPool(con);
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;

                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ fetch " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con.Close();
                SqlConnection.ClearPool(con);
            }
        }

        protected int SaveNew(string sqlQuery, CommandType cmdtype, ArrayList arrIN, string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            int recAffected = 0;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                    string str = arrIN[i] + ",";
                }
                recAffected = sqlCmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con.Close();
            }
            return recAffected;
        }

        protected void SaveNew(string sqlQuery, CommandType cmdtype, ArrayList arrIN, DataSet ds, string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con.Close();
            }
        }

        protected void SaveNew(string sqlQuery, CommandType cmdtype, DataSet ds, string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            SqlConnection con = new SqlConnection(conString);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;
                da.SelectCommand = sqlCmd;
                da.Fill(ds, "Rec");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ save " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con.Close();
            }
        }

        protected int EditNew(string sqlQuery, CommandType cmdtype, ArrayList arrIN, string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            int recAffected = 0;
            SqlConnection con = new SqlConnection(conString);
            SqlCommand sqlCmd = new SqlCommand();
            try
            {
                //sqlCmd = CreateCommand();
                con.Open();
                sqlCmd.Connection = con;
                sqlCmd.CommandText = sqlQuery;
                sqlCmd.CommandType = cmdtype;

                SqlCommandBuilder.DeriveParameters(sqlCmd);
                for (int i = 0; i < arrIN.Count; i++)
                {
                    sqlCmd.Parameters[i + 1].Value = arrIN[i];
                }
                recAffected = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured @ edit " + ex.Message);
            }
            finally
            {
                sqlCmd.Dispose();
                con.Close();
            }
            return recAffected;
        }

        public int insertQueryNew(string myQuery, string k, byte[] bytes,string dbselect)
        {
            string conString = "";
            if (dbselect == "masterdb")
            {
                conString = ConfigurationSettings.AppSettings["connstrMaster"].ToString();
            }
            else if (dbselect == "kmbrweb")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBR"].ToString();
            }
            else if (dbselect == "kmbrimage")
            {
                conString = ConfigurationSettings.AppSettings["connstrKMBRImagelog"].ToString();
            }
            int row = 0;
            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    SqlCommand sqlCmd = new SqlCommand(myQuery, con);
                    sqlCmd.Parameters.AddWithValue(k, bytes);

                    try
                    {
                        row = sqlCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Exception occured @ fetch " + ex.Message);
                    }
                    finally
                    {
                        sqlCmd.Dispose();
                        con.Close();
                        SqlConnection.ClearPool(con);
                    }
                }
            }
            return row;
        }


    }
}
