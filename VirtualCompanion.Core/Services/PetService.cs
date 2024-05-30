using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Exceptions;
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
            try
            {
                return _petRepository.GetAll(ownerId);
            }
            catch (PetException ex)
            {
                throw new PetException("Retreiving pets failed, contact administrator", ex);
            }
        }

        public List<Pet> GetAllPets()
        {
            try
            {
                return _petRepository.GetAll();
            }
            catch (PetException ex)
            {
                throw new PetException("Retreiving pets failed, contact administrator", ex);
            }
        }

        public Pet GetPet(int petId)
        {
            try
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
            catch (PetException ex)
            {
                throw new PetException("Retreiving pet failed, contact administrator", ex);
            }
        }

        public void UpdatePet(Pet pet)  
        {
            if (pet == null)
            {
                throw new ArgumentNullException(nameof(pet), "Pet cannot be null!");
            }

            pet.ValidateAttributes();
            pet.CheckHealth();

            if (!_petRepository.Update(pet))
            {
                throw new PetException($"Update failed, pet '{pet.Name}' with ID {pet.Id} might not exist.");
            }
        }

        public bool DeletePet(int petId)
        {
            if (petId <= 0)
            {
                throw new ArgumentException("Pet ID cannot be negative!", nameof(petId));
            }

            return _petRepository.Delete(petId);
        }

        public void ApplyItemToPet(int petId, Item item)
        {
            Pet pet = _petRepository.Get(petId);

            pet.UpdateAttributesByAmount(item.Health, item.Hunger, item.Energy, item.Mood, item.Hygiene, item.Experience);
        }
    }
}
