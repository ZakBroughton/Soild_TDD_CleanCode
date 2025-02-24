using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Assignment.DataGateway
{
    // This class and its subclasses implement the Table Data Gateway 
    // and Template Method design patterns
    public abstract class DatabaseSelector<T> : ISelector<T>
    {

        // This method is a Template Method
        public T Select()
        {
            T item;
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
                item = DoSelect(command);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            connectionPool.ReleaseConnection(conn);
            return item;
        }

        protected abstract T DoSelect(MySqlCommand command);
        protected abstract string GetSQL();
    }
}