using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnTheBar : MonoBehaviour
{
    public Canvas balanceUI;
    public Slider balanceSlider;

    public float nudgeAmount = 1.0f;
    public float driftAmount = 0.2f;

    public float balanceNumber = 0;
    public int balanceRounded;

    public bool inTheZone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inTheZone)
        {
            if (!balanceUI.gameObject.activeSelf)
            {
                balanceUI.gameObject.SetActive(true);
            }

            if (balanceNumber > 0) 
            { 
                if (balanceNumber < 100.1) 
                {
                    balanceNumber += driftAmount;
                }
                else
                {
                    //fall off right
                    balanceUI.enabled = false;
                }
            }

            if (balanceNumber < 0)
            {
                if (balanceNumber > -100.1)
                {
                    balanceNumber -= driftAmount;
                }
                else
                {
                    //fall off left
                    balanceUI.enabled = false;

                }
            }
            if (Input.GetKey("k"))
            {
                balanceNumber -= nudgeAmount;
            }
            if (Input.GetKey("l"))
            {
                balanceNumber += nudgeAmount;
            }

            balanceSlider.value = balanceNumber;

        }
        else
        {
            if (balanceUI.gameObject.activeSelf)
            {
                balanceUI.gameObject.SetActive(false);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inTheZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inTheZone = false;
        }
    }


}
