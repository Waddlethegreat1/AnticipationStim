using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveLogToTxt : MonoBehaviour
{
    public string tm;
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
        DateTime dt = DateTime.Now;
        tm = dt.ToString("HH_mm_ss-yyyy-MM-dd");
        // fileName = @"C:\Users\geoff\Research\BCM\Data\Anti_Logs\Logs.txt";
    }
    public void Log(string logString, string stackTrace, LogType type){
        if(logString.Substring(0, 1) == "R"){
            using(TextWriter tw = new StreamWriter(fileName+"ButtonPressLogs-"+tm+".txt", true)){
                tw.WriteLine(logString + " " + System.DateTime.Now);
                tw.Close();
            }
        }
        else if(logString.Substring(0, 1) == "_"){
            using(TextWriter tw = new StreamWriter(fileName+"KeyPresses-"+tm+".txt", true)){
                tw.WriteLine(logString);
                tw.Close();
            }
        }
        else if(logString.Substring(0,3) == "[R]"){
            using(TextWriter tw = new StreamWriter(fileName+"RoundLogs-"+tm+".txt", true)){
                tw.WriteLine(logString + " " + System.DateTime.Now);
                tw.Close();
            }
        }
    }

    // Update is called once per frame
}
