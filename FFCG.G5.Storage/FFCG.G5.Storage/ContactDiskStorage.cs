using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace FFCG.G5.Storage
{
    public class ContactDiskStorage : IContactStorage
    {
        private readonly string _basePath;

        public ContactDiskStorage(string basePath)
        {
            _basePath = basePath;

            if (!Directory.Exists(_basePath))
            {
                Directory.CreateDirectory(_basePath);
            }
        }

        public Contact Store(Contact contact)
        {
            //Todo: Fix validation of already existing file with id!
            var serialized = JsonConvert.SerializeObject(contact);

            var filePath = Path.Combine(_basePath, contact.Id);
            File.WriteAllText(filePath, serialized);

            return contact;
        }

        public IEnumerable<Contact> All()
        {
            var contacts = new List<Contact>();
            foreach (var filePath in Directory.GetFiles(_basePath))
            {
                var fileContent = File.ReadAllText(filePath);

                var contact = JsonConvert.DeserializeObject<Contact>(fileContent);

                contacts.Add(contact);
            }
            return contacts;
        }

        public void Delete(Contact contact)
        {
            
        }
    }
}
