using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces
{
    public interface IPetRepository
    {
        List<Pet> GetAll();
        List<Pet> GetAll(int ownerId);
        Pet GetPet(int id);
        bool Update(Pet pet);
        bool Delete(int id);
    }
}
