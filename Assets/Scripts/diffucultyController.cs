using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class diffucultyController : MonoBehaviour
{
    public float den;
    public float inten;
    private float Iden;
    private float Iinten;
    private GameObject gamemanage;
    private GameObject bright;
    // Start is called before the first frame update
    void Start()
    {
        bright = GameObject.FindGameObjectWithTag("BRIGHT");
        Iden = bright.GetComponent<adjustBrightness>().fogDen;
        Iinten = bright.GetComponent<adjustBrightness>().brightness;
        den = Iden;
        inten = Iinten;
    }

    // Update is called once per frame
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            den = Iden;
            inten = Iinten;
        }
        gamemanage = GameObject.FindGameObjectWithTag("gm");
        if (gamemanage != null)
        {
            gamemanage.GetComponent<GameManager>().candleLightIntensity = inten;
            gamemanage.GetComponent<GameManager>().FogDensity = den;
        }
    }
    public void increaseDifficulty(float currInten, float currDen)
    {
        den = currDen;
        inten = currInten;
        if(den < 0.5f)
        {
            den += 0.004f;
        }
        if(inten > 0.2)
        {
            inten -= 0.12f;
        }
    }
    public void decreaseDifficulty(float currInten, float currDen)
    {
        den = currDen;
        inten = currInten;
        if (den > 0)
        {
            den -= 0.004f;
        }
        if (inten < 5)
        {
            inten += 0.12f;
        }
    }
}
