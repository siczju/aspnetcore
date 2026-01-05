using System;
using System.Collections.Generic;
using System.Text;

namespace concessionaria
{
    internal class Veiculo
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        public Veiculo() { }

        public Veiculo(string marca, string modelo, int ano)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
        }

        // Método virtual que pode ser sobrescrito pelas classes derivadas
        public virtual void Acelerar()
        {
            Console.WriteLine($"{Marca} {Modelo} está acelerando...");
        }

        public virtual void Frear()
        {
            Console.WriteLine($"{Marca} {Modelo} está freando...");
        }

        public virtual string ObterInformacoes()
        {
            return $"Veículo: {Marca} {Modelo} ({Ano})";
        }
    }
}