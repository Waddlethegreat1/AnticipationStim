using UnityEngine;

public class ButtonTracking : MonoBehaviour
{
    void Start()
    {
        if (!PlayerPrefs.HasKey("Round"))
        {
            PlayerPrefs.SetInt("Round", 1); 
        }
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E)) // tracks E press 
        {
            int round = PlayerPrefs.GetInt("Round"); 
            Debug.Log("E key pressed on round: " + round); 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetRoundCount();  // manually resets the round count with the R key 
        }
    }

    void ResetRoundCount()
    {
        PlayerPrefs.SetInt("Round", 1); 
        Debug.Log("Round count reset to 1."); 
    }
}
