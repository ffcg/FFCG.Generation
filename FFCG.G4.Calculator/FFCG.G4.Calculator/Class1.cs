using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace FFCG.G4.Calculator
{
    [TestFixture]
    public class className
    {
        [TestFixtureSetUp]
        public void TestFixtureSetUp()
        {
            
            
        }


        [Test]
        public void FooTest()
        {
            double[,] d = new double[1,2];
            Addition addition = 1, 2, 3, 4;
            //addition.Add(1);
            addition.Result.Should().Be(3);
        }
    }

    public interface IDoAddition
    {
        
    }

    public class Addition
    {
        public List<double> Terms { get; set; }

        public Addition StartsWith(double x)
        {
            Terms.Add(x);
            return this;
        }

        public Addition Add(double x)
        {
            Terms.Add(x);
            return this;
        }

        private readonly double _start;
        //public static implicit operator Addition(params object[] args)
        //{
        //    var addition = new Addition(0);

        //    return addition;
        //}

        //private Addition(double x)
        //{
        //    _start = x;
        //    Terms = new List<double>();
        //}

        public double Result
        {
            get
            {
                return Terms.Sum(x => x) + _start;
            }
        }

        public double Calculate(List<double> terms)
        {
            var sum = terms.Sum(x => x);
            return sum;
        }
    }
}
