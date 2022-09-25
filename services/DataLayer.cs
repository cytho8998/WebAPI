namespace WebAPI.services
{
    using System.Data;
    using System.Data.SqlClient;

    public class DataLayer
    {
        private string _connectionString = "";
        private int _timeout = 30;
        public DataLayer(string connectionString)
        {
            _connectionString = connectionString;
            
        }

        public SqlConnection connectToDB()
        {
            try
            {
                SqlConnection cn = new SqlConnection();

                cn.ConnectionString = _connectionString;

                cn.Open();
                if (cn.State == ConnectionState.Open)
                {
                    return cn;
                }
                else
                {
                    throw (new Exception("Unable to open " + _connectionString));
                }
            }
            catch (System.Exception ex)
            {
                throw (new Exception("Connection err:" + ex.Message));
            }
        }

        public DataTable GetDataTable(SqlConnection cn, string sql)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn = connectToDB();
                }
                //SqlCommand cmd=new SqlCommand(sql,cn);
                SqlDataAdapter da = new SqlDataAdapter(sql, cn);
                DataTable dt = new DataTable();
                da.SelectCommand.CommandTimeout = _timeout;// 180; //20090831
                da.Fill(dt);

                da.SelectCommand.Dispose();
                da.Dispose();

                return dt;

            }

            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteNonQuery(SqlConnection cn, string sql)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn = connectToDB();
                }
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandTimeout = _timeout;// 180;
                return cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                throw;
            }
        }

        public int ExecuteNonQuery(SqlConnection cn, string sql, SqlTransaction tran)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn = connectToDB();
                }
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandTimeout = _timeout;// 180;
                cmd.Transaction = tran;
                return cmd.ExecuteNonQuery();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public object ExecuteScalar(SqlConnection cn, string sql)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn = connectToDB();
                }
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandTimeout = _timeout;// 180;
                return cmd.ExecuteScalar();

            }

            catch (Exception)
            {
                throw;
            }
        }

        public object ExecuteScalar(SqlConnection cn, string sql, SqlTransaction tran)
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn = connectToDB();
                }
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandTimeout = _timeout;// 180;
                cmd.Transaction = tran;
                return cmd.ExecuteScalar();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public long ExecuteScalarGetIndentity(SqlConnection cn, string sql, SqlTransaction tran)
        {

            long recID = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandTimeout = _timeout;// 180;
                cmd.Transaction = tran;
                //20151208 if (cmd.ExecuteNonQuery() == 1)
                int recAff = cmd.ExecuteNonQuery();
                if (recAff >= 1)
                {
                    recID = Convert.ToInt32( ExecuteScalar(cn, "Select @@IDENTITY ", tran));
                }
                return recID;
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
