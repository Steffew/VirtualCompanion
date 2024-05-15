using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces
{
    public interface IPetRepository
    {
        List<Pet> GetAllPets();
        List<Pet> GetAllPetsByOwnerId(int ownerId);
        Pet GetPet(int id);
        bool UpdatePet(Pet pet);
        bool DeletePet(int id);
    }
}
