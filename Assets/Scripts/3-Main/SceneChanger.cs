using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    Scene _scene;

    private void Start()
    {
        _scene = GetComponent<Scene>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _scene.SceneChange();
    }
}
