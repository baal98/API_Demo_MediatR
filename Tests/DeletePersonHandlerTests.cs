using application.Commands;
using application.DataAccess;
using application.Handlers;
using application.Models;
using Moq;

namespace Tests
{
    // Test class for DeletePersonHandler
    [TestFixture]
    public class DeletePersonHandlerTests
    {
        [Test]
        public async Task DeletePersonCommand_Should_RemovePerson()
        {
            // Arrange
            var mockDataAccess = new Mock<IDataAccess>();
            var handler = new DeletePersonHandler(mockDataAccess.Object);
            var command = new DeletePersonCommand(1);

            mockDataAccess.Setup(m => m.DeletePerson(It.IsAny<int>()))
                .Returns(new PersonModel { Id = 1, FirstName = "John", LastName = "Doe" });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(command.Id, result.Id);
            mockDataAccess.Verify(m => m.DeletePerson(command.Id), Times.Once);
        }
    }
}
