using System;
namespace TFLAppHandcoded.Dictionary
{
	class DictionaryRecord<K, V>: IEquatable<K>
	{
		public K key { get; set; }
		public V value { get; set; }

        public DictionaryRecord(K key, V value)
		{
			this.key = key;
			this.value = value;
		}

		public bool Equals(K? other)		// A record equals to another one if they have the same key
		{
			if (this.key.Equals(other))
				return true;
			return false;
		}
    }
}

