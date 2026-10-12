using UnityEngine;

public class MessageTrigger : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelManager.instance.ShowMessage("This is a basic message!");
        }
    }
}
