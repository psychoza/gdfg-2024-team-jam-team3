using System;
using System.Collections.Generic;

namespace Preferences.Scripts
{
    public class Preference<T> where T : Enum
    {
        public T Value;
        private List<T> values = new();

        public Preference(T initialValue)
        {
            Value = initialValue;
            var arrayOfValues = Enum.GetValues(typeof(T));
            foreach (var value in arrayOfValues)
            {
                values.Add((T)value);
            }
        }

        public T IncrementValue()
        {
            var index = values.FindIndex(x => x.Equals(Value));
            Value = index + 1 == values.Count ? Value = values[0] : values[index + 1];
            return Value;
        }

        public T DecrementValue()
        {
            var index = values.FindIndex(x => x.Equals(Value));
            Value = index == 0 ? values[^1] : values[index - 1];
            return Value;
        }
    }
}