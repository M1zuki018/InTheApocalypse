using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Activate();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // 見えない所に移動する
            this.transform.position = Camera.main.transform.position;
            // コライダーを無効にする
            GetComponent<Collider2D>().enabled = false;
            // プレイヤーにアイテムを渡す
            collision.gameObject.GetComponent<PlayerItem>().GetItem(this);
        }
    }
}
