using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces
{
    public interface IInventoryRepository
    {
        List<Inventory> GetAll(int ownerId);
        void Add(Inventory inventory);
        bool Update(Inventory inventory);
        bool Delete(int ownerId, int itemId);
        Inventory GetByOwnerIdAndItemId(int ownerId, int itemId);
    }
}
