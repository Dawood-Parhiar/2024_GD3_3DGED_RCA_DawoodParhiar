using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "IntVariable", menuName = "DkIT/Scriptable Objects/Types/Variables/Int", order = 2)]
    public class IntVariable : ScriptableDataType<int>
    {
        public void Add(IntVariable a)
        {
            Value += a.Value;
        }

        public void Set(IntVariable a)
        {
            Set(a.Value);
        }

        public bool Equals(IntVariable other)
        {
            return Value.Equals(other.Value);
        }
    }
}