using System;

// C# also features top level sourcecode. Without a namespace and a class you can just start writing code
// This is great for teachers, teaching programming since none of that complicated namespace and class and
// static stuff needs to be explained.

// It's also great for writing scripts
// And for sourcecode like this for which one should get shot for :D

// Reference: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#top-level-statements

Console.WriteLine("Screw all that code and let's start!");

Console.WriteLine($"I even support {GetMethodName()}");

string GetMethodName()
{
    return "methods and functions";
}

Console.WriteLine("This almost remind me to some old basic code. Just the line numbers are missing");

// Too bad
string Wow()
{


    return "But being able to define methods everywhere is reating a huge mess";
}

Console.WriteLine(Wow());

string[] text = { "Even ", "goto ", "works!" };

int i = 0;
start:
Console.WriteLine(text[i]);
i++;
if (i < text.Length)
    goto start;

Console.WriteLine("Now I'm really reminded to old basic code");