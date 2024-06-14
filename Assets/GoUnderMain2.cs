using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
public class goUnderMain2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject mainMenu;
    public GameObject cool;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mainMenu = GameObject.FindGameObjectWithTag("mainMenu");
        PlayerPrefs.SetInt("Round", 1); // if round doesn't exists it sets it to 1 
        if (mainMenu != null)
        {
            this.transform.SetParent(mainMenu.transform, true);
        }
        StartCoroutine(waiter());
    }
    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
        cool.GetComponent<Animator>().Play("Fader_1", 0, 0.0f);
        cool.SetActive(false);
    }
}
