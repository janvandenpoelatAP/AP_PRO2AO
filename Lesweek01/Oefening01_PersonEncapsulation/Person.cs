using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening01_PersonEncapsulation;
public class Person
{
    private string firstName;
    private string lastName;
    private DateTime birthDate;
    private static int instanceCount;
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
        instanceCount++;
    }
    public static int InstanceCount
    {
        get
        {
            return instanceCount;
        }
    }
    public string FullName
    {
        get
        {
            return $"{firstName} {lastName}";
        }
    }
    public int Age
    {
        get
        {
            return DateTime.Now.Year - birthDate.Year;
        }
    }
}
