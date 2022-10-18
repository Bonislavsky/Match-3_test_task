using System;

namespace Match3
{
    class Program
    {
        static void Main(string[] args)
        {
            Grid Grid = new Grid();
            Grid.CreateGrid();

            Console.WriteLine(">>> початкова матриця\n");
            Grid.ShowGrid();
        }
    }
}
