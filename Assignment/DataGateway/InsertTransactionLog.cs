using Assignment.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public class InsertTransactionLog : DatabaseInserter<TransactionDTO>
    {
        protected override string GetSQL()
        {
            return "INSERT INTO transactionlogs (TypeOfTransaction, ItemID, ItemName, Quantity,ItemPrice, EmployeeName,  DateAdded) " +
                   "VALUES (@typeOfTransaction, @ItemID, @itemName, @quantity,@itemPrice ,@employeeName, @timestamp)";
        }


        protected override int DoInsert(MySqlCommand command, TransactionDTO logToInsert)
        {
            command.Parameters.AddWithValue("@typeOfTransaction", logToInsert.TypeOfTransaction);
            command.Parameters.AddWithValue("@ItemID", logToInsert.ItemID);
            command.Parameters.AddWithValue("@itemName", logToInsert.ItemName);
            command.Parameters.AddWithValue("@quantity", logToInsert.Quantity);
            command.Parameters.AddWithValue("@itemPrice", logToInsert.ItemPrice);
            command.Parameters.AddWithValue("@employeeName", logToInsert.EmployeeName);
           
            command.Parameters.AddWithValue("@timestamp", logToInsert.DateAdded);
            command.Prepare();
            int numRowsAffected = command.ExecuteNonQuery();

            if (numRowsAffected != 1)
            {
                throw new Exception("ERROR: transaction log not inserted");
            }
            return numRowsAffected;
        }
    }
}