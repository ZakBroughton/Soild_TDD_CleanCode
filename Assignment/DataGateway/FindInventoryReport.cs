using Assignment.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Assignment.DataGateway
{
    public class FindInventoryReport : DatabaseSelector<TransactionDTO>
    {
        public FindInventoryReport()
        {
            
        }


        protected override TransactionDTO DoSelect(MySqlCommand command)
        {
            TransactionDTO inventoryReport = null;

            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    string itemName = dr.GetString("ItemName");
                    int quantity = dr.GetInt32("Quantity");

                    
                    inventoryReport = new TransactionDTO("TypeOfTransaction", 0, itemName, 0, quantity, "", DateTime.Now);
            
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error fetching personal usage report", e);
            }

            return inventoryReport;
        }

        protected override string GetSQL()
        {
            return "SELECT ItemName, Quantity FROM TransactionLogs";
        }

    }
}