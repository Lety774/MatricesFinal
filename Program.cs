using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MatricesFinal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string otraOp;
            byte op;

            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("MENU DE OPCIONES");
                    Console.WriteLine("1.- Suma de dos Matrices");
                    Console.WriteLine("2.- Resta de dos Matrices");
                    Console.WriteLine("3.- Multiplicacion de dos Matrices");
                    Console.WriteLine("4.- Resultado anterior");
                    Console.WriteLine("5.- Salir");
                    Console.Write("\n\nElige una opcion: ");
                    op = byte.Parse(Console.ReadLine());
                    switch (op)
                    {
                        //manda a llamar la funcion correspondiente
                        case 1: Suma(); break;
                        case 2: Resta(); break;
                        case 3: Multiplicacion(); break;
                        //LA OPCION CUATRO NO SUPIMOS COMO HACERLA
                        case 5:
                            {
                                //termina la ejecucion del programa
                                Console.WriteLine("\n\nBye Bye Bye \nSaliste del programa");
                                Thread.Sleep(5000);
                                Environment.Exit(0);
                                break;
                            }
                    }

                    Console.WriteLine("\n\n¿Quieres otra operacion? (S/N)");
                    otraOp = Console.ReadLine();

                } while (otraOp != "N");

                Console.WriteLine("\n\nBye Bye Bye \nGracias por utizar este programa");

            } while (otraOp == "N");

            Console.WriteLine("\n\n----- Bienvenido -----");

            Console.ReadKey();
        }

        static void Suma()
        {
            //declaracion de variables
            int fila1 = 0, fila2 = 0, colum1 = 0, colum2 = 0;
            bool e;
            do
            {
                try
                {
                    //solicita cuantas filas y columnas que va a tener la matriz
                    //lee el dato, lo convierte a tipo entero, y lo almacena el dato introducido por el usuario
                    Console.WriteLine("[Matriz 1]");
                    Console.Write("Filas: ");
                    fila1 = int.Parse(Console.ReadLine());
                    Console.Write("Columnas: ");
                    colum1 = int.Parse(Console.ReadLine());
                    e = false;
                }
                //bloque que cacha la exepcion, evitando que se rompa la ejecucion
                catch (Exception)
                {
                    Console.WriteLine("Dato Incorrecto");
                    e = true;

                }
                //si alguno de estos datos esta incorrecto solicita de nuevo
                // todos los datos solicitados en este bloque de codigo
                try
                {
                    //solicita cuantas filas y columnas va a tener la matriz
                    //lee el dato, lo convierte a tipo entero, y lo almacena el dato introducido por el usuario
                    Console.WriteLine(" \n [Matriz 2]");
                    Console.Write("Filas: ");
                    fila2 = int.Parse(Console.ReadLine());
                    Console.Write("Columnas: ");
                    colum2 = int.Parse(Console.ReadLine());
                    e = false;
                }
                //bloque que cacha la exepcion, evitando que se rompa la ejecucion
                catch (Exception)
                {
                    Console.WriteLine("Dato Incorrecto");
                    e = true;

                }
                //declaracion de arreglos
                int[,] Matriz1 = new int[fila1 + 1, colum1 + 1];
                int[,] Matriz2 = new int[fila2 + 1, colum2 + 1];
                int[,] Suma = new int[fila1 + 1, colum2 + 1];

                //ve verifica que se intruscan valores de tipo entero
                //se verifica que columna 1 sea igual fila 2 ya que si no es asi mostrara un mensaje de error
                if (fila1 == colum1 && fila2 == colum2)
                {
                    try
                    {
                        //empezara a solitar los datos que se almacenara en Matriz1
                        Console.WriteLine(" \n Datos [Matriz 1]: ");
                        //empiza con la fila 1
                        for (int i = 1; i <= fila1; i++)
                        {
                            //toma en cuenta el indice segundo, por decir (1,1) se toma en cuenta el segundo 1,
                            //se le aumenta 1 a la siguiente iteracio
                            for (int j = 1; j <= colum1; j++)
                            {
                                Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i, j);
                                Matriz1[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato Incorrecto");
                    }

                    try
                    {
                        //empezara a solitar los datos que se almacenara en Matriz2
                        Console.WriteLine(" \n Datos [Matriz 2]: ");
                        //empiza con la fila 1
                        for (int i = 1; i <= fila1; i++)
                        {
                            //toma en cuenta el indice segundo, por decir (1,1) se toma en cuenta el segundo 1,
                            //se le aumenta 1 a la siguiente iteracio
                            for (int j = 1; j <= colum1; j++)
                            {
                                Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i, j);
                                Matriz2[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato Incorrecto");
                    }

                    //hara la suma, primer indice de la matriz1 mas el primer indice de la matriz2 y asi sucesivamente
                    for (int x = 0; x < Matriz1.GetLength(0); x++)
                    {
                        for (int y = 0; y < Matriz1.GetLength(1); y++)
                        {
                            Suma[x, y] = Matriz1[x, y] + Matriz2[x, y];
                        }
                    }

                    //para mostrar el resultado de la suma de matrices 
                    Console.WriteLine("Suma de 2 Matrices");
                    StreamWriter archivoExistente;
                    archivoExistente = File.AppendText("resultados.txt");

                    archivoExistente.Write("\n");
                    archivoExistente.Write("Suma de 2 Matrices\n");
                    for (int i = 1; i <= fila1; i++)
                    {
                        for (int j = 1; j <= colum2; j++)
                        {
                            Console.Write("{0} ", Suma[i, j]);
                            archivoExistente.Write("{0} ", Suma[i, j]);

                        }
                        Console.WriteLine();
                    }
                    //se cierra el archivo
                    archivoExistente.Close();
                    Console.WriteLine("La matriz del resultado se guardo en el archivo resultados");
                }
                else
                {
                    //si la columna 1 es diferente al valor de fila 2 se mostrara un mensaje de error
                    Console.WriteLine("Error: No se puede sumar las matrices. La dimension de las matrices deben ser iguales");
                }
                Console.Read();

            } while (fila1 != colum1 && fila2 != colum2);

        }

        static void Resta()
        {
            //declaracion de variables
            int fila1 = 0, fila2 = 0, colum1 = 0, colum2 = 0;
            bool e;
            do
            {
                try
                {
                    //solicita cuantas filas y columnas va a tener la matriz
                    //lee el dato, lo convierte a tipo entero, y lo almacena el dato introducido por el usuario
                    Console.WriteLine("[Matriz 1]");
                    Console.Write("Filas: ");
                    fila1 = int.Parse(Console.ReadLine());
                    Console.Write("Columnas: ");
                    colum1 = int.Parse(Console.ReadLine());
                    e = false;
                }
                //bloque que cacha la exepcion, evitando que se rompa la ejecucion
                catch (Exception)
                {
                    Console.WriteLine("Dato Incorrecto");
                    e = true;

                }
                //si alguno de estos datos esta incorrecto solicita de nuevo
                // todos los datos solicitados en este bloque de codigo
                try
                {
                    //solicita cuantas filas y columnas va a tener la matriz
                    //lee el dato, lo convierte a tipo entero, y lo almacena el dato introducido por el usuario
                    Console.WriteLine(" \n [Matriz 2]");
                    Console.Write("Filas: ");
                    fila2 = int.Parse(Console.ReadLine());
                    Console.Write("Columnas: ");
                    colum2 = int.Parse(Console.ReadLine());
                    e = false;
                }
                //bloque que cacha la exepcion, evitando que se rompa la ejecucion
                catch (Exception)
                {
                    Console.WriteLine("Dato Incorrecto");
                    e = true;

                }
                //declaracion de las matrices
                int[,] Matriz1 = new int[fila1 + 1, colum1 + 1];
                int[,] Matriz2 = new int[fila2 + 1, colum2 + 1];
                int[,] Resta = new int[fila1 + 1, colum2 + 1];

                //se verifica que se introduscan valores de tipo entero
                //se verifica que columna 1 sea igual fila 2 ya que si no es asi mostrara un mensaje de error
                if (fila1 == colum1 && fila2 == colum2)
                {
                    try
                    {
                        //empezara a solitar los datos que se almacenara en Matriz1
                        Console.WriteLine(" \n Datos [Matriz 1]: ");
                        //empiza con la fila 1
                        for (int i = 1; i <= fila1; i++)
                        {
                            //toma en cuenta el indice segundo, por decir (1,1) se toma en cuenta el segundo 1,
                            //se le aumenta 1 a la siguiente iteracio
                            for (int j = 1; j <= colum1; j++)
                            {
                                Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i, j);
                                Matriz1[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato Incorrecto");
                    }
                    //
                    try
                    {
                        //empezara a solitar los datos que se almacenara en Matriz2
                        Console.WriteLine(" \n Datos [Matriz 2]: ");
                        //empiza con la fila 1
                        for (int i = 1; i <= fila1; i++)
                        {
                            //toma en cuenta el indice segundo, por decir (1,1) se toma en cuenta el segundo 1,
                            //se le aumenta 1 a la siguiente iteracio
                            for (int j = 1; j <= colum1; j++)
                            {
                                Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i, j);
                                Matriz2[i, j] = int.Parse(Console.ReadLine());
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Dato Incorrecto");
                    }

                    //hara la suma, primer indice de la matriz1 mas el primer indice de la matriz2 y asi sucesivamente
                    for (int x = 0; x < Matriz1.GetLength(0); x++)
                    {
                        for (int y = 0; y < Matriz1.GetLength(1); y++)
                        {
                            Resta[x, y] = Matriz1[x, y] - Matriz2[x, y];
                        }
                    }

                    //para mostrar el resultado de la matriz 
                    Console.WriteLine("Resta de 2 Matrices");
                    StreamWriter archivoExistente;
                    archivoExistente = File.AppendText("resultados.txt");

                    archivoExistente.Write("\n");
                    archivoExistente.Write("Resta de 2 Matrices\n");
                    for (int i = 1; i <= fila1; i++)
                    {
                        for (int j = 1; j <= colum2; j++)
                        {
                            Console.Write("{0} ", Resta[i, j]);
                            archivoExistente.Write("{0} ", Resta[i, j]);

                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("La matriz del resultado se guardo en el archivo resultados");
                    archivoExistente.Close();
                }
                else
                {
                    //si la columna 1 es diferente al valor de fila 2 se mostrara un mensaje de error
                    Console.WriteLine("Error: No se puede restar las matrices");
                }
                Console.Read();

            } while (fila1 != colum1 && fila2 != colum2);

        }
        static void Multiplicacion()
        {
            //declaracion e inicializacion de variables
            int fila1 = 0, fila2 = 0, colum1 = 0, colum2 = 0;
            bool e;
            do
            {
                try
                {
                    //solicita cuantas filas y columnas va a tener la matriz
                    //lee el dato, lo convierte a tipo entero, y lo almacena el dato introducido por el usuario
                    Console.WriteLine("[Matriz 1]");
                    Console.Write("Filas: ");
                    fila1 = int.Parse(Console.ReadLine());
                    Console.Write("Columnas: ");
                    colum1 = int.Parse(Console.ReadLine());
                    e = false;
                }
                //bloque que cacha la exepcion, evitando que se rompa la ejecucion
                catch (Exception)
                {
                    Console.WriteLine("Dato Incorrecto");
                    e = true;

                }
                //si alguno de estos datos esta incorrecto solicita de nuevo
                // todos los datos solicitados en este bloque de codigo
                try
                {
                    //solicita cuantas filas y columnas va a tener la matriz
                    //lee el dato, lo convierte a tipo entero, y lo almacena el dato introducido por el usuario
                    Console.WriteLine(" \n [Matriz 2]");
                    Console.Write("Filas: ");
                    fila2 = int.Parse(Console.ReadLine());
                    Console.Write("Columnas: ");
                    colum2 = int.Parse(Console.ReadLine());
                    e = false;
                }
                //bloque que cacha la exepcion, evitando que se rompa la ejecucion
                catch (Exception)
                {
                    Console.WriteLine("Dato Incorrecto");
                    e = true;

                }
                //declaracion de las matrices
                int[,] Matriz1 = new int[fila1 + 1, colum1 + 1];
                int[,] Matriz2 = new int[fila2 + 1, colum2 + 1];
                int[,] Multiplicacion = new int[fila1 + 1, colum2 + 1];

                //se verifica que se intruscan valores de tipo entero
                //se verifica que columna 1 sea igual fila 2 ya que si no es asi mostrara un mensaje de error
                if (colum1 == fila2)
                {
                    //empezara a solitar los datos que se almacenara en Matriz1
                    Console.WriteLine(" \n Datos [Matriz 1]: ");
                    //primero se llenara lo que corresponde a la fila
                    for (int i = 1; i <= fila1; i++)
                    {
                        //toma en cuenta el indice segundo, por decir (1,1) se toma en cuenta el segundo 1,
                        //se le aumenta 1 a la siguiente iteracio
                        for (int j = 1; j <= colum1; j++)
                        {
                            Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i, j);
                            Matriz1[i, j] = int.Parse(Console.ReadLine());
                        }
                    }
                    //empezara a solitar los datos que se almacenara en Matriz1
                    Console.WriteLine("Datos [Matriz 2]: ");
                    for (int i = 1; i <= fila2; i++)
                    {
                        for (int j = 1; j <= colum2; j++)
                        {
                            Console.Write("Ingresa Dato (Fila: {0} - Columna: {1}): ", i, j);
                            Matriz2[i, j] = int.Parse(Console.ReadLine());
                        }
                    }
                    //hara la multiplicacion
                    //los valores de la primera matriz se toman de manera vertical
                    //los valores de la segunda matriz se toman de manera horizontal
                    //esos valores se multiplican y se suman
                    for (int i = 1; i <= fila1; i++)
                    {
                        for (int j = 1; j <= colum2; j++)
                        {
                            Multiplicacion[i, j] = 0;
                            for (int z = 1; z <= colum1; z++)
                            {
                                //se toma el valor por decir de 1,1 de la matriz1 y se multiplica por el valor por decir de 1,1 de la matriz2
                                //a la suiguiente iteracion se toma el valor por decir de 1,2 de la matriz1 y se multiplica por el valor por decir de 2,1 de la matriz2

                                Multiplicacion[i, j] = Matriz1[i, z] * Matriz2[z, j] + Multiplicacion[i, j];
                            }
                        }
                    }
                    //para mostrar el resultado de la matriz 
                    Console.WriteLine("Multiplicacion de 2 Matrices");
                    StreamWriter archivoExistente;
                    archivoExistente = File.AppendText("resultados.txt");

                    archivoExistente.Write("\n");
                    archivoExistente.Write("Multiplicación de 2 Matrices\n");
                    for (int i = 1; i <= fila1; i++)
                    {
                        for (int j = 1; j <= colum2; j++)
                        {
                            Console.Write("{0} ", Multiplicacion[i, j]);
                            archivoExistente.Write("{0} ", Multiplicacion[i, j]);
                            /*if(i == j+1) {
                                //archivoExistente.Write("{0} ", Multiplicacion[i, j]);
                                archivoExistente.Write("\n{0} ", Multiplicacion[i, j]);
                            }
                            else {
                                archivoExistente.Write("{0} ", Multiplicacion[i, j]);
                            }*/

                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("L matriz del resultado se guardo en el archivo resultados");
                    archivoExistente.Close();
                }
                else
                {
                    //si la columna 1 es diferente al valor de fila 2 se mostrara un mensaje de error
                    Console.WriteLine("Error: No se puede multiplicar las matrices" + " Columnas: {0}! = Filas: {1}", colum1, fila2);
                }
                Console.Read();

            } while (colum1 != fila2);


        }

    }
}
