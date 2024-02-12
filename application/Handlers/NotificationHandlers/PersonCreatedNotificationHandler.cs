using application.Notifications;
using MediatR;

namespace application.Handlers.NotificationHandlers
{
    public class PersonCreatedNotificationHandler : INotificationHandler<PersonCreatedNotification>
    {
        public async Task Handle(PersonCreatedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"New person created: {notification.Person.FirstName} {notification.Person.LastName}");
            await Task.CompletedTask;
        }
    }
}