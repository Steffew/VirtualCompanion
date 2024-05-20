using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces.Repository;

namespace VirtualCompanion.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly string _connectionString;

        public OwnerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Owner> GetAll()
        {
            var owners = new List<Owner>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM owner", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        owners.Add(new Owner(
                            reader.GetInt32("id"),
                            reader.GetInt32("balance"),
                            reader.GetInt32("petCapacity")));
                    }
                }
            }
            return owners;
        }

        public Owner Get(int id)
        {
            Owner? owner = null;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM owner WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        owner = new Owner(
                            reader.GetInt32("id"),
                            reader.GetInt32("balance"),
                            reader.GetInt32("petCapacity"));
                    }
                }
            }
            return owner;
        }

        public bool Update(Owner owner)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE owner SET nickname = @nickname, balance = @balance, petCapacity = @petCapacity WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", owner.Id);
                cmd.Parameters.AddWithValue("@balance", owner.Balance);
                cmd.Parameters.AddWithValue("@petCapacity", owner.PetCapacity);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }

        public bool Delete(int id)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM owner WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }
    }
}
