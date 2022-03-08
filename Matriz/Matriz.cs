using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz
{
    internal class Matriz
    {
        private int[,] matriz;
        private int row;
        private int column;
        public Matriz(int row, int column)
        {
            this.row = row;
            this.column = column;
            matriz = new int[row, column];
        }

        public void insert()
        {
            Random R1 = new Random();
            for (int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                    matriz[i, j] = R1.Next(0, 100);
        }
        public void printMatriz()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string character = "";
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                    character += matriz[i, j] + " ";
                character += "\n";
            }
                
            return string.Format(character);
        }
    }
}
