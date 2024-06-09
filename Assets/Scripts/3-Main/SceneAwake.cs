using UnityEngine;

public class SceneAwake : MonoBehaviour
{
    Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _animator.Play("MainAwake");
        Invoke("ThisDestroy", 1);
    }

    void ThisDestroy()
    {
        Destroy(gameObject);
    }
}
