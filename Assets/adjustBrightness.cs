using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
        if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.LeftArrow))
        {
            increaseBright();
        }
        if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.RightArrow))
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
        if (fogDen > 0)
        {
            fogDen -= 0.001f;
        }
        if (brightness < 5)
        {
            brightness += 0.03f;
        }
    }
    public void decreaseBright()
    {
        if (fogDen < 0.5f)
        {
            fogDen += 0.001f;
        }
        if (brightness > 0.2)
        {
            brightness -= 0.03f;
        }
    }
}
