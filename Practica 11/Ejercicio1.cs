using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_11
{
    class Ejercicio1
    {
        static void Main(string[] args)
        {
            //Jose Humberto Posada Castro
            try
            {
                Console.Write("Ingrese los datos del cliente.");
                Console.WriteLine();
                Console.Write("Nombre: ");
                string Nombre = Console.ReadLine();
                Console.Write("Telefono: ");
                int Celular = Convert.ToInt32(Console.ReadLine());
                Console.Write("Fecha de Nacimiento: ");
                string Nacimiento = Console.ReadLine();
                Console.Write("Sueldo: ");
                double Sueldo = Convert.ToDouble(Console.ReadLine());
                FileStream stream = new FileStream("empleado.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter binario = new BinaryWriter(stream);
                binario.Write(Nombre);
                binario.Write(Celular);
                binario.Write(Nacimiento);
                binario.Write(Sueldo);
                stream.Close();
                binario.Close();
                Console.ReadKey();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();



        }

    }
}
