namespace Lucerna.Entities
{
    public class GenericEntityComponent<T> : EntityComponent where T : EntityComponentManager
    {
        public new T Controller => base.Controller as T;
    }
}
