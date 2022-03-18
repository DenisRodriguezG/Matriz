using System;

namespace Matriz
{
    class Program
    {
        static void Main(string []args)
        {
            cMatriz M1 = new cMatriz(3, 3);
            M1.ingresar();
            Console.WriteLine(M1.AdjuntoElemento(2, 1));
            //Console.WriteLine(M1.MenorComplementario(1, 2));
           //Console.WriteLine(M1.Determinante2());
            //2 0 5 -7 1 2 4 4 -3
        }
    }
}
