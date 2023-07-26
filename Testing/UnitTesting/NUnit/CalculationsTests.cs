
using Calculations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnit
{
    [TestFixture]
    public class CalculationsTests
    {
        Calculator calculations;
        [SetUp]
        public void SetUp() 
        {
             calculations = new Calculator(100, 100);
            Console.WriteLine("SetUp");
        }
        [TestCase(10,20,Author = "Maha",Description ="Addition")]
        [TestCase(-10, -20, Author = "Maha", Description = "Addition")]
        [Order(1)]
        public void AddTest(int n1,int n2)
        {
          //  Console.WriteLine("Add");
            calculations = new Calculator(n1,n2);
            int result=  calculations.Add();
            Assert.AreEqual(n1+n2, result);
        }
        [Test]
        [Order(2)]
        //[Ignore("In Progress", Until ="2023-07-12")]
        public void SubTest()
        {
            Console.WriteLine("Sub");
            //Calculations calculations = new Calculations(100, 100);
            int result = calculations.Sub();
            Assert.AreEqual(0, result);
        }
        [Test]
        [Order(3)]
        public void MulTest()
        {
            Console.WriteLine("Mul");
            //Calculations calculations = new Calculations(100, 100);
            int result = calculations.Mul();
            Assert.AreEqual(10000, result);
        }

        [TearDown] 
        public void TearDown() 
        {
            Console.WriteLine("Teardown");
            calculations = null;
        }
    }
}
