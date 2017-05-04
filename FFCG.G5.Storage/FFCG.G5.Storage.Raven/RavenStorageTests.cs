using System;
using System.Diagnostics;
using FFCG.G5.Storage.Models;
using NUnit.Framework;
using Raven.Client.Document;

namespace FFCG.G5.Storage.Raven
{
    [TestFixture]
    public class RavenStorageTests
    {
        private DocumentStore _documentStore;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _documentStore = new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "G5.Demo"
            };

            _documentStore.Initialize(true);
        }

        [Test]
        public void Store_Company()
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(new Company
                {
                    Name = "Jens Company"
                });

                session.Store(new Company
                {
                    Name = "Jens Second Company"
                });


                session.SaveChanges();
            }
        }

        [Test]
        public void Load_Company()
        {
            
        }

        [Test]
        public void Delete_company()
        {
        }

        [Test]
        public void Store_many_Companies()
        {
            
        }
    }
}