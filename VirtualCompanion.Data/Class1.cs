using MySql.Data.MySqlClient;
using VirtualCompanion.Core.Entities;
using VirtualCompanion.Core.Interfaces;

namespace VirtualCompanion.Data
{
    public class ItemRepository : IItemRepository
    {
        private readonly string _connectionString;

        public ItemRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Item> GetAllItems()
        {
            var items = new List<Item>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM item", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(new Item(
                            reader.GetInt32("id"),
                            reader.GetInt32("cost"),
                            reader.GetFloat("experience"),
                            reader.GetFloat("energy"),
                            reader.GetFloat("mood"),
                            reader.GetFloat("hunger"),
                            reader.GetFloat("hygiene")));
                    }
                }
            }
            return items;
        }

        public Item GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateItem(Item item)
        {
            throw new NotImplementedException();
        }
        public bool DeleteItem(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
