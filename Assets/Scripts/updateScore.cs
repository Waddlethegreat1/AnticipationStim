using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateScore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gm;
    public Text txt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gm = GameObject.FindGameObjectWithTag("scoreKeep");
        Score gameM = gm.GetComponent<Score>();
        txt.text = gameM.points.ToString();
    }
}
