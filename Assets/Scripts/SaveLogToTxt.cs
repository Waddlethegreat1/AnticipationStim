using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveLogToTxt : MonoBehaviour
{
    // Start is called before the first frame update
    public string fileName = "";    
    void OnEnable(){
        Application.logMessageReceived += Log;
    }
    void OnDisable() {
        Application.logMessageReceived -= Log;
    }
    void Start()
    {
        // fileName = @"C:\Users\geoff\Research\BCM\Data\Anti_Logs\Logs.txt";
    }
    public void Log(string logString, string stackTrace, LogType type){
        if(logString.Substring(0, 1) == "R"){
            using(TextWriter tw = new StreamWriter(fileName+"ButtonPressLogs.txt", true)){
                tw.WriteLine(logString + " " + System.DateTime.Now);
                tw.Close();
            }
        }
        else if(logString.Substring(0, 1) == "_"){
            using(TextWriter tw = new StreamWriter(fileName+"KeyStrokes.txt", true)){
                tw.WriteLine(logString);
                tw.Close();
            }
        }
        else{
            using(TextWriter tw = new StreamWriter(fileName+"RoundLogs.txt", true)){
                tw.WriteLine(logString + " " + System.DateTime.Now);
                tw.Close();
            }
        }
    }

    // Update is called once per frame
}
