using System;
using System.Globalization;

namespace Prova
{
    class Prova
    {
        static void Main(string[] args)
        {
            string[] s1 = Console.ReadLine().Split(' ');

            int itemCodigo1 = int.Parse(s1[0]);
            int numeroDePecas1 = int.Parse(s1[1]);
            double valor1 = double.Parse(s1[2], CultureInfo.InvariantCulture);

            string[] s2 = Console.ReadLine().Split(' ');

            int itemCodigo2 = int.Parse(s2[0]);
            int numeroDePecas2 = int.Parse(s2[1]);
            double valor2 = double.Parse(s2[2], CultureInfo.InvariantCulture);

            double total = (numeroDePecas1 * valor1) + (numeroDePecas2 * valor2);

            Console.WriteLine("VALOR A SER PAGO: " + total.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}