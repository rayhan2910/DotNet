using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemSolving
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a problem to solve:");
            Console.WriteLine("1. Sort Character");
            Console.WriteLine("2. PSBB (Pembatasan Sosial Berskala Besar)");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SolveSortCharacterProblem();
                    break;
                case 2:
                    SolvePSBBProblem();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        static void SolveSortCharacterProblem()
        {
            Console.WriteLine("Input one line of words (S):");
            string input = Console.ReadLine();

            string result = SortCharacters(input);

            Console.WriteLine("Output:");
            Console.WriteLine(result);
        }

        static string SortCharacters(string input)
        {
            List<char> vowels = new List<char>();
            List<char> consonants = new List<char>();


            Func<char, bool> isVowel = c => "aeiou".Contains(char.ToLower(c));


            foreach (char c in input)
            {
 
                if (c != ' ')
                {

                    if (isVowel(c))
                    {
                        vowels.Add(char.ToLower(c));
                    }
                    else
                    {
                        consonants.Add(char.ToLower(c));
                    }
                }
            }


            vowels.Sort();
            consonants.Sort();

 
            string sortedVowels = "Vowel Characters :\n" + string.Join("", vowels);
            string sortedConsonants = "Consonant Characters :\n" + string.Join("", consonants);

            return sortedVowels + "\n" + sortedConsonants;
        }

        static void SolvePSBBProblem()
        {
            Console.WriteLine("Input the number of families:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Input the number of members in the family (separated by a space):");
            int[] familySizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int minBuses = CalculateMinBuses(n, familySizes);
            if (minBuses == -1)
            {
                Console.WriteLine("Input must be equal with count of family");
            }
            else
            {
                Console.WriteLine("Minimum bus required is: " + minBuses);
            }
        }

        static int CalculateMinBuses(int n, int[] familySizes)
        {
            int totalPassengers = familySizes.Sum();

            if (totalPassengers != n)
            {
                return -1; 
            }

            int minBuses = 0;
            while (familySizes.Length > 0)
            {
                minBuses++;
                int passengersOnBus = 0;
                int familiesOnBus = 0;
                for (int i = 0; i < familySizes.Length; i++)
                {
                    if (passengersOnBus + familySizes[i] <= 4 && familiesOnBus < 2)
                    {
                        passengersOnBus += familySizes[i];
                        familiesOnBus++;
                        familySizes[i] = 0; // Mark family as boarded
                    }
                }
                familySizes = familySizes.Where(x => x > 0).ToArray(); // Remove boarded families
            }

            return minBuses;
        }
    }
}
