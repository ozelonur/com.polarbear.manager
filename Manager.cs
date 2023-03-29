using UnityEngine;

namespace PolarBear.Manager
{
    public class Manager<T> : MonoBehaviour where T : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the manager
        /// </summary>
        #region Private Variables

        private static T _instance;

        #endregion

        #region Public Methods

        public static T Instance(bool persistent = true)
        {
            if (_instance != null) return _instance;

            _instance = FindObjectOfType<T>();

            if (_instance != null) return _instance;
            GameObject obj = new GameObject
            {
                name = typeof(T).Name
            };
            _instance = obj.AddComponent<T>();

            if (persistent)
            {
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }

        #endregion

        #region MonoBehaviour Methods

        protected virtual void Awake()
        {
            if (_instance == null)
            {
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        #endregion
    }
}