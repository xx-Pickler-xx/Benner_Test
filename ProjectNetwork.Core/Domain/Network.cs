using System;

namespace ProjectNetwork.Core.Domain
{
    public class Network
    {
        private int[] _elements;
        private int[] _level;

        public Network(int number_of_elements)
        {
            if (number_of_elements <= 0)
                throw new ArgumentException("O número de elementos deve ser positivo.");

            _elements = new int[number_of_elements];
            _level = new int[number_of_elements];

            for (int i = 0; i < number_of_elements; i++)
            {
                _elements[i] = i;
                _level[i] = 0;
            }
        }

        private void ValidateIndex(int i)
        {
            if (i < 0 || i >= _elements.Length)
                throw new IndexOutOfRangeException(string.Format("Índice inválido: {0}. Deve estar entre 0 e {1}.", i, _elements.Length - 1));
        }

        private int Find(int element)
        {
            ValidateIndex(element);

            if (_elements[element] != element)
                _elements[element] = Find(_elements[element]);

            return _elements[element];
        }

        public void Connect(int elementA, int elementB)
        {
            int representativeA = Find(elementA);
            int representativeB = Find(elementB);

            if (representativeA != representativeB)
            {
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
                    _elements[representativeB] = representativeA;
                    _level[representativeA]++;
                }
            }
        }

        public bool Query(int elementA, int elementB)
        {
            ValidateIndex(elementA);
            ValidateIndex(elementB);

            return Find(elementA) == Find(elementB);
        }
    }
}