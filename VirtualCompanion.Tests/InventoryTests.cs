
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


        //todo: Add more tests, GetItem etc.
    }
}
