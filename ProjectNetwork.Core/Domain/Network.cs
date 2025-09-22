using System;

namespace ProjectNetwork.Core.Domain
{
    public class Network
    {
        // Array que representa os "pais" de cada elemento no conjunto
        private int[] _elements;

        // Array que representa o n�vel (ou rank) de cada elemento (usado para Union by Level/Rank)
        private int[] _level;

        public Network(int number_of_elements)
        {
            if (number_of_elements <= 0)
                throw new ArgumentException("O n�mero de elementos deve ser positivo.");

            _elements = new int[number_of_elements];
            _level = new int[number_of_elements];

            // Inicializa cada elemento como seu pr�prio representante (conjunto separado)
            for (int i = 0; i < number_of_elements; i++)
            {
                _elements[i] = i;
                _level[i] = 0; // n�vel come�a em 0
            }
        }

        // Garante que o �ndice est� dentro dos limites do array
        private void ValidateIndex(int i)
        {
            if (i < 0 || i >= _elements.Length)
                throw new IndexOutOfRangeException(string.Format("�ndice inv�lido: {0}. Deve estar entre 0 e {1}.", i, _elements.Length - 1));
        }

        // Encontra o representante (raiz) de um elemento com compress�o de caminho
        private int Find(int element)
        {
            ValidateIndex(element);

            if (_elements[element] != element)
                _elements[element] = Find(_elements[element]); // path compression

            return _elements[element];
        }

        // Une dois conjuntos, usando Union by Level/Rank (n�vel)
        public void Connect(int elementA, int elementB)
        {
            int representativeA = Find(elementA);
            int representativeB = Find(elementB);

            // Se j� est�o conectados, n�o faz nada
            if (representativeA != representativeB)
            {
                // Anexa o conjunto de menor n�vel ao de maior n�vel
                if (_level[representativeA] < _level[representativeB])
                {
                    _elements[representativeA] = representativeB;
                }
                else if (_level[representativeA] > _level[representativeB])
                {
                    _elements[representativeB] = representativeA;
                }
                else
                {
                    // Se os n�veis forem iguais, escolhe um e aumenta seu n�vel
                    _elements[representativeB] = representativeA;
                    _level[representativeA]++;
                }
            }
        }

        // Verifica se dois elementos est�o no mesmo conjunto
        public bool Query(int elementA, int elementB)
        {
            ValidateIndex(elementA);
            ValidateIndex(elementB);

            return Find(elementA) == Find(elementB);
        }
    }
}