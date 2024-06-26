﻿
using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Exceptions;

namespace VirtualCompanion.Test
{
    public class InventoryTests
    {
        [Fact]
        public void GetInventoryByOwnerIdAndItemId_Found()
        {
            // Arrange
            var inventories = new List<Inventory>
        {
            new Inventory(itemId: 1, ownerId: 1, amount: 10, itemName: "Item1"),
            new Inventory(itemId: 2, ownerId: 1, amount: 5, itemName: "Item2")
        };
            var mockRepository = new MockInventoryRepository(inventories);
            var inventoryService = new InventoryService(mockRepository);

            // Act
            var result = inventoryService.GetInventoryByOwnerIdAndItemId(1, 2);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.ItemId);
            Assert.Equal(1, result.OwnerId);
        }

        [Fact]
        public void GetInventoryByOwnerIdAndItemId_NotFound()
        {
            // Arrange
            var inventories = new List<Inventory>
        {
            new Inventory(itemId: 1, ownerId: 1, amount: 10, itemName: "Item1")
        };
            var mockRepository = new MockInventoryRepository(inventories);
            var inventoryService = new InventoryService(mockRepository);

            // Act
            var result = inventoryService.GetInventoryByOwnerIdAndItemId(1, 3);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void AddItemToInventory_Success()
        {
            // Arrange
            var inventories = new List<Inventory>();
            var mockRepository = new MockInventoryRepository(inventories);
            var inventoryService = new InventoryService(mockRepository);
            var newInventory = new Inventory(itemId: 1, ownerId: 1, amount: 10, itemName: "NewItem");

            // Act
            inventoryService.AddItemToInventory(newInventory);

            // Assert
            Assert.Contains(newInventory, inventories);
            Assert.Equal(1, inventories.Count);
        }

        [Fact]
        public void UpdateInventoryItem_Success()
        {
            // Arrange
            var inventory = new Inventory(itemId: 1, ownerId: 1, amount: 5, itemName: "OriginalItem");
            var inventories = new List<Inventory> { inventory };
            var mockRepository = new MockInventoryRepository(inventories);
            var inventoryService = new InventoryService(mockRepository);

            // Act
            inventory.AdjustAmount(5);
            var result = inventoryService.UpdateInventoryItem(inventory);

            // Assert
            Assert.True(result);
            Assert.Equal(10, inventories.First().Amount);
        }

        [Fact]
        public void RemoveItemFromInventory_Success()
        {
            // Arrange
            var owner = new Owner(id: 1, balance: 100, petCapacity: 5);
            var item = new Item(id: 1, name: "ItemToRemove", health: 0, cost: 20, experience: 0, energy: 0, mood: 0, hunger: 0, hygiene: 0);

            var inventory = new Inventory(itemId: 1, ownerId: 1, amount: 10, itemName: "ItemToRemove");
            var inventories = new List<Inventory> { inventory };

            var mockRepository = new MockInventoryRepository(inventories);
            var inventoryService = new InventoryService(mockRepository);

            // Act
            var result = inventoryService.RemoveItemFromInventory(owner, item);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(inventory, inventories);
        }

        [Fact]
        public void GetAll_ShouldThrowInventoryException_WhenDatabaseConnectionFails()
        {
            // Arrange
            var mockRepository = new MockInventoryRepository(new List<Inventory>(), throwException: true);
            IInventoryService inventoryService = new InventoryService(mockRepository);

            // Act & Assert
            Assert.Throws<InventoryException>(() => inventoryService.GetInventoriesByOwnerId(1));
        }

        // Exceptions

        [Fact]
        public void GetByOwnerIdAndItemId_ShouldThrowInventoryException_WhenDatabaseConnectionFails()
        {
            // Arrange
            var mockRepository = new MockInventoryRepository(new List<Inventory>(), throwException: true);
            IInventoryService inventoryService = new InventoryService(mockRepository);

            // Act & Assert
            Assert.Throws<InventoryException>(() => inventoryService.GetInventoryByOwnerIdAndItemId(1, 1));
        }

        [Fact]
        public void Add_ShouldThrowInventoryException_WhenDatabaseConnectionFails()
        {
            // Arrange
            var mockRepository = new MockInventoryRepository(new List<Inventory>(), throwException: true);
            IInventoryService inventoryService = new InventoryService(mockRepository);
            var inventory = new Inventory(1, 1, 10, "Test Item");

            // Act & Assert
            Assert.Throws<InventoryException>(() => inventoryService.AddItemToInventory(inventory));
        }

        [Fact]
        public void Update_ShouldThrowInventoryException_WhenDatabaseConnectionFails()
        {
            // Arrange
            var mockRepository = new MockInventoryRepository(new List<Inventory>(), throwException: true);
            IInventoryService inventoryService = new InventoryService(mockRepository);
            var inventory = new Inventory(1, 1, 10, "Test Item");

            // Act & Assert
            Assert.Throws<InventoryException>(() => inventoryService.UpdateInventoryItem(inventory));
        }

        [Fact]
        public void Delete_ShouldThrowInventoryException_WhenDatabaseConnectionFails()
        {
            // Arrange
            var mockRepository = new MockInventoryRepository(new List<Inventory>(), throwException: true);
            IInventoryService inventoryService = new InventoryService(mockRepository);
            var owner = new Owner(1, 100, 5);
            var item = new Item(1, "Test Item", 0, 10, 0, 0, 0, 0, 0);

            // Act & Assert
            Assert.Throws<InventoryException>(() => inventoryService.RemoveItemFromInventory(owner, item));
        }
    }
}
