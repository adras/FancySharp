using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class Maybe<T>
    {
        public Maybe<T1> Map<T1>(Func<T, T1> f) =>
            this switch
            {
                None<T> { } => new None<T1>(),
                Some<T> { Value: T val } => new Some<T1>(f(val)),
                _ => throw new NotImplementedException(),
            };
    }
    public class None<T> : Maybe<T>
    {
        public None() { }
    }

    public class Some<T> : Maybe<T>
    {
        public readonly T Value;
        public Some(T value) => this.Value = value;

    }

    class Person
    {
        public readonly string name;
        public readonly string age;

        public Person(string name, string age)
        {
            this.name = name;
            this.age = age;
        }
    }

    /// <summary>
    /// Example for the Maybe Monad from functional programming
    /// </summary>
    class MaybeTest
    {

        /// <summary>
        /// Parses a string like: 'Name: Peter Age: 22' into a person object with name and age set
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static Maybe<Person> GetPerson(string input)
        {
            string namePattern = "Name:";
            int nameIdx = input.IndexOf(namePattern);

            string agePattern = "Age:";
            int ageIdx = input.IndexOf(agePattern);

            if (nameIdx == -1 || ageIdx == -1)
                return new None<Person>();


            string name = input.Substring(nameIdx + namePattern.Length, input.Length - ageIdx);
            string age = input.Substring(ageIdx + agePattern.Length);

            Person result = new Person(name, age);

            return new Some<Person>(result);
        }

        void Run()
        {
            List<string> persons = new List<string>
            {
                "Name: Peter Age: 12",
                "Name: Johne Age: 44",
                "Name: Peter",
                "Nam Age: 12",
                "Name: Bob Age: 112",
            };


            foreach (string person in persons)
            {
                Maybe<Person> result = GetPerson(person);
                switch (result)
                {
                    case Some<Person> s:
                        Console.WriteLine("Name: " + s.Value.name);
                        Console.WriteLine("Age: " + s.Value.age);
                        break;
                    case None<Person> _:
                        Console.WriteLine($"Could not parse: '{person}'");
                        break;

                }
                Console.WriteLine();
            }


        }
    }
}
