using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class Score : MonoBehaviour
{
    public GameObject music1;
    public GameObject leaderboard;
    // Start is called before the first frame update
    public int points;
    public GameObject mainMenu;
    public Text txt2;
    private int index;
    public int highScore;
    public Text txt;
    public GameObject nameTracker;
    private List<Transform> highscoreEntryTransformList;
    void Start()
    {
        nameTracker = GameObject.FindGameObjectWithTag("name");
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        bool ok = false;
        for(int i = 0; i < highscores.highscoreEntryList.Count; i++){
            if(highscores.highscoreEntryList[i].name == nameTracker.GetComponent<trackName>().name){
                highScore = highscores.highscoreEntryList[i].points;
                index = i;
                ok = true;
            }
        }
        if(!ok){
            highScore = 0;
            leaderboard.GetComponent<HighscoreTable>().AddHighscoreEntry(0, nameTracker.GetComponent<trackName>().name);
        }
        music1.SetActive(false);
        highScore = 0;
        points = 0;
    }
    // public void checkName(){
    //     // for(int i = 0; i < highscoreList.Count(); i++){
    //     //     if(highscoreList[i].name == input.text){

    //     //     }
    //     // }
    //     if(input.text.Length > 0 && input.text.Length <= 4){
    //         confirmButton.SetActive(true);
    //         warning.SetActive(false);
    //         name = input.text;
    //     }
    //     else if(input.text.Length == 0){
    //         warning.SetActive(false);
    //         confirmButton.SetActive(false);
    //     }
    //     else{
    //         warning.SetActive(true);
    //         confirmButton.SetActive(false);
    //     }
    // }
    void Update(){
        DontDestroyOnLoad(this.gameObject);
        Scene currentScene = SceneManager.GetActiveScene(); 

        if(currentScene.name == "MainMenu"){
            mainMenu.SetActive(true);
            if(points != -1){
                txt2.text = "Score: " + points.ToString();
            }
            highScore = Mathf.Max(points, highScore);
            if(highScore > )
            txt.text = "Personal Highscore: " + highScore.ToString();
            points = -1;
        }
        else{
            if(points == -1){
                points = 0;
            }
        }
    }
    // Update is called once per frame
}
