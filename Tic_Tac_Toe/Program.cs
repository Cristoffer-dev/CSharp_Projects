using System;

namespace MyNamespace
{
    class Program
    {

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;


            //calling the method
            CreateBoard();

            do
            {
                if (player == 2)
                {
                    player = 1;
                    WriteXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    WriteXorO(player, input);
                }
                CreateBoard();
                #region //code for imput data validation 
                do
                {
                    Console.WriteLine("Welcome to the game!");
                    Console.WriteLine("Player {0}: Please Select Spot...", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a number");
                    }
                    if ((input == 1) && (boardGame[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (boardGame[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (boardGame[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (boardGame[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (boardGame[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (boardGame[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (boardGame[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (boardGame[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (boardGame[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\n Incorrect input! Please use another field");
                        inputCorrect = false;
                    }

                } while (!inputCorrect);
                #endregion

                #region //Checking for a winner
                char[] playerSign = { 'X', 'O' };
                bool gameWon = false;
                foreach (char sign in playerSign)
                {
                    if ((boardGame[0, 0] == sign && boardGame[0, 1] == sign && boardGame[0, 2] == sign) ||
                        (boardGame[1, 0] == sign && boardGame[1, 1] == sign && boardGame[1, 2] == sign) ||
                        (boardGame[2, 0] == sign && boardGame[2, 1] == sign && boardGame[2, 2] == sign) ||
                        (boardGame[0, 0] == sign && boardGame[1, 0] == sign && boardGame[2, 0] == sign) ||
                        (boardGame[0, 1] == sign && boardGame[1, 1] == sign && boardGame[2, 1] == sign) ||
                        (boardGame[0, 2] == sign && boardGame[1, 2] == sign && boardGame[2, 2] == sign) ||
                        (boardGame[0, 0] == sign && boardGame[1, 1] == sign && boardGame[2, 2] == sign) ||
                        (boardGame[0, 2] == sign && boardGame[1, 1] == sign && boardGame[2, 0] == sign))
                    {
                        if (sign == 'X')
                            System.Console.WriteLine("Congrats! Player 1 is the Winner!!");
                        else
                            System.Console.WriteLine("Congrats! Player 2 is the Winner!!");
                        System.Console.WriteLine("Press any botton to restart the game");
                        Console.Read();
                        input = 0;
                        Reset();

                        break;
                    }
                    else if (turn == 10)
                    {
                        System.Console.WriteLine("It's a draw!");
                        System.Console.WriteLine("Press any botton to restart the game");
                        Console.Read();
                        input = 0;
                        Reset();
                        break;
                    }
                }
                #endregion
            } while (true);

        }

        //Method for player identifier
        public static void WriteXorO(int player, int input)
        {
            char sign = ' ';
            if (player == 1)
            {
                sign = 'X';
            }
            else if (player == 2)
            {
                sign = 'O';
            }
            switch (input)
            {
                case 1: boardGame[0, 0] = sign; break;
                case 2: boardGame[0, 1] = sign; break;
                case 3: boardGame[0, 2] = sign; break;
                case 4: boardGame[1, 0] = sign; break;
                case 5: boardGame[1, 1] = sign; break;
                case 6: boardGame[1, 2] = sign; break;
                case 7: boardGame[2, 0] = sign; break;
                case 8: boardGame[2, 1] = sign; break;
                case 9: boardGame[2, 2] = sign; break;
            }
        }

        //array to save game variables
        static char[,] boardGame =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        //array to save teh initial game variables
        static char[,] boardGameInitial =
       {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };

        static int  turn = 0 ;


        //Metod for the creation of the board
        public static void CreateBoard()
        {
            Console.Clear();
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", boardGame[0, 0], boardGame[0, 1], boardGame[0, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", boardGame[1, 0], boardGame[1, 1], boardGame[1, 2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |");
            Console.WriteLine("  {0}  |  {1}  |  {2} ", boardGame[2, 0], boardGame[2, 1], boardGame[2, 2]);
            Console.WriteLine("     |     |");
            turn++;
        }

        //Method for restart the game
        public static void Reset()
        {
            boardGame = boardGameInitial;
            CreateBoard();
            turn = 0;
        }
    }
}
