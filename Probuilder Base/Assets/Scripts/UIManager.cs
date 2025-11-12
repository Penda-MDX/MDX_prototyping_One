using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Canvas infoBar;
    public Canvas messageBox;

    public Text messageTextonScreen;
    public Text statusScreen;
    public float timeOnScreen = 2f;

    private float timeComplete = 0f;
    private bool showMessage=false;
    // Update is called once per frame
    void Update()
    {
        if(!showMessage || timeComplete < timeOnScreen)
        {
            messageBox.gameObject.SetActive(false);
        }
    }
    public void ShowMessage(string currentMessage)
    {
        messageTextonScreen.text = currentMessage;
        messageBox.gameObject.SetActive(true);
        timeComplete = Time.time + timeOnScreen;
        showMessage = true;
    }
    public void HideMessage()
    {
        showMessage = false;
    }


}
