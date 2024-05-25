
namespace VirtualCompanion.Test
{
    public class InventoryTests
    {
        [Fact]
        public void Get_all_by_correct_ID()
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
        public void Get_all_by_wrong_ID()
        {
            Inventory inventory1 = new Inventory(itemId: 1, ownerId: 2, amount: 1);

            List<Inventory> inventoryList = new List<Inventory>();
            inventoryList.Add(inventory1);

            MockInventoryRepository mockRepository = new MockInventoryRepository(inventoryList);
            InventoryService inventoryService = new InventoryService(mockRepository);

            Assert.Equal(0, inventoryService.GetInventoriesByOwnerId(1).Count);
        }

        //todo: Add more tests, GetItem etc.
    }
}
