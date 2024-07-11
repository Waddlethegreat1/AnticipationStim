using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class adjustBrightness : MonoBehaviour
{
    // Start is called before the first frame update
    public float fogDen;
    public float brightness;
    public GameObject[] candles;
    // Update is called once per frame
    void Update()
    {
        RenderSettings.fogDensity = fogDen;
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].GetComponent<Light>().intensity = brightness;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            increaseBright();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            decreaseBright();
        }
    }
    public void LOADTHESCENE()
    {
        SceneManager.LoadScene("NameScene");
    }
    public void increaseBright()
    {
        fogDen -= 0.004f;
        brightness += 0.12f;
    }
    public void decreaseBright()
    {
        fogDen += 0.004f;
        brightness -= 0.12f;
    }
}
