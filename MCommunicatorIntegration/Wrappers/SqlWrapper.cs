using System;
using System.Data;
using System.Data.SqlClient;
using MCommunicatorIntegration.Interfaces.Wrappers;

namespace MCommunicatorIntegration.Wrappers
{
    public class SqlWrapper : ISqlWrapper
    {
        private readonly string _connectionString;

        private SqlConnection _sqlConnection;
        private readonly SqlCommand _sqlCommand;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public SqlWrapper(string connectionString, string sqlCommandString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
            _sqlCommand = new SqlCommand(sqlCommandString, _sqlConnection);
        }

        public SqlWrapper(string connectionString)
        {
            _connectionString = connectionString;
            _sqlConnection = new SqlConnection(_connectionString);
        }

        public IDbConnection Connection(string connectionString)
        {
            _sqlConnection = new SqlConnection(_connectionString);
            return _sqlConnection;
        }

        public IDbConnection Connection()
        {
            return new SqlConnection(_connectionString);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public IDbCommand Command(string sqlCommand)
        {
            return new SqlCommand(sqlCommand, _sqlConnection);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public IDbCommand Command(string sqlCommand, IDbConnection connection)
        {
            return new SqlCommand(sqlCommand, (SqlConnection)connection);
        }

        public IDbCommand Command()
        {
            return _sqlCommand;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_sqlConnection")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2213:DisposableFieldsShouldBeDisposed", MessageId = "_sqlCommand")]
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _sqlConnection?.Dispose();
                _sqlCommand?.Dispose();
            }
        }
    }
}