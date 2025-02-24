﻿using MySqlConnector;
using System;

namespace Assignment.DataGateway
{
    //single Responsibility Principle (SRP) and the Open/Closed Principle (OCP) 
    // Class responsible for updating quantity of an item in the database
    public class AddQuantity : DatabaseUpdater<Item>
    {
        private int quantityToAdded;


        // Constructor setting the quantity to be added
        public AddQuantity(int quantityToAdded)
        {

            this.quantityToAdded = quantityToAdded;
        }
        // Method for updating the quantity in the database
        protected override int DoUpdate(MySqlCommand command, Item itemToUpdate)
        {
            try
            {
                if (itemToUpdate != null)
                {

                    // Update command parameters
                    command.Parameters.AddWithValue("@QuantityToAdded", quantityToAdded);
                    command.Parameters.AddWithValue("@ItemID", itemToUpdate.ItemID);

                    return command.ExecuteNonQuery();
                }
                else
                {
                    Console.WriteLine("Item to update is null");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred: " + ex.Message);
                return -1;
            }
        }
        // Method to provide the SQL update query
        protected override string GetSQL()
        {
            return "UPDATE Items SET Quantity = Quantity + @QuantityToAdded WHERE ItemID = @ItemID";
        }
    }
}

