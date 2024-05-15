namespace VirtualCompanion.Core.Entities
{
    public class Pet
    {
        public int OwnerId { get; set; }
        public string? Name { get; private set; }
        public float Health { get; private set; }
        public float Experience { get; private set; }
        public float Energy { get; private set; }
        public float Mood { get; private set; }
        public float Hunger { get; private set; }
        public float Hygiene { get; private set; }

        public Pet(int ownerId, string name, float health, float experience, float energy, float mood, float hunger, float hygiene)
        {
            OwnerId = ownerId;
            Name = name;
            Health = health;
            Experience = experience;
            Energy = energy;
            Mood = mood;
            Hunger = hunger;
            Hygiene = hygiene;
        }

        public void UseItem(Item item)
        {
            Experience += item.Experience;
            Energy += item.Energy;
            Mood += item.Mood;
            Hunger += item.Hunger;
            Hygiene += item.Hygiene;
        }
    }
}
