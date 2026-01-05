using Biblioteca.Enum;
using System;

namespace Biblioteca.Models
{
    public class Livro
    {
        public Livro() { }
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public StatusDoLivro Status { get; set; }

        public Livro(int id, string titulo, string autor, StatusDoLivro status)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Autor = autor;
            this.Status = status;
        }

        public void Emprestar()
        {
            Status = StatusDoLivro.Emprestado;
        }

        public void Devolver()
        {
            Status = StatusDoLivro.Disponivel;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Título: {Titulo}, Autor: {Autor}, Status: {Status}";
        }
    }
}