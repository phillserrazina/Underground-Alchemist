using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Lucerna.Entities
{
    public class EntityComponentManager : MonoBehaviour
    {
        // VARIABLES
        private List<EntityComponent> components = new List<EntityComponent>();

        public event EventHandler OnInitialized;

        // EXECUTION FUNCTIONS
        private void Awake()
        {
            OnAwake();
        }

        private void Start()
        {
            OnStart();
        }

        // METHODS

        /// <summary>
        /// Initialize the EntityManager by getting all the EntityComponents
        /// attached to this gameObject.
        /// </summary>
        public virtual void OnAwake()
        {
            components = GetComponentsInChildren<EntityComponent>(true).ToList();

            foreach (var component in components)
            {
                component.OnAwake(this);
            }

            OnInitialized?.Invoke(this, EventArgs.Empty);
        }

        public virtual void OnStart()
        {
            foreach (var component in components)
            {
                component.OnStart();
            }
        }

        public virtual void AddComponentToList(EntityComponent newComponent)
        {
            components.Add(newComponent);
            newComponent.OnAwake(this);
            newComponent.OnStart();
        }

        /// <summary>
        /// Get component of type T that is attached to the gameObject,
        /// where T inherits from the EntityComponent class.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : EntityComponent
        {
            if (components.Count == 0)
            {
                OnAwake();
            }

            foreach (var component in components)
            {
                if (component is T)
                {
                    return component as T;
                }
            }

            //Debug.LogWarning($"EntityComponentManager::Get() --- No component of type { typeof(T).Name } found!");
            return default;
        }

        public bool TryGet<T>(out T result) where T : EntityComponent
        {
            result = Get<T>();
            return result != null;
        }

        /// <summary>
        /// Destroy all the components of type EntityComponent attached
        /// to this gameObject.
        /// </summary>
        public virtual void DestroyAllComponents()
        {
            foreach (var component in components)
            {
                Destroy(component);
            }
        }
    }
}
