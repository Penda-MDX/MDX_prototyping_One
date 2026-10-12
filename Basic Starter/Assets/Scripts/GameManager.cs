using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton pattern
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("There's more than one GameMnager! " + transform + " - " + instance);
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex< SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
