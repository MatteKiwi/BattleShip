using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SänkSkepp
{
    class Game
    {
        public Game()
        {
            int ver = 0;
            int hor = 0;
            int boats = 5;
            int score = 0;
            string playerName;
            Random r = new Random();
            int hBounds = 1;
            int vBounds = 1;

            Console.WriteLine("***************************");
            Console.WriteLine("******BATTLESHIP GAME******");
            Console.WriteLine("***************************");

            char[,] grid, answer_grid;
            Grid(out grid, out answer_grid);

            Populate(r, answer_grid);

            Console.WriteLine("Get ready to battle! There are 5 ships to find.");
            Console.WriteLine("Please Enter your name: ");

            playerName = GetName();

            //kallar generic klass
            GetPoint<string> obj = new GetPoint<string>();
            obj.Value = "1 - Press 1 Start Game.\n2 - Press 0 to Exit System.";

            Console.WriteLine(obj.Value);

            string userInput = Console.ReadLine();

            userInput = ValidInput(userInput);

            if (userInput == "0")
            {
                Environment.Exit(0);
            }
            else if (userInput == "1")
            {
                Console.Clear();
                ActullyTheGame(ref ver, ref hor, ref boats, ref score, playerName, ref hBounds, ref vBounds, grid, answer_grid);
            }
            Console.ReadLine();
        }

        private void ActullyTheGame(ref int ver, ref int hor, ref int boats, ref int score, string playerName, ref int hBounds, ref int vBounds, char[,] grid, char[,] answer_grid)
        {
            while (boats > 0)
            {
                HBounds(ref hor, ref hBounds);
                VBounds(ref ver, score, playerName, ref vBounds);
                ShipLocation(ver, hor, ref boats, ref score, grid, answer_grid);

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    for (int j = 0; j < grid.GetLength(1); j++)
                    {
                        Console.Write(grid[i, j]);
                    }
                    Console.WriteLine();
                }
                AnswerGrid(out hBounds, out vBounds, answer_grid);
            }
            Console.WriteLine("You win!");
        }

        private string ValidInput(string userInput)
        {
            while (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Please enter a valid input!");
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        private void HBounds(ref int hor, ref int hBounds)
        {
            
            while (hBounds == 1)
            {
                //kallar generic klass
                HorizontalCordinates<string> horizontal = new HorizontalCordinates<string>();
                horizontal.Value = "Please enter your horizontal coordinate (1-8):";
                Console.WriteLine(horizontal.Value);
                hor = Convert.ToInt32(Console.ReadLine());
                if (hor < 1 || hor > 8)
                {
                    Console.WriteLine("Please only enter a number 1-8.");
                }
                if (hor >= 1 && hor <= 8)
                {
                    hBounds = 2;
                }
            }
        }

        private void VBounds(ref int ver, int score, string playerName, ref int vBounds)
        {
            while (vBounds == 1)
            {
                //kallar generic klass
                VerticalCordinates<string> vertical = new VerticalCordinates<string>();
                vertical.Value = "Please enter your vertical coordinate (1-8) or enter 0 to exit!";
                Console.WriteLine(vertical.Value);
                ver = Convert.ToInt32(Console.ReadLine());
                if (ver == 0)
                {
                    string message = playerName + ", Your Score is: " + score;
                    Console.WriteLine(score);

                    Console.WriteLine("Exiting..!");
                    Environment.Exit(0);
                }
                if (ver < 1 || ver > 8)
                {
                    Console.WriteLine("Please only enter a number 1-8.");
                }
                if (ver >= 1 && ver <= 8)
                {
                    vBounds = 2;
                }
            }
        }

        private void ShipLocation(int ver, int hor, ref int boats, ref int score, char[,] grid, char[,] answer_grid)
        {
            //sätter vart "shipen" ska vara
            if (answer_grid[ver - 1, hor - 1] == '1') //hittate skäppet
            {
                grid[ver - 1, hor - 1] = '*';
                score++; //adding the score
                Console.WriteLine("hit!");
                Console.WriteLine("Your Score is: " + score);
                boats = boats - 1;
            }
            else if (answer_grid[ver - 1, hor - 1] == '2') // nära skäppet
            {
                grid[ver - 1, hor - 1] = '%';
                Console.WriteLine("near miss!");
                Console.WriteLine("Your Score is: " + score);
            }
            else // miss
            {
                grid[ver - 1, hor - 1] = 'x';
                Console.WriteLine("miss!");
                Console.WriteLine("Your Score is: " + score);
            }
        }

        private void AnswerGrid(out int hBounds, out int vBounds, char[,] answer_grid)
        {
            //visa svars grid
            Console.WriteLine();
            Console.WriteLine("ANSWER GRID");
            for (int i = 0; i < answer_grid.GetLength(0); i++)
            {
                for (int j = 0; j < answer_grid.GetLength(1); j++)
                {
                    Console.Write(answer_grid[i, j]);
                }
                Console.WriteLine();
            }
            vBounds = 1;
            hBounds = 1;
        }

        private string GetName()
        {
            string playerName = Console.ReadLine();
            //frågar om namn
            while (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Please Enter your name to continue: ");
                playerName = Console.ReadLine();
            }

            return playerName;
        }

        private void Populate(Random r, char[,] answer_grid)
        {
            for (int populate = 0; populate <= 4; populate++)
            {

                int a = r.Next(0, 8);
                int b = r.Next(0, 8);

                answer_grid[a, b] = '1';

                if (a > 0 && answer_grid[a - 1, b] != '1')
                {
                    answer_grid[a - 1, b] = '2';
                }
                if (a < 7 && answer_grid[a + 1, b] != '1')
                {
                    answer_grid[a + 1, b] = '2';
                }
                if (b > 0 && answer_grid[a, b - 1] != '1')
                {
                    answer_grid[a, b - 1] = '2';
                }
                if (b < 7 && answer_grid[a, b + 1] != '1')
                {
                    answer_grid[a, b + 1] = '2';
                }
            }
        }

        private void Grid(out char[,] grid, out char[,] answer_grid)
        {
            //gör ett grid av arrays av arrays
            grid = new char[8, 8];
            for (int i = 0; i < grid.GetLength(0); i++)
            {

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    //single char är i '', strings är i ""
                    grid[i, j] = '0';
                }
            }

            answer_grid = new char[8, 8];
            for (int x = 0; x < answer_grid.GetLength(0); x++)
            {

                for (int y = 0; y < answer_grid.GetLength(1); y++)
                {
                    //single char är i '', strings är i ""
                    answer_grid[x, y] = '0';
                }
            }
        }

    }
}
