using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class trackName : MonoBehaviour
{
    public TMP_InputField input;
    public GameObject music2;
    public string name;
    public GameObject confirmButton;
    public GameObject warning;
    // Start is called before the first frame update
    void Start()
    {
        confirmButton.SetActive(false);
        warning.SetActive(false);
    }
    public void checkName(){
        // for(int i = 0; i < highscoreList.Count(); i++){
        //     if(highscoreList[i].name == input.text){

        //     }
        // }
        if(input.text.Length > 0 && input.text.Length <= 4){
            confirmButton.SetActive(true);
            warning.SetActive(false);
            name = input.text;
            name = name.ToUpper();
        }
        else if(input.text.Length == 0){
            warning.SetActive(false);
            confirmButton.SetActive(false);
        }
        else{
            warning.SetActive(true);
            confirmButton.SetActive(false);
        }
    }
}
