﻿using UnityEngine;
using UnityEngine.Events;

namespace GD
{
    public abstract class BaseGameEventListener<T> : MonoBehaviour
    {
        [SerializeField]
        private string description;

        [SerializeField]
        [Tooltip("Specify the game event (scriptable object) which will raise the event")]
        private BaseGameEvent<T> Event;  //read event + delegate -> GDEvent

        [SerializeField]
        private UnityEvent<T> Response;

        private void OnEnable()
        {
            if (Event != null)
            {
                Event.RegisterListener(this);
            }
            else
            {
                Debug.LogWarning("Event is not assigned in " + gameObject.name);
            }
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public virtual void OnEventRaised(T data)
        {
            Response?.Invoke(data);
        }
    }
}