﻿using System.Collections.Generic;
using System.Linq;

namespace Cryptography.Obfuscation.DataStructure
{
    /// <summary>
    ///     Dictionary with unique key and unique value combination.
    /// </summary>
    /// <typeparam name="TKey">
    ///     First type parameter.
    /// </typeparam>
    /// <typeparam name="TValue">
    ///     Second type parameter.
    /// </typeparam>
    public class UniqueDictionary<TKey, TValue>
    {
        /// <summary>
        ///     Get the underlying Dictionary object.
        /// </summary>
        public Dictionary<TKey, TValue> Dictionary { get; private set; }

        /// <summary>
        ///     Get the underlying Inverse (Reversed Key:Value) Dictionary object.
        /// </summary>
        public Dictionary<TValue, TKey> InverseDictionary { get; private set; }

        /// <summary>
        ///     Initialize a new UniqueDictionary.
        /// </summary>
        public UniqueDictionary()
        {
            Dictionary = new Dictionary<TKey, TValue>();
            InverseDictionary = new Dictionary<TValue, TKey>();
        }
        
        /// <summary>
        ///     Get dictionary value based on the specified key.
        /// </summary>
        /// <param name="key">
        ///     The key of the requested value.
        /// </param>
        /// <returns>
        ///     Value represented by the specified key.
        /// </returns>
        public TValue GetFromKey(TKey key)
        {
            return Dictionary[key];
        }

        /// <summary>
        ///     Get dictionary key based on the specified value.
        /// </summary>
        /// <param name="value">
        ///     The value of the request key.
        /// </param>
        /// <returns>
        ///     Value represented by the specified key.
        /// </returns>
        public TKey GetFromValue(TValue value)
        {
            return InverseDictionary[value];
        }

        /// <summary>
        ///     Get how many items are stored in the dictionary.
        /// </summary>
        public int Count
        {
            get
            {
                return Dictionary.Count;
            }
        }
        
        /// <summary>
        ///     Add a new item to the dictionary.
        /// </summary>
        /// <param name="key">
        ///     Item key.
        /// </param>
        /// <param name="value">
        ///     Item value.
        /// </param>
        public void Add(TKey key, TValue value)
        {
            Dictionary.Add(key, value);
            InverseDictionary.Add(value, key);
        }
        
        /// <summary>
        ///     Remove the specified KeyValuePaid from dictionary.
        /// </summary>
        /// <param name="key">
        ///     The key of the KeyValuePair to remove.
        /// </param>
        /// <returns>
        ///     True if key exists, false otherwise.
        /// </returns>
        public bool Remove(TKey key)
        {
            foreach (var inverseKey in InverseDictionary.Where(kvp => kvp.Value.Equals(key)).ToList())
            {
                InverseDictionary.Remove(inverseKey.Key);
            }
            return Dictionary.Remove(key);
        }

        /// <summary>
        ///     Try to get value from the dictionary using the specified key.
        /// </summary>
        /// <param name="key">
        ///     The item key.
        /// </param>
        /// <param name="value">
        ///     The variable to store the return value in.
        /// </param>
        /// <returns>
        ///     True if key exists, false otherwise.
        /// </returns>
        public bool TryGetValue(TKey key, out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        ///     Checks whether dictionary contains the specified key.
        /// </summary>
        /// <param name="key">
        ///     The item key.
        /// </param>
        /// <returns>
        ///     True if key exists, false otherwise.
        /// </returns>
        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        /// <summary>
        ///     Checks whether dicitonary contains the specified value.
        /// </summary>
        /// <param name="value">
        ///     The item value.
        /// </param>
        /// <returns>
        ///     True if value exists, false otherwise.
        /// </returns>
        public bool ContainsValue(TValue value)
        {
            return InverseDictionary.ContainsKey(value);
        }
    }
}