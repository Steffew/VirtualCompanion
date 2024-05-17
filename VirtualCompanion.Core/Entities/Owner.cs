namespace VirtualCompanion.Core.Entities
{
    public class Owner
    {
        public int Id { get; private set; }
        public int Balance { get; private set; }
        public int PetCapacity { get; private set; }

        public Owner(int id, int balance, int petCapacity)
        {
            Id = id;
            Balance = balance;
            PetCapacity = petCapacity;
        }
    }
}