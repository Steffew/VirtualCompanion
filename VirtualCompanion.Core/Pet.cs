namespace VirtualCompanion.Core
{
    public class Pet
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public float Health { get; set; }
        public float Experience { get; set; }
        public float Energy { get; set; }
        public float Mood { get; set; }
        public float Hunger { get; set; }
        public float Hygiene { get; set; }

        public Pet(int id, string name, float health, float experience, float energy, float mood, float hunger, float hygiene)
        {
            Id = id;
            Name = name;
            Health = health;
            Experience = experience;
            Energy = energy;
            Mood = mood;
            Hunger = hunger;
            Hygiene = hygiene;
        }
    }
}
