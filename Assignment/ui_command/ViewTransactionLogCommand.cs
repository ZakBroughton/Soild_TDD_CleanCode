using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ui_command
{
    public class ViewTransactionLogCommand : UI_Command
    {
      
        private IDataGatewayFacade dataGatewayFacade;

   

        public ViewTransactionLogCommand(IDataGatewayFacade dataGatewayFacade)
        {
            this.dataGatewayFacade = dataGatewayFacade;
        }

        public void Execute()
        {
            List<TransactionDTO> tls = dataGatewayFacade.GetAllTransactionLog();

            Console.WriteLine("\nTransaction Log:");
            Console.WriteLine("\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                "Date", "TypeOfTransaction", "ItemID", "ItemName", "Quantity", "EmployeeName", "Price");

            foreach (var entry in tls)
            {
                Console.WriteLine("\t{0, -20} {1, -16} {2, -6} {3, -12} {4, -10} {5, -12} {6, -12}",
                    entry.DateAdded.ToString("dd/MM/yyyy"), entry.TypeOfTransaction,  entry.ItemID, entry.ItemName,
                    entry.Quantity, entry.EmployeeName,
                    string.Format("{0:C}", entry.ItemPrice));
            }
        }
    }
}