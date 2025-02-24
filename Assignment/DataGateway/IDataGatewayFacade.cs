using Assignment.DTO;
using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System.Text;


namespace Assignment.DataGateway
{
    public interface IDataGatewayFacade
    {
        public int AddEmployee(Employee e);

        public Item FindItemById(int id);
        public void AddTransactionLog(TransactionDTO transactionDTO);

        public void InitialiseMySqlDatabase();
        int AddItem(Item i);


        public int AddQuantity(int itemId, int quantityToAddedd);
        public int RemoveQuantity(int itemId, int quantityToRemove);

        public Employee FindEmployee(string employeeName);

        List<Item> GetAllItems();

        public List<Employee> GetAllEmployee();
        List<TransactionDTO> GetAllTransactionLog();


        List<TransactionDTO> FindPersonalUsageReport(string employeeName);

        TransactionDTO FindInventoryReport();
      
        List<TransactionDTO> FindFinancialReport();
       
    }
}