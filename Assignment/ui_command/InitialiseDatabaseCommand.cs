using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.ui_command
{
    public class InitialiseDatabaseCommand : UI_Command
    {
      
            private readonly IDataGatewayFacade dataGatewayFacade;

        public InitialiseDatabaseCommand(IDataGatewayFacade dataGatewayFacade)
        {
            this.dataGatewayFacade = dataGatewayFacade;
        }

        public void Execute()
        {
            dataGatewayFacade.InitialiseMySqlDatabase();
            dataGatewayFacade.AddEmployee(new Employee("Graham"));
            dataGatewayFacade.AddEmployee(new Employee("Phil"));
            dataGatewayFacade.AddEmployee(new Employee("Jan"));

            int newItemId1 = 1;
            Item i1 = new Item(newItemId1, "Pencil", 10, DateTime.Now);
            dataGatewayFacade.AddItem(i1);
            dataGatewayFacade.AddTransactionLog(
                new TransactionDTO("Item Added", i1.ItemID, i1.ItemName, 0.25f, i1.Quantity, "Graham", DateTime.Now));

            int newItemId2 = 2;
            Item i2 = new Item(newItemId2, "Eraser", 20, DateTime.Now);
            dataGatewayFacade.AddItem(i2);
            dataGatewayFacade.AddTransactionLog(
                new TransactionDTO("Item Added", i2.ItemID, i2.ItemName, 0.15f, i2.Quantity, "Phil", DateTime.Now));

            dataGatewayFacade.RemoveQuantity(2,4);
            dataGatewayFacade.AddTransactionLog(
                new TransactionDTO("Quantity Removed", i2.ItemID, i2.ItemName, -0.1f, 4, "Graham", DateTime.Now));

            dataGatewayFacade.AddQuantity(2,2);
            dataGatewayFacade.AddTransactionLog(
                new TransactionDTO("Quantity Added", i2.ItemID, i2.ItemName, 0.30f, 2, "Phil", DateTime.Now));
        }
    }
}
