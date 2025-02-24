using Assignment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentTests
{
    [TestClass]
    public class StockManagerTests
    {
        [TestMethod]
        public void AddItem_WhenNewItemAdded_ShouldIncreaseItemCount()
        {
            // Arrange
            var stockManager = new StockManager();
            var initialItemCount = stockManager.NumberOfItemsInStock;
            var itemId = 1;
            var itemName = "TestItem";
            var quantity = 5;

            // Act
            var newItem = stockManager.AddItem(itemId, itemName, quantity);
            var itemCountAfterAddition = stockManager.NumberOfItemsInStock;

            // Assert
            Assert.AreEqual(initialItemCount + 1, itemCountAfterAddition);
            Assert.IsNotNull(newItem);
            Assert.AreEqual(itemId, newItem.ItemID);
            Assert.AreEqual(itemName, newItem.ItemName);
            Assert.AreEqual(quantity, newItem.Quantity);
        }

        [TestMethod]
        public void AddItem_WhenDuplicateItemAdded_ShouldThrowException()
        {
            // Arrange
            var stockManager = new StockManager();
            var itemId = 1;
            var itemName = "TestItem";
            var quantity = 5;

            // Act
            stockManager.AddItem(itemId, itemName, quantity);

            // Assert
            Assert.ThrowsException<System.Exception>(() => stockManager.AddItem(itemId, itemName, quantity));
        }

        [TestMethod]
        public void FindItem_WhenItemExists_ShouldReturnItem()
        {
            // Arrange
            var stockManager = new StockManager();
            var itemId = 1;
            var itemName = "TestItem";
            var quantity = 5;
            stockManager.AddItem(itemId, itemName, quantity);

            // Act
            var foundItem = stockManager.FindItem(itemId);

            // Assert
            Assert.IsNotNull(foundItem);
            Assert.AreEqual(itemId, foundItem.ItemID);
            Assert.AreEqual(itemName, foundItem.ItemName);
            Assert.AreEqual(quantity, foundItem.Quantity);
        }

        [TestMethod]
        public void FindItem_WhenItemDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            var stockManager = new StockManager();
            var itemId = 1;

            // Act
            var foundItem = stockManager.FindItem(itemId);

            // Assert
            Assert.IsNull(foundItem);
        }
    }
}