using ModuloEstoque.Entidades;
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
                    case "3":
                        ImprimirMovimentos();
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
                              $"1. Pessoa;      2. Funcionário      3. Movimentos       X. Sair do Sistema{Environment.NewLine}" +
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

        private static void ImprimirMovimentos()
        {
            Console.WriteLine($"Movimentos:{Environment.NewLine}");
            foreach(EMovimento m in Movimentos(Produtos()))
            {
                Console.WriteLine(m.ToString() + Environment.NewLine);
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

        private static List<EProduto> Produtos()
        {
            ECategoria c1 = new(1, "Frios");
            //ECategoria c2 = new(2, "Horti-fruti");
            ECategoria c3 = new(3, "Carnes, peixes e frango");
            ECategoria c4 = new(4, "Massas");
            //ECategoria c5 = new(5, "Produtos de Limpeza");

            EUnidade u1 = new(1, "Quilo", "Kg");
            //EUnidade u2 = new(2, "Mililitro", "ml");
            //EUnidade u3 = new(3, "Grama", "g");
            EUnidade u4 = new(4, "Unidade", "UN");

            EProduto prod1 = new(1, "Queijo Prato Frimesa", 56.20, 15000, 30000, c1, u1);
            EProduto prod2 = new(2, "Macarrão Espaguete Ricosa 500g", 3.60, 60, 100, c4, u4);
            EProduto prod3 = new(3, "Picanha", 74.50, 30, 80, c3, u1);

            return new() { prod1, prod2, prod3 };
        }

        private static List<EMovimento> Movimentos(List<EProduto> produtos)
        {
            EMovimento m1 = new(1, 56.20, 0.300, produtos.Where(x => x.Id.Equals(1)).First(), GTipoMovimento.SAIDA);
            EMovimento m2 = new(2, 3.60, 4, produtos.Where(x => x.Id.Equals(2)).First(), GTipoMovimento.SAIDA);
            EMovimento m3 = new(3, 2.80, 50, produtos.Where(x => x.Id.Equals(2)).First(), GTipoMovimento.ENTRADA);
            EMovimento m4 = new(4, 74.50, 1.400, produtos.Where(x => x.Id.Equals(3)).First(), GTipoMovimento.SAIDA);

            return new() { m1, m2, m3, m4 };
        }
    }   
}

