using System;

namespace Matriz
{
    class Program
    {
        static void Main(string []args)
        {
            cMatriz M1 = new cMatriz(3, 3);
            M1.ingresar();
            Console.WriteLine(M1);
            M1.determinante();

        }
    }
}
