using UnityEngine;

namespace Unchord
{
    public abstract class Singleton<T_MonoBehaviour> : MonoBehaviour
    where T_MonoBehaviour : MonoBehaviour
    {
        public static T_MonoBehaviour Instance
        {
            get
            {
                if (s_instance != null)
                    return s_instance;

                GameObject instanceObject = new GameObject($"@{typeof(T_MonoBehaviour).Name}");
                s_instance = instanceObject.AddComponent<T_MonoBehaviour>();

                return s_instance;
            }
        }

        private static T_MonoBehaviour s_instance;
    }
}