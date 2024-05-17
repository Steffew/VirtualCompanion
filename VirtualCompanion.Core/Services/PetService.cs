using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Core.Services
{
    internal class PetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public void UpdatePet(Pet pet)
        {
            _petRepository.Update(pet);
        }

        public void ApplyItemToPet(int petId, Item item)
        {
            Pet pet = _petRepository.Get(petId);

            pet.UpdateAttributesByAmount(item.Health, item.Hunger, item.Energy, item.Mood, item.Hygiene, item.Experience);
        }
    }
}
