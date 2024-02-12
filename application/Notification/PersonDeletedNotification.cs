using MediatR;

namespace application.Notification
{
    public class PersonDeletedNotification : INotification
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}