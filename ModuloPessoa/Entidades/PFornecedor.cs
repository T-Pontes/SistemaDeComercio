using ModuloGlobal.Enums;

namespace ModuloPessoa.Entidades
{
    public class PFornecedor
    {
        public DateTime DtCadastro { get; set; }
        
        public GStatus Status { get; set; } //Tipo enumerado do módulo global
        public int PPessoaId { get; set; }
        public PPessoa Pessoa { get; set; }

        public PFornecedor(DateTime dtCadastro, GStatus status, PPessoa pessoa)
        {
            DtCadastro = dtCadastro;
            Status = status;
            Pessoa = pessoa;
        }

        public override bool Equals(object? obj)
        {
            return obj is PFornecedor fornecedor &&
                   EqualityComparer<PPessoa>.Default.Equals(Pessoa, fornecedor.Pessoa);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pessoa);
        }

        public override string ToString()
        {
            return $"Id: {Pessoa.Id}{Environment.NewLine}" +
                   $"Nome: {Pessoa.Nome}{Environment.NewLine}" +
                   $"Data de cadastro: {DtCadastro}{Environment.NewLine}" +
                   $"Status: {Status}";
        }

    }
}
