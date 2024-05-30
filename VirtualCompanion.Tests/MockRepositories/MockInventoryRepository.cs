using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Exceptions;
using Xunit.Sdk;

namespace VirtualCompanion.Test.MockRepositories
{
    public class MockInventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories = new List<Inventory>();
        private bool _throwException;

        public MockInventoryRepository(List<Inventory> inventories, bool throwException = false)
        {
            _inventories = inventories;
            _throwException = throwException;
        }

        public List<Inventory> GetAll(int ownerId)
        {
            if (_throwException)
            {
                throw new InventoryException("Failed to connect to the database.");
            }

            return _inventories.Where(inventory => inventory.OwnerId == ownerId).ToList();
        }

        public Inventory GetByOwnerIdAndItemId(int ownerId, int itemId)
        {
            if (_throwException)
            {
                throw new InventoryException("Failed to connect to the database.");
            }

            return _inventories.FirstOrDefault(inventory => inventory.OwnerId == ownerId && inventory.ItemId == itemId);
        }

        public void Add(Inventory inventory)
        {
            if (_throwException)
            {
                throw new InventoryException("Failed to connect to the database.");
            }

            _inventories.Add(inventory);
        }

        public bool Update(Inventory inventory)
        {
            if (_throwException)
            {
                throw new InventoryException("Failed to connect to the database.");
            }

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
            if (_throwException)
            {
                throw new InventoryException("Failed to connect to the database.");
            }

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
