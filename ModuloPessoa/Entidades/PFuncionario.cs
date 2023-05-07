using ModuloGlobal.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloPessoa.Entidades
{
    public class PFuncionario
    {
        public DateTime DtAdmissao { get; set; }
        public DateTime? DtDemissao { get; set; }

        public GStatus Status { get; set; } //Tipo enumerado do módulo global
        public PSetor Setor { get; set; }
        public int PPessoaId { get; set; }
        public PPessoa Pessoa { get; set; }

        public PFuncionario(DateTime dtAdmissao, DateTime? dtDemissao, GStatus status, PSetor setor, PPessoa pessoa)
        {
            DtAdmissao = dtAdmissao;
            DtDemissao = dtDemissao;
            Status = status;
            Setor = setor;
            Pessoa = pessoa;
        }

        public override bool Equals(object? obj)
        {
            return obj is PFuncionario funcionario &&
                   EqualityComparer<PPessoa>.Default.Equals(Pessoa, funcionario.Pessoa);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Pessoa);
        }

        public override string ToString()
        {
            return $"Id: {Pessoa.Id}{Environment.NewLine}" +
                   $"Nome: {Pessoa.Nome}{Environment.NewLine}" +
                   $"Data de Admissão: {DtAdmissao}{Environment.NewLine}" +
                   $"Data de Demissão: {DtDemissao}{Environment.NewLine}" +
                   $"Setor: {Setor.Descricao}{Environment.NewLine}" +
                   $"Status: {Status}";
        }
    }
}
