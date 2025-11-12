using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public int progressStage = 0;
    public int keyCount = 0;
    public int life = 3;

    public UIManager UIhandler;

    // Update is called once per frame
    void Update()
    {
        UIhandler.statusScreen.text = "Lives: " + life.ToString() + "          Keys: " + keyCount.ToString();
    }
}
