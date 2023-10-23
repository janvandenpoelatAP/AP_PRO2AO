using Oefening02_PersonsMVC.Entities;

namespace Oefening02_PersonsMVC.Services;

public class InMemoryPersonData : IPersonData
{
    static List<Person> persons;

    static InMemoryPersonData()
    {
        persons = new List<Person>
        {
            new Person {Id = 1, FirstName = "Jan", LastName = "Janssens", Gender = Gender.M},
            new Person {Id = 2, FirstName = "Piet", LastName = "Pieters", Gender = Gender.M}
        };
    }

    public IEnumerable<Person> GetAll()
    {
        return persons;
    }

    public Person Get(long id)
    {
        return persons.FirstOrDefault(x => x.Id == id);
    }

    public Person Add(Person newPerson)
    {
        newPerson.Id = persons.Max(x => x.Id) + 1;
        persons.Add(newPerson);

        return newPerson;
    }
}
