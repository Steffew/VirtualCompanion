using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces.Repository
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item Get(int id);
        bool Update(Item item);
        bool Delete(int id);
    }
}
