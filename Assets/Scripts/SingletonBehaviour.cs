using UnityEngine;

public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T> {
   private static T _instance;

   public static T I {
      get {
         if (_instance == null) {
            _instance = FindObjectOfType<T>();
            if (_instance == null) {
               var obj = new GameObject(typeof(T).ToString());
               _instance = obj.AddComponent(typeof(T)) as T;
            }
         }

         return _instance;
      }
   }
}