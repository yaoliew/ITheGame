 using UnityEngine;
 using UnityEngine.Events;
 
 [System.Serializable]
 public class VolFloatEvent : UnityEvent<float> { }
 
 public class VolPlayerPrefsFloatLoader : MonoBehaviour
 {
     [SerializeField] private string key;
     private float defaultValue = 0.5f;
     [SerializeField] private VolFloatEvent onValueLoaded;
 
     private void Awake()
     {
         onValueLoaded.Invoke(PlayerPrefs.GetFloat(key, defaultValue));
     }
 }