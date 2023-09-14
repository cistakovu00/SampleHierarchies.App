using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Bear : MammalBase, IBear
    {
        #region Public Methods

        /// <inheritdoc/>
        public override void MakeSound()
        {
            Console.WriteLine("My name is: {0} and I am growling", Name);
        }

        /// <inheritdoc/>
        public override void Move()
        {
            Console.WriteLine("My name is: {0} and I am walking", Name);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am a {KindOf} bear");
        }

        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is IBear bear)
            {
                base.Copy(animal);
                KindOf = bear.KindOf;
                PawSize = bear.PawSize;
                GoodSenseOfSmeel = bear.GoodSenseOfSmeel;
                SharpnessOfTheClaws = bear.SharpnessOfTheClaws;
            }
        }

        #endregion // Public Methods

        #region Ctors And Properties

        /// <inheritdoc/>
        public string KindOf { get; set; }

        public int PawSize { get; set; }

        public string GoodSenseOfSmeel { get; set; }

        public string SharpnessOfTheClaws { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="kindOf">Kind of bear</param>
        public Bear(string name, int age, string kindOf, int pawSize, string goodSenseOfSmeel, string sharpnessOfTheClaws) : base(name, age, MammalSpecies.Bear)
        {
            KindOf = kindOf;
            PawSize = pawSize;
            GoodSenseOfSmeel = goodSenseOfSmeel;
            SharpnessOfTheClaws = sharpnessOfTheClaws;
        }

        #endregion // Ctors And Properties
    }

}
