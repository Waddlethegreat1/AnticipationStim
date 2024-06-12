// this code tracks the current round (trial) 

using UnityEngine;

public class RoundTracker : MonoBehaviour
{
    private int currentRound = 1; // initializes the current round to 1 
    private float sceneStartTime; 

    // Start is called before the first frame update
    void Start()   
    {
        sceneStartTime = Time.time; // trigger to set start of timer

        if (PlayerPrefs.HasKey("Round")) // loads the current round from player prefs if it exists 
        {
            currentRound = PlayerPrefs.GetInt("Round"); 
        }
        else 
        {
            PlayerPrefs.SetInt("Round", currentRound); // if round doesn't exists it sets it to 1 
        }
        // Debug.Log("Current Round: " + currentRound + " " + sceneStartTime); 
    }

    public int GetCurrentRound() // funciton to get current round 
    {
        return currentRound; 
    }

    public void IncrementRound()
    {
        currentRound++; 
        PlayerPrefs.SetInt("Round", currentRound); // saves the current round to Player Prefs
    }

    public void ResetRound(int newRound) // funciton to manually reset round 
    {
        currentRound = newRound; 
        PlayerPrefs.SetInt("Round", currentRound); // saves the new round to Player Prefs

        Debug.Log("Round Reset to: " + currentRound); 
    }
}
