using System;

namespace SistemaFuncionario
{
    public abstract class Funcionario
    {
        private static readonly decimal SalarioMinimo = 1412.00m;
        private static readonly int IdadeMinima = 18;
        private static readonly int IdadeMaxima = 70;

        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cargo { get; protected set; }
        public decimal SalarioBase { get; set; }
        public FormaPagamento FormaPagamento { get; set; }
        public MetodoEntrega MetodoEntrega { get; set; }

        public Funcionario(string nome, int idade, decimal salarioBase,
                         FormaPagamento formaPagamento, MetodoEntrega metodoEntrega)
        {
            if (salarioBase < SalarioMinimo)
                throw new ArgumentException($"Salário base não pode ser menor que {SalarioMinimo:C}");

            if (idade < IdadeMinima || idade > IdadeMaxima)
                throw new ArgumentException($"Idade deve estar entre {IdadeMinima} e {IdadeMaxima} anos");

            Nome = nome;
            Idade = idade;
            SalarioBase = salarioBase;
            FormaPagamento = formaPagamento;
            MetodoEntrega = metodoEntrega;
        }

        public abstract decimal CalcularSalario();
        public virtual decimal CalcularImpostos() => 0m;

        public virtual void EntregarPagamento()
        {
            decimal salarioLiquido = CalcularSalario() - CalcularImpostos();
            Console.WriteLine($"\nPagamento entregue para {Nome}:");
            Console.WriteLine($"- Forma: {FormaPagamento}");
            Console.WriteLine($"- Método: {MetodoEntrega}");
            Console.WriteLine($"- Valor líquido: R$ {salarioLiquido:F2}");
        }

        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"\nInformações de {Nome}:");
            Console.WriteLine($"- Cargo: {Cargo}");
            Console.WriteLine($"- Idade: {Idade}");
            Console.WriteLine($"- Salário Base: R$ {SalarioBase:F2}");
            Console.WriteLine($"- Forma de Pagamento: {FormaPagamento}");
            Console.WriteLine($"- Método de Entrega: {MetodoEntrega}");
        }
    }
}