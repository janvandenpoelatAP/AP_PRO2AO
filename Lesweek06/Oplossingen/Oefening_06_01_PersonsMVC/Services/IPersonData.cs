using Oefening_06_01_PersonsMVC.Entities;

namespace Oefening_06_01_PersonsMVC.Services;
public interface IPersonData
{
    IEnumerable<Person> GetAll();
    Person Get(long id);
    Person Add(Person newPerson);
    void Delete(long id);
    void Update(Person newPerson);
}
