using System;

namespace ProjectNetwork.Core.Domain
{
    public class Network
    {
        private int[] _elements;

        public Network(int number_of_elements)
        {
            if (number_of_elements <= 0)
                throw new ArgumentException("O número de elementos deve ser positivo.");

            _elements = new int[number_of_elements];

            for (int i = 0; i < number_of_elements; i++)
            {
                _elements[i] = i;
            }
        }
    }
}