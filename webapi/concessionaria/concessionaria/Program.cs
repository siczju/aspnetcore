namespace concessionaria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Criando objetos
            Veiculo veiculo1 = new Veiculo("Fiat", "Uno", 2020);
            Moto moto1 = new Moto("Honda", "CB 500", 2023, 500);
            Console.WriteLine($"moto1 é um Veiculo? {moto1 is Veiculo}");

            // Demonstrando POLIMORFISMO
            // A variável é do tipo Veiculo, mas pode referenciar uma Moto
            Veiculo veiculo2 = new Moto("Yamaha", "YZF-R3", 2024, 321);

            Console.WriteLine("=== Informações dos Veículos ===");
            Console.WriteLine(veiculo1.ObterInformacoes());
            Console.WriteLine(moto1.ObterInformacoes());
            Console.WriteLine(veiculo2.ObterInformacoes());

            Console.WriteLine("\n=== Testando Métodos ===");
            veiculo1.Acelerar();
            moto1.Acelerar();
            veiculo2.Acelerar(); // Chama o método da Moto (polimorfismo!)

            Console.WriteLine("\n=== Freando ===");
            veiculo1.Frear();
            moto1.Frear();
            veiculo2.Frear();

            Console.WriteLine("\n=== Método Específico da Moto ===");
            moto1.Empinar();

            // veiculo2.Empinar(); // ERRO! Não compila porque veiculo2 é do tipo Veiculo

            // Para chamar métodos específicos, precisa fazer casting
            if (veiculo2 is Moto moto2)
            {
                moto2.Empinar();
            }

            Console.WriteLine("\n=== Polimorfismo com Array ===");
            Veiculo[] veiculos = new Veiculo[]
            {
                new Veiculo("Ford", "Ka", 2019),
                new Moto("Kawasaki", "Ninja 400", 2023, 400),
                new Moto("BMW", "S1000RR", 2024, 999)
            };

            foreach (var veiculo in veiculos)
            {
                Console.WriteLine(veiculo.ObterInformacoes());
                veiculo.Acelerar();
                Console.WriteLine();
            }
        }
    }
}