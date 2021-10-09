using System;
using System.Collections.Generic;

namespace classdemo_tictactoe
{
    class Program
    {
        static void DisplayBoard (List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static List<string> CreateBoard()
        {
            
            List<string> newBord = new List<string>();

            for (int spotNumber = 1; spotNumber < 10; spotNumber++)
            {
                newBord.Add(spotNumber.ToString());
            }
                        
            return newBord;
        }

        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;
            
            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                isGameOver = true;
            }
            return isGameOver;
        }

        static bool IsWinner(List<string> board, string player)
        {
            bool isWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
                {
                    isWinner = true;
                }
                
                return isWinner;
        }

        static bool IsTie(List<string> board)
        {
            bool foundDigit = false;

            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }

        static int GetMoveChoice(string currentPlayer)
        {
            Console.WriteLine($"{currentPlayer}'s turn to choose a square (1-9): ");
            string moveString = Console.ReadLine();
            int choice = int.Parse(moveString);

            return choice;
        }

        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            int index = choice -1;

            board[index] = currentPlayer;
        }
        
        static void Main(string[] args)
        {
            List<string> board = CreateBoard ();
            string currentPlayer = "x";

            while(!IsGameOver(board))
            {
                DisplayBoard(board);
                int choice = GetMoveChoice(currentPlayer);
                MakeMove(board, choice, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);         
            }

            DisplayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }
    }
}
 