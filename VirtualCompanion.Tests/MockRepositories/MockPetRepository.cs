public class MockPetRepository : IPetRepository
{
    private readonly List<Pet> _pets;

    public MockPetRepository(List<Pet> pets)
    {
        _pets = pets;
    }

    public List<Pet> GetAll()
    {
        return _pets;
    }

    public List<Pet> GetAll(int ownerId)
    {
        return _pets.Where(p => p.OwnerId == ownerId).ToList();
    }

    public Pet Get(int id)
    {
        return _pets.FirstOrDefault(p => p.Id == id);
    }

    public void Add(Pet pet)
    {
        var maxId = _pets.Max(p => p.Id);
        pet.Id = maxId + 1;
        _pets.Add(pet);
    }

    public bool Update(Pet pet)
    {
        var existingPet = _pets.FirstOrDefault(p => p.Id == pet.Id);
        if (existingPet == null) return false;

        existingPet.Name = pet.Name;
        existingPet.Health = pet.Health;
        existingPet.Experience = pet.Experience;
        existingPet.Energy = pet.Energy;
        existingPet.Mood = pet.Mood;
        existingPet.Hunger = pet.Hunger;
        existingPet.Hygiene = pet.Hygiene;
        return true;
    }

    public bool Delete(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet == null) return false;

        _pets.Remove(pet);
        return true;
    }
}
