using Microsoft.EntityFrameworkCore;

namespace Oefening_7_1_EFMigrations;

internal class Program
{
    static void Main(string[] args)
    {
        AddPerson();
        Console.WriteLine();
        ShowData();
        Console.ReadKey();
    }

    private static void ShowData()
    {
        var city = ReadWithLabel("Show people for city");
        using (var context = new PersonContext())
        {
            var people = context.People.Include(x => x.Address).Where(x => x.Address.City == city).ToList();
            foreach (var person in people)
            {
                Console.WriteLine($"FirstName: {person.FirstName}\tLastName: {person.LastName}\tStreet: {person.Address.Street}\tCity: {person.Address.City}");
            }
        }
    }

    private static void AddPerson()
    {
        Console.WriteLine("Enter a new person");
        Console.WriteLine("------------------\n");
        var person = new Person
        {
            FirstName = ReadWithLabel("FirstName"),
            LastName = ReadWithLabel("LastName"),
            Address = new Address
            {
                Street = ReadWithLabel("Street"),
                City = ReadWithLabel("City")
            }
        };

        using (var context = new PersonContext())
        {
            context.People.Add(person);
            context.SaveChanges();
        }
    }

    private static string ReadWithLabel(string message)
    {
        Console.Write($"{message}: ");
        return Console.ReadLine();
    }
}
