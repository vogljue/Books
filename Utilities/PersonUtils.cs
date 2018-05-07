using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Books.Entities;

namespace Books.Utilities
{
    public class PersonUtils
    {
            private static List<Person> Persons = new List<Person>()
            {
                new Person() {
                    Id = 1,
                    Lastname = "Miller",
                    Firstname = "Floyd",
                    Address = "Wood Road",
                    EmailAddress = "miller@acme.com",
                    Country = "USA"
                },
                new Person() {
                    Id = 2,
                    Lastname = "Smith",
                    Firstname = "Henry",
                    Address = "Picadelly Road",
                    EmailAddress = "smith@acme.com",
                    Country = "UK"
                },
                new Person() {
                    Id = 3,
                    Lastname = "Gold",
                    Firstname = "Seth",
                    Address = "West Road",
                    EmailAddress = "gold@acme.com",
                    Country = "DE"
                }
            };

        public static void PrintList()
        {
            Console.WriteLine("All Persons ---");
            foreach (Person item in Persons)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("UK Persons ---");
            List<Person> ukPersons = Persons.FindAll(c => c.Country.Equals("UK"));
            foreach (Person p in ukPersons)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("USA Persons ---");
            IEnumerable<Person> usaPersons = from p in Persons where p.Country.Equals("USA") select p;
            foreach (Person p in usaPersons)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("Xml Persons ---");
            using (StringWriter stringWriter = new StringWriter())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
                xmlSerializer.Serialize(stringWriter, Persons);
                Console.WriteLine(stringWriter.ToString());
            }
        }
    }
}
