using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalObject : MonoBehaviour
{
    public LevelModeSwitchController modeController;
    public string modeName;
    // Start is called before the first frame update
    void Start()
    {
        if (modeController == null)
        {
            modeController = GameObject.FindGameObjectWithTag("ModeController").GetComponent<LevelModeSwitchController>();
        }
        modeController.RegisterMe(gameObject,modeName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
