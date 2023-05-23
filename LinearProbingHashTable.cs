using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class LinearProbingHashTable
    {
        private int[] keys;
        private string[] values;
        private int capacity;
        private int size;

        public LinearProbingHashTable(int capacity)
        {
            this.capacity = capacity;
            keys = new int[capacity];
            values = new string[capacity];
            size = 0;
        }

        private int HashFunction(int key)
        {
            return (11 * key) % capacity;
        }

        private int LinearProbe(int index, int attempt)
        {
            return (index + attempt) % capacity;
        }

        public void Add(int key, string value)
        {
            if (size == capacity)
            {
                return;
            }

            int hash = HashFunction(key);
            int index = hash;

            int attempt = 0;
            while (keys[index] != 0)
            {
                attempt++;
                index = LinearProbe(hash, attempt);
            }

            keys[index] = key;
            values[index] = value;
            size++;
        }

        public string Get(int key)
        {
            int hash = HashFunction(key);
            int index = hash;

            int attempt = 0;
            while (keys[index] != 0)
            {
                if (keys[index] == key)
                    return values[index];

                attempt++;
                index = LinearProbe(hash, attempt);
            }

            return null;
        }

        public void Display()
        {
            for (int i = 0; i < capacity; i++)
            {
                if (keys[i] != 0)
                    Console.WriteLine($"Индекс: {i}\tКлюч: {keys[i]}\tЗначение: {values[i]}");
            }
        }
    }
}
