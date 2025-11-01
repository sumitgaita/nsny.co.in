using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace rg.framework.Data
{
    public class Factory
    {
        IDbConnection con;
        public Factory()
        {

            con = (IDbConnection)new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }

        public IDbConnection GetConnection()
        {
            return con;
        }

        public IDbConnection GetConnection(string connectionString)
        {
            con = (IDbConnection)new SqlConnection(connectionString);
            return con;
        }

        public IDbCommand GetCommand()
        {
            return (IDbCommand)new SqlCommand();
        }

        public IDbCommand GetCommand(string CommandText)
        {
            return (IDbCommand)new SqlCommand(CommandText);
        }

        public IDbCommand GetCommand(string CommandText, IDbConnection con)
        {
            SqlConnection connection = (SqlConnection)con;
            return (IDbCommand)new SqlCommand(CommandText, connection);
        }

        public IDbCommand GetCommand(string CommandText, IDbConnection con, IDbTransaction trans)
        {
            SqlConnection connection = (SqlConnection)con;
            SqlTransaction transaction = (SqlTransaction)trans;
            return (IDbCommand)new SqlCommand(CommandText, connection, transaction);
        }

        public IDbDataParameter GetParameter()
        {
            return (IDbDataParameter)new SqlParameter();
        }

        public IDbDataParameter GetParameter(ParameterDirection direction)
        {
            IDbDataParameter par = (IDbDataParameter)new SqlParameter();
            par.Direction = direction;
            return par;
        }

        public IDbDataParameter GetParameter(string ParameterName, object Value)
        {
            return (IDbDataParameter)new SqlParameter(ParameterName, Value);
        }

        public IDbDataParameter GetParameter(string ParameterName, object Value, ParameterDirection direction)
        {
            IDbDataParameter par = (IDbDataParameter)new SqlParameter(ParameterName, Value);
            par.Direction = direction;
            return par;
        }

        public IDbDataParameter GetParameter(string ParameterName, SqlDbType ParameterType)
        {
            return (IDbDataParameter)new SqlParameter(ParameterName, ParameterType);
        }

        public IDbDataParameter GetParameter(string ParameterName, SqlDbType ParameterType, ParameterDirection direction)
        {
            IDbDataParameter par = (IDbDataParameter)new SqlParameter(ParameterName, ParameterType);
            par.Direction = direction;
            return par;
        }

        public IDbDataParameter GetParameter(string ParameterName, SqlDbType ParameterType, int size)
        {
            return (IDbDataParameter)new SqlParameter(ParameterName, ParameterType, size);
        }

        public IDbDataParameter GetParameter(string ParameterName, SqlDbType ParameterType, int size, ParameterDirection direction)
        {
            IDbDataParameter par = (IDbDataParameter)new SqlParameter(ParameterName, ParameterType, size);
            par.Direction = direction;
            return par;
        }

        public IDbDataParameter GetParameter(string ParameterName, SqlDbType ParameterType, int size, string SourceColumn)
        {
            return (IDbDataParameter)new SqlParameter(ParameterName, ParameterType, size, SourceColumn);
        }

        public IDbDataParameter GetParameter(string ParameterName, SqlDbType ParameterType, int size, string SourceColumn, ParameterDirection direction)
        {
            IDbDataParameter par = (IDbDataParameter)new SqlParameter(ParameterName, ParameterType, size, SourceColumn);
            par.Direction = direction;
            return par;
        }

        public IDataAdapter GetAdapter()
        {
            return (IDataAdapter)new SqlDataAdapter();
        }

        public IDataAdapter GetAdapter(IDbCommand cmd)
        {
            SqlCommand command = (SqlCommand)cmd;
            return (IDataAdapter)new SqlDataAdapter(command);
        }

        public IDataAdapter GetAdapter(string query, IDbConnection con)
        {
            SqlConnection connection = (SqlConnection)con;
            return (IDataAdapter)new SqlDataAdapter(query, connection);
        }

    }
}
