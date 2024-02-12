using application.Notification;
using MediatR;

namespace application.Handlers.NotificationHandlers
{
    public class PersonDeletedNotificationHandler : INotificationHandler<PersonDeletedNotification>
    {
        public async Task Handle(PersonDeletedNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Person deleted: {notification.FirstName} {notification.LastName}");
            await Task.CompletedTask;
        }
    }
}