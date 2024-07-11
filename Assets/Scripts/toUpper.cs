using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class toUpper : MonoBehaviour
{
    public TMP_InputField input;
    // Start is called before the first frame update
    public void TU()
    {
        input.text = input.text.ToUpper();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
