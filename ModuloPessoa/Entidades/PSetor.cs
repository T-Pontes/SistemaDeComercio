namespace ModuloPessoa.Entidades
{
    public class PSetor
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public List<PFuncionario> Funcionarios = new();

        public PSetor(int id, string descricao)
        {
            Id = id;
            Descricao = descricao;
        }

        public override bool Equals(object? obj)
        {
            return obj is PSetor setor &&
                   Id == setor.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"   ID: {Id}{Environment.NewLine}" +
                   $"   Setor: {Descricao}";
        }
    }
}
