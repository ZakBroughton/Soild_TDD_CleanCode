using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public class TransactionLogGateway : DatabaseGateWay
    {
        protected override string InsertionSQL { get; } = "INSERT INTO TransactionLogs (TypeOfTransaction,ItemID, ItemName, Quantity,ItemPrice , EmployeeName,  DateAdded) VALUES (@typeOfTransaction, @itemID, @itemName,@itemPrice ,@quantity, @employeeName, @dateAdded)";

        public void AddTransactionLog(TransactionLogEntry logEntry)
        {
            using (MySqlConnection conn = GetMySQLConnection())
            {
                MySqlCommand command = new MySqlCommand(InsertionSQL, conn);
                command.Parameters.AddWithValue("@typeOfTransaction", logEntry.TypeOfTransaction);
                command.Parameters.AddWithValue("@itemID", logEntry.ItemID);
                command.Parameters.AddWithValue("@itemName", logEntry.ItemName);
                command.Parameters.AddWithValue("@quantity", logEntry.Quantity);
                command.Parameters.AddWithValue("@itemPrice", logEntry.ItemPrice);
                command.Parameters.AddWithValue("@employeeName", logEntry.EmployeeName);
                command.Parameters.AddWithValue("@dateAdded", logEntry.DateAdded);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("ERROR: insertion of transaction log failed", e);
                }
            }
        }

        protected override void DoInsertion(MySqlCommand command, object objectToInsert)
        {
            throw new NotImplementedException();
        }

       
    }
}