using System;

class Program
{
    static void Main()
    {
        int[,] bigM = new int[3, 3];

        Console.WriteLine("Welcome to the Tic Tac Toe game!");

        Console.WriteLine("Player 1, enter your name:");
        string name1 = Console.ReadLine();

        Console.WriteLine("Player 2, enter your name:");
        string name2 = Console.ReadLine();

        for (int turn = 0; turn < 9; turn++)
        {
            // Player 1
            if (turn % 2 == 0)
            {
                MakeMove(bigM, name1, 1);
                PrintBoard(bigM);

                if (CheckWin(bigM, 1))
                {
                    Console.WriteLine(name1 + " wins!");
                    return;
                }
            }
            // Player 2
            else
            {
                MakeMove(bigM, name2, 2);
                PrintBoard(bigM);

                if (CheckWin(bigM, 2))
                {
                    Console.WriteLine(name2 + " wins!");
                    return;
                }
            }
        }

        Console.WriteLine("It's a draw!");
    }

    static void MakeMove(int[,] board, string name, int player)
    {
        while (true)
        {
            Console.WriteLine(name + ", choose place (row col):");

            int row = Convert.ToInt32(Console.ReadLine());
            int col = Convert.ToInt32(Console.ReadLine());

            if (row < 0 || row > 2 || col < 0 || col > 2)
            {
                Console.WriteLine("Invalid input. Use 0-2.");
                continue;
            }

            if (board[row, col] != 0)
            {
                Console.WriteLine("Already taken. Try again.");
                continue;
            }

            board[row, col] = player;
            break;
        }
    }

    static void PrintBoard(int[,] board)
    {
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 0)
                    Console.Write("* ");
                else if (board[i, j] == 1)
                    Console.Write("X ");
                else
                    Console.Write("O ");
            }
            Console.WriteLine();
        }

        Console.WriteLine();
    }

    static bool CheckWin(int[,] board, int player)
    {
        // rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == player &&
                board[i, 1] == player &&
                board[i, 2] == player)
                return true;
        }

        // columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == player &&
                board[1, i] == player &&
                board[2, i] == player)
                return true;
        }

        // diagonals
        if (board[0, 0] == player &&
            board[1, 1] == player &&
            board[2, 2] == player)
            return true;

        if (board[0, 2] == player &&
            board[1, 1] == player &&
            board[2, 0] == player)
            return true;

        return false;
    }
}