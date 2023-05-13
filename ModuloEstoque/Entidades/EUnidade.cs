using System;

namespace ModuloEstoque.Entidades
{
    public class EUnidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Abreviacao { get; set; }

        public List<EProduto> Produtos = new();

        public EUnidade(int id, string descricao, string abreviacao)
        {
            Id = id;
            Descricao = descricao;
            Abreviacao = abreviacao;
        }

        public override bool Equals(object? obj)
        {
            return obj is EUnidade unidade &&
                   Id == unidade.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"   Id: {Id}{Environment.NewLine}" +
                   $"   Unidade de Medida: {Descricao}{Environment.NewLine}" +
                   $"   Abreviação: {Abreviacao}";
        }
    }
}
