namespace VirtualCompanion.Core.Entities
{
    public class Item
    {
        public int Id { get; private set; }
        public string? Name { get; private set; }
        public int Cost { get; private set; }
        public float Experience { get; private set; }
        public float Energy { get; private set; }
        public float Mood { get; private set; }
        public float Hunger { get; private set; }
        public float Hygiene { get; private set; }

        public Item(int id, string name, int cost, float experience, float energy, float mood, float hunger, float hygiene)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or null.", nameof(name));

            if (cost < 0)
                throw new ArgumentException("Cost must be a non-negative number.", nameof(cost));

            Id = id;
            Name = name;
            Cost = cost;
            Experience = experience;
            Energy = energy;
            Mood = mood;
            Hunger = hunger;
            Hygiene = hygiene;
        }
    }
}
