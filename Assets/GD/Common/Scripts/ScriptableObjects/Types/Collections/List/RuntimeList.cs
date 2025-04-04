﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// Contains a generic abstract list from which we can extend to create concrete list types
/// </summary>
/// <see cref ="https://www.tutorialsteacher.com/csharp/csharp-exception"/>
namespace GD.Collections
{
    #region Generic Type

    //Note - We cannot directly instantiate a GENERIC ScriptableObject from the Context Menu - see RuntimeStringList
    [System.Serializable]
    public abstract class RuntimeList<T> : ScriptableGameObject, IEnumerable<T>
    {
        [Header("List Contents")]
        [SerializeField]
        private List<T> list = new List<T>();

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= list.Count)
                    throw new System.ArgumentException($"Invalid index [{index}] in indexer method");               //https://www.tutorialsteacher.com/csharp/csharp-exception

                return list[index];
            }
            set
            {
                if (index < 0 || index >= list.Count)
                    throw new System.ArgumentException($"Invalid index [{index}] in indexer method");

                list[index] = value;
            }
        }

        public void Push(T obj)
        {
            if (!list.Contains(obj))
            {
                list.Add(obj);
            }
        }

        public T Pop()
        {
            if (IsEmpty())
                return default(T);

            T obj = list[list.Count - 1];
            list.Remove(obj); ;
            return obj;
        }

        public T Peek()
        {
            if (IsEmpty())
                return default(T);

            return list[list.Count - 1];
        }

        public void Remove(T obj)
        {
            if (list.Contains(obj))
            {
                list.Remove(obj);
            }
        }

        public int RemoveAll(Predicate<T> predicate)
        {
            return list.RemoveAll(predicate);
        }

        public void Clear()
        {
            list.Clear();
        }

        public int Count()
        {
            return list.Count;
        }

        public int Count(Func<T, bool> predicate)
        {
            //using C#'s Language Integrated Query (Linq) library - https://dotnettutorials.net/course/linq/
            return list.Count(predicate); //remember we have an enumerator in RuntimeList which allows us to call this method
        }

        public bool IsEmpty()
        {
            return list.Count == 0;
        }

        public void Sort(IComparer<T> comparer)
        {
            list.Sort(comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)list).GetEnumerator();
        }
    }

    #endregion Generic Type

    #region Specific List Types

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeBoolList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/Bool", order = 1)]
    public class RuntimeBoolList : RuntimeList<bool>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeIntList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/Int", order = 2)]
    public class RuntimeIntList : RuntimeList<int>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeFloatList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/Float", order = 3)]
    public class RuntimeFloatList : RuntimeList<float>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeStringList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/String", order = 4)]
    public class RuntimeStringList : RuntimeList<string>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeVector3List", menuName = "DkIT/Scriptable Objects/Types/Collections/List/Vector3", order = 5)]
    public class RuntimeVector3List : RuntimeList<Vector3>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeTransformList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/Transform", order = 6)]
    public class RuntimeTransformList : RuntimeList<Transform>
    {
    }

    [System.Serializable]
    [CreateAssetMenu(fileName = "RuntimeGameObjectList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/Game Object", order = 7)]
    public class RuntimeGameObjectList : RuntimeList<GameObject>
    {
    }

    #endregion Specific List Types
}