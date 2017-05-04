using System.Collections.Generic;

namespace FFCG.G5.Storage
{
    public interface IStorage
    {
        T Store<T>(T item);
        T Load<T>(object id) where T : class;
        IEnumerable<T> All<T>();
        void Delete<T>(T item);
    }
}