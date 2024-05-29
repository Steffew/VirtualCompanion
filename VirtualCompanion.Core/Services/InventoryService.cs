using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Exceptions;
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
            try
            {
                return _inventoryRepository.GetAll(ownerId);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
        }

        public Inventory GetInventoryByOwnerIdAndItemId(int ownerId, int itemId)
        {
            return _inventoryRepository.GetByOwnerIdAndItemId(ownerId, itemId);
        }

        public void AddItemToInventory(Inventory inventory)
        {
            _inventoryRepository.Add(inventory);
        }

        public bool RemoveItemFromInventory(Owner owner, Item item)
        {
            return _inventoryRepository.Delete(owner.Id, item.Id);
        }

        public bool UpdateInventoryItem(Inventory inventory)
        {
            return _inventoryRepository.Update(inventory);
        }

        public void UseItem(Owner owner, Item item, int amount)
        {
            var inventory = _inventoryRepository.GetByOwnerIdAndItemId(owner.Id, item.Id);
            if (inventory != null && inventory.Amount >= amount)
            {
                inventory.AdjustAmount(-amount);
                if (inventory.Amount > 0)
                {
                    UpdateInventoryItem(inventory);
                }
                else
                {
                    RemoveItemFromInventory(owner, item);
                }
            }
        }
    }
}
