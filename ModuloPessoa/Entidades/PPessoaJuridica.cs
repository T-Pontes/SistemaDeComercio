using ModuloGlobal.Enums;

namespace ModuloPessoa.Entidades
{
    public class PPessoaJuridica : PPessoa
    {
        public string Cnpj { get; set; }
        public DateTime DtAbertura { get; set; }
        public string NomeFantasia { get; set; }

        public PPessoaJuridica(int id, string nome, string cnpj, DateTime dtAbertura, string nomeFantasia, GStatus status) : base(id, nome, status)
        {
            Cnpj = cnpj;
            DtAbertura = dtAbertura;
            NomeFantasia = nomeFantasia;
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
                   $"Nome Fantasia: {NomeFantasia}{Environment.NewLine}" +
                   $"CNPJ: {Cnpj}{Environment.NewLine}" +
                   $"Data de Nascimento: {DtAbertura}{Environment.NewLine}" +
                   $"Status: {Status}";
        }
    }
}
