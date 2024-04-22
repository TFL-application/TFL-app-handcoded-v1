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

		public bool Equals(K? other)
		{
			if (this.key.Equals(other))
				return true;
			return false;
		}

		//public K GetKey() { return key; }
		//public void SetKey(K key) { this.key = key; }
  //      public V GetValue() { return value; }
  //      public void SetValue(V value) { this.value = value; }
    }
}

