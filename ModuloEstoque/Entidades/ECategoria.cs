using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloEstoque.Entidades
{
    public class ECategoria
    {
        public int Id { get; set; }
        public string Descricao { get; set;}

        public List<EProduto> Produtos = new();

        public ECategoria(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool Equals(object? obj)
        {
            return obj is ECategoria categoria &&
                   Id == categoria.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"   Id: {Id}{Environment.NewLine}" +
                   $"   Categoria: {Descricao}";
        }
    }
}
