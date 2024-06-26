﻿using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Core.Interfaces.Service
{
    public interface IPetService
    {
        void CreatePet(Pet pet);
        List<Pet> GetAllPets(int ownerId);
        List<Pet> GetAllPets();
        Pet GetPet(int ownerId);
        void UpdatePet(Pet pet);
        bool DeletePet(int petId);
        void ApplyItemToPet(int petId, Item item);
    }
}