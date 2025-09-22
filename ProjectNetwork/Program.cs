using System;
using ProjectNetwork.Core.Domain;

class Program
{
    static void Main()
    {
        // Cria uma rede com 8 elementos (índices de 0 a 7)
        Network network = new Network(8);

        // Conecta os elementos 1 e 2
        network.Connect(1, 2);

        // Conecta os elementos 3 e 4
        network.Connect(3, 4);

        // Conecta os conjuntos de 1-2 e 3-4 via o elemento 2 e 4
        network.Connect(2, 4);

        // Verifica se 1 e 3 estão conectados (esperado: True)
        Console.WriteLine(network.Query(1, 3)); // True

        // Verifica se 1 e 5 estão conectados (esperado: False)
        Console.WriteLine(network.Query(1, 5)); // False
    }
}