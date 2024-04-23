namespace VirtualCompanion.Core
{
    public class Item
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cost { get; set; }
        public float Experience { get; set; }
        public float Energy { get; set; }
        public float Mood { get; set; }
        public float Hunger { get; set; }
        public float Hygiene { get; set; }

        public Item(int id, string name, int cost, float experience, float energy, float mood, float hunger, float hygiene)
        {
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
