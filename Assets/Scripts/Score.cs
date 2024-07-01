using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
using static HighscoreTable;
public class Score : MonoBehaviour
{
    public int totalRounds = 0;
    public GameObject music1;
    public GameObject leaderboard;
    // Start is called before the first frame update
    public int points;
    public GameObject mainMenu;
    public Text txt2;
    public Text rounds;
    public int index;
    public int highScore;
    public Highscores highscores;
    public Text txt;
    public String name2;
    public GameObject nameTracker;
    private List<Transform> highscoreEntryTransformList;
    private List<HighscoreEntry> highscoreEntryList;
    void Start()
    {
        totalRounds = 0;
        nameTracker = GameObject.FindGameObjectWithTag("name");
        name2 = nameTracker.GetComponent<trackName>().name;
        music1.SetActive(true);
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
        if (highscores == null)
        {
            leaderboard.GetComponent<HighscoreTable>().refresh();
            bool ok = false;
            highscores = leaderboard.GetComponent<HighscoreTable>().highscores;
            //Debug.Log(highscores);
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                //Debug.Log(highscores.highscoreEntryList[i].name + " " + nameTracker.GetComponent<trackName>().name);
                if (highscores.highscoreEntryList[i].name == nameTracker.GetComponent<trackName>().name)
                {
                    highScore = highscores.highscoreEntryList[i].score;
                    index = i;
                    ok = true;
                }
            }
            if (!ok)
            {
                highScore = 0;
                leaderboard.GetComponent<HighscoreTable>().AddHighscoreEntry(0, nameTracker.GetComponent<trackName>().name);
                index = highscores.highscoreEntryList.Count;
                //Debug.Log("Hapepsn");
            }
            leaderboard.GetComponent<HighscoreTable>().refresh();
        }

        if (currentScene.name == "MainMenu"){
            rounds.text = "Rounds Finished: " + totalRounds;
            for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
            {
                if (highscores.highscoreEntryList[i].name == nameTracker.GetComponent<trackName>().name)
                {
                    index = i;
                }
            }
            mainMenu.SetActive(true);
            if(points != -1){
                txt2.text = "Score: " + points.ToString();
            }
            highScore = Mathf.Max(points, highScore);
            string jsonString = PlayerPrefs.GetString("highscoreTable");
            if (highScore > highscores.highscoreEntryList[index].score)
            {
                for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
                {
                    if (highscores.highscoreEntryList[i].name == nameTracker.GetComponent<trackName>().name)
                    {
                        index = i;
                    }
                }
                leaderboard.GetComponent<HighscoreTable>().UpdateHighscoreEntry(highScore, name);
                leaderboard.GetComponent<HighscoreTable>().refresh();
                for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
                {
                    if (highscores.highscoreEntryList[i].name == nameTracker.GetComponent<trackName>().name)
                    {
                        index = i;
                    }
                }
                leaderboard.GetComponent<HighscoreTable>().refresh();
            }
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
