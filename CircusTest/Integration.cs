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
    public class Integration
    {
        [TestMethod()]
        public void NoCrash()
        {
            Train t = new();
            Random r = new();
            int amt = 200;

            for (int i = 0; i < r.Next(amt); i++) t.AddAnimal(new Animal("small vegan", Size.Small, Diet.Vegan));
            for (int i = 0; i < r.Next(amt); i++) t.AddAnimal(new Animal("medium vegan", Size.Medium, Diet.Vegan));
            for (int i = 0; i < r.Next(amt); i++) t.AddAnimal(new Animal("large vegan", Size.Large, Diet.Vegan));
            for (int i = 0; i < r.Next(amt); i++) t.AddAnimal(new Animal("small meat", Size.Small, Diet.Meat));
            for (int i = 0; i < r.Next(amt); i++) t.AddAnimal(new Animal("medium meat", Size.Medium, Diet.Meat));
            for (int i = 0; i < r.Next(amt); i++) t.AddAnimal(new Animal("large meat", Size.Large, Diet.Meat));

            t.SortAnimals();

            Console.WriteLine(t);
        }

        [TestMethod()]
        public void AddSingleAnimal()
        {
            Train t = new();

            Assert.IsNull(t.GetWagons);
            Assert.IsNull(t.GetUnsortedAnimals);

            t.AddAnimal(new());

            Assert.IsNull(t.GetWagons);
            Assert.AreEqual(t.GetUnsortedAnimals.Count, 1);

            t.SortAnimals();

            Assert.AreEqual(t.GetWagons.Count, 1);
            Assert.IsNull(t.GetUnsortedAnimals);
        }

        [TestMethod()]
        public void EveryAnimalOnce()
        {
            Train t = new();

            t.AddAnimal(new Animal("small vegan", Size.Small, Diet.Vegan));

            t.AddAnimal(new Animal("medium vegan", Size.Medium, Diet.Vegan));

            t.AddAnimal(new Animal("large vegan", Size.Large, Diet.Vegan));

            t.AddAnimal(new Animal("small meat eater", Size.Small, Diet.Meat));

            t.AddAnimal(new Animal("medium meat eater", Size.Medium, Diet.Meat));

            t.AddAnimal(new Animal("large meat eater", Size.Large, Diet.Meat));

            Assert.AreEqual(t.GetUnsortedAnimals.Count, 6);

            t.SortAnimals();

            Assert.IsNull(t.GetUnsortedAnimals);
        }
    }
}
