using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "StringVariable", menuName = "DkIT/Scriptable Objects/Types/Variables/String", order = 4)]
    public class StringVariable : ScriptableDataType<string>
    {
        public void Add(StringVariable a)
        {
            Value += a.Value;
        }

        public void Set(StringVariable a)
        {
            Set(a.Value);
        }

        public bool Equals(StringVariable other)
        {
            return Value.Equals(other.Value);
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(Value);
        }

        public void Clear()
        {
            Value = string.Empty;
        }
    }
}