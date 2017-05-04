using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace FFCG.G5.Storage
{
    public class GenericStorage : IStorage
    {
        private readonly DirectoryInfo _base;
        
        public GenericStorage(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            _base = new DirectoryInfo(path);
        }
        
        public T Store<T>(T item)
        {
            EnsureStorageFolder<T>();

            object id = FetchId(item);

            var serialized = JsonConvert.SerializeObject(item, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var itemDirectory = GetItemDirectory<T>();
            var targetFilePath = Path.Combine(itemDirectory.FullName, id.ToString());
            
            File.WriteAllText(targetFilePath, serialized);

            return item;
        }

        public T Load<T>(object id) where T : class
        {
            var itemDirectory = GetItemDirectory<T>();
            var targetFilePath = Path.Combine(itemDirectory.FullName, id.ToString());

            if (!File.Exists(targetFilePath))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(targetFilePath));
        }

        public IEnumerable<T> All<T>()
        {
            var itemDirectory = GetItemDirectory<T>();
            foreach (var fileInfo in itemDirectory.GetFiles())
            {
                yield return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileInfo.FullName));
            }
        }

        public void Delete<T>(T item)
        {
            var itemDirectory = GetItemDirectory<T>();
            var filePath = Path.Combine(itemDirectory.FullName, item.GetId().ToString());

            if (!File.Exists(filePath))
            {
                return;
            }

            File.Delete(filePath);
        }

        private void EnsureStorageFolder<T>()
        {
            var itemFolder = GetItemDirectory<T>();

            if (!itemFolder.Exists)
            {
                itemFolder.Create();
            }
        }

        private object FetchId(object item)
        {
            var value = item.GetId();

            if (value == null)
            {
                var idProperty = item.GetIdProperty();
                value = TryGenerateId(idProperty);
                if (value == null)
                {
                    throw new InvalidOperationException("Can not generate id, please provide one");
                }

                idProperty.SetValue(item, value);
            }

            return value;
        }

        private object TryGenerateId(PropertyInfo idProperty)
        {
            if (idProperty.PropertyType == typeof(string))
            {
                return Guid.NewGuid().ToString();
            }

            if (idProperty.PropertyType == typeof(Guid))
            {
                return Guid.NewGuid();
            }

            return null;
        }

        private DirectoryInfo GetItemDirectory<T>()
        {
            var name = typeof(T).Name;
            var itemFolder = new DirectoryInfo(Path.Combine(_base.FullName, name));
            return itemFolder;
        }
    }
}