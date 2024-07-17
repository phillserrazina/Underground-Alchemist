using UnityEngine;

namespace Lucerna.Entities
{
    public class EntityComponent : MonoBehaviour
    {
        // VARIABLES
        public EntityComponentManager Controller { get; protected set; }

        // METHODS
        public virtual void OnAwake(EntityComponentManager manager)
        {
            Controller = manager;
        }

        public virtual void OnStart()
        {

        }
    }
}
