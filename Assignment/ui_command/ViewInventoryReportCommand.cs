using Assignment.DataGateway;
using Assignment.ui_command;
using Assignment;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ui_command
{
    public class ViewInventoryReportCommand : UI_Command
    {
       
        private  IDataGatewayFacade dataGatewayFacade;
       
        public ViewInventoryReportCommand(IDataGatewayFacade dataGatewayFacade)
        {
            this.dataGatewayFacade = dataGatewayFacade;
        }

        public void Execute()
        {
            Execute(dataGatewayFacade);
        }

        public void Execute(IDataGatewayFacade gatewayFacade)
        {
            List<Item> items = gatewayFacade.GetAllItems();
            Console.WriteLine("\nAll items");
            Console.WriteLine("\t{0, -4} {1, -20} {2, -20}", "ItemID", "ItemName", "Quantity");
            foreach (Item i in items)
            {
                DisplayItem(i);
            }


        }
        private static void DisplayItem(Item i)
        {
            Console.WriteLine("\t{0, -4} {1, -20} {2, -20}", i.ItemID, i.ItemName, i.Quantity);

        }
    }
}
