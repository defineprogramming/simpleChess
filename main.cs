using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Chess!");

            // Create the board
            string[,] board = new string[8, 8]
            {
                { "R", "N", "B", "Q", "K", "B", "N", "R" },
                { "P", "P", "P", "P", "P", "P", "P", "P" },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { " ", " ", " ", " ", " ", " ", " ", " " },
                { "p", "p", "p", "p", "p", "p", "p", "p" },
                { "r", "n", "b", "q", "k", "b", "n", "r" }
            };

            // Main game loop
            while (true)
            {
                // Print the board
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write(board[i, j]);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }

                // Get player move
                Console.WriteLine("Enter move (e.g. a2 a4):");
                string input = Console.ReadLine();
                string[] splitInput = input.Split(' ');
                int fromX = int.Parse(splitInput[0][0].ToString()) - 1;
                int fromY = int.Parse(splitInput[0][1].ToString()) - 1;
                int toX = int.Parse(splitInput[1][0].ToString()) - 1;
                int toY = int.Parse(splitInput[1][1].ToString()) - 1;

                // Check if move is valid
                if (board[fromX, fromY] == " ")
                {
                    Console.WriteLine("Invalid move! Try again.");
                    continue;
                }
                if (board[toX, toY] != " " && board[fromX, fromY][0] == board[toX, toY][0])
                {
                    Console.WriteLine("Invalid move! Try again.");
                    continue;
                }

                // Make move
                board[toX, toY] = board[fromX, fromY];
                board[fromX, fromY] = " ";

                // Check if game is over
                bool whiteKingFound = false;
                bool blackKingFound = false;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] == "k")
                        {
                            blackKingFound = true;
                        }
                        if (board[i, j] == "K")
                        {
                            whiteKingFound = true;
                        }
                    }
                }

                if (!whiteKingFound || !blackKingFound)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                // Get AI move
                Random random = new Random();
                while (true)
                {
                    int aiFromX = random.Next(0, 8);
                    int aiFromY = random.Next(0, 8);
                    int aiToX = random.Next(0, 8);
                    int aiToY = random.Next(0, 8);

                    // Check if move is valid
                    if (board[aiFromX, aiFromY] == " ")
                    {
                        continue;
                    }
                    if (board[aiToX, aiToY] != " " && board[aiFromX, aiFromY][0] == board[aiToX, aiToY][0])
                    {
                        continue;
                    }

                    // Make move
                    board[aiToX, aiToY] = board[aiFromX, aiFromY];
                    board[aiFromX, aiFromY] = " ";
                    break;
                }
            }
        }
    }
}

