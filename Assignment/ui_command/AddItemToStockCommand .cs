using Assignment;
using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using Assignment.ui_command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ui_command
{
    public class AddItemToStockCommand : UI_Command
    {
        private readonly IDataGatewayFacade dataGatewayFacade;

        public AddItemToStockCommand(IDataGatewayFacade dataGatewayFacade)
        {
            this.dataGatewayFacade = dataGatewayFacade;
        }

        public void Execute()
        {
            try
            {
                string employeeName = ConsoleReader.ReadString("\nEmployee ItemName");
                Employee employee = dataGatewayFacade.FindEmployee(employeeName);
                if (employee == null)
                {
                    throw new Exception("ERROR: Employee not found");
                }

                int itemId = ConsoleReader.ReadInteger("Item ItemID");
                string itemName = ConsoleReader.ReadString("Item ItemName");
                int itemQuantity = ConsoleReader.ReadInteger("Item Quantity");
                double itemPrice = ConsoleReader.ReadDouble("Item Price");

                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }

                Item itemToAdd = new Item(itemId, itemName, itemQuantity, DateTime.Now);
                int addedItemId = dataGatewayFacade.AddItem(itemToAdd);

                dataGatewayFacade.AddTransactionLog(new TransactionDTO(
                    "Item Added", addedItemId, itemName, itemPrice, itemQuantity, employeeName, DateTime.Now));

                Console.WriteLine("Item Added");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
            }
        }
    }
}