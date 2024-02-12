using application.Models;

namespace application.DataAccess
{
    public interface IDataAccess
    {
        List<PersonModel> GetPeople();
        PersonModel InsertPerson(string firstName, string lastName);

        PersonModel UpdatePerson(int id, string firstName, string LastName);

        PersonModel DeletePerson(int id);
    }
}