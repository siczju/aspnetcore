using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Class1
    {
        public async Task FritarOvo()
        {
            Console.WriteLine("Fritand ovo....");
            await Task.Delay(TimeSpan.FromSeconds(10));
            Console.WriteLine("Terminou ovo...." + Environment.NewLine);
        }

        public async Task FazerSuco()
        {
            Console.WriteLine("Fazendo suco.....");
            await Task.Delay(TimeSpan.FromSeconds(3));
            Console.WriteLine("Terminou Suco suco....." + Environment.NewLine);
        }

        public async Task LavarPanela()
        {
            Console.WriteLine("Lavando Panela.....");
            await Task.Delay(TimeSpan.FromSeconds(4));
            Console.WriteLine("Terminou Panela....." + Environment.NewLine);
        }

    }
}
