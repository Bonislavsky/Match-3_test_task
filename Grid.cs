using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3
{
    public class Grid
    {
        private int[,] _grid = new int[GRID_COLUMN, GRID_ROW];
        private Random rnd = new Random();
        private const int GRID_COLUMN = 4;     // don't forget to change to 9
        private const int GRID_ROW = 4;        // don't forget to change to 9

        public void CreateGrid()
        {
            for (int i = 0; i < GRID_COLUMN; i++)
            {
                for (int j = 0; j < GRID_ROW; j++)
                {
                    _grid[i,j] = rnd.Next(0, 4);
                }
            }
        }

        public void ShowGrid()
        {
            for (int i = 0; i < GRID_ROW+1; i++)
            {
                Console.Write($"[{i}]");
            }

            for (int i = 0; i < GRID_COLUMN; i++)
            {
                Console.Write($"\n[{i+1}] ");
                for (int j = 0; j < GRID_ROW; j++)
                {
                    Console.Write($"{_grid[i, j]}, ");
                }
            }
        }
    }
}
