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

    // Update is called once per frame
    private void Awake()
    {
        infoBar.gameObject.SetActive(true);
    }
    void Update()
    {
        if(timeComplete < Time.time)
        {
            messageBox.gameObject.SetActive(false);
        }
    }
    public void ShowMessage(string currentMessage)
    {
        messageTextonScreen.text = currentMessage;
        messageBox.gameObject.SetActive(true);
        timeComplete = Time.time + timeOnScreen;
        
    }
    public void HideMessage()
    {
        timeComplete = 0f;
        messageBox.gameObject.SetActive(false);
    }


}
