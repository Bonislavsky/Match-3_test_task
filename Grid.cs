using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3
{
    public class Grid
    {
        private int[,] _grid = new int[WIDTH_HEIGHT_MATRIX, WIDTH_HEIGHT_MATRIX];
        private Random rnd = new Random();
        private const int WIDTH_HEIGHT_MATRIX = 9;     
        private int MutableVar = -1;

        public void CreateGrid()
        {
            for (int i = 0; i < WIDTH_HEIGHT_MATRIX; i++)
            {
                for (int j = 0; j < WIDTH_HEIGHT_MATRIX; j++)
                {
                    _grid[i, j] = GetRndNumber();
                }
            }
        }

        public void ShowGrid()
        {
            Console.Write("   ");
            for (int i = 0; i < WIDTH_HEIGHT_MATRIX; i++)
            {
                Console.Write($"[{i}]");
            }

            for (int i = 0; i < WIDTH_HEIGHT_MATRIX; i++)
            {
                Console.Write($"\n[{i}] ");
                for (int j = 0; j < WIDTH_HEIGHT_MATRIX; j++)
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
                while (!ArrayNoSequences && attemptsWithoutSequences < WIDTH_HEIGHT_MATRIX - 1)
                {
                    attemptsWithoutSequences = 0;
                    for (int i = 0; i < WIDTH_HEIGHT_MATRIX; i++)
                    {
                        if (ReplaceSequence(MutableVar, i) && ReplaceSequence(i, MutableVar)) 
                        {
                            attemptsWithoutSequences++;
                        }
                        else
                        {
                            ValueShift(i);
                            ChangeValue();
                            break;
                        }
                    }
                }
            }
        }

        private bool ReplaceSequence(int coordX, int coordY)
        {
            bool NoSequences = true;
            if (coordX == MutableVar)
            {
                for (int i = 0; i < WIDTH_HEIGHT_MATRIX - 2; i++)
                {
                    int tmpNumI = _grid[i, coordY];

                    if (tmpNumI == MutableVar) continue;

                    int count = 1;
                    for (int j = i + 1; j < WIDTH_HEIGHT_MATRIX; j++)
                    {
                        if (tmpNumI == _grid[j, coordY]) count++;

                        if (tmpNumI != _grid[j, coordY] || j == _grid.GetLength(0) - 1 || tmpNumI != _grid[j+1, coordY])
                        {
                            if (count >= 3)
                            {
                                NoSequences = false;

                                for (int h = i; h <= j; h++)
                                {
                                    _grid[h, coordY] = MutableVar;                                    
                                }
                            }
                            else if (count < 3)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            else if (coordY == MutableVar)
            {
                for (int i = 0; i < WIDTH_HEIGHT_MATRIX - 2; i++)
                {
                    int tmpNumI = _grid[coordX, i];

                    if (tmpNumI == MutableVar) continue;

                    int count = 1;
                    for (int j = i + 1; j < WIDTH_HEIGHT_MATRIX; j++)
                    {
                        if (tmpNumI == _grid[coordX, j]) count++;

                        if (tmpNumI != _grid[coordX, j] || j == _grid.GetLength(0) - 1 || tmpNumI != _grid[coordX, j+1])
                        {
                            if (count >= 3)
                            {
                                NoSequences = false;

                                for (int h = i; h <= j; h++)
                                {
                                    _grid[coordX, h] = MutableVar;
                                }
                            }
                            else if (count < 3)
                            {
                                break;
                            }
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

        private void ValueShift(int coordY)
        {
            for (int i = 0; i < WIDTH_HEIGHT_MATRIX; i++)
            {
                if (_grid[i, coordY] == -1)
                {
                    for (int j = 0; j < i; j++)
                    {
                        if (_grid[j, coordY] != -1)
                        {
                            int tmpn = _grid[j, coordY];
                            _grid[j, coordY] = _grid[i, coordY];
                            _grid[i, coordY] = tmpn;
                            break;
                        }
                    }
                }
            }
        }

        private void ChangeValue()
        {
            for (int i = 0; i < WIDTH_HEIGHT_MATRIX; i++)
            {
                for (int j = 0; j < WIDTH_HEIGHT_MATRIX; j++)
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
