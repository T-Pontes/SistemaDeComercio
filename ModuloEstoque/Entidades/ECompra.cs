using ModuloInfra.Entidades;
using ModuloPessoa.Entidades;

namespace ModuloEstoque.Entidades
{
    public class ECompra
    {
        public int Id { get; set; }

        public PFornecedor Fornecedor { get; set; }
        public PFuncionario Comprador { get; set; }
        public InfEstabelecimento Loja { get; set; }

        public List<EMovimento> Itens = new();

        public ECompra(int id, PFornecedor fornecedor, PFuncionario comprador, InfEstabelecimento loja)
        {
            Id = id;
            Fornecedor = fornecedor;
            Comprador = comprador;
            Loja = loja;
        }

        public override bool Equals(object? obj)
        {
            return obj is ECompra compra &&
                   Id == compra.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"Id: {Id}{Environment.NewLine}" +
                   $"Fornecedor: {Fornecedor.Pessoa.Nome}{Environment.NewLine}" +
                   $"Comprador: {Comprador.Pessoa.Nome}{Environment.NewLine}" +
                   $"Loja: {Loja.Pessoa.Nome}";
        }
    }
}
