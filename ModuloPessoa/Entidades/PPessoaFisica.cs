using ModuloGlobal.Enums;

namespace ModuloPessoa.Entidades
{
    public class PPessoaFisica : PPessoa
    {
        public string Cpf { get; set; }
        public DateTime DtNascimento { get; set; }

        public PPessoaFisica(int id, string nome, string cpf, DateTime dtNascimento, GStatus status) : base(id, nome, status)
        {
            Cpf = cpf;
            DtNascimento = dtNascimento;
        }

        public override bool Equals(object? obj)
        {
            return obj is PPessoaFisica fisica &&
                   base.Equals(obj) &&
                   Id == fisica.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Id);
        }

        public override string ToString()
        {
            return $"Id: {Id}{Environment.NewLine}" +
                   $"Nome: {Nome}{Environment.NewLine}" +
                   $"CPF: {Cpf}{Environment.NewLine}" +
                   $"Data de Nascimento: {DtNascimento}{Environment.NewLine}" +
                   $"Status: {Status}";
        }
    }
}
