using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class ActivateSwitchMessage : MonoBehaviour
{

    [SerializeField] private GameObject gameObjectToActivate;


    private bool canActivate = false;



    // Update is called once per frame
    void Update()
    {
        if (canActivate && Keyboard.current.eKey.isPressed)
        {
            gameObjectToActivate.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelManager.instance.ShowMessage("Press E to Activate!");
            canActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canActivate = false;
        }
    }
}
