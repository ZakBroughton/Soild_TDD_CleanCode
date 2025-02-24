using System;

namespace Assignment
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get;  set; }
       // public string EmployeeName { get; set; }
        public double ItemPrice { get; set; }
        public DateTime DateCreated { get; }


        public Item(int id, string name, int quantity, DateTime dateCreated)
        {
            string errorMsg = "";

            if (id < 1)
            {
                errorMsg += "ItemID below 1; ";
            }

            if (quantity < 1)
            {
                errorMsg += "Quantity below 1; ";
            }

            if (name.Length == 0)
            {
                errorMsg += "Item name is empty; ";
            }

            if (errorMsg.Length > 0)
            {
                throw new Exception("ERROR: Test 4" + errorMsg);
            }

            this.ItemID = id;
            this.ItemName = name;
            this.Quantity = quantity;
            this.DateCreated = dateCreated;
        }

        public void AddQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being added is below 0");
            }

            this.Quantity += quantity;
        }

        public void RemoveQuantity(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("ERROR: Quantity being removed is below 0");
            }

            if (quantity > this.Quantity)
            {
                throw new Exception("ERROR: Quantity too many");
            }

            this.Quantity -= quantity;
        }


    }
}
