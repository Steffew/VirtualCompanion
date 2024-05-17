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
        public bool IsAlive { get; private set; } = true;

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

        public void UpdateAttributesByAmount(float health = 0, float hunger = 0, float energy = 0, float mood = 0, float hygiene = 0, float experience = 0)
        {
            Health += health;
            Hunger += hunger;
            Energy += energy;
            Mood += mood;
            Hygiene += hygiene;
            Experience += experience;

            ValidateAttributes();
            CheckHealth();
        }

        private void SetAttributes(float health = 0, float hunger = 0, float energy = 0, float mood = 0, float hygiene = 0, float experience = 0)
        {
            Health = health;
            Hunger = hunger;
            Energy = energy;
            Mood = mood;
            Hygiene = hygiene;
            Experience = experience;
        }

        private void ValidateAttributes()
        {
            Health = Math.Clamp(Health, 0, 100);
            Energy = Math.Clamp(Energy, 0, 100);
            Mood = Math.Clamp(Mood, 0, 100);
            Hunger = Math.Clamp(Hunger, 0, 100);
            Hygiene = Math.Clamp(Hygiene, 0, 100);
        }

        private void CheckHealth()
        {
            if (Health <= 0 && IsAlive)
            {
                HandleDeath();
            }
        }

        private void HandleDeath()
        {
            IsAlive = false;
        }
    }
}
