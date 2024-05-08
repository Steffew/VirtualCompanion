namespace VirtualCompanion.Core.Interfaces
{
    public interface IItemRepository
    {
        List<Pet> GetAllItems();
        Pet GetItem(int id);
        bool UpdateItem(Item item);
        bool DeleteItem(Item item);
    }
}
