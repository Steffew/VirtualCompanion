using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Core
{
    internal class PetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        void UpdatePet(Pet pet)
        {
            _petRepository.Update(pet);
        }

        void ApplyItemToPet(int petId, Item item)
        {
            Pet pet = _petRepository.Get(petId);

            pet.UpdateAttributesByAmount(item.Experience, item.Energy, item.Mood, item.Hygiene);
        }
    }
}
