using UnityEngine;

public class LeftWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Boss")
        {
            Boss_Move bossMove;
            bossMove = collision.gameObject.GetComponent<Boss_Move>();
            bossMove._offset = new Vector3(4f, 2f, 0f);
        }
    }
}
