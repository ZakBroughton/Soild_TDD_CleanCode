﻿using Assignment.DataGateway;
using Assignment.DTO;
using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment.ui_command
{
    public class ViewFinancialReportCommand : UI_Command
    {
        private readonly IDataGatewayFacade dataGatewayFacade;

        public ViewFinancialReportCommand(IDataGatewayFacade dataGatewayFacade)
        {
            this.dataGatewayFacade = dataGatewayFacade;
        }

        public void Execute()
        {
            Execute(dataGatewayFacade);
        }

        public void Execute(IDataGatewayFacade gatewayFacade)
        {
            Console.WriteLine("\nFinancial Report:");
            List<TransactionDTO> transactions = gatewayFacade.FindFinancialReport();

            if (transactions.Any())
            {
                Dictionary<string, double> itemTotalCosts = new Dictionary<string, double>();

                Console.WriteLine("Transaction Found:");
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"Item Name: {transaction.ItemName}");
                    Console.WriteLine($"Total price of item: {transaction.TotalCost:C}");
                    Console.WriteLine();

                    // Aggregate the total cost for each item
                    if (itemTotalCosts.ContainsKey(transaction.ItemName))
                    {
                        itemTotalCosts[transaction.ItemName] += transaction.TotalCost;
                    }
                    else
                    {
                        itemTotalCosts.Add(transaction.ItemName, transaction.TotalCost);
                    }
                }

                Console.WriteLine("Total price of all items:");
                foreach (var itemTotal in itemTotalCosts)
                {
                    Console.WriteLine($"{itemTotal.Key}: Total price of item: {itemTotal.Value:C}");
                }

                double totalPriceOfAllItems = transactions.Sum(t => t.TotalCost);
                Console.WriteLine($"Total price of all items: {totalPriceOfAllItems:C}");
            }
            else
            {
                Console.WriteLine("No Financial Transactions Found.");
            }
        }
    }
}