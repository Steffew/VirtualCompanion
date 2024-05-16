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

        public void Add(Pet pet)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO pet (ownerId, name, health, experience, energy, mood, hunger, hygiene) VALUES (@ownerId, @name, @health, @experience, @energy, @mood, @hunger, @hygiene)", conn);
                cmd.Parameters.AddWithValue("@ownerId", pet.OwnerId);
                cmd.Parameters.AddWithValue("@name", pet.Name);
                cmd.Parameters.AddWithValue("@health", pet.Health);
                cmd.Parameters.AddWithValue("@experience", pet.Experience);
                cmd.Parameters.AddWithValue("@energy", pet.Energy);
                cmd.Parameters.AddWithValue("@mood", pet.Mood);
                cmd.Parameters.AddWithValue("@hunger", pet.Hunger);
                cmd.Parameters.AddWithValue("@hygiene", pet.Hygiene);
                cmd.ExecuteNonQuery();
            }
        }

        public bool Delete(int id)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM pet WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }

        public Pet Get(int id)
        {
            Pet? pet = null;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM pet WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pet = new Pet(
                            reader.GetInt32("id"),
                            reader.GetInt32("ownerId"),
                            reader.GetString("name"),
                            reader.GetFloat("health"),
                            reader.GetFloat("experience"),
                            reader.GetFloat("energy"),
                            reader.GetFloat("mood"),
                            reader.GetFloat("hunger"),
                            reader.GetFloat("hygiene"));
                    }
                }
            }
            return pet;
        }

        public bool Update(Pet pet)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE pet SET ownerId = @ownerId, name = @name, health = @health, experience = @experience, energy = @energy, mood = @mood, hunger = @hunger, hygiene = @hygiene WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", pet.Id);
                cmd.Parameters.AddWithValue("@ownerId", pet.OwnerId);
                cmd.Parameters.AddWithValue("@name", pet.Name);
                cmd.Parameters.AddWithValue("@health", pet.Health);
                cmd.Parameters.AddWithValue("@experience", pet.Experience);
                cmd.Parameters.AddWithValue("@energy", pet.Energy);
                cmd.Parameters.AddWithValue("@mood", pet.Mood);
                cmd.Parameters.AddWithValue("@hunger", pet.Hunger);
                cmd.Parameters.AddWithValue("@hygiene", pet.Hygiene);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }
    }
}
