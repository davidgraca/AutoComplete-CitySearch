// <copyright file="Program.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>

using System.Collections.Generic;

namespace CitySearch
{
    using System;
    using System.Diagnostics;
    using Core.Model.Classes;
    using Core.Model.Processing;

    /// <summary>
    /// Console app to test auto complete search
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Runs de test program
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Tree<CityTreeNode> tree = new CityTreeBuilder()
                .GetData()
                .LoadTree()
                .Build();

            Stopwatch s1 = Stopwatch.StartNew();
            while (true)
            {
                Console.WriteLine("Please type the city you want: (press enter after each character)");
                var result = Console.ReadLine();


                List<int> lst = new List<int>();
                s1.Restart();
                var searchNode = tree.Search(result.ToLower());
                if (searchNode == null)
                {
                    Console.WriteLine("No results found.");
                    continue;
                }

                AutoCompleteResult possibleResults = searchNode.GetPossibleResults();

                if (possibleResults == null)
                {
                    Console.WriteLine("No possible results found.");
                    continue;
                }

                s1.Stop();
                Console.WriteLine(possibleResults.ToString());
                Console.WriteLine("Do another search.");
                Console.WriteLine("Time taken: {0}ms on 3000 results", s1.ElapsedMilliseconds);
            }
        }
    }
}
