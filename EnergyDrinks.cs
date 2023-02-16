using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] stack = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> mgOfcoffein = new Stack<int>(stack);

            int[] queue = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> energyDrinks = new Queue<int>(queue);

            int maxCoffein = 300;
            int coffeinOfStamat = 0;

            while (mgOfcoffein.Count > 0 && energyDrinks.Count > 0)
            {
                
                if (((int)mgOfcoffein.Peek()*(int)energyDrinks.Peek() + coffeinOfStamat)<= maxCoffein)
                {
                    coffeinOfStamat += (int)mgOfcoffein.Pop() * (int)energyDrinks.Dequeue();                    
                }
                else
                {
                    mgOfcoffein.Pop();
                    energyDrinks.Enqueue(energyDrinks.Dequeue());
                    if (coffeinOfStamat - 30 >= 0)
                    {
                        coffeinOfStamat -= 30;
                    }
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {coffeinOfStamat} mg caffeine.");
        }
    }
}
