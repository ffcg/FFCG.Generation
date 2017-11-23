using System.Collections.Generic;

namespace FFCG.Generation.Collector
{
    public class DataCollector
    {
        private class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private readonly List<Person> _persons = new List<Person>();

        public void CollectData(string name, int age)
        {
            var person = new Person
            {
                Name = name,
                Age = age
            };

            _persons.Add(person);
        }

        public void PresentData(IPresenter presenter)
        {
            foreach (var person in _persons)
            {
                presenter.Present(person.Name, person.Age);
            }
        }
    }
}