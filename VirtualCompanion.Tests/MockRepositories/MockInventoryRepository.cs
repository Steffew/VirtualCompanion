using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Test.MockRepositories
{
    public class MockInventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories = new List<Inventory>();
        // todo: Test ALL outcomes, even exceptions from the service class, add params to methods to test exceptions
        public MockInventoryRepository(List<Inventory> inventories)
        {
            _inventories = inventories;
        }

        public List<Inventory> GetAll(int ownerId)
        {
            return _inventories.Where(inventory => inventory.OwnerId == ownerId).ToList();
        }

        public Inventory GetByOwnerIdAndItemId(int ownerId, int itemId)
        {
            return _inventories.FirstOrDefault(inventory => inventory.OwnerId == ownerId && inventory.ItemId == itemId);
        }

        public void Add(Inventory inventory)
        {
            _inventories.Add(inventory);
        }

        public bool Update(Inventory inventory)
        {
            Inventory existingInventory = GetByOwnerIdAndItemId(inventory.OwnerId, inventory.ItemId);
            if (existingInventory != null)
            {
                int amountDifference = inventory.Amount - existingInventory.Amount;

                existingInventory.AdjustAmount(amountDifference);

                existingInventory.ItemName = inventory.ItemName;

                return true;
            }
            return false;
        }


        public bool Delete(int ownerId, int itemId)
        {
            var inventory = GetByOwnerIdAndItemId(ownerId, itemId);
            if (inventory != null)
            {
                _inventories.Remove(inventory);
                return true;
            }
            return false;
        }
    }
}
