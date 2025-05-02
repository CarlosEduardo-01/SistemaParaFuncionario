using System;

namespace SistemaFuncionario
{
    public class Desenvolvedor : Funcionario
    {
        private static readonly int HorasExtrasMaximas = 40;
        private static readonly decimal ValorHoraExtraMinimo = 30m;
        private static readonly decimal TaxaImposto = 0.10m;

        public int HorasExtras { get; set; }
        public decimal ValorHoraExtra { get; set; }

        public Desenvolvedor(string nome, int idade, decimal salarioBase,
                           FormaPagamento formaPagamento, MetodoEntrega metodoEntrega,
                           int horasExtras, decimal valorHoraExtra)
            : base(nome, idade, salarioBase, formaPagamento, metodoEntrega)
        {
            if (horasExtras < 0 || horasExtras > HorasExtrasMaximas)
                throw new ArgumentException($"Horas extras devem estar entre 0 e {HorasExtrasMaximas}");

            if (valorHoraExtra < ValorHoraExtraMinimo)
                throw new ArgumentException($"Valor por hora extra não pode ser menor que {ValorHoraExtraMinimo:C}");

            Cargo = "Desenvolvedor";
            HorasExtras = horasExtras;
            ValorHoraExtra = valorHoraExtra;
        }

        public override decimal CalcularSalario() => SalarioBase + (HorasExtras * ValorHoraExtra);
        public override decimal CalcularImpostos() => CalcularSalario() * TaxaImposto;

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"- Horas Extras: {HorasExtras}");
            Console.WriteLine($"- Valor por Hora Extra: R$ {ValorHoraExtra:F2}");
            Console.WriteLine($"- Salário Total: R$ {CalcularSalario():F2}");
            Console.WriteLine($"- Impostos ({TaxaImposto * 100}%): R$ {CalcularImpostos():F2}");
            Console.WriteLine($"- Salário Líquido: R$ {CalcularSalario() - CalcularImpostos():F2}");
        }
    }
}