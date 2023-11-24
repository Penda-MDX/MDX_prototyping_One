using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelModeSwitchController : MonoBehaviour
{
    public string currentMode;
    public List<GameObject> modeOneObjects;
    public List<GameObject> modeTwoObjects;
    public List<GameObject> modeThreeObjects;

    public Canvas switchCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMode(string newMode)
    {
        if (newMode == "Mode One")
        {
            ChangeModeOneObjects(false);
            ChangeModeTwoObjects(true);
            ChangeModeThreeObjects(true);
        }
        if (newMode == "Mode Two")
        {
            ChangeModeOneObjects(true);
            ChangeModeTwoObjects(false);
            ChangeModeThreeObjects(true);
        }
        if (newMode == "Mode Three")
        {
            ChangeModeOneObjects(true);
            ChangeModeTwoObjects(true);
            ChangeModeThreeObjects(false);
        }

        currentMode = newMode;
    }

    void ChangeModeOneObjects(bool enableObjects)
    {
        foreach(GameObject _item in modeOneObjects)
        {
            _item.SetActive(enableObjects);
        }
    }

    void ChangeModeTwoObjects(bool enableObjects)
    {
        foreach (GameObject _item in modeTwoObjects)
        {
            _item.SetActive(enableObjects);
        }
    }
    void ChangeModeThreeObjects(bool enableObjects)
    {
        foreach (GameObject _item in modeThreeObjects)
        {
            _item.SetActive(enableObjects);
        }
    }

    public void RegisterMe(GameObject _gameObject, string ModeName)
    {
        if (ModeName == "Mode One")
        {
            modeOneObjects.Add(_gameObject);
        }

        if (ModeName == "Mode Two")
        {
            modeTwoObjects.Add(_gameObject);
        }

        if (ModeName == "Mode Three")
        {
            modeThreeObjects.Add(_gameObject);
        }

    }

}
