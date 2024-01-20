 using UnityEngine;
 
 public class VolPlayerPrefsFloatSaver : MonoBehaviour
 {
     [SerializeField] private string key;
     
     public void SetFloat(float value)
     {
         PlayerPrefs.SetFloat(key, value);
     }
 }
