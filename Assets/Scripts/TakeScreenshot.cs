using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreenshot : MonoBehaviour
{
    public String folderpath;
    public void captureScreen()
    {
        DateTime dt = DateTime.Now;
        String ok = dt.ToString("HH_mm_ss-yyyy-MM-dd");
        ScreenCapture.CaptureScreenshot(folderpath + "Leaderboard" + " " + ok + ".png");
        Debug.Log(ok);
    }
}
