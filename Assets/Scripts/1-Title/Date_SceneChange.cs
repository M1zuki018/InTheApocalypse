
using UnityEngine;

public class Date_SceneChange : MonoBehaviour
{
    Scene _scene;

    // Start is called before the first frame update
    void Start()
    {
       _scene = GetComponent<Scene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            _scene.SceneChange();
        }
    }
}
