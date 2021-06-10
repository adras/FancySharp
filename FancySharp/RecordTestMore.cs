using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancySharp
{
    // Note the missing curly brackes, it could also be written like this:
    // public record ReadonlyPlantRecord (string name, int height);

    // This record automatically get's a constructor which assignes the values
    public abstract record ReadonlyPlantRecord
    (
         string name,
         int height
    );

    public record GrowablePlantRecord : ReadonlyPlantRecord
    {
        public GrowablePlantRecord(string name, int height) : base(name, height)
        {
            this.name = name;
            this.height = height;
        }

        // The following doesn't work, because it would modify the state of the record
        //public void Grow(int amount)
        //{
        //    this.height += amount;
        //}

        // But this works
        public GrowablePlantRecord Grow(int amount)
        {
            GrowablePlantRecord result = this with { height = height + amount };
            return result;
        }
    }

    class RecordTestMore
    {
        private static string CreateBigString(long length)
        {
            Random r = new Random();
            StringBuilder bigString = new StringBuilder();
            for (long i = 0; i < length; i++)
            {
                bigString.Append((char)r.Next((byte)'a', (byte)'z'));
            }
            return bigString.ToString();
        }

        public static void Run()
        {
            GrowablePlantRecord ophelia = new GrowablePlantRecord("Ophelia", 33 );

            // Grow the plant
            // Not possible, because Records with braces () are readonly
            // ophelia.height = 50;

            // You can still grow it though:
            ReadonlyPlantRecord grownOphelia = ophelia with { height = ophelia.height + 50 };
            ReadonlyPlantRecord evenBiggerOphelia = ophelia.Grow(50000);

            Console.WriteLine($"Ophelia: {ophelia}");
            Console.WriteLine($"GrownOphelia: {grownOphelia}");
            Console.WriteLine($"EvenBiggerOphelia: {evenBiggerOphelia}");
        }
    }
}
