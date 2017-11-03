using System.Collections.Generic;

namespace FFCG.G5.Storage
{
public interface IContactStorage
{
    Contact Store(Contact contact);
    IEnumerable<Contact> All();
    void Delete(Contact contact);
}
}