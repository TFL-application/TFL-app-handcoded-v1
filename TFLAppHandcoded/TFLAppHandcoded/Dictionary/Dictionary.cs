﻿using System;
namespace TFLAppHandcoded.Dictionary
{
	public class Dict<K, V>
	{
		private DictionaryRecord<K, V>[] dictionary;

        public Dict()
		{
			this.dictionary = new DictionaryRecord<K, V>[0];
        }

		public int GetLength() { return this.dictionary.Length; }

        public K[] GetRecordKeys()
        {
            K[] keys = new K[this.dictionary.Length];
            for (int i = 0; i < this.dictionary.Length; i++)
                keys[i] = this.dictionary[i].key;

            return keys;
        }

        public bool CheckKeyExists(K key)
        {
            foreach (DictionaryRecord<K, V> record in dictionary)
                if (record.Equals(key))
                {
                    return true;
                }
            return false;
        }

        public bool AddRecord(K key, V value)
		{
            DictionaryRecord<K, V> newRecord = new DictionaryRecord<K, V>(key, value);

            int newLength = dictionary.Length + 1;
            DictionaryRecord<K, V>[] newDictionary = new DictionaryRecord<K, V>[newLength];

            for (int i = 0; i < newLength - 1; i++)
            {
                if (this.dictionary[i].Equals(key))
                    return false;
                newDictionary[i] = this.dictionary[i];
            }
            newDictionary[this.dictionary.Length] = newRecord;

            this.dictionary = newDictionary;

            return true;
		}

        public bool DeleteRecordWithKey(K key)
        {
            int newLength = this.dictionary.Length - 1;
            DictionaryRecord<K, V>[] newDictionary = new DictionaryRecord<K, V>[newLength];

            int newArrayIndex = 0;

            foreach (DictionaryRecord<K, V> record in dictionary)
            {
                if (!record.Equals(key))
                {
                    if (newArrayIndex < newLength)
                        newDictionary[newArrayIndex] = record;
                    newArrayIndex++;
                }
            }

            if (newArrayIndex != newLength)
                return false;

            this.dictionary = newDictionary;
            return true;
        }

		public V? FindRecordValueWithKey(K key)
        {
            foreach (DictionaryRecord<K, V> record in this.dictionary)
                if (record.Equals(key))
                    return record.value;

            return default;
        }

		public bool SetRecordValueWithKey(K key, V value)
        {
            foreach (DictionaryRecord<K, V> record in this.dictionary)
            {
                if (record.Equals(key))
                {
                    record.value = value;
                    return true;
                }
            }

            return false;
        }

        public void PrintDict()
        {
            for (int i = 1; i <= dictionary.Length; i++)
            {
                Console.WriteLine($"{i}. " +
                    $"{dictionary[i - 1].key.ToString()} : " +
                    $"{dictionary[i - 1].value.ToString()}");
            }
        } 
    }
}

