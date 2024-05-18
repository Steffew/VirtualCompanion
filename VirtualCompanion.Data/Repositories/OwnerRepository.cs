using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

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

        public Item Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Owner owner)
        {
            throw new NotImplementedException();
        }
    }
}
