using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace FancySharp
{
    class Program
    {
        static void Main(string[] args)
        {
            MaybeTest.Run();
            Console.WriteLine("-----------------------------");
            RecordTest.Run();
        }
    }
}
