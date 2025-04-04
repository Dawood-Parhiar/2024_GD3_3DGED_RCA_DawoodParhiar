﻿using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "DkIT/Scriptable Objects/Types/Variables/Vector3", order = 5)]
    public class Vector3Variable : ScriptableDataType<Vector3>
    {
        public void Add(Vector3Variable a)
        {
            Value += a.Value;
        }

        public void Set(Vector3Variable a)
        {
            Set(a.Value);
        }

        public bool Equals(Vector3Variable other)
        {
            return Value.Equals(other.Value);
        }

        public float Distance(Vector3 target)
        {
            return Vector3.Distance(Value, target);
        }
    }
}