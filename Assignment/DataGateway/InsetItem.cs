using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public class InsertItem : DatabaseInserter<Item>
    {
        protected override string GetSQL()
        {
            return "INSERT INTO Items (ItemName, Quantity, ItemPrice) " +
                   "VALUES (@name, @quantity, @itemPrice)";
        }

        protected override int DoInsert(MySqlCommand command, Item itemToInsert)
        {
            try
            {
                command.Parameters.AddWithValue("@name", itemToInsert.ItemName);
                command.Parameters.AddWithValue("@quantity", itemToInsert.Quantity);
                command.Parameters.AddWithValue("@itemPrice", itemToInsert.ItemPrice);


                command.Prepare();
                int numRowsAffected = command.ExecuteNonQuery();

                if (numRowsAffected != 1)
                {
                    throw new Exception("ERROR: item not inserted");
                }
                return numRowsAffected;
            }
            catch (Exception ex)
            {
                
                
                throw new Exception("EEROR occurred during insertion,", ex); 
            }
        }
    }
}