using ModuloPessoa.Entidades;

namespace ModuloInfra.Entidades
{
    public class InfEstabelecimento
    {
        public bool Matriz { get; set; }

        public int PessoaId { get; set; }
        public PPessoa Pessoa { get; set; }

        public InfEstabelecimento(bool matriz, int pessoaId, PPessoa pessoa)
        {
            Matriz = matriz;
            PessoaId = pessoaId;
            Pessoa = pessoa;
        }

        public override bool Equals(object? obj)
        {
            return obj is InfEstabelecimento estabelecimento &&
                   EqualityComparer<PPessoa>.Default.Equals(Pessoa, estabelecimento.Pessoa);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pessoa);
        }

        public override string ToString()
        {
            return $"       Id: {Pessoa.Id}{Environment.NewLine}" +
                   $"       Razão social: {Pessoa.Nome}{Environment.NewLine}" +
                   $"       Status: {Pessoa.Status}{Environment.NewLine}" +
                   $"       Matriz {Matriz}{Environment.NewLine}";
        }
    }
}