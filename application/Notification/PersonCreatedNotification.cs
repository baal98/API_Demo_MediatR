using MediatR;
using application.Models;

namespace application.Notifications
{
    public class PersonCreatedNotification : INotification
    {
        public PersonModel Person { get; set; }
    }
}