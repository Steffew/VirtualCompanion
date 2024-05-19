using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Core.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void CreatePet(Pet pet)
        {
            _petRepository.Add(pet);
        }

        public List<Pet> GetAllPets(int ownerId)
        {
            return _petRepository.GetAll(ownerId);
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAll();
        }

        public Pet GetPet(int petId)
        {
            return _petRepository.Get(petId);
        }

        public void UpdatePet(Pet pet)  
        {
            _petRepository.Update(pet);
        }

        public bool DeletePet(int petId)
        {
            return _petRepository.Delete(petId);
        }

        public void ApplyItemToPet(int petId, Item item)
        {
            Pet pet = _petRepository.Get(petId);

            pet.UpdateAttributesByAmount(item.Health, item.Hunger, item.Energy, item.Mood, item.Hygiene, item.Experience);
        }
    }
}
