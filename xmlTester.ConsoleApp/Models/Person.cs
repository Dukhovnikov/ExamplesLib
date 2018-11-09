using System.Collections.Generic;

namespace xmlTester.ConsoleApp.Models
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public static class PersonService
    {
        public static readonly IEnumerable<Person> Persons = new List<Person>()
        {
            new Person() {Age = 23, Name = "Alex"},
            new Person() {Age = 30, Name = "Mike"}
        };
    }
}