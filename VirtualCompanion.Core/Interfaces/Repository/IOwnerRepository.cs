using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces.Repository
{
    public interface IOwnerRepository
    {
        List<Owner> GetAll();
        Owner Get(int id);
        bool Update(Owner owner);
        bool Delete(int id);
    }
}
