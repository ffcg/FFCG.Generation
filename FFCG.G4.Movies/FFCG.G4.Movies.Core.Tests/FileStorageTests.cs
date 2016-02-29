using System.IO;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G4.Movies.Core.Tests
{
    [TestFixture]
    public class FileStorageTests
    {
        private FileStorage _fileStorage;
        private string _basePath;

        [SetUp]
        public void SetUp()
        {
            _basePath = @"fileStorageTest";
            _fileStorage = new FileStorage(_basePath);
        }

        [Test]
        public void Store_should_save_entity_to_disk()
        {
            var testClass = new TestClass {Id = 1, Name = "Test name", Description = "Test Description"};
            _fileStorage.Store(testClass);

            FileAssert.Exists(_basePath + @"\TestClass\1");
        }

        [Test]
        public void Load_should_load_stored_entity_and_deserialize_it()
        {
            var testClass = new TestClass { Id = 1, Name = "Test name", Description = "Test Description" };
            _fileStorage.Store(testClass);
            var returnedClass = _fileStorage.Load<TestClass>(1);

            returnedClass.ShouldBeEquivalentTo(testClass);
        }

        [Test]
        public void Load_non_existing_should_return_null()
        {
            var returnedClass = _fileStorage.Load<TestClass>(999);
            returnedClass.Should().BeNull();
        }

        [Test]
        public void All_should_return_all_entities_of_given_type()
        {
            var testClass = new TestClass { Id = 1, Name = "Test name", Description = "Test Description" };
            var testClass2 = new TestClass { Id = 2, Name = "Test name 2", Description = "Test Description 2" };

            _fileStorage.Store(testClass);
            _fileStorage.Store(testClass2);

            var testClasses = _fileStorage.All<TestClass>();
            testClasses.ShouldAllBeEquivalentTo(new [] { testClass, testClass2});
        }

        [Test]
        public void Store_existing_should_overwrite_document()
        {
            var testClass = new TestClass { Id = 1, Name = "Test name", Description = "Test Description" };
            var testClass2 = new TestClass { Id = 1, Name = "Test name 2", Description = "Test Description 2" };

            _fileStorage.Store(testClass);
            _fileStorage.Store(testClass2);

            var testClasses = _fileStorage.All<TestClass>();
            testClasses.ShouldAllBeEquivalentTo(new[] { testClass2 });
        }

        [Test]
        public void Delete_should_remove_entity()
        {
            var testClass = new TestClass { Id = 1, Name = "Test name", Description = "Test Description" };

            _fileStorage.Store(testClass);

            FileAssert.Exists(_basePath + @"\TestClass\1");

            _fileStorage.Delete(testClass);

            _fileStorage.Load<TestClass>(1).Should().BeNull();

            FileAssert.DoesNotExist(_basePath + @"\TestClass\1");
        }

        [TearDown]
        public void CleanUp()
        {
            Directory.Delete(_basePath, true);
        }
    }

    public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}