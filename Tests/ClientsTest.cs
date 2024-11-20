using ClientsMicroservice.Models;
using ClientsMicroservice.Repositories;
using Moq;

namespace Tests
{
    public class ClientsTest
    {
        [Fact]
        public async Task GetAllAsync()
        {
            var mockRepo = new Mock<Repository<Client>>();

            mockRepo.Setup(repo => repo.GetAllAsync()).Returns(
                Task.FromResult<IEnumerable<Client>>(new List<Client>
            {
                new() { Id = 1, Name = "Mayte Baez", Gender = "Femenino", Age = 27,
                            DocumentNumber = "1275635632", Address = "Quito", PhoneNumber = "20563256",
                            Password = "1234", State = true },
                new() { Id = 2, Name = "Product2" }
            }));

            var repository = mockRepo.Object;

            var clients = await repository.GetAllAsync();

            Assert.Equal(2, clients.Count());
        }
    }
}