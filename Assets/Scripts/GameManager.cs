// This code controls how long each trial is and is responsible for resetting the scene 

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public GameObject photodiode;
    public int points = 0;
    public GameObject valve;
    public GameObject incoming;
    private float timer = 0f;
    public float monsterChance; //chance of monster appearing 0.7 being 70%
    public float priestChance; //chance of the healing priest appearing 0.05 being 5%
    public float roundDuration; // Time interval for each trial 
    public float blackScreenDuration = 2f; // duration of the black screen 
    private bool isBlackScreen = false; // flag to track if black screen is active 
    public GameObject blackScreen; // ref to blackscreen GameObject 
    private RoundTracker roundTracker; // reference to RoundTracker Script 
    public bool isScenePaused = false; // flag to track if the scene is paused 
    public GameObject ScoreKeeper;
    public float FogDensity; //The density of the fog 0.1 on default;
    public GameObject[] candles;
    public float candleLightIntensity; //The intensity of the candles' lights. 2 is default.
    private float deduction = 0;
    private bool gameOver;
    private GameObject HealthKeeper;
    public GameObject release;
    public GameObject partcle;
    public GameObject[] screams;

    void Start()
    {

        gameOver = false;
        points = 0;
        roundTracker = FindObjectOfType<RoundTracker>(); // finds the script in the area 
        blackScreen.SetActive(false); // ensure that the black screen is initially disabled 
        Debug.Log("_RS" + Time.time);
        RenderSettings.fogDensity = FogDensity;
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].GetComponent<Light>().intensity = candleLightIntensity;
        }
        StartCoroutine(ShowPhotoDiode());
    }

    void Update()
    {
        RenderSettings.fogDensity = FogDensity;
        for (int i = 0; i < candles.Length; i++)
        {
            candles[i].GetComponent<Light>().intensity = candleLightIntensity;
        }
        partcle = GameObject.FindGameObjectWithTag("particle");
        if (partcle != null && !isScenePaused)
        {
            partcle.GetComponent<ParticleSystemRenderer>().enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("_RE" + Time.time);
            Debug.Log("_Round ended by user");
            SceneManager.LoadScene("MainMenu");
        }
        ScoreKeeper = GameObject.FindGameObjectWithTag("scoreKeep");
        HealthKeeper = GameObject.FindGameObjectWithTag("healthKeep");
        if (!isScenePaused)
        {
            timer += Time.deltaTime; // time increment
        }
        if(timer >= roundDuration - 0.05){
            incoming = GameObject.FindGameObjectWithTag("LERP_2");
            bool isMonster;
            if(incoming != null){
                isMonster = true;
            }
            else{
                incoming = GameObject.FindGameObjectWithTag("LERP_Human");
                isMonster = false;
            }
            incoming = GameObject.FindGameObjectWithTag("LERP_Priest");
            AN_Button VALV = valve.GetComponent<AN_Button>();
            if(isMonster && !VALV.isOpened){
                points = 100;
                deduction = 0;
            }
            else if(!isMonster && VALV.isOpened && incoming == null){
                points = 50;
                deduction = 0;
            }
            else if(!isMonster && VALV.isOpened && incoming != null)
            {
                deduction = -1f;
                points = 50;
            }
            else{
                points = 0;
                deduction = 1f;
            }
        }
        if (!isBlackScreen && timer >= roundDuration) // check if timer has exceeded round duration and black screen isn't activ 
        {
            isBlackScreen = true; // set the black screen flag
            PlayerStats ps = HealthKeeper.GetComponent<PlayerStats>();
            ps.health -= deduction;
            incoming = GameObject.FindGameObjectWithTag("LERP_2");
            AN_Button VALV = valve.GetComponent<AN_Button>();
            int isMonster;
            if(incoming != null){
                isMonster = 1;
            }
            else{
                incoming = GameObject.FindGameObjectWithTag("LERP_Human");
                isMonster = 0;
            }
            int correctAnswer;
            if(deduction <= 0){
                correctAnswer = 1;
            }  
            else{
                correctAnswer = 0;
            }
            int isOp;
            if(VALV.isOpened){
                isOp = 0;
            }
            else{
                isOp = 1;
            }
            Debug.Log("[R] " + PlayerPrefs.GetInt("Round") + " " + isMonster + " " + isOp + " " + correctAnswer + " " + HealthKeeper.GetComponent<PlayerStats>().health + " " + this.GetComponent<ButtonPressTracker>().reactionTime);
            if(HealthKeeper.GetComponent<PlayerStats>().health <= 0){
                gameOver = true;
            }
            else if(HealthKeeper.GetComponent<PlayerStats>().health > 3)
            {
                HealthKeeper.GetComponent<PlayerStats>().health = 3;
            }
            StartCoroutine(ShowBlackScreen()); // start coroutine to show the black screen 
        }
    }

    IEnumerator ShowPhotoDiode(){
        photodiode.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        photodiode.SetActive(false);
    }
    IEnumerator ShowBlackScreen()
    {
        ScoreKeeper.GetComponent<Score>().totalRounds++;
        ButtonPressTracker bpt = this.GetComponent<ButtonPressTracker>();
        Debug.Log("_RE" + Time.time);
        int correct = 0;
        isScenePaused = true; // pauses the scene 
        //Debug.Log("Round: " + PlayerPrefs.GetInt("Round") + " " + bpt.keyTracker);
        if (deduction < 0)
        {
            correct = 1;
            incoming = GameObject.FindGameObjectWithTag("LERP_Priest");
            partcle.GetComponent<ParticleSystemRenderer>().enabled = true;
            partcle.GetComponent<ParticleSystem>().Clear();
            Animator anim = incoming.GetComponent<Animator>();
            anim.Play("Male Attack 1");
            yield return new WaitForSeconds(2f);
        }
        else if(deduction == 0)
        {
            correct = 1;
        }
        else if(deduction > 0)
        {
            correct = -1;
            int randScream = (int)(Random.value * screams.Length);
            screams[randScream].GetComponent<AudioSource>().Play();
        }
        GameObject dcontrol = GameObject.FindGameObjectWithTag("difficulty");
        if (correct == 1)
        {
            diffucultyController diffucultyController = dcontrol.GetComponent<diffucultyController>();
            diffucultyController.increaseDifficulty(candleLightIntensity, FogDensity);
        }
        else
        {
            diffucultyController diffucultyController = dcontrol.GetComponent<diffucultyController>();
            diffucultyController.decreaseDifficulty(candleLightIntensity, FogDensity);
        }
        blackScreen.SetActive(true); // enable the black screen GameObject 
        release.SetActive(false);
        Score scorekeep = ScoreKeeper.GetComponent<Score>();
        scorekeep.points += points;
        yield return new WaitForSeconds(blackScreenDuration); // wait for listed black screen duration 
        //reset the scene
        while(Input.GetKey(KeyCode.E))
        {
            release.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
        release.SetActive(false);
        isScenePaused = false; //unpauses the scene 
        Scene currentScene = SceneManager.GetActiveScene(); 
        
        if(!gameOver){
            SceneManager.LoadScene(currentScene.buildIndex); 
        }
        else{
            SceneManager.LoadScene("MainMenu");
        }

        //Increment the round 
        roundTracker.IncrementRound(); 
        // reset the timer after the black screen duration 
        timer = 0f; 
        isBlackScreen = false; 
    }
}