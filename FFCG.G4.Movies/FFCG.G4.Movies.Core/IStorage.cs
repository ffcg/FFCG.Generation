using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FFCG.G4.Movies.Core
{
    public interface IStorage
    {
        T Load<T>(object id);
        void Store(object obj);
        IEnumerable<T> All<T>();
        void Delete(object obj);
    }

    public class FileStorage : IStorage
    {
        private readonly string _basePath;

        public FileStorage(string basePath)
        {
            _basePath = basePath;
            if (!Directory.Exists(_basePath))
                Directory.CreateDirectory(_basePath);
        }
        
        public void Store(object obj)
        {
            var serializeObject = SerializeObject(obj);
            var id = GetObjectId(serializeObject);

            var path = GetPath(obj);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var documentPath = Path.Combine(path, id.ToString());

            File.WriteAllText(documentPath, serializeObject);
        }

        private string GetPath(object obj)
        {
            var typeName = obj.GetType().Name;
            return Path.Combine(_basePath, typeName);
        }

        private static JToken GetObjectId(string serializeObject)
        {
            var jToken = JToken.Parse(serializeObject);
            var id = jToken["Id"];
            return id;
        }

        private static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public IEnumerable<T> All<T>()
        {
            var typeName = typeof(T).Name;
            var files = Directory.GetFiles(Path.Combine(_basePath, typeName));
            foreach (var documentPath in files)
            {
                if (!File.Exists(documentPath))
                    yield return default(T);

                var json = File.ReadAllText(documentPath);
                yield return JsonConvert.DeserializeObject<T>(json);
            }
        }

        public T Load<T>(object id)
        {
            var typeName = typeof (T).Name;
            var documentPath = Path.Combine(_basePath, typeName, id.ToString());

            if (!File.Exists(documentPath))
                return default(T);

            var json = File.ReadAllText(documentPath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Delete(object obj)
        {
            var serializeObject = SerializeObject(obj);
            var id = GetObjectId(serializeObject);

            var path = GetPath(obj);

            var documentPath = Path.Combine(path, id.ToString());

            if (File.Exists(documentPath))
            {
                File.Delete(documentPath);
            }
        }
    }
}