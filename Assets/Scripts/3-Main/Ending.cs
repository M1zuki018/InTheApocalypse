using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] string _loadScene;
    [SerializeField] GameObject _fadeOut;


    // Start is called before the first frame update
    void Start()
    {
        _fadeOut.SetActive(false);
        Invoke("FadeOut", 5);
        Invoke("BackTitle", 9);
    }

    void FadeOut()
    {
        _fadeOut.SetActive(true);
    }

    void BackTitle()
    {
        SceneManager.LoadScene(_loadScene);
    }
}
