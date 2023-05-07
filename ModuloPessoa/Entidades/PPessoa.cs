using ModuloGlobal.Enums;

namespace ModuloPessoa.Entidades
{
    public abstract class PPessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public GStatus Status { get; set; } //Tipo enumerado do módulo global

        public List<PTelefone> Telefones = new();

        public List<PEndereco> Enderecos = new();

        public PPessoa(int id, string nome, GStatus status)
        {
            Id = id;
            Nome = nome;
            Status = status;
        }

        public override bool Equals(object? obj)
        {
            return obj is PPessoa pessoa &&
                   Id == pessoa.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
