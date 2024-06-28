using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieObj : MonoBehaviour
{
    [SerializeField] float _lifeTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, _lifeTime);
    }

}
