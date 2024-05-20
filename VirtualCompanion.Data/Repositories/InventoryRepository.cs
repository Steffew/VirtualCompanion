using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces.Repository;

namespace VirtualCompanion.Data.Repositories
{
    public class InventoryRepository : IInventoryRepository
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

        public Inventory GetByOwnerIdAndItemId(int ownerId, int itemId)
        {
            Inventory inventory = null;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM inventory WHERE ownerId = @ownerId AND itemId = @itemId LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);
                cmd.Parameters.AddWithValue("@itemId", itemId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inventory = new Inventory(
                            reader.GetInt32("itemId"),
                            ownerId,
                            reader.GetInt32("quantity")
                        );
                    }
                }
            }
            return inventory;
        }

        public void Add(Inventory inventory)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("INSERT INTO inventory (itemId, ownerId, quantity) VALUES (@itemId, @ownerId, @quantity)", conn);
                cmd.Parameters.AddWithValue("@itemId", inventory.ItemId);
                cmd.Parameters.AddWithValue("@ownerId", inventory.OwnerId);
                cmd.Parameters.AddWithValue("@quantity", inventory.Quantity);

                cmd.ExecuteNonQuery();
            }
        }

        public bool Update(Inventory inventory)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE inventory SET quantity = @quantity WHERE itemId = @itemId AND ownerId = @ownerId", conn);
                cmd.Parameters.AddWithValue("@quantity", inventory.Quantity);
                cmd.Parameters.AddWithValue("@itemId", inventory.ItemId);
                cmd.Parameters.AddWithValue("@ownerId", inventory.OwnerId);

                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }

        public bool Delete(int ownerId, int itemId)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("DELETE FROM inventory WHERE ownerId = @ownerId AND itemId = @itemId", conn);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);
                cmd.Parameters.AddWithValue("@itemId", itemId);

                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected > 0;
        }
    }
}
