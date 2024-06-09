using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    Scene _scene;
    [SerializeField] GameObject _fadePanel;
    Animator _animator;

    private void Start()
    {
        _scene = GetComponent<Scene>();
        _animator = _fadePanel.GetComponent<Animator>();
        _fadePanel.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _fadePanel.SetActive(true);
        _animator.Play("MainChange");
        _scene.MainSceneChange();
    }
}
