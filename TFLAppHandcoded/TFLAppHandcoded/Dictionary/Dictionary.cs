using System;
namespace TFLAppHandcoded.Dictionary
{
	public class Dict<K, V>
	{
		private DictionaryRecord<K, V>[] dictionary;

        public Dict()
		{
			dictionary = new DictionaryRecord<K, V>[0];
        }

		public int GetLength() { return dictionary.Length; }

        public K[] GetRecordKeys()
        {
            K[] keys = new K[dictionary.Length];
            for (int i = 0; i < dictionary.Length; i++)
                keys[i] = dictionary[i].key;

            return keys;
        }

        //public bool CheckKeyExists(Object key)
        //{
        //    foreach (DictionaryRecord<K, V> record in dictionary)
        //        if (record.Equals(key))
        //            return true;
        //    return false;
        //}

        public bool AddRecord(K key, V value)
		{
            //if (CheckKeyExists(key))
            //    return false;

            DictionaryRecord<K, V> newRecord = new DictionaryRecord<K, V>(key, value);

            int newLength = dictionary.Length + 1;
            DictionaryRecord<K, V>[] newDictionary = new DictionaryRecord<K, V>[newLength];

            for (int i = 0; i < newLength - 1; i++)
            {
                if (dictionary[i].Equals(key))
                    return false;
                newDictionary[i] = this.dictionary[i];
            }
            newDictionary[dictionary.Length] = newRecord;

            this.dictionary = newDictionary;

            return true;
		}

        public bool DeleteRecordWithKey(K key)
        {
            int newLength = dictionary.Length - 1;
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
    }
}

