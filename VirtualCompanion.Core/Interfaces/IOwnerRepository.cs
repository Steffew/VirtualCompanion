using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces
{
    public interface IOwnerRepository
    {
        List<Owner> GetAll();
        Item Get(int id);
        bool Update(Owner owner);
        bool Delete(int id);
    }
}
