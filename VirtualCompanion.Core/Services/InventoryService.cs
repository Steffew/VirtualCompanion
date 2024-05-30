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
                throw new InventoryException("Retreiving inventory failed, contact administrator",ex);
            }
        }

        public Inventory GetInventoryByOwnerIdAndItemId(int ownerId, int itemId)
        {
            try
            {
                return _inventoryRepository.GetByOwnerIdAndItemId(ownerId, itemId);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException("Retreiving inventory failed, contact administrator", ex);
            }
        }

        public void AddItemToInventory(Inventory inventory)
        {
            try
            {
                _inventoryRepository.Add(inventory);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException("Adding item to inventory failed, contact administrator", ex);
            }
        }

        public bool RemoveItemFromInventory(Owner owner, Item item)
        {
            try
            {
                return _inventoryRepository.Delete(owner.Id, item.Id);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException("Removing item from inventory failed, contact administrator", ex);
            }
        }

        public bool UpdateInventoryItem(Inventory inventory)
        {
            try
            {
                return _inventoryRepository.Update(inventory);
            }
            catch (InventoryException ex)
            {
                throw new InventoryException("Updating item failed, contact administrator", ex);
            }
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
