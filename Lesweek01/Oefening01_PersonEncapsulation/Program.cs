using Oefening01_PersonEncapsulation;

var person = new Person("Dimitri", "Sturm", new DateTime(1984, 06, 22));
Console.WriteLine($"{person.FullName} is {person.Age} jaar ");
Console.WriteLine($"Aantal instanties: {Person.InstanceCount}");
Console.ReadKey();