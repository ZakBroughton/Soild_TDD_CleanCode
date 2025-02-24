using MySqlConnector;
using System;
using System.Data;

namespace Assignment.DataGateway
{
    /* 
    This class, DatabaseGateway, exemplifies adherence to SOLID principles:
    - Single Responsibility Principle (SRP) by managing database interactions.
    - Open/Closed Principle (OCP) through the Template Method pattern for extensibility.
    - Potential adherence to Liskov Substitution Principle (LSP) depending on derived class implementations.
    - Considerations for Dependency Inversion Principle (DIP) by suggesting usage of abstractions for dependencies.
    */


    public abstract class DatabaseGateWay
    {
        private DatabaseConnectionPool connectionPool;

        protected abstract string InsertionSQL { get; }

        public DatabaseGateWay()
        {
            connectionPool = DatabaseConnectionPool.GetInstance();
        }

        protected void CloseMySQLConnection(MySqlConnection conn)
        {
            connectionPool.ReleaseConnection(conn);
        }

        protected MySqlConnection GetMySQLConnection()
        {
            return connectionPool.AcquireConnection();
        }

        // This implements the Template Method design pattern
        public void Insert(Object objectToInsert)
        {
            MySqlConnection conn = GetMySQLConnection();

            MySqlCommand command = new MySqlCommand
            {
                Connection = conn,
                CommandText = InsertionSQL,
                CommandType = CommandType.Text
            };

            try
            {
                DoInsertion(command, objectToInsert);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }

            CloseMySQLConnection(conn);
        }

        protected abstract void DoInsertion(MySqlCommand command, Object objectToInsert);
    }
}