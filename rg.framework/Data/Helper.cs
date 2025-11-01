using System;
using System.Collections.Generic;
using System.Data;

namespace rg.framework.Data
{
    public class Helpers
    {
        private Factory myFactory;
        public Helpers()
        {
            myFactory = new Factory();
        }

        public DataTable GetDataTable(string query)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            IDataAdapter adapter = myFactory.GetAdapter(query, con);
            DataSet set = new DataSet();
            adapter.Fill(set);
            if (set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public DataTable GetDataTable(string query, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (IDbDataParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            IDataAdapter adapter = myFactory.GetAdapter(cmd);
            DataSet set = new DataSet();
            adapter.Fill(set);
            if (set.Tables.Count > 0)
            {
                return set.Tables[0];
            }
            else
            {
                return new DataTable();
            }
        }

        public DataSet GetDataSet(string query, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (IDbDataParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            IDataAdapter adapter = myFactory.GetAdapter(cmd);
            DataSet set = new DataSet();
            adapter.Fill(set);
            return set;
        }
        public DataTable GetDataTableByReader(string query)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            DataTable dt = new DataTable();
            IDataReader idr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dt.Load(idr);
            return dt;
        }

        public DataTable GetDataTableByReader(string query, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            foreach (IDbDataParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            DataTable dt = new DataTable();

            IDataReader idr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            dt.Load(idr);
            return dt;
        }

        public bool ExecuteDmlQuery(string query, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            foreach (IDbDataParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }
            try
            {
                con.Open();
                return (cmd.ExecuteNonQuery() > 0) ? true : false;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public object GetScalar(string query, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            foreach (IDbDataParameter p in parameters)
            {
                cmd.Parameters.Add(p);
            }

            try
            {
                con.Open();
                return cmd.ExecuteScalar();
            }
            catch
            {
                return false;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public object GetScalar(string query)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(query, con);
            try
            {
                con.Open();
                return cmd.ExecuteScalar();
            }
            catch
            {
                return false;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }

        public bool ExecuteStoredProcedure(string StoredProcedureName, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(StoredProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Count > 0)
            {
                foreach (IDbDataParameter p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            try
            {
                con.Open();
                return (cmd.ExecuteNonQuery() > 0) ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
        public int ReturnStoredProcedure(string StoredProcedureName, ref List<IDbDataParameter> parameters)
        {
            IDbConnection con = myFactory.GetConnection();
            IDbCommand cmd = myFactory.GetCommand(StoredProcedureName, con);
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            if (parameters != null && parameters.Count > 0)
            {
                foreach (IDbDataParameter p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            }
            try
            {
                con.Open();                
                return (cmd.ExecuteNonQuery() > 0) ? 1 : 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }
            }
        }
    }
}
