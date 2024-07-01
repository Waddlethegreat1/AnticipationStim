using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class turnOffMenu : MonoBehaviour
{
    public bool isCool = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (isCool)
        {
            if (currentScene.name == "MainMenu" || currentScene.name == "NameScene")
            {
                this.GetComponent<AudioSource>().volume = 1.0f;
            }
            else
            {
                this.GetComponent<AudioSource>().volume = 0f;
            }
        }
        else
        {
            if (currentScene.name == "MainMenu" || currentScene.name == "NameScene")
            {
                this.GetComponent<AudioSource>().volume = 0f;
            }
            else
            {
                AudioListener.volume = 1f;
                this.GetComponent<AudioSource>().volume = 1.0f;
            }
        }
    }
}
