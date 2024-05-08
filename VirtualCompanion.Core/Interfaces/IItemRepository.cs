namespace VirtualCompanion.Core.Interfaces
{
    public interface IItemRepository
    {
        List<Item> GetAllItems();
        Item GetItem(int id);
        bool UpdateItem(Item item);
        bool DeleteItem(Item item);
    }
}
