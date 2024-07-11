// This code tracks when and for how long a button is being pressed relative to start scene 

using UnityEngine;

public class ButtonPressTracker : MonoBehaviour
{
    private float sceneStartTime; 
    private bool buttonPressed = false; 
    private float pressStartTime;
    public float reactionTime;
    private float pressDuration; 
    private RoundTracker roundTracker; // reference to the round tracker script 
    public string keyTracker;
    private int cnt = 0;
    // Start is called before the first frame update 
    void Start()
    {
        sceneStartTime = Time.time; // trigger to set start of timer
        keyTracker = "";
        roundTracker = FindObjectOfType<RoundTracker>(); // finds the round tracker script 
        cnt = 0;
        reactionTime = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow)) // checks if button is being pressed 
        {
            buttonPressed = true; 
            pressStartTime = Time.time - sceneStartTime; 
            Debug.Log("_KH" + pressStartTime);
            cnt++;
            if(cnt == 1)
            {
                reactionTime = Time.time - sceneStartTime;
            }
        }
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
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
