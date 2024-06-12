// This code controls how long each trial is and is responsible for resetting the scene 

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;  

public class GameManager : MonoBehaviour
{
    public GameObject photodiode;
    public int points = 0;
    public GameObject valve;
    public GameObject incoming;
    private float timer = 0f;
    public float roundDuration = 3f; // Time interval for each trial 
    public float blackScreenDuration = 2f; // duration of the black screen 
    private bool isBlackScreen = false; // flag to track if black screen is active 
    public GameObject blackScreen; // ref to blackscreen GameObject 
    private RoundTracker roundTracker; // reference to RoundTracker Script 
    private bool isScenePaused = false; // flag to track if the scene is paused 
    public GameObject ScoreKeeper;
    private float deduction = 0;
    private bool gameOver;
    private GameObject HealthKeeper;

    void Start()
    {
        gameOver = false;
        points = 0;
        roundTracker = FindObjectOfType<RoundTracker>(); // finds the script in the area 
        blackScreen.SetActive(false); // ensure that the black screen is initially disabled 
        Debug.Log("_RS" + Time.time);
        StartCoroutine(ShowPhotoDiode());
    }

    void Update()
    {
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
            AN_Button VALV = valve.GetComponent<AN_Button>();
            if(isMonster && !VALV.isOpened){
                points = 100;
                deduction = 0;
            }
            else if(!isMonster && VALV.isOpened){
                points = 50;
                deduction = 0;
            }
            else{
                points = 0;
                deduction = 1f;
            }
        }
        if (!isBlackScreen && timer >= roundDuration) // check if timer has exceeded round duration and black screen isn't activ 
        {
            isBlackScreen = true; // set the black screen flag
            Score scorekeep = ScoreKeeper.GetComponent<Score>();
            PlayerStats ps = HealthKeeper.GetComponent<PlayerStats>();
            scorekeep.points += points;
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
            if(deduction == 0){
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
            Debug.Log(PlayerPrefs.GetInt("Round") + " " + isMonster + " " + isOp + " " + correctAnswer + " " + HealthKeeper.GetComponent<PlayerStats>().health + " " + Time .time);
            if(HealthKeeper.GetComponent<PlayerStats>().health <= 0){
                gameOver = true;
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
        ButtonPressTracker bpt = this.GetComponent<ButtonPressTracker>();
        Debug.Log("_RE" + Time.time);
        Debug.Log("Round: " + PlayerPrefs.GetInt("Round") + " " + bpt.keyTracker);
        blackScreen.SetActive(true); // enable the black screen GameObject 
        isScenePaused = true; // pauses the scene 
        yield return new WaitForSeconds(blackScreenDuration); // wait for listed black screen duration 
        //reset the scene

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