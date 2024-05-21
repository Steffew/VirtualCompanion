using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces.Service
{
    public interface IInventoryService
    {
        List<Inventory> GetInventoriesByOwnerId(int ownerId);
        Inventory GetInventoryByOwnerIdAndItemId(int ownerId, int itemId);
        void AddItemToInventory(Inventory inventory);
        bool UpdateInventoryItem(Inventory inventory);
        bool RemoveItemFromInventory(int ownerId, int itemId);
        void UseItem(int ownerId, int itemId, int quantity);
    }
}