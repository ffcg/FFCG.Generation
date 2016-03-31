using System;
using FFCG.Generation.DocumentDatabase.Models;
using Raven.Client.Document;

namespace FFCG.Generation.DocumentDatabase.Raven
{
    class Program
    {
        static void Main(string[] args)
        {
            var documentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Demo"
            };

            documentStore.Initialize();

            using (var session = documentStore.OpenSession())
            {
                var employee = session.Load<Employee>("employees/1");
                
                Console.WriteLine("Name: {0} {1}", employee.FirstName, employee.LastName);
            }
        }
    }
}