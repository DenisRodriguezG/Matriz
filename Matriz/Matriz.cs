using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz
{
    internal class cMatriz
    {
        private int nRenglones;
        private int nColumnas;
        private int[,] Tabla;
        private string nombre;

        public string Nombre { get => nombre; set => nombre = value; }

        public cMatriz()//primer constructor sin parametro
        {
            nRenglones = 3;
            nColumnas = 2;
            Tabla = new int[nRenglones, nColumnas];
            nombre = "Sin nombre";
        }
        public cMatriz(string n)//primer constructor con parametro
        {
            nRenglones = 3;
            nColumnas = 2;
            Tabla = new int[nRenglones, nColumnas];
            nombre = n;
        }
        public cMatriz(int r, int c)//recibe los renglones y columnas
        {
            nRenglones = r;
            nColumnas = c;
            Tabla = new int[nRenglones, nColumnas];
            nombre = "Sin nombre";
        }
        public cMatriz(int r, int c, string n)//este recibe todos los parametros
        {
            nRenglones = r;
            nColumnas = c;
            Tabla = new int[nRenglones, nColumnas];
            nombre = n;
        }
        public cMatriz(cMatriz Copia)//copia profunda de los datos
        {
            nRenglones = Copia.nRenglones;
            nColumnas = Copia.nColumnas;
            Tabla = new int[nRenglones, nColumnas];
            nombre = Copia.nombre;
            for (int i = 0; i < nRenglones; i++)
                for (int j = 0; j < nColumnas; j++)
                    Tabla[i, j] = Copia.Tabla[i, j];
        }
        public void ingresar()//caputa los elementos que les solicita al usuario
        {
            Console.WriteLine("Matriz :" + nombre);
            Console.WriteLine("Matriz de {0} renglones y {1} columnas ", nRenglones, nColumnas);
            Console.WriteLine("---------------------------------------------------");
            for (int i = 0; i < nRenglones; i++)
            {
                Console.WriteLine("Para el renglon = {0}", i + 1);
                for (int j = 0; j < nColumnas; j++)
                {
                    Console.WriteLine("Ingrese posicion[" + (i + 1) + "," + (j + 1) + "]: ");
                    string linea;
                    linea = Console.ReadLine();
                    Tabla[i, j] = int.Parse(linea);
                }
            }
            Console.WriteLine("---------------------------------------------------");
        }
        public void ActualizaCasilla(int r, int c, int v)
        {
            Tabla[r, c] = v;
        }
        public void Imprimir()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string character = "";
            for (int i = 0; i < nRenglones; i++)
            {
                for (int j = 0; j < nColumnas; j++)
                    character += Tabla[i, j] + " ";
                character += "\n";

            }

            return string.Format(character);
        }
        public bool MatrizDeFilaRenglo()
        {
            if (nRenglones == 1)
                return true;
            return false;
        }
        public bool MatrizDeFilaColum()
        {
            if (nColumnas == 1)
                return true;
            return false;
        }
        public bool verificaOpuesta(cMatriz Op1)
        {
            if (nRenglones == Op1.nRenglones && nColumnas == Op1.nColumnas)
            {
                for (int i = 0; i < nRenglones; i++)
                    for (int j = 0; j < nColumnas; j++)
                        if (Tabla[i, j] != Op1.Tabla[i, j] * -1)
                            return false;
                return true;
            }
            return false;
        }
        public cMatriz Opuesta()
        {
            cMatriz O = new cMatriz(this);
            O.nombre = "Opuesta de " + this.nombre;
            for (int i = 0; i < nRenglones; i++)
                for (int j = 0; j < nColumnas; j++)
                    O.Tabla[i, j] = Tabla[i, j] * -1;
            return O;
        }
        public bool verificaNula()
        {
            for (int i = 0; i < nRenglones; i++)
                for (int j = 0; j < nColumnas; j++)
                    if (Tabla[i, j] != 0)
                        return false;
            return true;
        }
        public bool verificaCuadrada()
        {
            if (nRenglones == nColumnas)
                return true;
            return false;
        }
        public void imprimeDiagonal()
        {
            if (verificaCuadrada())
            {
                Console.WriteLine("elementos de la diagonal de la matriz {0}", Nombre);
                for (int i = 0; i < nRenglones; i++)
                {
                    for (int j = 0; j < nColumnas; j++)

                        if (i == j)
                            Console.Write("{0,4}", Tabla[i, j]);
                        else
                            Console.Write("     ");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("La matriz {0} No tiene diagonal por que no es cuadrada");
        }

        public bool TriangularSuperio()
        {
            if (!verificaCuadrada())
                return false;
            for (int i = 1; i < nRenglones; i++)
                for (int j = 0; j < i; j++)
                    if (Tabla[i, j] != 0)
                        return false;
            return true;

        }
        public bool TringularInferior()
        {
            if (!verificaCuadrada())
                return false;
            for (int i = 0; i < nRenglones - 1; i++)
                for (int j = i + 1; j < nColumnas; j++)
                    if (Tabla[i, j] != 0)
                        return false;
            return true;
        }
        public bool matrizDiagonal()
        {
            if (!verificaCuadrada())
                if (TringularInferior() && TriangularSuperio())
                    return true;
            return false;
        }
        public bool matrisIdentidad()
        {
            if (!verificaCuadrada())
                return false;
            for (int i = 0; i < nRenglones; i++)
                for (int j = 0; j < nColumnas; j++)
                    if (i == j)
                    {
                        if (Tabla[i, j] != 1)//si todos los de la diagonal son 1
                            return false;
                    }
                    else
                        if (Tabla[i, j] != 0)//pregunta si los demas son 0
                        return false;
            return true;
        }
        static public bool operator ==(cMatriz Op1, cMatriz Op2)
        {
            if (Op1.nRenglones == Op2.nRenglones && Op1.nColumnas == Op2.nColumnas)
            {
                for (int i = 0; i < Op1.nRenglones; i++)
                    for (int j = 0; j < Op2.nColumnas; j++)
                        if (Op1.Tabla[i, j] != Op2.Tabla[i, j])
                            return false;
            }
            else
                return false;
            return true;
        }
        static public bool operator !=(cMatriz Op1, cMatriz Op2)
        {
            if (Op1 == Op2)
                return false;
            return true;
        }
        public override bool Equals(object obj)
        {
            cMatriz aux = (cMatriz)obj;
            return base.Equals(this == aux);
        }
        public bool VerificaTranspuesta(cMatriz aux)
        {
            if (nRenglones == aux.nColumnas && nColumnas == aux.nRenglones)
            {
                for (int i = 0; i < nRenglones; i++)
                    for (int j = 0; j < nColumnas; j++)
                        if (Tabla[i, j] != aux.Tabla[j, i])
                            return false;
            }
            else
                return false;
            return true;
        }
        public cMatriz Trabspuesta()
        {
            cMatriz T = new cMatriz(nColumnas, nRenglones, "Transpuesta de " + this.nombre);//se crea la matriz transpuesta y se le da el nombre de cual sera transpuesta 
            for (int i = 0; i < T.nRenglones; i++)
                for (int j = 0; j < T.nColumnas; j++)
                    T.Tabla[i, j] = Tabla[j, i];
            return T;
        }
        public bool Simetrica()
        {
            if (!verificaCuadrada())
                return false;
            cMatriz T = new cMatriz(this.Trabspuesta());
            if (this == T)
                return true;
            return false;
        }
        public bool antiSimetrica()
        {
            cMatriz o = new cMatriz(this.Opuesta());
            cMatriz t = new cMatriz(this.Trabspuesta());
            if (t == o)
                return true;
            return false;
        }
        public static cMatriz operator +(cMatriz Op1, cMatriz Op2)
        {
            cMatriz suma = new cMatriz(Op1.nRenglones, Op1.nColumnas, Op1.nombre + " + " + Op2.nombre);
            if (Op1.nColumnas == Op2.nColumnas && Op1.nRenglones == Op2.nRenglones)
                for (int i = 0; i < Op1.nRenglones; i++)
                    for (int j = 0; j < Op2.nColumnas; j++)
                        suma.Tabla[i, j] = Op1.Tabla[i, j] + Op2.Tabla[i, j];
            return suma;
        }
        public static cMatriz operator -(cMatriz Op1, cMatriz Op2)
        {
            cMatriz resta = new cMatriz(Op1.nRenglones, Op1.nColumnas, Op1.nombre + " - " + Op2.nombre);
            if (Op1.nColumnas == Op2.nColumnas && Op1.nRenglones == Op2.nRenglones)
                for (int i = 0; i < Op1.nRenglones; i++)
                    for (int j = 0; j < Op2.nColumnas; j++)
                        resta.Tabla[i, j] = Op1.Tabla[i, j] - Op2.Tabla[i, j];
            return resta;
        }
        public static cMatriz operator *(cMatriz Op1, int e)
        {
            cMatriz m = new cMatriz(Op1.nRenglones, Op1.nColumnas, Op1.nombre + " * " + e.ToString());
            for (int i = 0; i < Op1.nRenglones; i++)
                for (int j = 0; j < Op1.nColumnas; j++)
                    m.Tabla[i, j] = Op1.Tabla[i, j] * e;
            return m;
        }
        public static cMatriz operator *(int e, cMatriz Op1)
        {
            cMatriz m = new cMatriz(Op1.nRenglones, Op1.nColumnas, Op1.nombre + " * " + e.ToString());
            for (int i = 0; i < Op1.nRenglones; i++)
                for (int j = 0; j < Op1.nColumnas; j++)
                    m.Tabla[i, j] = Op1.Tabla[i, j] * e;
            return m;
        }
        public static cMatriz operator *(cMatriz Op1, cMatriz Op2)
        {
            int suma = 0;
            cMatriz resultado = new cMatriz(Op1.nRenglones, Op2.nColumnas, Op1.nombre + " * " + Op2.nombre);
            if (Op1.nColumnas == Op2.nRenglones)
            {
                for (int i = 0; i < resultado.nRenglones; i++)
                    for (int j = 0; j < resultado.nColumnas; j++)
                    {
                        suma = 0;
                        for (int k = 0; k < Op1.nColumnas; k++)
                            suma += Op1.Tabla[i, k] * Op2.Tabla[k, j];
                        resultado.Tabla[i, j] = suma;
                    }
            }
            return resultado;
        }
        public bool MatrizIdempotente()
        {
            if (!verificaCuadrada())
                return false;
            return (this * this == this);
        }
        public void determinante()
        {
            int p1V = 0;
            int p2V = 0;
            int p3V = 0;
            int r1V = 0;
            int r2V = 0;
            int r3V = 0;
            int determinanteTotal = 0;
            for (int i = 1; i < nRenglones; i++)
            {
                int clave = i - 1;
                for (int j = 0; j < nColumnas; j++)
                {
                    if(i == 1 && j == 1)
                    {
                        p1V = Tabla[clave, 0] * Tabla[i, j];
                    }
                    if (i == 2 && j == 2)
                    {
                        p1V = p1V * Tabla[i, j];
                    }
                    if (i == 1 && j == 2)
                    {
                        p2V = Tabla[clave, 1] * Tabla[i, j];
                    }
                    if (i == 2 && j == 0)
                    {
                        p2V = p2V * Tabla[i, j];
                    }
                    if (i == 1 && j == 0)
                    {
                        p3V = Tabla[clave, 2] * Tabla[i, j];
                    }
                    if (i == 2 && j == 1)
                    {
                        p3V = p3V * Tabla[i, j];
                    }
                    if(i == 1 && j == 1)
                    {
                        r1V = Tabla[clave, 2] * Tabla[i, j];
                    }
                    if (i == 2 && j == 1)
                    {
                        r1V = r1V * Tabla[i, j];
                    }
                    if (i == 1 && j == 2)
                    {
                        r2V = Tabla[clave, 0] * Tabla[i, j];
                    }
                    if (i == 2 && j == 1)
                    {
                        r2V = r2V * Tabla[i, j];
                    }
                    if (i == 1 && j == 0)
                    {
                        r3V = Tabla[clave, 1] * Tabla[i, j];
                    }
                    if (i == 2 && j == 2)
                    {
                        r3V = r3V * Tabla[i, j];
                    }
                }
            }
            determinanteTotal = p1V + p2V + p3V - r1V - r2V - r3V;
            Console.WriteLine(determinanteTotal);
        }
        public int Determinante2()
        {
            cMatriz Temp = new cMatriz(nRenglones, nColumnas * 2, "Temporal");

            for (int i = 0; i < nRenglones; i++)
                for (int j = 0; j < nRenglones; j++)
                    Temp.Tabla[i, j] = Tabla[i, j];

            for (int i = 0; i < nRenglones; i++)
                for (int j = nRenglones; j < (nColumnas * 2); j++)
                    Temp.Tabla[i, j] = Tabla[i, j - nRenglones];

            //Operación suma
            int acomulaMulti, det = 0, k;
            int p1V = 0;
            int p2V = 0;
            if (nRenglones == 2) 
            {
                for (int i = 1; i < nRenglones; i++)
                {
                    int clave = i - 1;
                    for (int j = 0; j < nColumnas; j++)
                    {
                        if (i == 1 && j == 1)
                        {
                            p1V = Tabla[clave, 0] * Tabla[i, j];
                        }
                        if (i == 1 && j == 0)
                        {
                            p2V = Tabla[clave, 1] * Tabla[i, j];
                        }
                    }
                }
                det = p1V - p2V;
                        }
            else
            {
                for (int i = 0; i < nRenglones; i++)
                {
                    acomulaMulti = 1;
                    k = i;
                    for (int j = 0; j < nRenglones; j++, k++)
                    {
                        acomulaMulti *= Temp.Tabla[j, k];

                    }
                    det += acomulaMulti;
                }

                //Operación resta
                for (int i = 0; i < nRenglones; i++)
                {
                    acomulaMulti = 1;
                    k = i;
                    for (int j = (nRenglones - 1); j >= 0; j--, k++)
                    {
                        acomulaMulti *= Temp.Tabla[j, k];

                    }
                    det -= acomulaMulti;
                }
            }
            return det;
        }
        public int MenorComplementario(int Aii, int Ajj)
        {
            int Ai = (Aii - 1);
            int Aj = (Ajj - 1);
            cMatriz MCA = new cMatriz(nRenglones - 1, nColumnas - 1, "Menor Complementario");
            int inc = 0;
            int jin = 0;
            bool findIt = true;
            if (Ai < 0 || Aj < 0)
                return 0;
            if (Ai >= nRenglones || Aj >= nColumnas)
                return 0;
            for(int i = 0; i < nRenglones; i++)
            {
                Console.WriteLine("inc -> " + inc);

                findIt = false;
                for (int j = 0; j < nColumnas; j++)
                    {
                    
                        if (i != Ai && j != Aj)
                        {
                            Console.WriteLine(Tabla[i, j]);
                            MCA.Tabla[inc, jin] = Tabla[i, j];//MCA.Tabla[inc++, jin++] = Tabla[i, j];
                        findIt = true;
                            jin++;
                        }
                    }
                if (findIt)
                    inc = inc + 1;
                
                jin = 0;
            }
            Console.WriteLine(MCA);
            return MCA.Determinante2();
        }
    }
}
