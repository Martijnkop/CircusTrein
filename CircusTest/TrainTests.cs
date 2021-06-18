using CircusTrein;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTest
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void AddAnimal_Test()
        {
            Animal animal = new();
            Train t = new();
            t.AddAnimal(animal);
            Assert.AreEqual(t.TotalAnimals, 1);
        }

        [TestMethod]
        public void SortAnimals_WithNoAnimals_SameAsBefore()
        {
            Train t = new();
            IReadOnlyList<Wagon> wagons = t.GetWagons;
            IReadOnlyList<Animal> animals = t.GetUnsortedAnimals;

            t.SortAnimals();

            Assert.AreEqual(wagons, t.GetWagons);
            Assert.AreEqual(animals, t.GetUnsortedAnimals);
        }

        [TestMethod]
        public void SortAnimals_WithAnimals_Sorted()
        {
            Train t = new();
            Animal animal = new();
            t.AddAnimal(animal);

            IReadOnlyList<Wagon> wagons = t.GetWagons;

            t.SortAnimals();
            IReadOnlyList<Animal> animals = t.GetUnsortedAnimals;

            Assert.AreEqual(animal, t.GetWagons[0].GetAnimals[0]);
            Assert.IsNull(animals);
        }

        [TestMethod]
        public void SortAnimals_WithSortedAndUnsorted_Sorted()
        {
            Train t = new();
            Animal animal = new();
            t.AddAnimal(animal);

            IReadOnlyList<Wagon> wagons = t.GetWagons;

            t.SortAnimals();
            IReadOnlyList<Animal> animals = t.GetUnsortedAnimals;

            t.AddAnimal(animal);
            t.SortAnimals();

            Assert.AreEqual(animal, t.GetWagons[0].GetAnimals[0]);
            Assert.AreEqual(t.TotalAnimals, 2);
            Assert.IsNull(animals);
        }
    }
}
