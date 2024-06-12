using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class KeyPressedTracking : MonoBehaviour
{
    // Start is called before the first frame update
    private List<bool> keyPressed = new List<bool>();
    public List<string> keyCodes = new List<string>();
    private List<double> timeElapsed = new List<double>();
    public void ClearLog()
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
    void Start()
    {   
        ClearLog();
        for(int i = 0; i < keyCodes.Capacity; i++){
            timeElapsed.Add(0);
            keyPressed.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("escape")){
            UnityEditor.EditorApplication.isPlaying = false;
        }
        for(int i = 0; i < keyCodes.Capacity; i++){
            if(Input.GetKey(keyCodes[i])){
                if(!keyPressed[i]){
                    timeElapsed[i] = 0;
                }
                timeElapsed[i] += Time.deltaTime;
                keyPressed[i] = true;
            }
            else{
                if(keyPressed[i]){
                    Debug.Log(keyCodes[i] + " was held for " + timeElapsed[i] + " seconds.");
                    timeElapsed[i] = 0;
                }
                keyPressed[i] = false;
            }
        }
    }
}
