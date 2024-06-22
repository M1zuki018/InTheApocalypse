using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] string _loadScene;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BackTitle", 5);
    }

    void BackTitle()
    {
        SceneManager.LoadScene(_loadScene);
    }
}
