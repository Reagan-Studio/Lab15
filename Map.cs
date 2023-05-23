using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab15
{
    class HashNode<K, V>
    {
        public K Key { get; }
        public V Value { get; set; }
        public int HashCode { get; }
        public HashNode<K, V> Next { get; set; }

        public HashNode(K key, V value, int hashCode)
        {
            Key = key;
            Value = value;
            HashCode = hashCode;
            Next = null;
        }
    }

    class Map<K, V>
    {
        private List<HashNode<K, V>> bucketArray;
        private int numBuckets;
        private int size;

        public Map(int initialSize)
        {
            bucketArray = new List<HashNode<K, V>>(initialSize);
            numBuckets = initialSize;
            size = 0;

            for (int i = 0; i < numBuckets; i++)
                bucketArray.Add(null);
        }

        public int Size { get { return size; } }
        public bool IsEmpty { get { return size == 0; } }

        private int HashCode(K key)
        {
            return key.GetHashCode();
        }

        private int GetBucketIndex(K key)
        {
            int hashCode = HashCode(key);
            int index = hashCode % numBuckets;
            index = index < 0 ? index * -1 : index;
            return index;
        }

        public V Remove(K key)
        {
            int bucketIndex = GetBucketIndex(key);
            int hashCode = HashCode(key);
            HashNode<K, V> head = bucketArray[bucketIndex];
            HashNode<K, V> prev = null;

            while (head != null)
            {
                if (head.Key.Equals(key) && head.HashCode == hashCode)
                    break;

                prev = head;
                head = head.Next;
            }

            if (head == null)
                return default(V);

            size--;

            if (prev != null)
                prev.Next = head.Next;
            else
                bucketArray[bucketIndex] = head.Next;

            return head.Value;
        }

        public V Get(K key)
        {
            int bucketIndex = GetBucketIndex(key);
            int hashCode = HashCode(key);
            HashNode<K, V> head = bucketArray[bucketIndex];

            while (head != null)
            {
                if (head.Key.Equals(key) && head.HashCode == hashCode)
                    return head.Value;

                head = head.Next;
            }

            return default(V);
        }

        public void Add(K key, V value)
        {
            int bucketIndex = GetBucketIndex(key);
            int hashCode = HashCode(key);
            HashNode<K, V> head = bucketArray[bucketIndex];

            while (head != null)
            {
                if (head.Key.Equals(key) && head.HashCode == hashCode)
                {
                    head.Value = value;
                    return;
                }

                head = head.Next;
            }

            size++;
            head = bucketArray[bucketIndex];
            HashNode<K, V> newNode = new HashNode<K, V>(key, value, hashCode);
            newNode.Next = head;
            bucketArray[bucketIndex] = newNode;
        }

        public void Display()
        {
            for (int i = 0; i < numBuckets; i++)
            {
                Console.Write($"{i}: ");

                HashNode<K, V> node = bucketArray[i];
                while (node != null)
                {
                    Console.Write($"{node.Value} ");
                    node = node.Next;
                }

                Console.WriteLine();
            }
        }
    }
}
