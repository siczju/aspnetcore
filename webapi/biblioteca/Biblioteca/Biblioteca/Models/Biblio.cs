using System;
using System.Collections.Generic;
using System.Linq;

namespace Biblioteca.Models
{
    public class Biblio : Livro
    {
        public Biblio() { }
        public List<Livro> livros = new List<Livro>();

        public void AdicionarLivro(Livro livro)
        {
            livros.Add(livro);
        }
        
        public void ListarLivros()
        {
            foreach(var livro in livros)
            {
                Console.WriteLine(livro);
            }
            Console.WriteLine();
        }

        public void EmprestarLivro(int id)
        {
            var livro = livros.FirstOrDefault(l => l.Id == id);
            if(livro != null)
            {
                livro.Emprestar();
            }
        }

        public void DevolverLivro(int id)
        {
            var livro = livros.Find(l => l.Id == id);

            if(livro != null)
            {
                livro.Devolver();
            }
        }

        public void RemoverLivro(int id)
        {
            var livro = livros.Find(l => l.Id == id);

            if(livro != null)
            {
                livros.Remove(livro);
            }
        }
    }
}