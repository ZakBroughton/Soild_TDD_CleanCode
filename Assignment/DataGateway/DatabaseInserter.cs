using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Assignment.DataGateway
{
    // This class and its subclasses implement the Table Data Gateway 
    // and Template Method design patterns
    public abstract class DatabaseInserter<T> : IInserter<T>
    {

        // This method is a Template Method
        public int Insert(T itemToInsert)
        {
            int numRowsInserted = 0;
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
                numRowsInserted = DoInsert(command, itemToInsert);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            connectionPool.ReleaseConnection(conn);
            return numRowsInserted;
        }

        protected abstract int DoInsert(MySqlCommand command, T itemToInsert);
        protected abstract string GetSQL();
    }
}