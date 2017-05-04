using System;
using System.Diagnostics;
using System.Linq;
using FFCG.G5.Storage.Models;
using NUnit.Framework;

namespace FFCG.G5.Storage.Tests
{
    [TestFixture]
    public class GenericStorageTests
    {
        private IStorage _storage;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _storage = new GenericStorage(@"D:\temp\generic");
        }

        [Test]
        public void Store_Contact()
        {
            var contact = new Contact
            {
                Name = "Jens",
                Age = 36
            };

            _storage.Store(contact);
        }

        [Test]
        public void Store_Company()
        {
            var company = new Company
            {
                Id = "company-id",
                Name = "My company"
            };

            _storage.Store(company);
        }

        [Test]
        public void Delete_company()
        {
            var company = _storage.Load<Company>("company-id");

            if (company != null)
            {
                _storage.Delete(company);
            }
        }

        [Test]
        public void Store_many_Companies()
        {
            var stopwatch = Stopwatch.StartNew();
            for (int i = 1; i < 1000; i++)
            {
                var company = new Company
                {
                    Id = i.ToString(),
                    Name = $"Company-{i}"
                };

                _storage.Store(company);
            }

            stopwatch.Stop();
            Console.WriteLine($"Storing took: {stopwatch.Elapsed}");
        }

        [Test]
        public void GetAll_Companies()
        {
            var companies = _storage.All<Company>().ToList();
        }
    }
}
