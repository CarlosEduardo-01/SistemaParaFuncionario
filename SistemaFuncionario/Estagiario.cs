using System;

namespace SistemaFuncionario
{
    public class Estagiario : Funcionario
    {
        private static readonly decimal SalarioMaximoEstagiario = 2000m;
        private static readonly int IdadeMinimaEstagiario = 16;

        public Estagiario(string nome, int idade, decimal salarioBase,
                         FormaPagamento formaPagamento, MetodoEntrega metodoEntrega)
            : base(nome, idade, salarioBase, formaPagamento, metodoEntrega)
        {
            if (salarioBase > SalarioMaximoEstagiario)
                throw new ArgumentException($"Salário de estagiário não pode exceder {SalarioMaximoEstagiario:C}");

            if (idade < IdadeMinimaEstagiario)
                throw new ArgumentException($"Estagiário deve ter no mínimo {IdadeMinimaEstagiario} anos");

            Cargo = "Estagiário";
        }

        public override decimal CalcularSalario() => SalarioBase;

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"- Salário Total: R$ {CalcularSalario():F2}");
            Console.WriteLine($"- Impostos: R$ {CalcularImpostos():F2} (Isento)");
            Console.WriteLine($"- Salário Líquido: R$ {CalcularSalario() - CalcularImpostos():F2}");
        }
    }
}