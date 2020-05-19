using Domain;
using Domain.UseCase;
using Moq;
using Xunit;

namespace IntegrationTests
{
    public class FetchCustomerProfileTest
    {
        [Fact]
        public async void Test()
        {
            var repository = new Mock<ICustomerRepository>();

            var userName = "Some name";

            var customer1 = new Customer(userName);
            
            repository.Setup(r => r.FindByName(It.IsAny<string>())).ReturnsAsync(customer1);
            
            var useCase = new FetchCustomerProfile(repository.Object);

            var response = await useCase.Fetch(userName);

            Assert.Equal(customer1, response);
        }
    }
}