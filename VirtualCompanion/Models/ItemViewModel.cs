namespace VirtualCompanion.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cost { get; set; }
        public float Health { get; set; }
        public float Hunger { get; set; }
        public float Energy { get; set; }
        public float Mood { get; set; }
        public float Hygiene { get; set; }
        public float Experience { get; set; }
    }

    public class ItemListViewModel
    {
        public List<ItemViewModel> Pets { get; set; } = new List<ItemViewModel>();
    }
}
