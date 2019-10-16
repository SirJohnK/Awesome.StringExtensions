using Awesome.StringExtensions;
using System;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Start!");
            Console.ReadLine();
            Console.WriteLine("hello to the world!".ToTitleCase());
            Console.WriteLine("hello to the world!".ToTitleCase(new System.Globalization.CultureInfo("en-EN")));
            Console.WriteLine("The world is alive in the USA!".ToTitleCase(new System.Globalization.CultureInfo("en-US")));
            Console.WriteLine("ford mondeo är en fin bil!".ToTitleCase());
            Console.WriteLine("en produk kan vara ett ärende och resultat!".ToTitleCase());
            Console.ReadLine();
        }
    }
}