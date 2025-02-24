using Assignment.DTO;
using Assignment.Libary;
using System.Collections.Generic;

namespace Assignment.DataGateway
{
    /* 
    This class, DatabaseOperationFactoryForTransactionLog, illustrates adherence to SOLID principles:
    - Single Responsibility Principle (SRP) by managing the creation of various database operations related to TransactionLog entities.
    - Interface Segregation Principle (ISP) by offering multiple creation methods for different types of database selectors and inserters.
    
    
    Note: The class structure aligns with SRP and ISP by focusing on creation methods for specific database operations; 
    */
    public class DatabaseOperationFactoryForTransactionLog
    {
        public const int INSERT_TRANSACTION = 1;
        public const int FINANCIAL_REPORT = 2;
        public const int INVENTORY_REPORT = 3;
        public const int PERSONAL_USAGE_REPORT = 4;
        public const int TRANSACTION_LOG = 5;

        public DatabaseInserter<TransactionDTO> CreateInserter()
        {
            return new InsertTransactionLog();
        }



        public ISelector<List<TransactionDTO>> CreateFinancialReportSelector(int typeOfSelection)
        {
            switch (typeOfSelection)
            {
                case FINANCIAL_REPORT:
                    return new FindFincacialReport();
                default:
                    return new NullSelector<List<TransactionDTO>>();
            }
        }

        public ISelector<TransactionDTO> CreateInventoryReportSelector(int typeOfSelection)
        {
            switch (typeOfSelection)
            {
                case INVENTORY_REPORT:
                    return new FindInventoryReport();
                default:
                    return new NullSelector<TransactionDTO>();
            }
        }

        public ISelector<List<TransactionDTO>> CreatePersonalUsageReportSelector(int typeOfSelection, string employeeName)
        {
            switch (typeOfSelection)
            {
                case PERSONAL_USAGE_REPORT:
                    return new FindPersonalReport(employeeName);
                default:
                    return new NullSelector<List<TransactionDTO>>();
            }
        }
        public ISelector<List<TransactionDTO>> CreateSelector(int typeOfSelection)
        {
            switch (typeOfSelection)
            {
                case TRANSACTION_LOG:
                    return new GetAllTransactionLog();
                default:
                    return new NullSelector<List<TransactionDTO>>();
            }
        }
    }
}