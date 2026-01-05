using System;
using System.Collections.Generic;
using System.Text;

namespace concessionaria
{
    internal class Moto : Veiculo
    {
        public int Cilindradas { get; set; }

        public Moto() { }

        public Moto(string marca, string modelo, int ano, int cilindradas)
            : base(marca, modelo, ano)
        {
            Cilindradas = cilindradas;
        }

        // Sobrescreve o método da classe base (polimorfismo)
        public override void Acelerar()
        {
            Console.WriteLine($"Moto {Marca} {Modelo} empinando e acelerando com {Cilindradas}cc!");
        }

        public override void Frear()
        {
            Console.WriteLine($"Moto {Marca} {Modelo} freando rapidamente!");
        }

        public override string ObterInformacoes()
        {
            return $"Moto: {Marca} {Modelo} ({Ano}) - {Cilindradas}cc";
        }

        // Método específico da Moto
        public void Empinar()
        {
            Console.WriteLine($"{Marca} {Modelo} está empinando!");
        }
    }
}