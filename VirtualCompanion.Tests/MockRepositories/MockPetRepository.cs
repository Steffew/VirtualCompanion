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
        _pets.Add(pet);
    }


    public bool Update(Pet pet)
    {
        var existingPet = _pets.FirstOrDefault(p => p.Id == pet.Id);
        if (existingPet != null)
        {
            existingPet.SetAttributes(pet.Health, pet.Hunger, pet.Energy, pet.Mood, pet.Hygiene, pet.Experience, false);

            return true;
        }
        return false;
    }

    public bool Delete(int id)
    {
        var pet = _pets.FirstOrDefault(p => p.Id == id);
        if (pet == null) return false;

        _pets.Remove(pet);
        return true;
    }
}
