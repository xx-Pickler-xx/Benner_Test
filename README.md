# Projeto Network - Estrutura Union-Find

Este projeto implementa a estrutura de dados **Union-Find** (Disjoint Set Union), também conhecida como **Network**, com otimização de **path compression**.

## Estrutura `Network`

- **Connect(int elementA, int elementB)**: conecta dois elementos, unindo seus conjuntos.
- **Query(int elementA, int elementB)**: verifica se dois elementos pertencem ao mesmo conjunto.

## Como testar

A classe `Program` contém um exemplo simples para demonstrar as operações básicas:

```csharp
using System;
using ProjectNetwork.Core.Domain;

class Program
{
    static void Main()
    {
        Network network = new Network(10);

        network.Connect(1, 2);
        network.Connect(3, 4);
        network.Connect(2, 4);

        Console.WriteLine(network.Query(1, 3)); // True
        Console.WriteLine(network.Query(1, 5)); // False
    }
}
