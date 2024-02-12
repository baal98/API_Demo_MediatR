using application.DataAccess;
using application.Handlers;
using application.Models;
using application.Queries;
using Moq;

namespace Tests
{
    // Test class for GetPersonListHandler
    [TestFixture]
    public class GetPersonListHandlerTests
    {
        [Test]
        public async Task GetPersonListQuery_Should_ReturnAllPeople()
        {
            // Arrange
            var mockDataAccess = new Mock<IDataAccess>();
            var handler = new GetPersonListHandler(mockDataAccess.Object);
            var query = new GetPersonListQuery();

            var peopleList = new List<PersonModel>
            {
                new PersonModel { Id = 1, FirstName = "John", LastName = "Doe" },
                new PersonModel { Id = 2, FirstName = "Jane", LastName = "Doe" }
            };

            mockDataAccess.Setup(m => m.GetPeople())
                .Returns(peopleList);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(2, result.Count());
            mockDataAccess.Verify(m => m.GetPeople(), Times.Once);
        }
    }
}
