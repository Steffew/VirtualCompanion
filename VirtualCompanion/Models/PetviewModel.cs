namespace VirtualCompanion.Models
{
    public class PetViewModel
    {
        public int OwnerId { get; set; }
        public string Name { get; set; }
        public float Health { get; set; }
        public float Experience { get; set; }
        public float Energy { get; set; }
        public float Mood { get; set; }
        public float Hunger { get; set; }
        public float Hygiene { get; set; }
    }

    public class PetListViewModel
    {
        public List<PetViewModel> Pets { get; set; } = new List<PetViewModel>();
    }
}
