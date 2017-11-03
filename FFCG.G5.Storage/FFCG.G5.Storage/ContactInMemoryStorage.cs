using System;
using System.Collections.Generic;
using System.Linq;

namespace FFCG.G5.Storage
{
    public class ContactInMemoryStorage : IContactStorage
    {
        private readonly List<Contact> _contacts;

        public ContactInMemoryStorage()
        {
            _contacts = new List<Contact>();
        }

        public Contact Store(Contact contact)
        {
            if (_contacts.Any(x => x.Id == contact.Id))
            {
                throw new Exception("Contact already exists!");
            }

            _contacts.Add(contact);
            return contact;
        }

        public IEnumerable<Contact> All()
        {
            return _contacts;
        }

        public void Delete(Contact contact)
        {
            _contacts.RemoveAll(x => x.Id == contact.Id);
        }
    }
}