
using Biblioteca.Models;
using Biblioteca.Enum;
using System;
using System.Linq;

namespace Biblioteca
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             1 - Ver livros disponíveis
             2 - Adicionar livro (Id, Titulo, Autor, Status (Disponivel/Emprestado)
             3 - Remover livro (Id)
             4 - Emprestar livro (Id)
             5 - Devolver livro (Id)
             0 - Sair
             */

            Biblio biblioteca = new Biblio();
            
            biblioteca.AdicionarLivro(new Livro(1, "O Senhor dos Aneis", "J.R.R. Tolkien", StatusDoLivro.Disponivel));
            biblioteca.AdicionarLivro(new Livro(2, "1984", "George Orwell", StatusDoLivro.Disponivel));

            bool continuar = true;
            while (continuar)
            {
                ExibirMenu();

                if (!int.TryParse(Console.ReadLine(), out int opcao))
                {
                    Console.WriteLine("Opção inválida! Digite um número.\n");
                    continue;
                }

                switch (opcao)
                {
                    case 0:
                        Console.WriteLine("Saindo...");
                        continuar = false;
                        break;
                    case 1:
                        Console.WriteLine("Listando todos os livros: ");
                        biblioteca.ListarLivros();
                        break;
                    case 2:
                        AdicionarLivro(biblioteca);
                        break;
                    case 3:
                        RemoverLivro(biblioteca);
                        break;
                    case 4:
                        EmprestarLivro(biblioteca);
                        break;
                    case 5:
                        DevolverLivro(biblioteca);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!!! Tente novamente.\n");
                        break;
                }
            } 


        }

        private static void ExibirMenu()
        {
            Console.WriteLine("\n=== SISTEMA DE BIBLIOTECA ===");
            Console.WriteLine("1 - Ver livros disponíveis");
            Console.WriteLine("2 - Adicionar livro");
            Console.WriteLine("3 - Remover livro");
            Console.WriteLine("4 - Emprestar livro");
            Console.WriteLine("5 - Devolver livro");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
        }
        private static void AdicionarLivro(Biblio biblioteca)
        {
            try
            {
                Console.WriteLine("\nColoque as informações do livro no seguinte formato: Id,Titulo,Autor,Status (0-Disponivel/1-Emprestado):");
                string[] informacoesDoLivro = Console.ReadLine().Split(',', 4);

                if (informacoesDoLivro.Length < 4)
                {
                    Console.WriteLine("\nFormato inválido! Certifique-se de informar todos os dados.");
                    return;
                }

                int id = int.Parse(informacoesDoLivro[0]);
                string titulo = informacoesDoLivro[1];
                string autor = informacoesDoLivro[2];
                StatusDoLivro status = (StatusDoLivro)int.Parse(informacoesDoLivro[3]);

                biblioteca.AdicionarLivro(new Livro(id, titulo, autor, status));
                Console.WriteLine("Livro adicionado com sucesso");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"\nErro ao adicionar livro: {ex.Message}\n");
            }
        }

        private static void RemoverLivro(Biblio biblioteca)
        {
            Console.WriteLine("\nDigite o ID do livro a ser removido...");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!\n");
                return;
            }

            biblioteca.RemoverLivro(id); 
            Console.WriteLine("Livro " + id + " removido...");
        }

        private static void EmprestarLivro(Biblio biblioteca)
        {
            Console.WriteLine("\nDigite qual livro você quer emprestar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("\nID inválido!\n");
                return;
            }
            biblioteca.EmprestarLivro(id);
            Console.WriteLine("\nLivro " + id + " emprestado...");
        }

        private static void DevolverLivro(Biblio biblioteca)
        {
            Console.WriteLine("\nDigite qual livro você quer devolver: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID inválido!\n");
                return;
            }
            biblioteca.DevolverLivro(id);
            Console.WriteLine("\nLivro " + id + " devolvido...");
        }
    }
}