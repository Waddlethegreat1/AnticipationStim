using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class turnAudioOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu" || currentScene.name == "NameScene")
        {
            this.gameObject.SetActive(true);
            this.GetComponent<AudioListener>().enabled = true;
        }
    }
}
