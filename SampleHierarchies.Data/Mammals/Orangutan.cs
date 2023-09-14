using SampleHierarchies.Interfaces.Data.Mammals;
using SampleHierarchies.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHierarchies.Data.Mammals
{
    public class Orangutan : MammalBase, IOrangutan
    {
        #region Public Methods

        /// <inheritdoc/>
        public override void MakeSound()
        {
            Console.WriteLine("My name is: {0} and I am making orangutan sounds", Name);
        }

        /// <inheritdoc/>
        public override void Move()
        {
            Console.WriteLine("My name is: {0} and I am climbing", Name);
        }

        /// <inheritdoc/>
        public override void Display()
        {
            Console.WriteLine($"My name is: {Name}, my age is: {Age} and I am an orangutan");
        }

        /// <inheritdoc/>
        public override void Copy(IAnimal animal)
        {
            if (animal is IOrangutan ao)
            {
                base.Copy(animal);
                Intelligence = ao.Intelligence;
                ClimbingSpeed = ao.ClimbingSpeed;
                Diet = ao.Diet;
                SocialBehavior = ao.SocialBehavior;
            }
        }

        #endregion // Public Methods

        #region Ctors And Properties

        /// <inheritdoc/>
        public int Intelligence { get; set; }

        /// <inheritdoc/>
        public double ClimbingSpeed { get; set; }

        /// <inheritdoc/>
        public string Diet { get; set; }

        /// <inheritdoc/>
        public string SocialBehavior { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="age">Age</param>
        /// <param name="intelligence">Intelligence</param>
        /// <param name="climbingSpeed">Climbing speed</param>
        /// <param name="diet">Diet</param>
        /// <param name="socialBehavior">Social behavior</param>
        public Orangutan(string name, int age, int intelligence, double climbingSpeed, string diet, string socialBehavior)
            : base(name, age, MammalSpecies.Orangutan)
        {
            Intelligence = intelligence;
            ClimbingSpeed = climbingSpeed;
            Diet = diet;
            SocialBehavior = socialBehavior;
        }

        #endregion // Ctors And Properties
    }

}
