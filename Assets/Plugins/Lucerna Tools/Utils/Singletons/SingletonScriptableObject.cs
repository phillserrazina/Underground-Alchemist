using System.Runtime.CompilerServices;
using UnityEngine;

namespace Lucerna.Common.Singletons
{
	public class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
    {
        // VARIABLES
        private static T cachedInstance;

        public static T Instance
        {
            get
            {
                if (cachedInstance == null)
                {
                    cachedInstance = Resources.Load<T>(typeof(T).Name);
                }

                return cachedInstance;
            }
        }
    }
}