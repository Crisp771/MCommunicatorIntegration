using System;
using System.Data;

namespace MCommunicatorIntegration.Interfaces.Wrappers
{
    public interface ISqlWrapper : IDisposable
    {
        IDbConnection Connection(string connectionString);
        IDbConnection Connection();
        IDbCommand Command(string sqlCommand);
        IDbCommand Command(string sqlCommand, IDbConnection connection);
        IDbCommand Command();
    }
}