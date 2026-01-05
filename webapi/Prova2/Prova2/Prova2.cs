using System;
using System.Globalization;

namespace VoltandoABase
{
    class Prova2
    {
        static void Main(string[] args)
        {
            double pi = 3.14159;
            double raio = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double area = pi * (raio * raio);

            Console.WriteLine("A = " + area.ToString("F4", CultureInfo.InvariantCulture));

        }
    }
}
