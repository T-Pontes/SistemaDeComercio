namespace ModuloPessoa.Entidades
{
    public class PCidade
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public PEstado Estado { get; set; }

        public List<PEndereco> Enderecos = new();

        public PCidade(int id, string descricao, PEstado estado)
        {
            Id = id;
            Descricao = descricao;
            Estado = estado;
        }

        public override bool Equals(object? obj)
        {
            return obj is PCidade cidade &&
                   Id == cidade.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"   Id: {Id}{Environment.NewLine}" +
                   $"   Cidade: {Descricao}";
        }
    }
}