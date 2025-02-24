using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Assignment.DataGateway
{
    // This class and its subclasses implement the Table Data Gateway 
    // and Template Method design patterns
    public abstract class DatabaseUpdater<T> : IUpdater<T>
    {

        // This method is a Template Method
        public int Update(T itemToUpdate)
        {
            int numRowsUpdated = 0;
            DatabaseConnectionPool connectionPool = DatabaseConnectionPool.GetInstance();
            MySqlConnection conn = connectionPool.AcquireConnection();

            MySqlCommand command = new MySqlCommand
            {
                Connection = conn,
                CommandText = GetSQL(),
                CommandType = CommandType.Text
            };

            try
            {
                numRowsUpdated = DoUpdate(command, itemToUpdate);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            connectionPool.ReleaseConnection(conn);
            return numRowsUpdated;
        }

        protected abstract int DoUpdate(MySqlCommand command, T itemToUpdate);
        protected abstract string GetSQL();
    }
}