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
        private const int GRID_COLUMN = 9;     
        private const int GRID_ROW = 9;        
        private int MutableVar = -1;

        public void CreateGrid()
        {
            for (int i = 0; i < GRID_COLUMN; i++)
            {
                for (int j = 0; j < GRID_ROW; j++)
                {
                    _grid[i, j] = GetRndNumber();
                }
            }
        }

        public void ShowGrid()
        {
            Console.Write("   ");
            for (int i = 0; i < GRID_ROW; i++)
            {
                Console.Write($"[{i}]");
            }

            for (int i = 0; i < GRID_COLUMN; i++)
            {
                Console.Write($"\n[{i}] ");
                for (int j = 0; j < GRID_ROW; j++)
                {
                    Console.Write($"{_grid[i, j]}  ");
                }
            }
        }

        public void MatchingSearch()
        {
            for (int re = 0; re < 2; re++)
            {
                int attemptsWithoutSequences = 0;
                bool ArrayNoSequences = false;
                while (!ArrayNoSequences && attemptsWithoutSequences < GRID_COLUMN-1)
                {
                    attemptsWithoutSequences = 0;
                    for (int i = 0; i < GRID_COLUMN; i++)
                    {
                        var tmpArrayColumn = new int[GRID_COLUMN];
                        var tmpArrayRow = new int[GRID_ROW];

                        for (int j = 0; j < GRID_ROW; j++)
                        {
                            tmpArrayColumn[j] = _grid[j, i];
                            tmpArrayRow[j] = _grid[i, j];
                        }

                        if (ReplaceSequence(tmpArrayColumn, MutableVar, i) && ReplaceSequence(tmpArrayRow, i, MutableVar)) 
                        {
                            attemptsWithoutSequences++;
                        }
                        else
                        {
                            ValueShift(tmpArrayColumn, i);
                            ChangeValue();
                            break;
                        }
                    }
                }
            }
        }

        private bool ReplaceSequence(int[] arr, int coordX, int coordY)
        {
            bool NoSequences = true;
            for (int i = 0; i < arr.Length-2; i++)
            {
                int tmpNum = arr[i];

                if (tmpNum == MutableVar) continue;
                int count = 1;
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(tmpNum == arr[j]) count++;
                    if (tmpNum != arr[j] || j == arr.Length-1 || tmpNum != arr[j+1])
                    {
                        if(count >= 3)
                        {
                            NoSequences = false;

                            for (int h = i; h <= j; h++)
                            {
                                if (coordX == -1)
                                {
                                    arr[h] = -1;
                                    _grid[h, coordY] = MutableVar;
                                }
                                else if (coordY == -1)
                                {
                                    arr[h] = -1;
                                    _grid[coordX, h] = MutableVar;
                                }
                            }
                        }
                        else if(count < 3)
                        {
                            break;
                        }
                    }
                }
            }
            return NoSequences;
        }

        private int GetRndNumber()
        {
            return rnd.Next(0, 4);
        }

        private void ValueShift(int[] arr, int coordY)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == -1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (arr[j] != -1)
                        {
                            int tmpn = _grid[j, coordY];
                            _grid[j, coordY] = _grid[i, coordY];
                            _grid[i, coordY] = tmpn;

                            int tmp = arr[j];
                            arr[j] = arr[i];
                            arr[i] = tmp;
                            break;
                        }
                    }
                }
            }
        }

        private void ChangeValue()
        {
            for (int i = 0; i < GRID_COLUMN; i++)
            {
                for (int j = 0; j < GRID_ROW; j++)
                {
                    if (_grid[i, j] == -1)
                    {
                        _grid[i, j] = GetRndNumber();
                    }
                }
            }
        }
    }
}
