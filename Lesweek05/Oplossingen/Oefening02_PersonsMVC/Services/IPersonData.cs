using Oefening02_PersonsMVC.Entities;

namespace Oefening02_PersonsMVC.Services;

public interface IPersonData
{
    IEnumerable<Person> GetAll();
    Person Get(long id);
    Person Add(Person newPerson);
}
