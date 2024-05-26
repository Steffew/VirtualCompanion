
namespace VirtualCompanion.Test
{
    public class PetTests
    {
        [Fact]
        public void GetAllPets_ReturnsAllPets()
        {
            // Arrange
            var pets = new List<Pet>
            {
                new Pet(id: 1, ownerId: 1, "Pet1", health: 50, experience: 20, energy: 60, mood: 80, hunger: 70, hygiene: 90),
                new Pet(id: 2, ownerId: 1, "Pet1", health: 60, experience: 30, energy: 70, mood: 90, hunger: 20, hygiene: 10),
            };
            var mockRepository = new MockPetRepository(pets);
            var petService = new PetService(mockRepository);

            // Act
            var result = petService.GetAllPets();

            // Assert
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void GetAllPetsByOwner_ReturnsCorrectPets()
        {
            // Arrange
            var pets = new List<Pet>
            {
                new Pet(id: 1, ownerId: 1, "Pet1", health: 50, experience: 20, energy: 60, mood: 80, hunger: 70, hygiene: 90),
                new Pet(id: 2, ownerId: 2, "Pet2", health: 60, experience: 30, energy: 70, mood: 90, hunger: 20, hygiene: 10),
            };
            var mockRepository = new MockPetRepository(pets);
            var petService = new PetService(mockRepository);

            // Act
            var result = petService.GetAllPets(1);

            // Assert
            Assert.Single(result);
            Assert.Equal("Pet1", result.First().Name);
        }

        [Fact]
        public void GetPet_ReturnsCorrectPet()
        {
            // Arrange
            var pets = new List<Pet>
            {
                new Pet(id: 1, ownerId: 1, "Pet1", health: 50, experience: 20, energy: 60, mood: 80, hunger: 70, hygiene: 90),
            };
            var mockRepository = new MockPetRepository(pets);
            var petService = new PetService(mockRepository);

            // Act
            var result = petService.GetPet(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pet1", result.Name);
        }
    }
}
