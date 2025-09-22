using System;
using ProjectNetwork.Core.Domain;

class Program
{
    static void Main()
    {
        // Cria uma rede com 8 elementos (0 a 7)
        Network network = new Network(8);

        // Conecta alguns elementos
        network.Connect(1, 2);
        network.Connect(3, 4);
        network.Connect(2, 4);

        // Consulta conexões
        Console.WriteLine(network.Query(1, 3)); // True
        Console.WriteLine(network.Query(1, 5)); // False
    }
}