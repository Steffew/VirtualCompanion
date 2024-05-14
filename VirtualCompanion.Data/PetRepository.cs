using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Data
{
    internal class PetRepository : IPetRepository
    {
        private readonly string _connectionString;

        public PetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        bool IPetRepository.DeletePet(int id)
        {
            throw new NotImplementedException();
        }

        List<Pet> IPetRepository.GetAllPets()
        {
            throw new NotImplementedException();
        }

        Pet IPetRepository.GetPet(int id)
        {
            throw new NotImplementedException();
        }

        bool IPetRepository.UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
