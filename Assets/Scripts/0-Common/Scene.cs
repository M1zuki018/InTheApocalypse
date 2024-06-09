using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{

    [SerializeField] string _loadScene;

    public void SceneChange()
    {
        if (_loadScene == string.Empty )
        {
            Debug.Log("_loadScene is not set.");
            return;
        }
        SceneManager.LoadScene(_loadScene);
    }

    public void MainSceneChange()
    {
        GameObject audioObj = GameObject.Find("Audio");
        DontDestroyOnLoad(audioObj);
        Invoke("SceneChange", 1);
    }

}
