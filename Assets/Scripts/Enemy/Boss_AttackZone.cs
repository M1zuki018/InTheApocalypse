using UnityEngine;

public class Boss_AttackZone : MonoBehaviour
{

    [SerializeField] int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController._chara1HP = PlayerController._chara1HP - _damage;

        }
    }
}
