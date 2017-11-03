using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFCG.G5.Storage.Host
{
    class Program
    {
        private static IContactStorage _storage;

        static void Main(string[] args)
        {
            _storage = new ContactDiskStorage(@"D:\temp\contacts");
            while (true)
            {
                Console.Write("\nPress 1 to create new contact and 2 to load contacts: ");
                var line = Console.ReadLine();

                switch (line)
                {
                    case "1":
                        CreateNewContact();
                        break;
                    case "2":
                        LoadAllContacts();
                        break;
                }

                if (line == "x")
                    break;
            }
        }

        private static void LoadAllContacts()
        {
            var contacts = _storage.All().ToList();

            Console.WriteLine($"Found {contacts.Count}");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"\tName: {contact.Name} \tAge:{contact.Age}");
            }
        }

        private static void CreateNewContact()
        {
            Console.Write("Enter name: ");
            var name = Console.ReadLine();

            Console.Write("Enter age: ");
            var age = int.Parse(Console.ReadLine());

            var contact = new Contact
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = name,
                Age = age
            };

            var storedContact = _storage.Store(contact);

            Console.WriteLine($"Stored contact with id: {storedContact.Id}");
        }
    }
}
