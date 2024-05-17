namespace VirtualCompanion.Core.Entities
{
    public class Pet
    {
        public int Id { get; private set; }
        public int OwnerId { get; private set; }
        public string? Name { get; private set; }
        public float Health { get; private set; }
        public float Experience { get; private set; }
        public float Energy { get; private set; }
        public float Mood { get; private set; }
        public float Hunger { get; private set; }
        public float Hygiene { get; private set; }

        private float minAttributeValue = 0;
        private float maxAttributeValue = 100;

        public Pet(int id, int ownerId, string name, float health, float experience, float energy, float mood, float hunger, float hygiene)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Health = health;
            Experience = experience;
            Energy = energy;
            Mood = mood;
            Hunger = hunger;
            Hygiene = hygiene;
        }

        public void UpdateAttributesByAmount(float experience = 0, float energy = 0, float mood = 0, float hunger = 0, float hygiene = 0)
        {
            Experience += experience;
            Energy += energy;
            Mood += mood;
            Hunger += hunger;
            Hygiene += hygiene;
        }
    }
}
