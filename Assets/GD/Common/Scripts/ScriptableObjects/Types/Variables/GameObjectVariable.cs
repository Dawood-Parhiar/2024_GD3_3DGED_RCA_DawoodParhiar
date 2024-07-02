using UnityEngine;

namespace GD
{
    [CreateAssetMenu(fileName = "GameObjectVariable", menuName = "DkIT/Scriptable Objects/Types/Variables/Game Object", order = 7)]
    public class GameObjectVariable : ScriptableDataType<GameObject>
    {
        public void Set(GameObjectVariable a)
        {
            Set(a.Value);
        }

        public bool Equals(GameObjectVariable other)
        {
            return Value.Equals(other.Value);
        }
    }
}