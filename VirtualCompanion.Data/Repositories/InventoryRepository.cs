using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Exceptions;
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
                try
                {
                    conn.Open();
                }
                catch (MySqlException ex)
                {
                    throw new InventoryException("Failed to connect to the database: " + ex.Message);
                }

                var cmd = new MySqlCommand(
                    "SELECT i.itemId, i.ownerId, i.amount, item.name FROM inventory i JOIN item ON i.itemId = item.id WHERE i.ownerId = @ownerId", conn);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventories.Add(new Inventory(
                            reader.GetInt32("itemId"),
                            ownerId,
                            reader.GetInt32("amount"),
                            reader.GetString("name")
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
                var cmd = new MySqlCommand(
                    "SELECT i.itemId, i.ownerId, i.amount, item.name FROM inventory i JOIN item ON i.itemId = item.id WHERE i.ownerId = @ownerId AND i.itemId = @itemId LIMIT 1", conn);
                cmd.Parameters.AddWithValue("@ownerId", ownerId);
                cmd.Parameters.AddWithValue("@itemId", itemId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        inventory = new Inventory(
                            reader.GetInt32("itemId"),
                            ownerId,
                            reader.GetInt32("amount"),
                            reader.GetString("name")
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
                var cmd = new MySqlCommand("INSERT INTO inventory (itemId, ownerId, amount) VALUES (@itemId, @ownerId, @amount)", conn);
                cmd.Parameters.AddWithValue("@itemId", inventory.ItemId);
                cmd.Parameters.AddWithValue("@ownerId", inventory.OwnerId);
                cmd.Parameters.AddWithValue("@amount", inventory.Amount);

                cmd.ExecuteNonQuery();
            }
        }

        public bool Update(Inventory inventory)
        {
            int rowsAffected;
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("UPDATE inventory SET amount = @amount WHERE itemId = @itemId AND ownerId = @ownerId", conn);
                cmd.Parameters.AddWithValue("@amount", inventory.Amount);
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
