namespace VirtualCompanion.Core
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
    }
}
