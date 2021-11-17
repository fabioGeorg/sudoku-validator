using System;

namespace SudokuValidator
{
    class Program
    {
        private static int GRID_WIDTH = 9;
        private static int GRID_HEIGHT = 9;
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Argument missing");
                return;
            }
            else if (args.Length > 1)
            {
                Console.WriteLine("Too many arguments. Only one needed!");
                return;
            }            
            Console.WriteLine(Validate(args[0]));
            //Console.WriteLine(Validate("123456789234567891345678912456789123567891234678912345789123456891234567912345678"));         
        }

        private static string Validate(string grid)
        {
            int[,] parsedGrid = ParseGrid(grid);
            bool valid = true;
            int countLine = 0;            

            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                countLine = parsedGrid[0, y] + parsedGrid[1, y] + parsedGrid[2, y]
                    + parsedGrid[3, y] + parsedGrid[4, y] + parsedGrid[5, y]
                    + parsedGrid[6, y] + parsedGrid[7, y] + parsedGrid[8, y];
                valid = countLine == 45 && valid;
                countLine = 0;
            }

            for(int x = 0; x < GRID_WIDTH; x++)
            {
                countLine = parsedGrid[x, 0] + parsedGrid[x, 1] + parsedGrid[x, 2]
                    + parsedGrid[x, 3] + parsedGrid[x, 4] + parsedGrid[x, 5]
                    + parsedGrid[x, 6] + parsedGrid[x, 7] + parsedGrid[x, 8];
                valid = countLine == 45 && valid;
                countLine = 0;
            }

            ShowGrid(parsedGrid);

            return valid ? "Valid" : "Invalid";
        }

        private static int[,] ParseGrid(string grid)
        {
            int[] gridArray = new int[grid.Length];
            int[,] tmp = new int[GRID_WIDTH, GRID_HEIGHT];

            for (int i = 0; i < gridArray.Length; i++)            
                int.TryParse(grid[i].ToString(), out gridArray[i]);                            

            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                for (int x = 0; x < GRID_WIDTH; x++)                
                    tmp[x, y] = gridArray[x + (y * GRID_WIDTH)];                
            }

            return tmp;
        }

        private static void ShowGrid(int[,] grid)
        {
            for (int y = 0; y < GRID_HEIGHT; y++)
            {
                for (int x = 0; x < GRID_WIDTH; x++)                
                    Console.Write(grid[x, y] + " ");                
                Console.WriteLine();
            }
        }
    }
}
