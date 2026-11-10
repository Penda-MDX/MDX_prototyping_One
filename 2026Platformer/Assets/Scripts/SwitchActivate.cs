using UnityEngine;
using UnityEngine.InputSystem;

public class SwitchActivate : MonoBehaviour
{
    [SerializeField] private GameObject objectToChange;
    [SerializeField] private float coolDownTime;
    private bool isAvailable = false;
    private float timedOut;

    // Update is called once per frame
    void Update()
    {
        if (timedOut<Time.time && isAvailable && Keyboard.current.eKey.isPressed)
        {
            objectToChange.SetActive(!objectToChange.activeSelf);
            timedOut = Time.time + coolDownTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAvailable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAvailable = false;
        }
    }
}
