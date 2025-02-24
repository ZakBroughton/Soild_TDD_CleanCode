using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ui_command
{
    public class AddQuantityToItemCommand : UI_Command
    {
       
        
        private readonly IDataGatewayFacade dataGatewayFacade;



        public AddQuantityToItemCommand(IDataGatewayFacade dataGatewayFacade)
        {
            this.dataGatewayFacade = dataGatewayFacade;
        }

        public void Execute()
        {
            try
            {
                string employeeName = ConsoleReader.ReadString("\nEmployee Name");
                Employee employee = dataGatewayFacade.FindEmployee(employeeName);
                if (employee == null)
                {
                    throw new Exception("ERROR: Employee not found");
                }

                int itemId = ConsoleReader.ReadInteger("Item ID");
                Item item = dataGatewayFacade.FindItemById(itemId);
                if (item == null)
                {
                    throw new Exception("ERROR: Item not found");
                }

                int quantityToAdd = ConsoleReader.ReadInteger("How many items would you like to add?");
                double itemPrice = ConsoleReader.ReadDouble("Item Price");

                if (itemPrice < 0)
                {
                    throw new Exception("ERROR: Price below 0");
                }

                dataGatewayFacade.AddQuantity( itemId,quantityToAdd);
                Console.WriteLine(
                    "{0} items have been added to Item ItemID: {1} on {2}",
                    quantityToAdd,
                    itemId,
                    DateTime.Now.ToString("dd/MM/yyyy"));

                dataGatewayFacade.AddTransactionLog(
                    new TransactionDTO("Quantity Added", item.ItemID, item.ItemName, itemPrice, quantityToAdd, employeeName, DateTime.Now));
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: Test 2",e.Message);
            }
        }
    }
}