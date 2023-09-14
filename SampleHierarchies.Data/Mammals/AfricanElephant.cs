using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class AfricanElephant : MammalBase, IAfricanElephant
    {
        #region Public Methods

        /// <inheritdoc/>
        public override void MakeSound()
        {
            Console.WriteLine("My name is: {0} and I am trumpeting", Name);
        }

        /// <inheritdoc/>
        public override void Move()
        {
            Console.WriteLine("My name is: {0} and I am walking", Name);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age}, and I am an African elephant");
        }

        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is IAfricanElephant ae)
            {
                base.Copy(animal);
                Height = ae.Height;
                Weight = ae.Weight;
                TuskLength = ae.TuskLength;
                LongLifeSpan = ae.LongLifeSpan;
                SocialBehavior = ae.SocialBehavior;
            }
        }

        #endregion // Public Methods

        #region Ctors And Properties

        /// <inheritdoc/>
        public float Height { get; set; }

        /// <inheritdoc/>
        public float Weight { get; set; }

        /// <inheritdoc/>
        public float TuskLength { get; set; }

        /// <inheritdoc/>
        public int LongLifeSpan { get; set; }

        /// <inheritdoc/>
        public string SocialBehavior { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="height">Height</param>
        /// <param name="weight">Weight</param>
        /// <param name="tuskLength">Tusk Length</param>
        /// <param name="longLifeSpan">Long Life Span</param>
        /// <param name="socialBehavior">Social Behavior</param>
        public AfricanElephant(string name, int age, float height, float weight, float tuskLength, int longLifeSpan, string socialBehavior)
            : base(name, age, MammalSpecies.AfricanElephant)
        {
            Height = height;
            Weight = weight;
            TuskLength = tuskLength;
            LongLifeSpan = longLifeSpan;
            SocialBehavior = socialBehavior;
        }

        #endregion // Ctors And Properties
    }

}
