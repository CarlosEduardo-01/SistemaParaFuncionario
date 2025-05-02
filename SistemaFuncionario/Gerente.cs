using System;

namespace SistemaFuncionario
{
    public class Gerente : Funcionario
    {
        private static readonly decimal BonusMinimo = 0m;
        private static readonly decimal BonusMaximo = 5000m;
        private static readonly decimal TaxaImposto = 0.275m;

        public decimal Bonus { get; set; }

        public Gerente(string nome, int idade, decimal salarioBase,
                      FormaPagamento formaPagamento, MetodoEntrega metodoEntrega, decimal bonus)
            : base(nome, idade, salarioBase, formaPagamento, metodoEntrega)
        {
            if (bonus < BonusMinimo || bonus > BonusMaximo)
                throw new ArgumentException($"Bônus deve estar entre {BonusMinimo:C} e {BonusMaximo:C}");

            Cargo = "Gerente";
            Bonus = bonus;
        }

        public override decimal CalcularSalario() => SalarioBase + Bonus;
        public override decimal CalcularImpostos() => CalcularSalario() * TaxaImposto;

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"- Bônus: R$ {Bonus:F2}");
            Console.WriteLine($"- Salário Total: R$ {CalcularSalario():F2}");
            Console.WriteLine($"- Impostos ({TaxaImposto * 100}%): R$ {CalcularImpostos():F2}");
            Console.WriteLine($"- Salário Líquido: R$ {CalcularSalario() - CalcularImpostos():F2}");
        }
    }
}