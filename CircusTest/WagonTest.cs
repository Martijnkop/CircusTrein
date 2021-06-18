using CircusTrein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTest
{
    [TestClass()]
    public class WagonTest
    {
        [TestMethod()]
        public void TestWagonProperties()
        {
            Animal testAnimal = new("TestAnimal", Size.Large, Diet.Meat);
            Wagon w = new(testAnimal);

            Assert.AreEqual(w.SpacesLeft, w.MAXSIZE - (int)Size.Large);

            Assert.AreEqual(w.GetAnimals.Count, 1);

            Assert.IsFalse(w.CheckAndAddAnimal(testAnimal));

            Assert.AreEqual(w.SpacesLeft, w.MAXSIZE - (int)Size.Large);

            Assert.AreEqual(w.GetAnimals.Count, 1);

            Assert.IsFalse(w.CheckAndAddAnimal(new Animal()));
        }

        [TestMethod]
        public void CheckAndAddAnimal_Valid()
        {
            Animal testAnimal = new("TestAnimal", Size.Small, Diet.Meat);
            Wagon w = new(testAnimal);

            Animal add2 = new("test", Size.Large, Diet.Vegan);
            bool res = w.CheckAndAddAnimal(add2);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void CheckAndAddAnimal_Invalid_Size()
        {
            Animal testAnimal = new("TestAnimal", Size.Small, Diet.Meat);
            Wagon w = new(testAnimal);

            Animal add2 = new("test", Size.Large, Diet.Vegan);
            w.CheckAndAddAnimal(add2);
            bool res = w.CheckAndAddAnimal(add2);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void CheckAndAddAnimal_Invalid_Diet()
        {
            Animal testAnimal = new("TestAnimal", Size.Small, Diet.Meat);
            Wagon w = new(testAnimal);

            Animal add2 = new("test", Size.Small, Diet.Vegan);
            bool res = w.CheckAndAddAnimal(add2);

            Assert.IsFalse(res);
        }
    }
}
