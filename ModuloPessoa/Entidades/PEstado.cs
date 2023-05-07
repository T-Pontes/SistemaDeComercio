namespace ModuloPessoa.Entidades
{
    public class PEstado
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Uf { get; set; }

        public List<PCidade> Cidades = new();

        public PEstado(int id, string descricao, string uf)
        {
            Id = id;
            Descricao = descricao;
            Uf = uf;
        }

        public override bool Equals(object? obj)
        {
            return obj is PEstado estado &&
                   Id == estado.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"   Id: {Id}{Environment.NewLine}" +
                   $"   Estado: {Descricao}{Environment.NewLine}" +
                   $"   UF: {Uf}";
        }
    }
}