using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancySharp
{
    public record TreeRecord
    {
        public string name;
        public int height;
    }

    public class TreeClass
    {
        public string name;
        public int height;
    }

    public class TreeRecordAsClass : IEquatable<TreeRecordAsClass>, IComparable<TreeRecordAsClass>
    {
        public string name;
        public int height;

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, height);
        }

        public bool Equals(TreeRecordAsClass other)
        {
            return (this.name == other.name && this.height == other.height);
        }

        public int CompareTo(TreeRecordAsClass other)
        {
            return this.CompareTo(other);
        }

        public static bool operator ==(TreeRecordAsClass left, TreeRecordAsClass right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(TreeRecordAsClass left, TreeRecordAsClass right)
        {
            return !(left == right);
        }
    }

    /// <summary>
    /// Records are basically the same as classes from. It's just that the compiler overrides 
    /// and implements for you for convience purposes. Namely: Equals, GetHashCode, ToString, 
    /// ==, != operators, IEquatable
    /// For details see: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records
    /// 
    /// TreeRecordClass is a rough design of the result the compiler generates when you use record
    /// instead of class. Being able to compare classes by value is a common usecase, but implementing it is a lot of effort, and you can quickly make mistakes, especially implementing GetHashCode.
    /// Best way to do all this is to add the interfaces and use the quick actions and refactorings
    /// </summary>
    public class RecordTest
    {
        private static string BoolToEqualOrNotToEqualHAHA (bool input)
        {
            string result = input ? "Equal" : "Not Equal";
            return result;
        }

        /// <summary>
        /// Shows the difference of comparing classes and records using the == operator
        /// </summary>
        public static void Run()
        {
            // Yeah, screw these $ at the beginning of the string :D

            TreeRecord pineRecord = new TreeRecord() { name = "Pine", height = 44 };
            TreeRecord otherPineRecord = new TreeRecord() { name = "Pine", height = 44 };
            TreeRecord tallerPineRecord = new TreeRecord() { name = "Pine", height = 1000000 };
            TreeRecord instancePineRecord = pineRecord;

            Console.WriteLine("See how the following are equal because they have the same values");
            Console.WriteLine($"pineRecord == otherPineRecord: " + BoolToEqualOrNotToEqualHAHA(pineRecord == otherPineRecord));
            Console.WriteLine($"pineRecord == tallerPineRecord: " + BoolToEqualOrNotToEqualHAHA(pineRecord == tallerPineRecord));
            Console.WriteLine($"pineRecord == instancePineRecord: " + BoolToEqualOrNotToEqualHAHA(pineRecord == instancePineRecord));
            Console.WriteLine();

            TreeClass pineClass = new TreeClass() { name = "Pine", height = 44 };
            TreeClass otherPineClass = new TreeClass() { name = "Pine", height = 44 };
            TreeClass tallerPineClass = new TreeClass() { name = "Pine", height = 1000000 };
            TreeClass instancePineClass = pineClass;

            Console.WriteLine($"pineClass == otherPineClass: " + BoolToEqualOrNotToEqualHAHA(pineClass == otherPineClass));
            Console.WriteLine($"pineClass == tallerPineClass: " + BoolToEqualOrNotToEqualHAHA(pineClass == tallerPineClass));
            Console.WriteLine($"pineClass == instancePineClass: " + BoolToEqualOrNotToEqualHAHA(pineClass == instancePineClass));
            Console.WriteLine();

            TreeRecordAsClass pineClassRecord = new TreeRecordAsClass() { name = "Pine", height = 44 };
            TreeRecordAsClass otherPineClassRecord = new TreeRecordAsClass() { name = "Pine", height = 44 };
            TreeRecordAsClass tallerPineClassRecord = new TreeRecordAsClass() { name = "Pine", height = 1000000 };
            TreeRecordAsClass instancePineClassRecord = pineClassRecord;

            Console.WriteLine($"pineClassRecord == otherPineClassRecord: " + BoolToEqualOrNotToEqualHAHA(pineClassRecord == otherPineClassRecord));
            Console.WriteLine($"pineClassRecord == tallerPineClassRecord: " + BoolToEqualOrNotToEqualHAHA(pineClassRecord == tallerPineClassRecord));
            Console.WriteLine($"pineClassRecord == instancePineClassRecord: " + BoolToEqualOrNotToEqualHAHA(pineClassRecord == instancePineClassRecord));
            Console.WriteLine();

        }
    }
}
