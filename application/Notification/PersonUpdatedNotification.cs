using MediatR;
using application.Models;

namespace application.Notification
{
    public class PersonUpdatedNotification : INotification
    {
        public PersonModel Person { get; set; }
    }
}