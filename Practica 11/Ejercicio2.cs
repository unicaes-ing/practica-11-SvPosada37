using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_11
{
    class Ejercicio2
    {
        static void Main(string[] args)
        {
            try
            {

                FileStream stream = new FileStream("empleado.dat", FileMode.Open, FileAccess.Read);
                BinaryReader binario = new BinaryReader(stream);
                string Nombre = binario.ReadString();
                int Celular = binario.ReadInt32();
                string Nacimiento = binario.ReadString();
                double Sueldo = binario.ReadDouble();
                stream.Close();
                binario.Close();
                Console.Clear();
                Console.WriteLine("Datos del empleado:");
                Console.WriteLine();
                Console.WriteLine("Nombre: {0}", Nombre);
                Console.WriteLine("Telefono: {0}", Celular);
                Console.WriteLine("Fecha de Nacimiento: {0}", Nacimiento);
                Console.WriteLine("Sueldo: {0}", Sueldo);
                Console.WriteLine("Presione enter para salir.");
                Console.ReadKey();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



        }

    }
}
