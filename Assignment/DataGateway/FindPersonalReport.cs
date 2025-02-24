using Assignment.DTO;
using Assignment.Libary;
using MySqlConnector;
using System;
using System.Collections.Generic;

namespace Assignment.DataGateway
{
    public class FindPersonalReport : DatabaseSelector<List<TransactionDTO>>
    {
        private string employeeName;

        public FindPersonalReport(string employeeName)
        {
            this.employeeName = employeeName;
        }

        protected override string GetSQL()
        {
            return "SELECT ItemID, ItemName, Quantity,ItemPrice ,DateAdded FROM TransactionLogs WHERE EmployeeName = @EmployeeName AND TypeOfTransaction = 'Quantity Removed'";
        }

        protected override List<TransactionDTO> DoSelect(MySqlCommand command)
        {
            List<TransactionDTO> PersonalReport = new List<TransactionDTO>();

            try
            {
                MySqlParameter mySqlParameter = command.Parameters.AddWithValue("@EmployeeName", employeeName);
                MySqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {   int itemID = dr.GetInt32("ItemID");
                    string itemName = dr.GetString("ItemName");
                    int quantity = dr.GetInt32("Quantity");
                    double itemPrice = dr.GetDouble("ItemPrice");
                    DateTime dateAdded = dr.GetDateTime("DateAdded");

                  
                   

                    
                    TransactionDTO transaction = new TransactionDTO("Quantity Removed", itemID, itemName, itemPrice, quantity, employeeName, dateAdded);

                   
                    PersonalReport.Add(transaction);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Error fetching personal report", e);
            }

            return PersonalReport;
        }
    }
}
