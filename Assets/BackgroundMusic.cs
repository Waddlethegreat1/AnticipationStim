using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackgroundMusic : MonoBehaviour
{
    // Start is called before the first frame update    
    [SerializeField] private float delay = 1f;
    public void LoadNextLevel(string name){
        StartCoroutine(LevelLoad(name));
    }
    IEnumerator LevelLoad(string name){
        float elapsedTime = 0;
        float currentVolume = AudioListener.volume;
        while(elapsedTime < delay){
            elapsedTime += Time.deltaTime;
            AudioListener.volume = Mathf.Lerp(currentVolume, 0, elapsedTime / delay);
            yield return null;
        }
        SceneManager.LoadScene(name);
    }
}
