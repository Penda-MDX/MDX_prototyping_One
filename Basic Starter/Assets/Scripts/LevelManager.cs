using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }

    [SerializeField] private Canvas infobar;
    [SerializeField] private Canvas messageBox;

    [SerializeField] private TMP_Text messageBoxText;
    
    [SerializeField] private float timeOnScreen = 2.5f;

    private float timeComplete = 0f; 


    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There's more than one LevelManager! " + transform + " - " + instance);
            Destroy(gameObject);
            return;
        }
        instance = this;
    }


    void Update()
    {
        if (timeComplete < Time.time) 
        { 
            messageBox.gameObject.SetActive(false);
        } 
    }

    public void ShowMessage(string message)
    {
        messageBoxText.text = message;
        messageBox.gameObject.SetActive(true);
        timeComplete = Time.time + timeOnScreen;
    }

}
