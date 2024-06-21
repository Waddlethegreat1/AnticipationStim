using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreTable : MonoBehaviour
{
    public Transform entryContainer;
    public GameObject scoreTracker;
    public Transform entryTemplate;
    public Highscores highscores;
    public int index;
    private int counter = 0; 
    //private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;
    private void Start(){
        counter = 0;
        refresh();
        this.gameObject.SetActive(false);
    }
    public void Update()
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);
    }
    public void refresh()
    {
        counter++;
        index = scoreTracker.GetComponent<Score>().index;

        //highscoreEntryList = new List<HighscoreEntry>() {
        //    new HighscoreEntry{score = 250, name = "JOHN"},
        //    new HighscoreEntry{score = 100, name = "GEOF"},
        //};
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Debug.Log(highscores);
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score)
                {
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            if (highscores.highscoreEntryList[i].name == scoreTracker.GetComponent<Score>().name2)
            {
                index = i;
            }
        }
        entryTemplate.gameObject.SetActive(false);
        if (counter > 1)
        {
            foreach (Transform t in highscoreEntryTransformList)
            {
                Destroy(t.gameObject);
            }
        }
        highscoreEntryTransformList = new List<Transform>();
        //Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        //string json = JsonUtility.ToJson(highscores);
        //PlayerPrefs.SetString("highscoreTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("highscoreTable"));
        //int cnt = 0;
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            //cnt++;
            //Debug.Log(cnt);
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }
    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList){
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -18 + -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch(rank) {
            default:
                rankString = rank + "TH"; break;
            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;
        }

        entryTransform.Find("postext").GetComponent<Text>().text = rankString;
        int score = highscoreEntry.score;
        entryTransform.Find("scoretext").GetComponent<Text>().text = score.ToString();
        string name = highscoreEntry.name;
        entryTransform.Find("nametext").GetComponent<Text>().text = name;
        entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);
        if(index == transformList.Count)
        {
            entryTransform.Find("nametext").GetComponent<Text>().fontStyle = FontStyle.Italic;
            entryTransform.Find("scoretext").GetComponent<Text>().fontStyle = FontStyle.Italic;
            entryTransform.Find("postext").GetComponent<Text>().fontStyle = FontStyle.Italic;
        }
        if(rank == 1){
            entryTransform.Find("nametext").GetComponent<Text>().color = Color.red;
            entryTransform.Find("postext").GetComponent<Text>().color = Color.red;
            entryTransform.Find("scoretext").GetComponent<Text>().color = Color.red;
        }
        transformList.Add(entryTransform);
    }
    public void AddHighscoreEntry(int score, string name){
        HighscoreEntry highscoreEntry = new HighscoreEntry{score = score, name = name};
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        highscores.highscoreEntryList.Add(highscoreEntry);

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
    }
    public void UpdateHighscoreEntry(int score, string name)
    {
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            if (highscores.highscoreEntryList[i].name == scoreTracker.GetComponent<Score>().name2)
            {
                index = i;
            }
        }
        HighscoreEntry highscoreEntry = highscores.highscoreEntryList[index];
        highscoreEntry.score = score;
        highscores.highscoreEntryList[index] = highscoreEntry;
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();
        refresh();
    }
    public class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }
    [System.Serializable]
    public class HighscoreEntry{
        public int score;
        public string name;
    }
}
