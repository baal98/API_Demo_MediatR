using application.Notification;
using MediatR;

namespace application.Handlers
{
    public class PersonUpdatedNotificationHandler : INotificationHandler<PersonUpdatedNotification>
    {
        public async Task Handle(PersonUpdatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Person updated: {notification.Person.FirstName} {notification.Person.LastName}");
            await Task.CompletedTask;
        }
    }
}