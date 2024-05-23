using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces.Service
{
    public interface IInventoryService
    {
        List<Inventory> GetInventoriesByOwnerId(int ownerId);
        Inventory GetInventoryByOwnerIdAndItemId(int ownerId, int itemId);
        void AddItemToInventory(Inventory inventory);
        bool UpdateInventoryItem(Inventory inventory);
        bool RemoveItemFromInventory(Owner owner, Item item);
        void UseItem(Owner owner, Item item, int quantity);
    }
}