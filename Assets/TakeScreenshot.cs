using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    public void captureScreen()
    {
        DateTime dt = DateTime.Now;
        String ok = dt.ToString("HH_mm_ss-yyyy-MM-dd");
        String folderpath = "C:/Users/Bartoli/Research/Baylor/data/Leaderboard/";
        ScreenCapture.CaptureScreenshot(folderpath + "Leaderboard" + " " + ok + ".png");
        Debug.Log(ok);
    }
}
