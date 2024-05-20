using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces
{
    public interface IInventoryService
    {
        List<Inventory> GetInventoriesByOwnerId(int ownerId);
        void AddItemToInventory(Inventory inventory);
        bool UpdateInventoryItem(Inventory inventory);
        bool RemoveItemFromInventory(int ownerId, int itemId);
        void UseItem(int ownerId, int itemId, int quantity);
    }
}