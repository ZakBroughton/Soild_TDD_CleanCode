using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Assignment.DataGateway
{

    /* 
    This class, DataGatewayFacade, showcases adherence to SOLID principles:
    - Liskov Substitution Principle (LSP) by utilizing different factories to create specific objects without detailed knowledge of their implementations.
    - Dependency Inversion Principle (DIP) by relying on abstractions (interfaces) to define behavior and method return types.
    
    
    */
    public class DataGatewayFacade : IDataGatewayFacade
    {
        
        public int AddEmployee(Employee e)
        {
            return new DatabaseOperationFactoryForEmployee()
                .CreateInserter()
                .Insert(e);
        }
        public int AddItem(Item i)
        {
            return new DatabaseOperationFactoryForItem()
                .AddItem()
                .Insert(i);
        }


        public List<Item> GetAllItems()
        {
            return new DatabaseOperationFactoryForItem()
                .CreateSelector(DatabaseOperationFactoryForItem.SELECT_ALL)
            .Select();
        }

        public List<Employee> GetAllEmployee()
        {
            return new DatabaseOperationFactoryForEmployee()
                .CreateSelector(DatabaseOperationFactoryForEmployee.SELECT_ALL)
                .Select();
        }

        public void InitialiseMySqlDatabase()
        {
            new DatabaseInitialiser().Initialise();
        }


       
        public void AddTransactionLog(TransactionDTO transactionDTO)
        {
            new DatabaseOperationFactoryForTransactionLog()
                .CreateInserter()
                .Insert(transactionDTO);
        }

        public Employee FindEmployee(string employeeName)
        {
            return new DatabaseOperationFactoryForEmployee()
                .CreateSelector(DatabaseOperationFactoryForEmployee.SELECT_BY_NAME, employeeName)
                .Select();
        }

        public Item FindItemById(int id)
        {
            return new DatabaseOperationFactoryForItem()
                .CreateSelector(DatabaseOperationFactoryForItem.SELECT_BY_ID, id)
                .Select();
        }


        List<TransactionDTO> IDataGatewayFacade.GetAllTransactionLog()
        {
            return new DatabaseOperationFactoryForTransactionLog()
               .CreateSelector(DatabaseOperationFactoryForTransactionLog.TRANSACTION_LOG)
               .Select();
        }



        List<TransactionDTO> IDataGatewayFacade.FindPersonalUsageReport(string employeeName)
        {
            return new DatabaseOperationFactoryForTransactionLog()
                .CreatePersonalUsageReportSelector(DatabaseOperationFactoryForTransactionLog.PERSONAL_USAGE_REPORT, employeeName)
                .Select();
        }


        TransactionDTO IDataGatewayFacade.FindInventoryReport()
        {
            return new DatabaseOperationFactoryForTransactionLog()
                .CreateInventoryReportSelector(DatabaseOperationFactoryForTransactionLog.INVENTORY_REPORT)
                .Select();
        }


        List<TransactionDTO> IDataGatewayFacade.FindFinancialReport()
        {
            return new DatabaseOperationFactoryForTransactionLog()
                .CreateFinancialReportSelector(DatabaseOperationFactoryForTransactionLog.FINANCIAL_REPORT)
                .Select();
        }

        public int AddQuantity(int itemId, int quantityToAdded)
        {
            Item itemAddQuantity = FindItemById(itemId);

            return new DatabaseOperationFactoryForItem()
                .CreateAddQuantityUpdater(quantityToAdded) 
                .Update(itemAddQuantity);
        }

        public int RemoveQuantity(int itemId, int quantityToRemove)
        {
            Item itemRemoveQuantity = FindItemById(itemId);

            return new DatabaseOperationFactoryForItem()
                .CreateRemoveQuantityUpdater(quantityToRemove) 
                .Update(itemRemoveQuantity);
        }


    }
}