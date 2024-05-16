using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Data
{
    public class PetRepository : IPetRepository
    {
        private readonly string _connectionString;

        public PetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Pet> GetAll(int ownerId)
        {
            var pets = new List<Pet>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM pet WHERE ownerId = @ownerId", conn);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pets.Add(new Pet(
                            reader.GetInt32("id"),
                            reader.GetInt32("ownerId"),
                            reader.GetString("name"),
                            reader.GetFloat("health"),
                            reader.GetFloat("experience"),
                            reader.GetFloat("energy"),
                            reader.GetFloat("mood"),
                            reader.GetFloat("hunger"),
                            reader.GetFloat("hygiene")));
                    }
                }
            }
            return pets;
        }

        public List<Pet> GetAll()
        {
            var pets = new List<Pet>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM pet", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pets.Add(new Pet(
                            reader.GetInt32("id"),
                            reader.GetInt32("ownerId"),
                            reader.GetString("name"),
                            reader.GetFloat("health"),
                            reader.GetFloat("experience"),
                            reader.GetFloat("energy"),
                            reader.GetFloat("mood"),
                            reader.GetFloat("hunger"),
                            reader.GetFloat("hygiene")));
                    }
                }
            }
            return pets;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }


        public Pet GetPet(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Pet pet)
        {
            throw new NotImplementedException();
        }
    }
}
