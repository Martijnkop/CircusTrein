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
    public class TestAnimal
    {
        [TestMethod()]
        public void CreateAnimal_NoParameters_Default()
        {
            Animal animal = new();
            Assert.AreEqual(animal.ToString(), "Medium vegan animal\n      Size = Medium\n      Diet = Vegan");
        }

        [TestMethod()]
        public void CreateAnimal_NameParameter()
        {
            Animal animal = new(name: "test");
            Assert.AreEqual(animal.ToString(), "test\n      Size = Medium\n      Diet = Vegan");
        }

        [TestMethod]
        public void CreateAnimal_SizeParameter()
        {
            Animal animal = new(size: Size.Large);
            Assert.AreEqual(animal.ToString(), "Medium vegan animal\n      Size = Large\n      Diet = Vegan");
        }

        [TestMethod]
        public void CreateAnimal_DietParameter()
        {
            Animal animal = new(diet: Diet.Meat);
            Assert.AreEqual(animal.ToString(), "Medium vegan animal\n      Size = Medium\n      Diet = Meat");
        }

        [TestMethod]
        public void CreateAnimal_AllParameters()
        {
            Animal animal = new(name: "test", diet: Diet.Meat, size: Size.Small);
            Assert.AreEqual(animal.ToString(), "test\n      Size = Small\n      Diet = Meat");
        } 
    }
}
