using ModuloGlobal.Enums;

namespace ModuloPessoa.Entidades
{
    public class PTelefone
    {
        public int Id { get; set; }
        public GTipoTelefone Tipo { get; set; }
        public string Numero { get; set; }
        public bool WhatsApp { get; set; }

        public PPessoa Pessoa { get; set; }

        public PTelefone(int id, GTipoTelefone tipo, string numero, bool whatsApp, PPessoa pessoa)
        {
            Id = id;
            Tipo = tipo;
            Numero = numero;
            WhatsApp = whatsApp;
            Pessoa = pessoa;
        }

        public override bool Equals(object? obj)
        {
            return obj is PTelefone telefone &&
                   Id == telefone.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"       Id: {Id}{Environment.NewLine}" +
                   $"       Tipo de Telefone: {Tipo}{Environment.NewLine}" +
                   $"       Número: {Numero}{Environment.NewLine}" +
                   $"       WhatsApp?: {WhatsApp}";
        }
    }
}
