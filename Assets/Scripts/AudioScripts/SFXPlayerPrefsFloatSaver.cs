 using UnityEngine;
 
 public class SFXPlayerPrefsFloatSaver : MonoBehaviour
 {
     [SerializeField] private string key;
     
     public void SetFloat(float value)
     {
         PlayerPrefs.SetFloat(key, value);
     }
 }
