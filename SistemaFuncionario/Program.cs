using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaFuncionario
{
    class Program
    {
        private static readonly string LinhaDivisoria = "------------------------------------";
        private static readonly string TituloSistema = "SISTEMA DE GESTÃO DE FUNCIONÁRIOS";

        static void Main(string[] args)
        {
            Console.WriteLine(TituloSistema);
            Console.WriteLine(LinhaDivisoria);

            List<Funcionario> funcionarios = new List<Funcionario>
            {
                new Gerente("João Silva", 35, 10000m, FormaPagamento.DebitoEmConta, MetodoEntrega.Automatico, 2000m),
                new Desenvolvedor("Maria Souza", 28, 8000m, FormaPagamento.Pix, MetodoEntrega.Automatico, 10, 50m),
                new Estagiario("Carlos Oliveira", 22, 2000m, FormaPagamento.Dinheiro, MetodoEntrega.Manual)
            };

            while (true)
            {
                Console.WriteLine("\nMENU PRINCIPAL:");
                Console.WriteLine("1 - Adicionar novo funcionário");
                Console.WriteLine("2 - Listar todos os funcionários");
                Console.WriteLine("3 - Atualizar funcionário");
                Console.WriteLine("4 - Remover funcionário");
                Console.WriteLine("5 - Sair do sistema");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarFuncionario(funcionarios);
                        break;
                    case "2":
                        ListarFuncionarios(funcionarios);
                        break;
                    case "3":
                        AtualizarFuncionario(funcionarios);
                        break;
                    case "4":
                        RemoverFuncionario(funcionarios);
                        break;
                    case "5":
                        Console.WriteLine("\nSaindo do sistema...");
                        return;
                    default:
                        Console.WriteLine("\nOpção inválida! Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarFuncionario(List<Funcionario> funcionarios)
        {
            Console.WriteLine("\nADICIONAR NOVO FUNCIONÁRIO");
            Console.WriteLine(LinhaDivisoria);

            try
            {
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                Console.Write("Idade: ");
                int idade = int.Parse(Console.ReadLine());

                Console.Write("Salário Base: R$ ");
                decimal salarioBase = decimal.Parse(Console.ReadLine());

                Console.WriteLine("\nFormas de Pagamento:");
                Console.WriteLine("1 - Pix");
                Console.WriteLine("2 - Débito em Conta");
                Console.WriteLine("3 - Dinheiro");
                Console.Write("Escolha a forma de pagamento (1-3): ");
                FormaPagamento formaPagamento = (FormaPagamento)(int.Parse(Console.ReadLine()) - 1);

                Console.WriteLine("\nMétodos de Entrega:");
                Console.WriteLine("1 - Automático");
                Console.WriteLine("2 - Manual");
                Console.Write("Escolha o método de entrega (1-2): ");
                MetodoEntrega metodoEntrega = (MetodoEntrega)(int.Parse(Console.ReadLine()) - 1);

                Console.WriteLine("\nTipos de Funcionário:");
                Console.WriteLine("1 - Gerente");
                Console.WriteLine("2 - Desenvolvedor");
                Console.WriteLine("3 - Estagiário");
                Console.Write("Escolha o tipo de funcionário (1-3): ");
                string tipoFuncionario = Console.ReadLine();

                Funcionario novoFuncionario;

                switch (tipoFuncionario)
                {
                    case "1":
                        Console.Write("Bônus: R$ ");
                        decimal bonus = decimal.Parse(Console.ReadLine());
                        novoFuncionario = new Gerente(nome, idade, salarioBase, formaPagamento, metodoEntrega, bonus);
                        break;
                    case "2":
                        Console.Write("Horas Extras: ");
                        int horasExtras = int.Parse(Console.ReadLine());
                        Console.Write("Valor por Hora Extra: R$ ");
                        decimal valorHoraExtra = decimal.Parse(Console.ReadLine());
                        novoFuncionario = new Desenvolvedor(nome, idade, salarioBase, formaPagamento, metodoEntrega, horasExtras, valorHoraExtra);
                        break;
                    case "3":
                        novoFuncionario = new Estagiario(nome, idade, salarioBase, formaPagamento, metodoEntrega);
                        break;
                    default:
                        throw new ArgumentException("Tipo de funcionário inválido!");
                }

                funcionarios.Add(novoFuncionario);
                Console.WriteLine("\nFuncionário adicionado com sucesso!");
                novoFuncionario.ExibirInformacoes();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nERRO: {ex.Message}");
                Console.WriteLine("Por favor, tente novamente.");
            }
        }

        static void ListarFuncionarios(List<Funcionario> funcionarios)
        {
            Console.WriteLine("\nLISTA DE FUNCIONÁRIOS");
            Console.WriteLine(LinhaDivisoria);
            Console.WriteLine($"Total de funcionários: {funcionarios.Count}\n");

            for (int i = 0; i < funcionarios.Count; i++)
            {
                Console.WriteLine($"FUNCIONÁRIO #{i + 1}");
                funcionarios[i].ExibirInformacoes();
                Console.WriteLine(LinhaDivisoria);
            }
        }

        static void AtualizarFuncionario(List<Funcionario> funcionarios)
        {
            if (funcionarios.Count == 0)
            {
                Console.WriteLine("\nNão há funcionários cadastrados para atualizar.");
                return;
            }

            Console.WriteLine("\nATUALIZAR FUNCIONÁRIO");
            Console.WriteLine(LinhaDivisoria);
            Console.WriteLine("NOTA: Nome não pode ser alterado após o cadastro.");

            Console.WriteLine("\nFuncionários cadastrados:");
            for (int i = 0; i < funcionarios.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {funcionarios[i].Nome} ({funcionarios[i].Cargo}) - Idade: {funcionarios[i].Idade}");
            }

            Console.Write("\nDigite o número do funcionário a ser atualizado (0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int indice) && indice > 0 && indice <= funcionarios.Count)
            {
                var funcionario = funcionarios[indice - 1];
                Console.WriteLine($"\nEditando {funcionario.Nome} ({funcionario.Cargo}):");
                Console.WriteLine($"- Nome: {funcionario.Nome} (não pode ser alterado)");

                try
                {
                    Console.Write($"- Mudar idade ({funcionario.Idade}): ");
                    string idadeInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(idadeInput))
                    {
                        int novaIdade = int.Parse(idadeInput);
                        if (novaIdade < funcionario.Idade)
                        {
                            Console.WriteLine("\nErro: Não é permitido reduzir a idade do funcionário!");
                        }                   
                    }


                    Console.Write($"- Salário Base (R$ {funcionario.SalarioBase:F2}): ");
                    string salarioInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(salarioInput))
                        funcionario.SalarioBase = decimal.Parse(salarioInput);

                    if (funcionario is Gerente gerente)
                    {
                        Console.Write($"- Bônus (R$ {gerente.Bonus:F2}): ");
                        string bonusInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(bonusInput))
                            gerente.Bonus = decimal.Parse(bonusInput);
                    }
                    else if (funcionario is Desenvolvedor desenvolvedor)
                    {
                        Console.Write($"- Horas Extras ({desenvolvedor.HorasExtras}): ");
                        string horasInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(horasInput))
                            desenvolvedor.HorasExtras = int.Parse(horasInput);

                        Console.Write($"- Valor por Hora Extra (R$ {desenvolvedor.ValorHoraExtra:F2}): ");
                        string valorInput = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(valorInput))
                            desenvolvedor.ValorHoraExtra = decimal.Parse(valorInput);
                    }

                    Console.WriteLine($"\nForma de Pagamento atual: {funcionario.FormaPagamento}");
                    Console.WriteLine("1 - Pix");
                    Console.WriteLine("2 - Débito em Conta");
                    Console.WriteLine("3 - Dinheiro");
                    Console.Write("Escolha nova forma (enter para manter): ");
                    string formaInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(formaInput))
                        funcionario.FormaPagamento = (FormaPagamento)(int.Parse(formaInput) - 1);

                    Console.WriteLine($"\nMétodo de Entrega atual: {funcionario.MetodoEntrega}");
                    Console.WriteLine("1 - Automático");
                    Console.WriteLine("2 - Manual");
                    Console.Write("Escolha novo método (enter para manter): ");
                    string metodoInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(metodoInput))
                        funcionario.MetodoEntrega = (MetodoEntrega)(int.Parse(metodoInput) - 1);

                    Console.WriteLine("\nFuncionário atualizado com sucesso!");
                    funcionario.ExibirInformacoes();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nERRO: {ex.Message}");
                    Console.WriteLine("As alterações não foram salvas.");
                }
            }
            else if (indice != 0)
            {
                Console.WriteLine("\nÍndice inválido!");
            }
        }

        static void RemoverFuncionario(List<Funcionario> funcionarios)
        {
            if (funcionarios.Count == 0)
            {
                Console.WriteLine("\nNão há funcionários cadastrados para remover.");
                return;
            }

            Console.WriteLine("\nREMOVER FUNCIONÁRIO");
            Console.WriteLine(LinhaDivisoria);

            Console.WriteLine("\nFuncionários cadastrados:");
            for (int i = 0; i < funcionarios.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {funcionarios[i].Nome} ({funcionarios[i].Cargo})");
            }

            Console.Write("\nDigite o número do funcionário a ser removido (0 para cancelar): ");
            if (int.TryParse(Console.ReadLine(), out int indice))
            {
                if (indice == 0)
                {
                    Console.WriteLine("Operação cancelada.");
                    return;
                }

                if (indice > 0 && indice <= funcionarios.Count)
                {
                    var funcionario = funcionarios[indice - 1];
                    Console.WriteLine($"\nTem certeza que deseja remover {funcionario.Nome} ({funcionario.Cargo})?");
                    Console.Write("Digite 'S' para confirmar: ");
                    string confirmacao = Console.ReadLine().ToUpper();

                    if (confirmacao == "S")
                    {
                        funcionarios.RemoveAt(indice - 1);
                        Console.WriteLine("\nFuncionário removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("\nRemoção cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("\nÍndice inválido!");
                }
            }
            else
            {
                Console.WriteLine("\nEntrada inválida! Digite apenas números.");
            }
        }
    }
}