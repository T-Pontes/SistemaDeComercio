namespace ModuloPessoa.Entidades
{
    public class PEndereco
    {
        public int Id { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }

        public PCidade Cidade { get; set; }
        public PPessoa Pessoa { get; set; }

        public PEndereco(int id, string cep, string logradouro, string numero, string complemento, string bairro, PCidade cidade, PPessoa pessoa)
        {
            Id = id;
            Cep = cep;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Pessoa = pessoa;
        }

        public override bool Equals(object? obj)
        {
            return obj is PEndereco endereco &&
                   Id == endereco.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"       Id: {Id}{Environment.NewLine}" +
                   $"       CEP: {Cep}{Environment.NewLine}" +
                   $"       Logradouro: {Logradouro}{Environment.NewLine}" +
                   $"       Numero: {Numero}{Environment.NewLine}" +
                   $"       Complemento: {Complemento}{Environment.NewLine}" +
                   $"       Bairro: {Bairro}{Environment.NewLine}" +
                   $"       Cidade: {Cidade.Descricao}{Environment.NewLine}" +
                   $"       UF: {Cidade.Estado.Descricao}";
        }
    }
}
