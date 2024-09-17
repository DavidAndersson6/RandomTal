using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lottery_alg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Call the Input method and store the result in the 'answer' array
            string[] answer = Input();

            string[] winNumbers = Win();

            // Now you can access the 'answer' array in Main
            Console.WriteLine("Siffrorna du angav är:");
            foreach (var num in answer)
            {
                Console.WriteLine(num);
            }
            bool anyExist = answer.Any(x => winNumbers.Contains(x));

            if (anyExist)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine("Lose");
            }

        }

        public static string[] Win()
        {
            Random random = new Random();
            int[] array = new int[3];
            string[] stringArray = new string[3];

            for (int i = 0; i < array.Length; i++)
            {

                array[i] = random.Next(1, 51);
                stringArray[i] = array[i].ToString();
                Console.WriteLine(array[i]);

            }
            return stringArray;
        }
       
    public static string[] Input()
        {
            bool validInput = false;
            string[] answer = new string[5]; // Declare the array outside the while loop to return it later

            while (!validInput)
            {
                Console.WriteLine("Skriv in 5 siffror, 1-50");

                bool allValid = true;

                for (int i = 0; i < answer.Length; i++)
                {
                    Console.Write($"Siffra {i + 1}: ");
                    string input = Console.ReadLine();

                    // Try to parse input to an integer
                    if (int.TryParse(input, out int number))
                    {
                        // Check if the number is between 1 and 50
                        if (number >= 1 && number <= 50)
                        {
                            answer[i] = input;
                        }
                        else
                        {
                            Console.WriteLine("Fel: Numret måste vara mellan 1 och 50.");
                            allValid = false;
                            break; // Exit the loop if an invalid number is entered
                        }
                    }
                    else
                    {
                        Console.WriteLine("Fel: Ange ett giltigt nummer.");
                        allValid = false;
                        break; // Exit the loop if parsing fails
                    }
                }

                // If all inputs are valid, exit the while loop
                if (allValid)
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Försök igen.");
                }
            }

            return answer; // Return the array to the caller
        }
    }
}