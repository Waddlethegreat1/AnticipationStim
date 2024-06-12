using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class setActiveOnMain : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject myself;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene(); 
        if(currentScene.name != "PlaceholderScene"){
            myself.SetActive(false);
        }
    }
}
