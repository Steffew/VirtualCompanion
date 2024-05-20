using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;

namespace VirtualCompanion.Data.Repositories
{
    public class InventoryRepository
    {
        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Inventory> GetAll(int ownerId)
        {
            var inventories = new List<Inventory>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM inventory WHERE ownerId = @ownerId", conn);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventories.Add(new Inventory(
                            reader.GetInt32("itemId"),
                            ownerId,
                            reader.GetInt32("quantity")
                        ));
                    }
                }
            }
            return inventories;
        }
    }
}
