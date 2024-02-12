using application.Commands;
using application.DataAccess;
using application.Handlers;
using application.Models;
using MediatR;
using Moq;

namespace Tests
{
    [TestFixture]
    public class InsertPersonHandlerTests
    {
        [Test]
        public async Task InsertPersonCommand_Should_InsertPerson()
        {
            // Arrange
            var mockDataAccess = new Mock<IDataAccess>();
            var mockMediator = new Mock<IMediator>();
            var handler = new InsertPersonHandler(mockDataAccess.Object, mockMediator.Object);
            var command = new InsertPersonCommand("John", "Doe");
            var expectedPerson = new PersonModel { FirstName = "John", LastName = "Doe" };

            mockDataAccess.Setup(m => m.InsertPerson(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expectedPerson);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedPerson.FirstName, result.FirstName);
            Assert.AreEqual(expectedPerson.LastName, result.LastName);
            mockDataAccess.Verify(m => m.InsertPerson(command.FirstName, command.LastName), Times.Once);
        }
    }
}