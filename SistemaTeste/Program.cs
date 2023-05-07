using ModuloGlobal.Enums;
using ModuloPessoa.Entidades;

namespace SistemaTeste
{
    public class SistemaTeste
    {
        public static void Main()
        {
            string? Opcao = SelecionarOpcao();

            while (Opcao != "X" && Opcao != "x")
            {
                Console.WriteLine(); //Quebra de linha
                switch (Opcao)
                {
                    case "1":
                        ImprimirPessoas();
                        break;
                    case "2":
                        ImprimirFuncionarios();
                        break;
                    default:
                        Console.WriteLine($"Não foi escolhida uma opção válida para impressão. Serão impressos os objetos da classe padrão: PPessoa.");
                        ImprimirPessoas();
                        break;
                }
                Opcao = SelecionarOpcao();
            }
        }

        private static string? SelecionarOpcao()
        {
            Console.WriteLine($"#################################################################{Environment.NewLine}" +
                              $"Selecione uma das opções para imprimir:{Environment.NewLine}" +
                              $"1. Pessoa;      2. Funcionário      X. Sair do Sistema{Environment.NewLine}" +
                              $"#################################################################{Environment.NewLine}");
            return Console.ReadLine();
        }

        private static void ImprimirPessoas()
        {
            Console.WriteLine($"# Listagem de pessoas físicas e juríricas:{Environment.NewLine}");

            foreach (PPessoa p in Pessoas())
            {
                Console.WriteLine(p.ToString() + Environment.NewLine);
                if (p.Telefones.Count > 0) 
                {
                    Console.WriteLine($"   # Telefones para contato:{Environment.NewLine}");
                    foreach (PTelefone t in p.Telefones)
                    {
                        Console.WriteLine(t.ToString() + Environment.NewLine);
                    }
                }

                if (p.Enderecos.Count > 0)
                {
                    Console.WriteLine($"   # Endereços:{Environment.NewLine}");
                    foreach (PEndereco e in p.Enderecos)
                    {
                        Console.WriteLine(e.ToString() + Environment.NewLine);
                    }
                }
            }
        }

        private static void ImprimirFuncionarios()
        {
            Console.WriteLine($"# Listagem de funcionários:{Environment.NewLine}");

            foreach (PFuncionario f in Funcionarios(Pessoas()))
            {
                Console.WriteLine(f.ToString() + Environment.NewLine);
                if (f.Pessoa.Telefones.Count > 0)
                {
                    Console.WriteLine($"   # Telefones do funcionário:{Environment.NewLine}");
                    foreach (PTelefone t in f.Pessoa.Telefones)
                    {
                        Console.WriteLine(t.ToString() + Environment.NewLine);
                    }
                }

                if (f.Pessoa.Enderecos.Count > 0)
                {
                    Console.WriteLine($"   # Endereços do funcionário:{Environment.NewLine}");
                    foreach (PEndereco e in f.Pessoa.Enderecos)
                    {
                        Console.WriteLine(e.ToString() + Environment.NewLine);
                    }
                }

            }
        }

            private static List<PPessoa> Pessoas()
        {
            PPessoa p1 = new PPessoaFisica(1, "Tiago de Pontes Lima", "004.850.962-00", Convert.ToDateTime("02/11/1988"), GStatus.ATIVO);
            PPessoa p2 = new PPessoaFisica(2, "Arthur Costa de Pontes", "001.850.962-01", Convert.ToDateTime("07/12/2019"), GStatus.ATIVO);
            PPessoa p3 = new PPessoaFisica(3, "Keylla Jose de Nazaré Costa", "822.365.752-34", Convert.ToDateTime("07/02/1983"), GStatus.INATIVO);
            PPessoa p4 = new PPessoaJuridica(4, "MRP - Comida Brasileira LTDA", "00.125.145/0001-00", Convert.ToDateTime("01/01/2000"), "Restaurante Panela Brasileira", GStatus.ATIVO);

            p1.Telefones.Add(new PTelefone(1, GTipoTelefone.CELULAR, "(91)99161-8971", true, p1));
            p1.Telefones.Add(new PTelefone(2, GTipoTelefone.FIXO, "(91)4009-4767", false, p1));
            p3.Telefones.Add(new PTelefone(3, GTipoTelefone.CELULAR, "(91)98425-6367", true, p3));
            p4.Telefones.Add(new PTelefone(4, GTipoTelefone.FIXO, "(91)3366-0866", true, p4));
            p4.Telefones.Add(new PTelefone(5, GTipoTelefone.CELULAR, "(91)99161-8971", true, p4));
            p4.Telefones.Add(new PTelefone(6, GTipoTelefone.FAX, "(91)3366-0890", false, p4));

            PEstado e1 = new(1, "Pará", "PA");
            PEstado e2 = new(1, "Santa Catarina", "SC");

            PCidade c1 = new(1, "Belém", e1);
            PCidade c2 = new(2, "Ananindeua", e1);
            PCidade c3 = new(3, "Jaraguá do Sul", e2);

            p1.Enderecos.Add(new PEndereco(1, "66640-465", "Conjunto Natália Lins", "3401", "Bl A9, Apto 108", "Manguerão", c1, p1));
            p1.Enderecos.Add(new PEndereco(2, "66825-070", "Rua Pres. Castelo Branco", "8", "Ao lado do mercadinho Preço Baixo", "Tapanã", c1, p1));
            p3.Enderecos.Add(new PEndereco(3, "66000-000", "Rodovia Mario Covas", "3251", "", "Coqueiro", c2, p3));
            p4.Enderecos.Add(new PEndereco(4, "12000-000", "Rua Nova Botafogo", "1000", "Em frente a chácara Nossa Senhora das Graças", "Jaraguazinho", c3, p4));

            return new(){ p1, p2, p3, p4 };
        }

        private static List<PFuncionario> Funcionarios(List<PPessoa> pessoas)
        {
            PSetor s1 = new(1, "Compras");
            PSetor s2 = new(2, "Vendas");
            PSetor s3 = new(2, "Estoque");

            PFuncionario f1 = new(Convert.ToDateTime("01/05/1990"), null, GStatus.ATIVO, s3, pessoas.Where(p => p.Id.Equals(1)).First());
            PFuncionario f2 = new(Convert.ToDateTime("01/09/2003"), Convert.ToDateTime("11/12/2009"), GStatus.INATIVO, s2, pessoas.Where(p => p.Id.Equals(2)).First());
            PFuncionario f3 = new(Convert.ToDateTime("14/01/1971"), null, GStatus.ATIVO, s1, pessoas.Where(p => p.Id.Equals(3)).First());

            return new(){  f1, f2, f3 };
        }

    }   
}

