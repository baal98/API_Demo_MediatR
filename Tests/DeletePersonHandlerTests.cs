using application.Commands;
using application.DataAccess;
using application.Handlers;
using application.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class DeletePersonHandlerTests
    {
        [Test]
        public async Task DeletePersonCommand_Should_RemovePerson()
        {
            // Arrange
            var mockDataAccess = new Mock<IDataAccess>();
            var mockMediator = new Mock<IMediator>();
            var logger = new Mock<ILogger<DeletePersonHandler>>();
            var handler = new DeletePersonHandler(mockDataAccess.Object, mockMediator.Object, logger.Object);
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