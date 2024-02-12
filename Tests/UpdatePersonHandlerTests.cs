using application.Commands;
using application.DataAccess;
using application.Handlers;
using application.Models;
using MediatR;
using Moq;

namespace Tests
{
    [TestFixture]
    public class UpdatePersonHandlerTests
    {
        [Test]
        public async Task UpdatePersonCommand_Should_UpdatePerson()
        {
            // Arrange
            var mockDataAccess = new Mock<IDataAccess>();
            var mockMediator = new Mock<IMediator>();
            var handler = new UpdatePersonHandler(mockDataAccess.Object, mockMediator.Object);
            var command = new UpdatePersonCommand(1, "Jane", "Doe");

            mockDataAccess.Setup(m => m.UpdatePerson(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new PersonModel { Id = 1, FirstName = "Jane", LastName = "Doe" });

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(command.FirstName, result.FirstName);
            Assert.AreEqual(command.LastName, result.LastName);
            mockDataAccess.Verify(m => m.UpdatePerson(command.Id, command.FirstName, command.LastName), Times.Once);
        }
    }
}