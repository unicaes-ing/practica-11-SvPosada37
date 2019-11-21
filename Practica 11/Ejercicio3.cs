using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Practica_11
{
    class Ejercicio3
    {
        static void Main(string[] args)
        {
            int Opcion;
            int AnchoRenglon = 20 + 4 + 4 + 16;
            int NumeroRenglon = 0;
            FileStream fileStream;
            BinaryWriter ArcihvoEscribir;
            BinaryReader ArcihvoLeer;

            try
            {
                fileStream = new FileStream("DatosAlumno.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                ArcihvoEscribir = new BinaryWriter(fileStream);
                ArcihvoLeer = new BinaryReader(fileStream);
                NumeroRenglon = Convert.ToInt32(Math.Ceiling((decimal)fileStream.Length / AnchoRenglon));
                do
                {
                    Console.Clear();
                    Console.WriteLine("Menú");
                    Console.WriteLine("\n1) Agregar alumno");
                    Console.WriteLine("\n2) Mostrar alumno");
                    Console.WriteLine("\n3) Buscar alumno");
                    
                    Opcion = Convert.ToInt32(Console.ReadLine());

                    switch (Opcion)
                    {
                        case 1:
                            //Agregar
                            try
                            {
                                Console.Clear();
                                NumeroRenglon = Convert.ToInt32(Math.Ceiling((decimal)fileStream.Length / AnchoRenglon));
                                ArcihvoEscribir.BaseStream.Seek(NumeroRenglon * AnchoRenglon, SeekOrigin.Begin);
                                Console.WriteLine("Ingrese los datos del alumno: ");
                                Console.WriteLine();
                                Console.WriteLine("\nCarnet: ");
                                string Carnet = Console.ReadLine();
                                Console.WriteLine("\nNombre: ");
                                string Nombre = Console.ReadLine();
                                Console.WriteLine("\nEdad: ");
                                int Edad = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("\nCUM: ");
                                decimal CUM = Convert.ToDecimal(Console.ReadLine());
                                ArcihvoEscribir.Write(Carnet);
                                ArcihvoEscribir.Write(Nombre);
                                ArcihvoEscribir.Write(Edad);
                                ArcihvoEscribir.Write(CUM);
                                Console.WriteLine("\nLos datos fueron almacenados correctamente.");
                                Console.ReadKey();



                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;


                        case 2:
                            //Mostrar
                            try
                            {
                                try
                                {
                                    NumeroRenglon = Convert.ToInt32(Math.Ceiling((decimal)fileStream.Length / AnchoRenglon));
                                    ArcihvoLeer.BaseStream.Seek(0, SeekOrigin.Begin);
                                    Console.Clear();
                                    Console.WriteLine("Datos de los alumnos.");
                                    Console.WriteLine();
                                    Console.WriteLine("{0,-4} {1,-24} {2,-10} {3,-12} {4} "
                                        , "N", "Carnet", "Nombre", "Edad", "CUM");
                                    Console.WriteLine("==========================================================");
                                    int NumeroAlumno = 1;


                                    do
                                    {

                                        string Carnet = ArcihvoLeer.ReadString();
                                        string Nombre = ArcihvoLeer.ReadString();
                                        int Edad = ArcihvoLeer.ReadInt32();
                                        decimal CUM = ArcihvoLeer.ReadDecimal();
                                        Console.WriteLine("{0,-5} {1,-22} {2, -11} {3, -12} {4}", NumeroAlumno, Carnet, Nombre, Edad, CUM);
                                        ArcihvoLeer.BaseStream.Seek(NumeroAlumno * AnchoRenglon, SeekOrigin.Begin);
                                        NumeroAlumno++;
                                    } while (true);


                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                }

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            Console.ReadKey();


                            break;

                        case 3:
                            //Buscar

                            try
                            {
                                Console.Clear();
                                Console.WriteLine("Numero de la persona que desea buscar: ");
                                int n = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                NumeroRenglon = Convert.ToInt32(Math.Ceiling((decimal)fileStream.Length / AnchoRenglon));
                                if (n <= NumeroRenglon)
                                {
                                    ArcihvoLeer.BaseStream.Seek((n - 1) * AnchoRenglon, SeekOrigin.Begin);
                                    string Carnet = ArcihvoLeer.ReadString();
                                    string Nombre = ArcihvoLeer.ReadString();
                                    int Edad = ArcihvoLeer.ReadInt32();
                                    decimal CUM = ArcihvoLeer.ReadDecimal();

                                    Console.WriteLine("\n{0,-21}", Carnet);
                                    Console.WriteLine("\n{0,-11}", Nombre);
                                    Console.WriteLine("\n{0,-11}", Edad);
                                    Console.WriteLine("\n{0:N2}", CUM);

                                }

                                else
                                {
                                    Console.WriteLine("No existe el numero de la persona solicitada...");
                                }
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 4:
                            //Salir
                            Console.Clear();
                            Console.WriteLine("Presione cualquier tecla para salir.");
                            Console.ReadKey();

                            break;
                    }

                } while (Opcion != 4);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
