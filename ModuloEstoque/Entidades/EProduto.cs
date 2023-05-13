namespace ModuloEstoque.Entidades
{
    public class EProduto
    {
        public int Id { get; set; }
        public string Descricao { get; set;}
        public double Preco { get; set; }
        public double EstoqueMin { get; set; }
        public double EstoqueMax { get; set; }

        public ECategoria Categoria { get; set; }
        public EUnidade Unidade { get; set; }

        public List<EMovimento> Movimentos = new();

        public EProduto(int id, string descricao, double preco, double estoqueMin, double estoqueMax, ECategoria categoria, EUnidade unidade)
        {
            Id = id;
            Descricao = descricao;
            Preco = preco;
            EstoqueMin = estoqueMin;
            EstoqueMax = estoqueMax;
            Categoria = categoria;
            Unidade = unidade;
        }

        public override bool Equals(object? obj)
        {
            return obj is EProduto produto &&
                   Id == produto.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"   Id: {Id}{Environment.NewLine}" +
                   $"   Descricao: {Descricao}{Environment.NewLine}" +
                   $"   Categora: {Categoria.Descricao}{Environment.NewLine}" +
                   $"   Unidade: {Unidade.Descricao}{Environment.NewLine}" +
                   $"   Preço: {Preco}{Environment.NewLine}" +
                   $"   Estoque mínimo: {EstoqueMin}{Environment.NewLine}" +
                   $"   Estoque máximo: {EstoqueMax}{Environment.NewLine}";
        }
    }
}
