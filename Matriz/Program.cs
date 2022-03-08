using System;

namespace Matriz
{
    class Program
    {
        static void Main(string []args)
        {
            Matriz M1 = new Matriz(3, 2);
            M1.insert();
            M1.printMatriz();
            int[,] N = { { 2, 3 }, { 5, 6 }, { 8, 6 } };

        }
    }
}
