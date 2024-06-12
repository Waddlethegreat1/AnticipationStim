// this script is used to reset the round 

using UnityEngine;

public class RoundReset : MonoBehaviour
{
    public RoundTracker roundTracker;
    // Start is called before the first frame update
    void Start()
    {
        roundTracker = FindObjectOfType<RoundTracker>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // currently set so R resets the round count 
        {
            roundTracker.ResetRound(1); 
        }
    }
}
