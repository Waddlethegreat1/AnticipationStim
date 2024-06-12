// This code tracks when and for how long a button is being pressed relative to start scene 

using UnityEngine;

public class ButtonPressTracker : MonoBehaviour
{
    private float sceneStartTime; 
    private bool buttonPressed = false; 
    private float pressStartTime; 
    private float pressDuration; 
    private RoundTracker roundTracker; // reference to the round tracker script 
    public string keyTracker;
    // Start is called before the first frame update 
    void Start()
    {
        sceneStartTime = Time.time; // trigger to set start of timer
        keyTracker = "";
        roundTracker = FindObjectOfType<RoundTracker>(); // finds the round tracker script 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // checks if button is being pressed 
        {
            buttonPressed = true; 
            pressStartTime = Time.time - sceneStartTime; 
            Debug.Log("_KH" + pressStartTime);
        }
        
        if (Input.GetKeyUp(KeyCode.E))
        {
            buttonPressed = false; 
            pressDuration = Time.time - sceneStartTime - pressStartTime; 
            float pressEndTime = Time.time - sceneStartTime; 
            Debug.Log("_KR" + pressDuration);
            int currentRound = roundTracker.GetCurrentRound(); // gets the current round
        }
        if(buttonPressed){
            keyTracker += "1";
        }
        else{
            keyTracker += "0";
        }     
    }
}
