using System;
using System.Globalization;

namespace Prova3
{
    class Program
    {
        static void Main(string[] args)
        {
            double total = 0;

            string[] s = Console.ReadLine().Split(' ');

            int escolha = int.Parse(s[0]);
            int qtde = int.Parse(s[1]);

            if (escolha == 1)
                total = 4 * qtde;
            if (escolha == 2)
                total = 4.50 * qtde;
            if (escolha == 3)
                total = 5 * qtde;
            if (escolha == 4)
                total = 2 * qtde;
            if (escolha == 5)
                total = 1.50 * qtde;

            Console.WriteLine("Total: R$ " + total.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}