using System;

namespace ProjectNetwork.Core.Domain
{
    public class Network
    {
        // Array que representa os "pais" de cada elemento no conjunto
        private int[] _elements;

        // Array que representa o nível (ou rank) de cada elemento (usado para Union by Level/Rank)
        private int[] _level;

        public Network(int number_of_elements)
        {
            if (number_of_elements <= 0)
                throw new ArgumentException("O número de elementos deve ser positivo.");

            _elements = new int[number_of_elements];
            _level = new int[number_of_elements];

            // Inicializa cada elemento como seu próprio representante (conjunto separado)
            for (int i = 0; i < number_of_elements; i++)
            {
                _elements[i] = i;
                _level[i] = 0; // nível começa em 0
            }
        }

        // Garante que o índice está dentro dos limites do array
        private void ValidateIndex(int i)
        {
            if (i < 0 || i >= _elements.Length)
                throw new IndexOutOfRangeException(string.Format("Índice inválido: {0}. Deve estar entre 0 e {1}.", i, _elements.Length - 1));
        }

        // Encontra o representante (raiz) de um elemento com compressão de caminho
        private int Find(int element)
        {
            ValidateIndex(element);

            if (_elements[element] != element)
                _elements[element] = Find(_elements[element]); // path compression

            return _elements[element];
        }

        // Une dois conjuntos, usando Union by Level/Rank (nível)
        public void Connect(int elementA, int elementB)
        {
            int representativeA = Find(elementA);
            int representativeB = Find(elementB);

            // Se já estão conectados, não faz nada
            if (representativeA != representativeB)
            {
                // Anexa o conjunto de menor nível ao de maior nível
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
                    // Se os níveis forem iguais, escolhe um e aumenta seu nível
                    _elements[representativeB] = representativeA;
                    _level[representativeA]++;
                }
            }
        }

        // Verifica se dois elementos estão no mesmo conjunto
        public bool Query(int elementA, int elementB)
        {
            ValidateIndex(elementA);
            ValidateIndex(elementB);

            return Find(elementA) == Find(elementB);
        }
    }
}