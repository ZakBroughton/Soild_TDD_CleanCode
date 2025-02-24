using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public class FindItemById : DatabaseSelector<Item>
    {
        private int itemID;

        public FindItemById(int itemID)
        {
            this.itemID = itemID;
        }

        protected override string GetSQL()
        {
            return "SELECT ItemID, ItemName, Quantity FROM items WHERE ItemID = @ItemID";
        }

        protected override Item DoSelect(MySqlCommand command)
        {
            Item item = null;

            try
            {
                command.Parameters.AddWithValue("@ItemID", itemID);
                command.Prepare();
                MySqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ItemID"]);
                    string name = Convert.ToString(dr["ItemName"]);
                    int quantity = Convert.ToInt32(dr["Quantity"]);

                    

                    DateTime dateCreated = DateTime.Now;
                    item = new Item(id, name, quantity, dateCreated);
                }

                dr.Close();
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of item failed", e);
            }

            return item;
        }
    }
}