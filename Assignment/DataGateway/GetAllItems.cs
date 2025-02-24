using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{
    public class GetAllItems : DatabaseSelector<List<Item>>
    {
        public GetAllItems()
        {

        }

        protected override string GetSQL()
        {
           
            return "SELECT ItemID, ItemName, Quantity FROM items";
        }

        protected override List<Item> DoSelect(MySqlCommand command)
        {
            List<Item> items = new List<Item>();
            try
            {
                MySqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["ItemID"]);
                    string name = Convert.ToString(dr["ItemName"]);
                    int quantity = Convert.ToInt32(dr["Quantity"]);
                    DateTime dateCreated = DateTime.Now;

                  
                    Item item = new Item(id, name, quantity, dateCreated);
                    items.Add(item);
                }
                dr.Close(); 
            }
            catch (Exception e)
            {
                throw new Exception("ERROR: retrieval of item failed", e);
              
            }

            return items;
        }
    }
}