
namespace VirtualCompanion.Test
{
    public class InventoryTests
    {
        [Fact]
        public void Get_all_by_correct_ID()
        {
            Inventory inventory1 = new Inventory(itemId:1, ownerId:1, amount:1);
            Inventory inventory2 = new Inventory(itemId:2, ownerId:1, amount:1);
            Inventory inventory3 = new Inventory(itemId:3, ownerId:1, amount:1);

            List<Inventory> inventoryList = new List<Inventory>();
            inventoryList.Add(inventory1);
            inventoryList.Add(inventory2);
            inventoryList.Add(inventory3);

            MockInventoryRepository mockRepository = new MockInventoryRepository(inventoryList);
            InventoryService inventoryService = new InventoryService(mockRepository);

            Assert.Equal(3, inventoryService.GetInventoriesByOwnerId(1).Count);
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
