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
        private const int GRID_COLUMN = 3;     // don't forget to change to 9
        private const int GRID_ROW = 3;        // don't forget to change to 9
        private bool ArrayNoSequences = false;
        private int MutableVar = -1;


        // [0,0]  [0,1]  [0,2]  [0,3]  [GRID_COLUMN, GRID_ROW]
        // [1,0]  [1,1]  [1,2]  [1,3]
        // [2,0]  [2,1]  [2,2]  [3,3]
        // [3,0]  [3,1]  [3,2]  [3,3]

        public void CreateGrid()
        {
            for (int i = 0; i < GRID_COLUMN; i++)
            {
                for (int j = 0; j < GRID_ROW; j++)
                {
                    _grid[i, j] = CreateNumber();
                }
            }
            MatchingSearch();
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
                    Console.Write($"{_grid[i, j]}  ");
                }
            }
        }

        public void MatchingSearch()
        {
            while (!ArrayNoSequences)
            {
                for (int i = 0; i < GRID_COLUMN; i++)
                {
                    var tmpArrayColumn = new int[GRID_COLUMN];
                    var tmpArrayRow = new int[GRID_ROW];

                    for (int j = 0; j < GRID_ROW; j++)
                    {
                        tmpArrayColumn[j] = _grid[j, i];
                        tmpArrayRow[j] = _grid[i, j];
                    }
                    ArrayNoSequences = реаре(tmpArrayColumn, MutableVar, i);
                    ArrayNoSequences = реаре(tmpArrayRow, i, MutableVar);

                    ValueShift();
                }
            }
        }

        private bool реаре(int[] arr, int coordX, int coordY)
        {
            bool NoSequences = true;
            for (int i = 0; i < arr.Length-2; i++)
            {
                int tmpNum = arr[i];
                int count = 0;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (tmpNum == arr[j]) count++;
                    else if(tmpNum != arr[j] || j == arr.Length-1)
                    {
                        if(count >= 3)
                        {
                            NoSequences = false;
                            for (int h = i; h < j; h++)
                            {
                                if(coordX == -1)
                                {
                                    _grid[h, coordY] = MutableVar;
                                }
                                else if(coordY == -1)
                                {
                                    _grid[coordX, h] = MutableVar;
                                }
                            }
                        }
                    }
                }
            }
            return NoSequences;
        }

        private int CreateNumber()
        {
            return rnd.Next(0, 4);
        } 

        private void ValueShift()
        {
            for (int i = 0; i < GRID_COLUMN-1; i++)
            {
                for (int j = 0; j < GRID_ROW; j++)
                {
                    if (_grid[i, j] == -1 && i == 0)
                    {
                        _grid[i, j] = CreateNumber();
                    }

                    else if (_grid[i, j] == -1 )
                    {

                    }
                }
            }
        }
    }
}
