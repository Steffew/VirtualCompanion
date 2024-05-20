using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces.Repository;
using VirtualCompanion.Core.Interfaces.Service;

namespace VirtualCompanion.Core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public List<Inventory> GetInventoriesByOwnerId(int ownerId)
        {
            return _inventoryRepository.GetAll(ownerId);
        }

        public void AddItemToInventory(Inventory inventory)
        {
            _inventoryRepository.Add(inventory);
        }

        public bool RemoveItemFromInventory(int ownerId, int itemId)
        {
            return _inventoryRepository.Delete(ownerId, itemId);
        }

        public bool UpdateInventoryItem(Inventory inventory)
        {
            return _inventoryRepository.Update(inventory);
        }

        public void UseItem(int ownerId, int itemId, int quantity)
        {
            var inventory = _inventoryRepository.GetByOwnerIdAndItemId(ownerId, itemId);
            if (inventory != null && inventory.Quantity >= quantity)
            {
                inventory.AdjustQuantity(-quantity);
                if (inventory.Quantity > 0)
                {
                    UpdateInventoryItem(inventory);
                }
                else
                {
                    RemoveItemFromInventory(ownerId, itemId);
                }
            }
        }
    }
}
