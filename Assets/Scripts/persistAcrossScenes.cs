using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class persistAcrossScenes : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject title;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
}
