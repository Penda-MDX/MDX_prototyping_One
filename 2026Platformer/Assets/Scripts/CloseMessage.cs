using UnityEngine;

public class CloseMessage : MonoBehaviour
{
    public void closeButton()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
