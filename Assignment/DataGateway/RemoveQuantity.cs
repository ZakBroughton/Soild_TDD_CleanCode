using MySqlConnector;
using System;

namespace Assignment.DataGateway
{
    public class RemoveQuantity : DatabaseUpdater<Item>
    {
        
        private int quantityToRemove;

        

        public RemoveQuantity(int quantityToRemove)
        {
          
            this.quantityToRemove = quantityToRemove;
        }

        protected override int DoUpdate(MySqlCommand command, Item itemToUpdate)
        {
            try
            {
                if (itemToUpdate != null)
                {
                    

                    command.Parameters.AddWithValue("@QuantityToRemove", quantityToRemove);
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

        protected override string GetSQL()
        {
            return "UPDATE Items SET Quantity = Quantity - @QuantityToRemove WHERE ItemID = @ItemID";
        }
    }
}

