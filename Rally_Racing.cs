using System;
using System.Linq;

namespace RallyRacing
{
    class StartUp
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            string carNumber =Console.ReadLine();

            char[,] matrix = new char[n, n];

            int tunnelEndRow = 0;
            int tunnelEndCol = 0;
            int countOfT = 0;

            for (int row = 0; row < n; row++)
            {
                char[] inputOfMatrix = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputOfMatrix[col];
                    char currentLetter = inputOfMatrix[col];
                    if (currentLetter == 'T' && countOfT == 0)
                    {
                        countOfT++;
                    }
                    else if (inputOfMatrix[col] == 'T' && countOfT == 1)
                    {
                        tunnelEndRow = row;
                        tunnelEndCol = col;
                    }
                }
            }
            int rowNumber = 0;
            int colNumber = 0;
            int kilometersPassed = 0;

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                switch (command)
                {
                    case "left":
                        colNumber--;
                        kilometersPassed += 10;
                        if (matrix[rowNumber,colNumber] == 'T')
                        {
                            kilometersPassed += 20;
                            matrix[rowNumber, colNumber] = '.';
                            rowNumber = tunnelEndRow;
                            colNumber = tunnelEndCol;
                            matrix[rowNumber, colNumber] = '.';
                        }
                        else if (matrix[rowNumber,colNumber] == 'F')
                        {
                            Console.WriteLine($"Racing car {carNumber} finished the stage!");
                            Console.WriteLine($"Distance covered {kilometersPassed} km.");
                            return;//!!!!!!return

                            matrix[rowNumber, colNumber] = 'C';

                            PrintMatrix(matrix);
                        }
                        break;
                    case "right":
                        colNumber++;
                        kilometersPassed += 10;
                        if (matrix[rowNumber, colNumber] == 'T')
                        {
                            kilometersPassed += 20;
                            matrix[rowNumber, colNumber] = '.';
                            rowNumber = tunnelEndRow;
                            colNumber = tunnelEndCol;
                            matrix[rowNumber, colNumber] = '.';
                        }
                        else if (matrix[rowNumber, colNumber] == 'F')
                        {
                            Console.WriteLine($"Racing car {carNumber} finished the stage!");
                            Console.WriteLine($"Distance covered {kilometersPassed} km.");

                            matrix[rowNumber, colNumber] = 'C';

                            PrintMatrix(matrix);
                            return;//!!!!!!return
                        }
                        break;
                    case "up":
                        rowNumber--;
                        kilometersPassed += 10;
                        if (matrix[rowNumber, colNumber] == 'T')
                        {
                            kilometersPassed += 20;
                            matrix[rowNumber, colNumber] = '.';
                            rowNumber = tunnelEndRow;
                            colNumber = tunnelEndCol;
                            matrix[rowNumber, colNumber] = '.';
                        }
                        else if (matrix[rowNumber, colNumber] == 'F')
                        {
                            Console.WriteLine($"Racing car {carNumber} finished the stage!");
                            Console.WriteLine($"Distance covered {kilometersPassed} km.");

                            matrix[rowNumber, colNumber] = 'C';

                            PrintMatrix(matrix);
                            return;//!!!!!!return
                        }
                        break;
                    case "down":
                        rowNumber++;
                        kilometersPassed += 10;
                        if (matrix[rowNumber, colNumber] == 'T')
                        {
                            kilometersPassed += 20;
                            matrix[rowNumber, colNumber] = '.';
                            rowNumber = tunnelEndRow;
                            colNumber = tunnelEndCol;
                            matrix[rowNumber, colNumber] = '.';
                        }
                        else if (matrix[rowNumber, colNumber] == 'F')
                        {
                            Console.WriteLine($"Racing car {carNumber} finished the stage!");
                            Console.WriteLine($"Distance covered {kilometersPassed} km.");

                            matrix[rowNumber, colNumber] = 'C';

                            PrintMatrix(matrix);
                            return;//!!!!!!return
                        }
                        break;
                    default:
                        break;
                }
            }

            if (command == "End")
            {
                Console.WriteLine($"Racing car {carNumber} DNF.");
            }

            Console.WriteLine($"Distance covered {kilometersPassed} km.");

            matrix[rowNumber, colNumber] = 'C';

            PrintMatrix(matrix);
        }
        public static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");

                }
                Console.WriteLine();
            }
        }
    } 
}
