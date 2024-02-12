using application.Models;

namespace application.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private List<PersonModel> people = new();

        public DataAccess()
        {
            people.Add(new PersonModel { Id = 1, FirstName = "Dimo", LastName = "Todorov" });
            people.Add(new PersonModel { Id = 2, FirstName = "Nushka", LastName = "Ivanova" });
        }

        public List<PersonModel> GetPeople()
        {
            return people;
        }

        public PersonModel InsertPerson(string firstName, string lastName)
        {
            PersonModel person = new PersonModel { FirstName = firstName, LastName = lastName };
            person.Id = people.Max(p => p.Id) + 1;
            people.Add(person);
            return person;
        }

        public PersonModel UpdatePerson(int id, string firstName, string lastName)
        {
            var person = people.FirstOrDefault(x => x.Id == id);

            if (person != null)
            {
                person.FirstName = firstName;
                person.LastName = lastName;
                person.Id = id;
            }
            return person;
        }

        public PersonModel DeletePerson(int id)
        {
            var person = people.FirstOrDefault(x => x.Id == id);

            if (person != null)
            {
                people.Remove(person);
                return person;
            }

            return person;
        }
    }
}