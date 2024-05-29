using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces.Repository;
using VirtualCompanion.Core.Interfaces.Service;

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
            if (pet == null)
            {
                throw new ArgumentNullException(nameof(pet), "Pet cannot be null!");
            }
            if (string.IsNullOrEmpty(pet.Name))
            {
                pet.ChangeName("Pet");
            }

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
            if (petId <= 0)
            {
                throw new ArgumentException("Pet ID cannot be negative!", nameof(petId));
            }

            Pet pet = _petRepository.Get(petId);
            if (pet == null)
            {
                throw new InvalidOperationException($"No pet found with ID {petId}!");
            }

            return pet;
        }

        public void UpdatePet(Pet pet)  
        {
            if (pet == null)
            {
                throw new ArgumentNullException(nameof(pet), "Pet cannot be null!");
            }

            if (pet.Id <= 0)
            {
                throw new ArgumentException("Pet ID cannot be negative!", nameof(pet));
            }

            if (!_petRepository.Update(pet))
            {
                throw new InvalidOperationException($"Update failed, pet '{pet.Name}' with ID {pet.Id} might not exist.");
            }
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
