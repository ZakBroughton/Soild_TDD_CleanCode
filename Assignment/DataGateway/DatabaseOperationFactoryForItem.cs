using Assignment.Libary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.DataGateway
{

    /* 
    This class, DatabaseOperationFactoryForItem, demonstrates adherence to SOLID principles:
    - Single Responsibility Principle (SRP) by managing the creation of various database operations (insertions, selections, updates) for Item entities.
    - Interface Segregation Principle (ISP) by offering multiple creation methods for different database operations.
    
    
    Note: The class structure aligns with SRP and ISP by focusing on creation methods for specific database operations;
    */
    public class DatabaseOperationFactoryForItem
    {
        public const int SELECT_ALL = 1;
        public const int SELECT_BY_ID = 2;
        public const int ADD_ITEM = 3;
        public const int ADD_ITEM_QUANTITY = 4;
        public const int REMOVE_ITEM_QUANTITY = 5;



        public DatabaseInserter<Item> AddItem()
        {
            return new InsertItem();
        }



        public ISelector<List<Item>> CreateSelector(int typeOfSelection)
        {
            if (typeOfSelection == SELECT_ALL)
            {
                return new GetAllItems();
            }
            return new NullSelector<List<Item>>();
        }



        public ISelector<Item> CreateSelector(int typeOfSelection, int i)
        {
            switch (typeOfSelection)
            {
                case SELECT_BY_ID:
                    return new FindItemById(i);
                default:
                    return new NullSelector<Item>();
            }
        }

        public IUpdater<Item> CreateAddQuantityUpdater(int quantityToAdded)
        {
            return new AddQuantity(quantityToAdded);
        }

        public IUpdater<Item> CreateRemoveQuantityUpdater(int quantityToRemove)
        {
            return new RemoveQuantity(quantityToRemove);
        }


    }
}









