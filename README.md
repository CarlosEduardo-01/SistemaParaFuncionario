<img src="https://img.shields.io/badge/C%2523-7.3-purple" alt="C#">


<img src="https://img.shields.io/badge/.NET-Framework%25204.8-blue" alt=".NET">


<img src="https://img.shields.io/badge/License-MIT-green" alt="License">


Um sistema completo para gerenciamento de funcionários desenvolvido em C# 7.3, demonstrando conceitos avançados de Programação Orientada a Objetos.

📌 Funcionalidades
✅ Cadastro de diferentes tipos de funcionários (Gerente, Desenvolvedor, Estagiário)

✅ Cálculo automático de salários e impostos

✅ CRUD completo (Create, Read, Update, Delete)

✅ Validações de entrada e tratamento de erros

✅ Menu interativo fácil de usar

🏗️ Estrutura do Projeto
SistemaFuncionario/
├── Models/
│   ├── Funcionario.cs       # Classe base abstrata
│   ├── Gerente.cs           # Implementação para gerentes
│   ├── Desenvolvedor.cs     # Implementação para desenvolvedores
│   └── Estagiario.cs        # Implementação para estagiários
├── Enums/
│   ├── FormaPagamento.cs    # Enum: Pix, Débito em Conta, Dinheiro
│   └── MetodoEntrega.cs     # Enum: Automático, Manual
└── Program.cs               # Lógica principal e menu
💻 Como Usar
Clone o repositório:

bash
git clone https://github.com/seu-usuario/SistemaFuncionario.git
Abra o projeto no Visual Studio 2022

Compile e execute (F5)

🧮 Regras de Cálculo
Cargo	Fórmula do Salário	Imposto
Gerente	Salário Base + Bônus - 27.5%	27.5%
Desenvolvedor	Salário Base + (Horas × Valor) - 10%	10%
Estagiário	Salário Base	Isento
🛠️ Tecnologias Utilizadas
C# 7.3

.NET Framework 4.8

Visual Studio 2022

📝 Licença
Este projeto está licenciado sob a licença MIT - veja o arquivo LICENSE para detalhes.

✨ Recursos Avançados
Polimorfismo: Métodos virtuais e sobrescritos

Encapsulamento: Propriedades com níveis de acesso controlados

Tratamento de erros: Validações robustas em todas as entradas

Padrões de projeto: Implementação de Repository Pattern (implícito)

🚀 Melhorias Futuras
Adicionar persistência em banco de dados

Implementar interface gráfica

Adicionar relatórios em PDF

🤝 Como Contribuir
Faça um fork do projeto

Crie uma branch para sua feature (git checkout -b feature/AmazingFeature)

Commit suas mudanças (git commit -m 'Add some AmazingFeature')

Push para a branch (git push origin feature/AmazingFeature)

Abra um Pull Request

📊 Exemplo de Saída
FUNCIONÁRIO #1
------------------------------------
Nome: João Silva
Cargo: Gerente
Salário Base: R$ 10.000,00
Bônus: R$ 2.000,00
Salário Total: R$ 12.000,00
Impostos (27.5%): R$ 3.300,00
Salário Líquido: R$ 8.700,00
------------------------------------
