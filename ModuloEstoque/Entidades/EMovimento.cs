using ModuloGlobal.Enums;
using ModuloInfra.Entidades;
using ModuloPessoa.Entidades;
using System.Drawing;
using System.Globalization;
using System.Runtime.ConstrainedExecution;

namespace ModuloEstoque.Entidades
{
    public class EMovimento
    {
        public int Id { get; set; }
        public double PrecoUnitario { get; set; }
        public double Quantidade { get; set; }
        public DateTime Data { get; set; }

        public EProduto Produto { get; set; }
        public GTipoMovimento Tipo { get; set; }
        public InfEstabelecimento Loja { get; set; }

        public EMovimento(int id, double precoUnitario, double quantidade, DateTime data, EProduto produto, GTipoMovimento tipo, InfEstabelecimento loja)
        {
            Id = id;
            PrecoUnitario = precoUnitario;
            Quantidade = quantidade;
            Data = data;
            Produto = produto;
            Tipo = tipo;
            Loja = loja;
        }

        public override bool Equals(object? obj)
        {
            return obj is EMovimento movimento &&
                   Id == movimento.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"       Id: {Id}{Environment.NewLine}" +
                   $"       Produto: {Produto.Descricao}{Environment.NewLine}" +
                   $"       Categora: {Produto.Categoria.Descricao}{Environment.NewLine}" +
                   $"       Preço Unitário: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.##}", PrecoUnitario)}({Produto.Unidade.Abreviacao}){Environment.NewLine}" +
                   $"       Quantidade: {Quantidade}{Produto.Unidade.Abreviacao}{Environment.NewLine}" +
                   $"       Total: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "R$ {0:#,###.##}", PrecoUnitario * Quantidade)}{Environment.NewLine}" +
                   $"       Data: {Data}{Environment.NewLine}" +
                   $"       Tipo de movimento: {Tipo}{Environment.NewLine}" +
                   $"       Loja: {Loja.Pessoa.Nome}";
        }
    }
}