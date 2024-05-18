namespace VirtualCompanion.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly string _connectionString;

        public OwnerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
