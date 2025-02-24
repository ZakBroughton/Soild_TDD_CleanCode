using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using Assignment.ui_command;
using AssignmentTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class InitialiseDatabaseCommandTests
    {
        [TestClass]
        public class DataGatewayFacadeTests
        {

            private IDataGatewayFacade dataGatewayFacade;

            [TestInitialize]
            public void TestInitialize()
            {
                // Initialize your data gateway facade
                dataGatewayFacade = new DataGatewayFacade();

                // Execute the command to populate the database with specific data
                var initialiseCommand = new InitialiseDatabaseCommand(dataGatewayFacade);
                initialiseCommand.Execute();
            }


            




            [TestMethod]
            public void AddEmployee_ShouldAddEmployeeToDatabase()
            {
                // Arrange
                var employee = new Employee("John Doe");

                // Act
                int employeeId = dataGatewayFacade.AddEmployee(employee);

                // Assert
                Assert.IsTrue(employeeId > 0);

                // Cleanup
               
               
            }
        


        [TestMethod]
            public void AddItem_ShouldAddItemToDatabase()
            {
                // Arrange
                var dateCreated = DateTime.Now;
                var item = new Item(1, "TestItem", 5, dateCreated); 

                // Act
                int itemId = dataGatewayFacade.AddItem(item);

                // Assert
                Assert.IsTrue(itemId > 0); 
            }

            [TestMethod]
            public void GetAllItems_ShouldReturnAllItems()
            {
                // Arrange
               
                var dateCreated1 = DateTime.Now;
                var item1 = new Item(1, "TestItem1", 5, dateCreated1);
                var dateCreated2 = DateTime.Now.AddDays(-1);
                var item2 = new Item(2, "TestItem2", 10, dateCreated2);
                dataGatewayFacade.AddItem(item1);
                dataGatewayFacade.AddItem(item2);

                // Act
                List<Item> retrievedItems = dataGatewayFacade.GetAllItems();

                // Assert
                Assert.IsNotNull(retrievedItems);
               

               
            }

            [TestMethod]
            public void GetAllEmployee_ShouldReturnAllEmployees()
            {
                // Arrange
               
                

                // Act
                List<Employee> retrievedEmployee = dataGatewayFacade.GetAllEmployee();

                // Assert
                Assert.IsNotNull(retrievedEmployee);
               

               
            }

            [TestMethod]
            public void AddTransactionLog_ShouldAddTransactionLog()
            {
                // Arrange
                var dataGatewayFacade = new DataGatewayFacade();
                var transactionDTO = new TransactionDTO("Quantity Removed", 1, "ItemName", 10.5, 5, "Employee", DateTime.Now);

                // Act
                try
                {
                    dataGatewayFacade.AddTransactionLog(transactionDTO);
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Adding transaction log failed: {ex.Message}");
                }

                // Assert
               
            }

            [TestMethod]
            public void FindEmployee_ShouldReturnMatchingEmployee()
            {
                // Arrange
               

                // Act
                var retrievedEmployee = dataGatewayFacade.FindEmployee("Graham");

                // Assert
                Assert.IsNotNull(retrievedEmployee);
                Assert.AreEqual("Graham", retrievedEmployee.EmployeeName);
            
            }
            [TestMethod]
            public void FindItemById_ShouldReturnMatchingItem()
            {
                // Arrange
               

                // Act
                var retrievedItem = dataGatewayFacade.FindItemById(1);

                // Assert
                Assert.IsNotNull(retrievedItem);
                Assert.AreEqual(1, retrievedItem.ItemID);
               
               
            }

            [TestMethod]
            public void GetAllTransactionLog_ShouldReturnAllTransactions()
            {
                // Arrange
              

                // Act
                List<TransactionDTO> retrievedTransactions = dataGatewayFacade.GetAllTransactionLog();

                // Assert
                Assert.IsNotNull(retrievedTransactions);
              
            }

            [TestMethod]
            public void FindPersonalUsageReport_ShouldReturnEmployeeTransactions()
            {
                // Arrange
                string employeeName = "Graham"; 

                // Act
                List<TransactionDTO> personalReport = dataGatewayFacade.FindPersonalUsageReport(employeeName);

                // Assert
                Assert.IsNotNull(personalReport);

             
                Assert.IsTrue(personalReport.All(t => t.EmployeeName == employeeName));
           
            }

            [TestMethod]
            public void FindInventoryReport_ShouldReturnInventoryReport()
            {
                // Arrange
               

                // Act
                TransactionDTO inventoryReport = dataGatewayFacade.FindInventoryReport();

                // Assert
                Assert.IsNotNull(inventoryReport);
                Assert.AreEqual("TypeOfTransaction", inventoryReport.TypeOfTransaction);
                
            }
            [TestMethod]
            public void FindFinancialReport_ShouldReturnFinancialReport()
            {
                // Arrange
                

                // Act
                List<TransactionDTO> financialReport = dataGatewayFacade.FindFinancialReport();

                // Assert
                Assert.IsNotNull(financialReport);

                
                Assert.IsTrue(financialReport.Any(t => t.TypeOfTransaction == "TypeOfTransaction" && t.Quantity > 0 && t.ItemPrice > 0));
                
            }
            [TestMethod]
            public void AddQuantityToItemCommand_ShouldIncreaseItemQuantity()
            {
                // Arrange
                var initialQuantity = 10; 
                var itemId = 1; 
                var employeeName = "Graham"; 
                var quantityToAdd = 5; 
                var itemPrice = 2.5; 

                // Simulate user input using your ConsoleReader class
               
                // Act
                var addQuantityCommand = new AddQuantityToItemCommand(dataGatewayFacade);
                FakeConsoleReader.SimulateUserInput(employeeName, itemId.ToString(), quantityToAdd.ToString(), itemPrice.ToString());
                addQuantityCommand.Execute();

                // Assert
                var retrievedItem = dataGatewayFacade.FindItemById(itemId);

               
                Assert.IsNotNull(retrievedItem);
                Assert.AreEqual(initialQuantity + quantityToAdd, retrievedItem.Quantity);

               
                FakeConsoleReader.ClearInput();
            }


            [TestMethod]
            public void TakeQuantityFromItemCommand_ShouldDecreaseItemQuantity()
            {   // Arrange
                var initialQuantity = 10; 
                var itemId = 1; 
                var employeeName = "Graham"; 
                var quantityToRemove = 2; 

                // Act
                var takeQuantityCommand = new TakeQuantityFromItemCommand(dataGatewayFacade);
                FakeConsoleReader.SimulateUserInput(employeeName, itemId.ToString(), quantityToRemove.ToString());
                takeQuantityCommand.Execute();

                // Assert
                var retrievedItem = dataGatewayFacade.FindItemById(itemId);

                
                Assert.IsNotNull(retrievedItem);
                Assert.AreEqual(initialQuantity - quantityToRemove, retrievedItem.Quantity);

                // Clean up simulated input
                FakeConsoleReader.ClearInput();
            }
        }


    }
 }



