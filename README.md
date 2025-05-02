<img src="https://img.shields.io/badge/C%2523-7.3-purple" alt="C#">


<img src="https://img.shields.io/badge/.NET-Framework%25204.8-blue" alt=".NET">


<img src="https://img.shields.io/badge/License-MIT-green" alt="License">


## Um sistema completo para gerenciamento de funcionários desenvolvido em C# 7.3, demonstrando conceitos avançados de Programação Orientada a Objetos.

### 📌 Funcionalidades
✅ Cadastro de diferentes tipos de funcionários (Gerente, Desenvolvedor, Estagiário)

✅ Cálculo automático de salários e impostos

✅ CRUD completo (Create, Read, Update, Delete)

✅ Validações de entrada e tratamento de erros

✅ Menu interativo fácil de usar


## 📌 Funcionalidades

✔ **Cadastro de funcionários**  
&nbsp;&nbsp; ↳ Gerentes, Desenvolvedores, Estagiários  

✔ **Cálculos automáticos**  
&nbsp;&nbsp; ↳ Impostos, salários líquidos  

<br>

## 🚀 Começando

1. Clone o repositório:  
   ```bash
   git clone https://github.com/CarlosEduardo-01/SistemaParaFuncionario.git
   ```

2. Execute o projeto:  
   ```bash
   cd SistemaFuncionario  
   dotnet run
   ```

Compile e execute (F5)

## 📊 Regras de Cálculo
| Cargo         | Fórmula                          | 
|---------------|----------------------------------|
| `Gerente`     | Salário + Bônus - 27.5%          |

## 💡 Exemplo de Código
```csharp
var gerente = new Gerente("João", 35, 10000m, FormaPagamento.Pix,
MetodoEntrega.Automatico, 2000m);
```

## 🛠️ Tecnologias Utilizadas

1. C# 7.3

2. .NET Framework 4.8

3. Visual Studio 2022

## ✨ Recursos Avançados

1. Polimorfismo: &nbsp; Métodos virtuais e sobrescritos

2. Encapsulamento: &nbsp; Propriedades com níveis de acesso controlados

3. Tratamento de erros: &nbsp; Validações robustas em todas as entradas

4. Padrões de projeto: &nbsp; Implementação de Repository Pattern (implícito)
   
## 🚀 Melhorias Futuras

1. Adicionar persistência em banco de dados

2. Implementar interface gráfica

3. Adicionar relatórios em PDF


## 📊 Exemplo de Saída
FUNCIONÁRIO #1

Nome: João Silva <br>
Cargo: Gerente <br>
Salário Base: R$ 10.000,00 <br>
Bônus: R$ 2.000,00 <br>
Salário Total: R$ 12.000,00 <br>
Impostos (27.5%): R$ 3.300,00 <br>
Salário Líquido: R$ 8.700,00 <br>

