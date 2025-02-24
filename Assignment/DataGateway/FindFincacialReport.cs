using Assignment.DTO;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Assignment.DataGateway
{
    public class FindFincacialReport : DatabaseSelector<List<TransactionDTO>>
    {
        public FindFincacialReport() { }

        protected override string GetSQL()
        {
            return "SELECT ItemName, Quantity, ItemPrice FROM TransactionLogs WHERE TypeOfTransaction = 'Quantity Added' OR TypeOfTransaction = 'Item Added' ";
        }

        protected override List<TransactionDTO> DoSelect(MySqlCommand command)
        {
            List<TransactionDTO> inventoryReports = new List<TransactionDTO>(); 

            try
            {
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read()) 
                {
                    string itemName = dr.GetString("ItemName");
                    int quantity = dr.GetInt32("Quantity");
                    double itemPrice = dr.GetDouble("ItemPrice"); 

                    double totalCost = itemPrice * quantity;

                   
                    TransactionDTO inventoryReport = new TransactionDTO("TypeOfTransaction", 0, itemName, itemPrice, quantity, "", DateTime.Now);
                    inventoryReport.TotalCost = totalCost; 

                    inventoryReports.Add(inventoryReport); 
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error fetching inventory report", e);
            }

            return inventoryReports;
        }
    }
}