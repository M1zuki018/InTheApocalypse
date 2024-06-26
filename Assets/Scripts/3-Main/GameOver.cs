using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _fadeOut;
    // Start is called before the first frame update
    void Start()
    {
        _fadeOut.SetActive(false);
    }

    public void BackTitle()
    {
        _fadeOut.SetActive(true);
        Invoke("SwitchScene", 2);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("Title");
    }
}
