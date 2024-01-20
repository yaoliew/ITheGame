 using UnityEngine;
 using UnityEngine.Events;
 
 [System.Serializable]
 public class SFXFloatEvent : UnityEvent<float> { }
 
 public class SFXPlayerPrefsFloatLoader : MonoBehaviour
 {
     [SerializeField] private string key;
     private float defaultValue = 0.5f;
     [SerializeField] private SFXFloatEvent onValueLoaded;
 
     private void Awake()
     {
         onValueLoaded.Invoke(PlayerPrefs.GetFloat(key, defaultValue));
     }
 }