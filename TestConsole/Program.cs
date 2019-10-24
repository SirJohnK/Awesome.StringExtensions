using Awesome.StringExtensions;
using System;

namespace TestConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("hello to the world!".ToTitleCase());
            Console.WriteLine("hello to the world!".ToTitleCase(new System.Globalization.CultureInfo("en-EN")));
            Console.WriteLine("The world is alive in the USA!".ToTitleCase(new System.Globalization.CultureInfo("en-US")));
            Console.WriteLine("ford mondeo är en fin bil!".ToTitleCase());
            Console.WriteLine("en produkt kan vara ett ärende och resultat!".ToTitleCase());

            Console.WriteLine("Mr. Sherlock Holmes and\r\n Dr. John Watson were better than the F.B.I.\r\n at crime fighting! Hej, vad heter du?r\n".CountSentences());
            Console.WriteLine("Mr. Sherlock Holmes and\r\n Dr. John Watson were better than the F.B.I.\r\n at crime fighting! Hej, vad heter du?r\n".CountWordLengths());
            Console.WriteLine("Mr. Sherlock Holmes and\r\n Dr. John Watson, the helper were better than the F.B.I.\r\n at crime fighting! Hej hej, vad heter du?r\n".CountUniqueWords());

            Console.ReadLine();
        }
    }
}