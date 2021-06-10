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

            // For more information about records see: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records            
            RecordTest.Run();
            
            Console.WriteLine("-----------------------------");
            RecordTestMore.Run();
        }
    }
}
