using UnityEngine;

public class StateChange : MonoBehaviour
{
    public Sprite[] _sprites;
    public SpriteRenderer _sr;

    // Start is called before the first frame update
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _sr.sprite = _sprites[0];
    }
}
